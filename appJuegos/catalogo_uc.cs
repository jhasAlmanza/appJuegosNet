using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using appJuegos;
using MySql.Data.MySqlClient;

namespace appJuegos
{
    public partial class catalogo_uc : UserControl
    {
        private FlowLayoutPanel flowLayoutPanel;
        private int idUsuario; // Variable para almacenar el id del usuario

        public catalogo_uc(int idUsuario)
        {
            InitializeComponent();
            InitializeFlowLayoutPanel();
            this.idUsuario = idUsuario; // Asignar el id del usuario
        }

        private void InitializeFlowLayoutPanel()
        {
            // Crear y configurar el FlowLayoutPanel
            flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10),
            };

            // Agregar el FlowLayoutPanel al UserControl
            this.Controls.Add(flowLayoutPanel);
        }

        public void LoadGamesFromDatabase(string connectionString)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, titulo, descripcion, precio, imagen FROM juegos";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Obtener datos de la base de datos
                            int idJuego = reader.GetInt32("id");
                            string titulo = reader.GetString("titulo");
                            string descripcion = reader.GetString("descripcion");
                            string precio = reader.GetDecimal("precio").ToString("0.00");
                            string rutaImagen = reader.GetString("imagen");

                            // Crear un control para mostrar los datos
                            var gameControl = new Juego_uc(idUsuario, idJuego)
                            {
                                Title = titulo,
                                Description = descripcion,
                                Price = precio,
                                GameImage = File.Exists(rutaImagen) ? Image.FromFile(rutaImagen) : null,
                                Margin = new Padding(10),
                            };

                            // Agregar el control al FlowLayoutPanel
                            flowLayoutPanel.Controls.Add(gameControl);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        private void catalogo_uc_Load(object sender, EventArgs e)
        {

        }
    }
}
