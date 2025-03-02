using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace appJuegos
{
    public partial class MisJuegosForm : Form
    {
        private int idUsuario;
        private FlowLayoutPanel flowLayoutPanel;
        private string username; // Agregar variable para el nombre de usuario

        public MisJuegosForm(int idUsuario, string username)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.username = username; // Asignar el nombre de usuario
            InitializeFlowLayoutPanel();
            LoadDownloadedGames();
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

            // Agregar el FlowLayoutPanel al panel1
            panel1.Controls.Add(flowLayoutPanel);
        }

        private void LoadDownloadedGames()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT j.id, j.titulo, j.descripcion, j.precio, j.imagen
                        FROM descargas d
                        JOIN juegos j ON d.id_juego = j.id
                        WHERE d.id_usuario = @idUsuario";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);
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
                                var gameControl = new miJuego_uc(idUsuario, idJuego)
                                {
                                    Title = titulo,
                                    Description = descripcion,
                                
                                    GameImage = File.Exists(rutaImagen) ? Image.FromFile(rutaImagen) : null,
                                    Margin = new Padding(10),
                                };

                                // Agregar el control al FlowLayoutPanel
                                flowLayoutPanel.Controls.Add(gameControl);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            var appForm = new App(username, idUsuario);
            appForm.Show();
            this.Close();
        }
    }
}
