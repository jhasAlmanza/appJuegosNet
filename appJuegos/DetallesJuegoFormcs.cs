using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace appJuegos
{
    public partial class DetallesJuegoForm : Form
    {
        private PictureBox pictureBox;
        private Label lblTitulo;
        private Label lblDescripcion;
        private Label lblPrecio;
        private Button btnComprar;
        private int idUsuario;
        private int idJuego;

        public DetallesJuegoForm(string titulo, string descripcion, double precio, Image imagen, int idUsuario, int idJuego)
        {
            InitializeComponent();
            this.Text = "Detalles del Juego";
            this.Size = new Size(600, 600);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.idUsuario = idUsuario;
            this.idJuego = idJuego;

            // Imagen del juego
            pictureBox = new PictureBox
            {
                Image = imagen,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(200, 300)
            };

            // Información del juego
            lblTitulo = new Label
            {
                Text = $"Título: {titulo}",
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true
            };

            lblDescripcion = new Label
            {
                Text = $"Descripción: {descripcion}",
                AutoSize = true
            };

            lblPrecio = new Label
            {
                Text = $"Precio: {precio} €",
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Green,
                AutoSize = true
            };

            // Botón de compra
            btnComprar = new Button
            {
                Text = "Comprar",
                Size = new Size(100, 30)
            };

            btnComprar.Click += (s, e) =>
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO descargas (id_usuario, id_juego, fecha_descarga) VALUES (@idUsuario, @idJuego, @fechaDescarga)";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idUsuario", this.idUsuario);
                            command.Parameters.AddWithValue("@idJuego", this.idJuego);
                            command.Parameters.AddWithValue("@fechaDescarga", DateTime.Now);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show($"¡Has comprado {titulo} por {precio} €!", "Compra realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al realizar la compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Agregar controles al formulario
            Controls.Add(pictureBox);
            Controls.Add(lblTitulo);
            Controls.Add(lblDescripcion);
            Controls.Add(lblPrecio);
            Controls.Add(btnComprar);

            CenterControls();

            this.Resize += (s, e) => CenterControls();
        }

        private void CenterControls()
        {
            pictureBox.Location = new Point((this.ClientSize.Width - pictureBox.Width) / 2, 20);
            lblTitulo.Location = new Point((this.ClientSize.Width - lblTitulo.Width) / 2, 330);
            lblDescripcion.Location = new Point((this.ClientSize.Width - lblDescripcion.Width) / 2, 360);
            lblPrecio.Location = new Point((this.ClientSize.Width - lblPrecio.Width) / 2, 390);
            btnComprar.Location = new Point((this.ClientSize.Width - btnComprar.Width) / 2, 420);
        }

        private void DetallesJuegoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
