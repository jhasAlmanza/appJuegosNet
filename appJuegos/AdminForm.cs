using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace appJuegos
{
    public partial class AdminForm : Form
    {
        private BindingSource bindingSourceUsuarios = new BindingSource();

        public AdminForm()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private MySqlConnection ObtenerConexion()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return new MySqlConnection(connectionString);
        }

        private void CargarUsuarios()
        {
            try
            {
                using (var connection = ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT nombre, pw, estado FROM usuarios";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    bindingSourceUsuarios.DataSource = dataTable;
                    dataGridViewUsuarios.DataSource = bindingSourceUsuarios;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_click(object sender, EventArgs e)
        {
            AddUsuarioForm addusuario = new AddUsuarioForm();
            addusuario.Show();
            this.Hide();
        }

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var nombreUsuario = dataGridViewUsuarios.Rows[e.RowIndex].Cells["nombre"].Value.ToString();

                if (e.ColumnIndex == dataGridViewUsuarios.Columns["btnEditar"].Index)
                {
                    var pwUsuario = dataGridViewUsuarios.Rows[e.RowIndex].Cells["pw"].Value.ToString();
                    var estadoUsuario = dataGridViewUsuarios.Rows[e.RowIndex].Cells["estado"].Value.ToString();
                    EditUsuarioForm editForm = new EditUsuarioForm(nombreUsuario, pwUsuario, estadoUsuario);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        CargarUsuarios();
                    }
                }
                else if (e.ColumnIndex == dataGridViewUsuarios.Columns["btnEliminar"].Index)
                {
                    var resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar a este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        EliminarUsuarioDeBaseDeDatos(nombreUsuario);
                        CargarUsuarios();
                    }
                }
                else if (e.ColumnIndex == dataGridViewUsuarios.Columns["btnBanear"].Index)
                {
                    var resultado = MessageBox.Show("¿Estás seguro de que quieres banear a este usuario?", "Confirmar baneo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        BanearUsuario(nombreUsuario);
                        CargarUsuarios();
                    }
                }
            }
        }

        private void EliminarUsuarioDeBaseDeDatos(string nombreUsuario)
        {
            try
            {
                using (var connection = ObtenerConexion())
                {
                    connection.Open();
                    string query = "DELETE FROM usuarios WHERE nombre = @nombreUsuario";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BanearUsuario(string nombreUsuario)
        {
            try
            {
                using (var connection = ObtenerConexion())
                {
                    connection.Open();
                    string query = "UPDATE usuarios SET estado = 0 WHERE nombre = @nombreUsuario";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al banear usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreBuscado = txtBuscar.Text.Trim();

                if (string.IsNullOrEmpty(nombreBuscado))
                {
                    CargarUsuarios();
                }
                else
                {
                    CargarUsuariosFiltrados(nombreBuscado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuariosFiltrados(string nombreBuscado)
        {
            bindingSourceUsuarios.Filter = $"nombre LIKE '%{nombreBuscado}%'";
        }

        private void administarJuegos_Click(object sender, EventArgs e)
        {
            AdminJuegosForm adminJuegos = new AdminJuegosForm();
            adminJuegos.Show();
            this.Hide();
        }

        // Método para cambiar los colores de los botones en el DataGridView
        private void dataGridViewUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Solo modificar si la celda es una celda de botón
            if (dataGridViewUsuarios.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (e.RowIndex >= 0)
                {
                    // Obtener el nombre de la columna para saber qué botón es
                    string columnName = dataGridViewUsuarios.Columns[e.ColumnIndex].Name;

                    // Dibujar el fondo del botón con el color deseado
                    if (columnName == "btnEditar")
                    {
                        e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#31aed3")), e.CellBounds); 
                    }
                    else if (columnName == "btnBanear")
                    {
                        e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#eea137")), e.CellBounds);
                    }
                    else if (columnName == "btnEliminar")
                    {
                        e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#f66161")), e.CellBounds);
                    }

          
                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds);

                
                    TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString(), e.CellStyle.Font,
                   e.CellBounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);


                    // Indicar que se ha personalizado el dibujo
                    e.Handled = true;
                }
            }
        }


        // Registrar el evento en el constructor
        private void AdminForm_Load(object sender, EventArgs e)
        {
            dataGridViewUsuarios.CellPainting += dataGridViewUsuarios_CellPainting;
        }
    }
}
