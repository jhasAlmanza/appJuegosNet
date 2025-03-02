using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace appJuegos
{
    public partial class EditUsuarioForm : Form
    {
        private string nombreUsuario;
        private string pwUsuario;
        private string estadoUsuario;

        public EditUsuarioForm(string nombre, string pw, string estado)
        {
            InitializeComponent();
            nombreUsuario = nombre;
            pwUsuario = pw;
            estadoUsuario = estado;
            // Cargar directamente los datos pasados por parámetros
            txtNombre.Text = nombreUsuario;
            txtContraseña.Text = pwUsuario;
            txtEstado.Text = estadoUsuario;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("La contraseña no puede estar vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Verificar si el nombre de usuario nuevo ya existe
                    string checkQuery = "SELECT COUNT(*) FROM usuarios WHERE nombre = @nuevoNombre AND nombre != @nombreActual";
                    using (var checkCommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@nuevoNombre", txtNombre.Text);
                        checkCommand.Parameters.AddWithValue("@nombreActual", nombreUsuario);

                        int userCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (userCount > 0)
                        {
                            MessageBox.Show("Ya existe un usuario con ese nombre.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Actualizar el usuario
                    string query = "UPDATE usuarios SET nombre = @nuevoNombre, pw = @pw, estado = @estado WHERE nombre = @nombreActual";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nuevoNombre", txtNombre.Text);
                        command.Parameters.AddWithValue("@pw", txtContraseña.Text);
                        command.Parameters.AddWithValue("@estado", txtEstado.Text);
                        command.Parameters.AddWithValue("@nombreActual", nombreUsuario);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Usuario actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Cerrar el formulario después de actualizar
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditUsuarioForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
