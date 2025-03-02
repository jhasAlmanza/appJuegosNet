using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace appJuegos
{
    public partial class JuegoControl : UserControl
    {
        private string idJuego;
        private bool esNuevoJuego = false;
        private AdminJuegosForm parentForm;

        public JuegoControl(AdminJuegosForm parent)
        {
            InitializeComponent();
            InicializarEventosWatermark();
            parentForm = parent;
            esNuevoJuego = true;

            this.Size = new System.Drawing.Size(1000, 700);
        }

        public void SetData(string idJuego, string titulo, string descripcion, string precio, string imagen)
        {
            this.idJuego = idJuego;
            txtTitulo.Text = titulo;
            txtDescripcion.Text = descripcion;
            txtPrecio.Text = precio;

            if (File.Exists(imagen))
            {
                pbImagen.Image = Image.FromFile(imagen);
                pbImagen.Tag = imagen;
            }
            esNuevoJuego = false; // Indicar que estamos editando un juego existente
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbImagen.Image = Image.FromFile(openFileDialog.FileName);
                pbImagen.Tag = openFileDialog.FileName;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            string precio = txtPrecio.Text.Trim().Replace(',', '.');
            string imagenRuta = pbImagen.Tag?.ToString();

            if (titulo == "Título" || descripcion == "Descripción" || precio == "Precio" ||
                string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(descripcion) ||
                string.IsNullOrWhiteSpace(precio) || string.IsNullOrWhiteSpace(imagenRuta))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query;

                    if (esNuevoJuego)
                    {
                        query = "INSERT INTO juegos (titulo, descripcion, precio, imagen) VALUES (@titulo, @descripcion, @precio, @imagen)";
                    }
                    else
                    {
                        query = "UPDATE juegos SET titulo = @titulo, descripcion = @descripcion, precio = @precio, imagen = @imagen WHERE id = @idJuego";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        if (!esNuevoJuego)
                        {
                            cmd.Parameters.AddWithValue("@idJuego", this.idJuego);
                        }
                        cmd.Parameters.AddWithValue("@titulo", titulo);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@imagen", imagenRuta);
                        cmd.ExecuteNonQuery();
                    }

                    string mensaje = esNuevoJuego ? "Juego añadido correctamente." : "Juego actualizado correctamente.";
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Visible = false;
                    parentForm.Controls.Clear(); 
                    parentForm.CargarJuegos(); 
                    parentForm.Controls.Add(parentForm.dataGridViewJuegos); 
                    parentForm.Controls.Add(parentForm.btnAgregarJuego);
                    parentForm.Controls.Add(parentForm.btnCerrar); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InicializarEventosWatermark()
        {
            ConfigurarWatermark(txtTitulo, "Título");
            ConfigurarWatermark(txtDescripcion, "Descripción");
            ConfigurarWatermark(txtPrecio, "Precio");
        }

        private void ConfigurarWatermark(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void JuegoControl_Load(object sender, EventArgs e)
        {

        }
    }
}
