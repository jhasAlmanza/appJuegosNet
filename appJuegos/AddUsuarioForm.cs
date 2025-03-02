using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace appJuegos
{
    public partial class AddUsuarioForm : Form
    {
        public AddUsuarioForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string password = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, rellena todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO usuarios (nombre, pw) VALUES (@nombre, @pw)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@pw", password);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario añadido correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al añadir el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddUsuarioForm_Load(object sender, EventArgs e)
        {

        }
    }
}
