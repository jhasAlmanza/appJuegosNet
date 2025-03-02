using System;
using System.Drawing;
using System.Windows.Forms;

namespace appJuegos
{
    public partial class Juego_uc : UserControl
    {
        private int idUsuario;
        private int idJuego;

        public Juego_uc(int idUsuario, int idJuego)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.idJuego = idJuego;
            this.Click += Juego_uc_Click;
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

        // precio del juego
        public string Price
        {
            get => lblPrice.Text;
            set => lblPrice.Text = $"Precio: {value} €";
        }

        // imagen del juego
        public Image GameImage
        {
            get => pictureBoxGame.Image;
            set => pictureBoxGame.Image = value;
        }

        private void Juego_uc_Click(object sender, EventArgs e)
        {
            // Convertir el precio a double
            double precio;
            if (double.TryParse(lblPrice.Text.Replace("Precio: ", "").Replace(" €", ""), out precio))
            {
                var detallesForm = new DetallesJuegoForm(Title, Description, precio, GameImage, idUsuario, idJuego);
                detallesForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error al convertir el precio del juego.");
            }
        }

        private void Juego_uc_Load(object sender, EventArgs e)
        {

        }
    }
}
