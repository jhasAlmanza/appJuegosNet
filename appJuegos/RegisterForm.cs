using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace appJuegos
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();


            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                lblMessage.Text = "Por favor, complete todos los campos.";
                return;
            }


            if (password != confirmPassword)
            {
                lblMessage.Text = "Las contraseñas no coinciden.";
                return;
            }


            if (UsuarioExiste(nombre))
            {
                lblMessage.Text = "El nombre de usuario ya está registrado.";
                return;
            }


            bool registroExitoso = RegistrarUsuario(nombre, password);

            if (registroExitoso)
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Usuario registrado exitosamente.";
            }
            else
            {
                lblMessage.Text = "Error al registrar el usuario.";
            }
        }

        private bool UsuarioExiste(string nombre)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM usuarios WHERE nombre = @nombre";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nombre);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private bool RegistrarUsuario(string nombre, string password)
        {
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

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnVolverLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void RegisterForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}


