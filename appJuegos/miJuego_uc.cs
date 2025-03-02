

using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace appJuegos
{
    public partial class miJuego_uc : UserControl
    {
        private int idUsuario;
        private int idJuego;

        public miJuego_uc(int idUsuario, int idJuego)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.idJuego = idJuego;
            this.Click += miJuego_uc_Click;
        }

        // título del juego
        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        // descripción del juego
        public string Description
        {
            get => lblDescription.Text;
            set => lblDescription.Text = value;
        }



        // imagen del juego
        public Image GameImage
        {
            get => pictureBoxGame.Image;
            set => pictureBoxGame.Image = value;
        }

        private void miJuego_uc_Click(object sender, EventArgs e)
        {
           

        }

        private void miJuego_uc_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este juego?",
                                                 "Confirmar Eliminación",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM descargas WHERE id_juego = @idJuego AND id_usuario = @idUsuario";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idJuego", idJuego);
                            command.Parameters.AddWithValue("@idUsuario", idUsuario);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Juego eliminado de tus descargas", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el juego: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            }
        }
    }
