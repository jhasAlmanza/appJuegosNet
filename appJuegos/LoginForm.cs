using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace appJuegos
{
    public partial class LoginForm : Form
    {
 
        private int intentosFallidos = 0;
        private const int maxIntentos = 3;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Por favor, complete todos los campos.";
                lblMessage.BringToFront();
                return;
            }

            // Validar las credenciales
            int idUsuario = ValidarUsuario(username, password);

            if (idUsuario != -1)
            {
                intentosFallidos = 0;

                // Si el usuario es admin, mostrar AdminForm
                if (username.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                    this.Hide();
                }
                else
                {
                    App homeForm = new App(username, idUsuario);
                    homeForm.Show();
                    this.Hide();
                }
            }
            else
            {
                intentosFallidos++;
                if (intentosFallidos >= maxIntentos)
                {
                    lblMessage.Text = "Demasiados intentos fallidos. Intente más tarde.";
                    btnLogin.Enabled = false;
                }
                else
                {
                    lblMessage.BringToFront();
                }
            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide(); 
        }


        private int ValidarUsuario(string username, string password)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Verificar si el usuario existe y está activo
                    string queryUsuario = "SELECT idUsuario, estado FROM usuarios WHERE nombre = @nombre";
                    using (var commandUsuario = new MySqlCommand(queryUsuario, connection))
                    {
                        commandUsuario.Parameters.AddWithValue("@nombre", username);
                        using (var reader = commandUsuario.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                lblMessage.Text = "El usuario no existe.";
                                btnRegistro.Visible = true; // Mostrar el botón de registro si el usuario no existe
                                return -1;
                            }

                            int estadoUsuario = reader.GetInt32("estado");
                            if (estadoUsuario == 0)
                            {
                                lblMessage.Text = "Tu cuenta ha sido baneada.";
                                return -1;
                            }

                            int idUsuario = reader.GetInt32("idUsuario");
                            reader.Close();

                            // Verificar las credenciales
                            string queryCredencialesValidas = "SELECT COUNT(*) FROM usuarios WHERE idUsuario = @idUsuario AND pw = @pw";
                            using (var commandCredencialesValidas = new MySqlCommand(queryCredencialesValidas, connection))
                            {
                                commandCredencialesValidas.Parameters.AddWithValue("@idUsuario", idUsuario);
                                commandCredencialesValidas.Parameters.AddWithValue("@pw", password);
                                int credencialesValidas = Convert.ToInt32(commandCredencialesValidas.ExecuteScalar());

                                if (credencialesValidas == 0)
                                {
                                    lblMessage.Text = "La contraseña es incorrecta.";
                                    return -1;
                                }

                                return idUsuario;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }


        private void FormLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
