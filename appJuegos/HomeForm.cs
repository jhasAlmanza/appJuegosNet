using System;
using System.Drawing;
using System.Windows.Forms;

namespace appJuegos
{
    public partial class App : Form
    {
        private string username;
        private int idUsuario;
        private catalogo_uc catalogoControl;

        public App(string username, int idUsuario)
        {
            InitializeComponent();
            this.username = username;
            this.idUsuario = idUsuario;
            this.Size = new Size(950, 600);
        }

        private void App_Load(object sender, EventArgs e)
        {
            label_usuario.Text = $"Hola, {username}!";
            label_usuario.AutoSize = true;
            label_usuario.Font = new Font(label_usuario.Font, FontStyle.Bold);

            // Crear instancia de catalogo_uc control
            catalogoControl = new catalogo_uc(idUsuario);
            catalogoControl.Dock = DockStyle.Fill;

            // Añadir el catalogo_uc al contenedor_vjuegos
            if (contenedor_vjuegos.Width > 0 && contenedor_vjuegos.Height > 0)
            {
                contenedor_vjuegos.Size = new Size(600, 450);
                contenedor_vjuegos.BackColor = Color.FromArgb(4, 76, 122);
                contenedor_vjuegos.Controls.Add(catalogoControl);
                catalogoControl.Visible = true;
                catalogoControl.BringToFront();

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                catalogoControl.LoadGamesFromDatabase(connectionString);
            }
            else
            {
                MessageBox.Show("El contenedor no tiene un tamaño válido.");
            }
        }

        private void btn_salir_click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void contenedor_vjuegos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contenedor_vjuegos_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void descargaBtn_Click(object sender, EventArgs e)
        {
            var misJuegosForm = new MisJuegosForm(idUsuario, username);
            misJuegosForm.Show();
            this.Hide();
        }

    }
}
