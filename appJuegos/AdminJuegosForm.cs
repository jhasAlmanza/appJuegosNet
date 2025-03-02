using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace appJuegos
{
    public partial class AdminJuegosForm : Form
    {
        private BindingSource bindingSourceJuegos = new BindingSource();

        public AdminJuegosForm()
        {
            InitializeComponent();
            CargarJuegos();
            this.Size = new System.Drawing.Size(800, 600);
        }

        private MySqlConnection ObtenerConexion()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return new MySqlConnection(connectionString);
        }

        public void CargarJuegos()
        {
            try
            {
                using (var connection = ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT id, titulo, descripcion, precio, imagen FROM juegos";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    bindingSourceJuegos.DataSource = dataTable;
                    dataGridViewJuegos.DataSource = bindingSourceJuegos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar juegos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarJuego_Click(object sender, EventArgs e)
        {
            JuegoControl juegoControl = new JuegoControl(this);
            this.Controls.Clear();
            this.Controls.Add(juegoControl);
        }

        public void dataGridViewJuegos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var idJuego = dataGridViewJuegos.Rows[e.RowIndex].Cells["id"].Value.ToString();

                if (e.ColumnIndex == dataGridViewJuegos.Columns["btnEditar"].Index)
                {
                    var tituloJuego = dataGridViewJuegos.Rows[e.RowIndex].Cells["titulo"].Value.ToString();
                    var descripcionJuego = dataGridViewJuegos.Rows[e.RowIndex].Cells["descripcion"].Value.ToString();
                    var precioJuego = dataGridViewJuegos.Rows[e.RowIndex].Cells["precio"].Value.ToString();
                    var imagenJuego = dataGridViewJuegos.Rows[e.RowIndex].Cells["imagen"].Value.ToString();

                    JuegoControl juegoControl = new JuegoControl(this);
                    juegoControl.SetData(idJuego, tituloJuego, descripcionJuego, precioJuego, imagenJuego);
                    this.Controls.Clear();
                    this.Controls.Add(juegoControl); // Agregar el control de usuario al formulario
                }
                else if (e.ColumnIndex == dataGridViewJuegos.Columns["btnEliminar"].Index)
                {
                    var resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar este juego?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        EliminarJuegoDeBaseDeDatos(idJuego);
                        CargarJuegos(); // Recargar juegos después de eliminar
                    }
                }
            }
        }

        public void EliminarJuegoDeBaseDeDatos(string idJuego)
        {
            try
            {
                using (var connection = ObtenerConexion())
                {
                    connection.Open();
                    string query = "DELETE FROM juegos WHERE id = @idJuego";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idJuego", idJuego);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar juego: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AdminJuegosForm_Load(object sender, EventArgs e)
        {
            // Registrar el evento de pintura de celdas
            dataGridViewJuegos.CellPainting += dataGridViewJuegos_CellPainting;
        }

        // Método para cambiar los colores de los botones en el DataGridView
        private void dataGridViewJuegos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Solo modificar si la celda es una celda de botón
            if (dataGridViewJuegos.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (e.RowIndex >= 0)
                {
                    // Obtener el nombre de la columna para saber qué botón es
                    string columnName = dataGridViewJuegos.Columns[e.ColumnIndex].Name;

                    // Dibujar el fondo del botón con el color deseado
                    if (columnName == "btnEditar")
                    {
                        e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#31aed3")), e.CellBounds);
                    }
                    else if (columnName == "btnEliminar")
                    {
                        e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#f66161")), e.CellBounds);
                    }

                    e.Graphics.DrawRectangle(Pens.Black, e.CellBounds);

                    // Dibujar el texto centrado en la celda
                    TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString(), e.CellStyle.Font,
                        e.CellBounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    // Indicar que se ha personalizado el dibujo
                    e.Handled = true;
                }
            }
        }

        private void btn_adminUsu_Click(object sender, EventArgs e)
        {
            AdminForm adminUsu = new AdminForm();
            adminUsu.Show();
            this.Hide();
        }
    }
}
