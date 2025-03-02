
using System.Drawing;
using System.Drawing.Drawing2D;

namespace appJuegos
{
    partial class miJuego_uc
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary> Limpia los recursos que se estén usando. </summary>
        /// <param name="disposing">true si los recursos administrados deben desecharse; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para la compatibilidad con el Diseñador. No modifiques
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btn_jugar = new System.Windows.Forms.Button();
            this.btn_eliminarJuego = new System.Windows.Forms.Button();
            this.pictureBoxGame = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(17, 172);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(47, 19);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Título";
            this.lblTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1c2d5d");

            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescription.Location = new System.Drawing.Point(17, 197);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(69, 15);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Descripción";
            // 
            // btn_jugar
            // 
            this.btn_jugar.BackColor = System.Drawing.Color.FromArgb(27, 31, 36);
            this.btn_jugar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_jugar.FlatStyle = System.Windows.Forms.FlatStyle.Flat; // Establece el estilo plano para quitar el borde predeterminado
            this.btn_jugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btn_jugar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_jugar.Location = new System.Drawing.Point(11, 221);
            this.btn_jugar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_jugar.Name = "btn_jugar";
            this.btn_jugar.Size = new System.Drawing.Size(67, 25);
            this.btn_jugar.TabIndex = 3;
            this.btn_jugar.Text = "Jugar";
            this.btn_jugar.UseVisualStyleBackColor = false;



            // 
            // btn_eliminarJuego
            // 
            this.btn_eliminarJuego.BackColor = System.Drawing.Color.FromArgb(230, 91, 101); 
            this.btn_eliminarJuego.FlatAppearance.BorderColor = System.Drawing.Color.Black; 
            this.btn_eliminarJuego.FlatStyle = System.Windows.Forms.FlatStyle.Flat; 
            this.btn_eliminarJuego.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254))); // Fuente en negrita
            this.btn_eliminarJuego.ForeColor = System.Drawing.SystemColors.ControlLightLight; 
            this.btn_eliminarJuego.Location = new System.Drawing.Point(82, 221);
            this.btn_eliminarJuego.Margin = new System.Windows.Forms.Padding(2);
            this.btn_eliminarJuego.Name = "btn_eliminarJuego";
            this.btn_eliminarJuego.Size = new System.Drawing.Size(67, 25);
            this.btn_eliminarJuego.TabIndex = 4;
            this.btn_eliminarJuego.Text = "Eliminar";
            this.btn_eliminarJuego.UseVisualStyleBackColor = false; 

  

            this.btn_eliminarJuego.Click += new System.EventHandler(this.btnEliminar_click);
            // 
            // pictureBoxGame
            // 
            this.pictureBoxGame.Location = new System.Drawing.Point(20, 12);
            this.pictureBoxGame.Name = "pictureBoxGame";
            this.pictureBoxGame.Size = new System.Drawing.Size(121, 157);
            this.pictureBoxGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGame.TabIndex = 0;
            this.pictureBoxGame.TabStop = false;
            this.pictureBoxGame.Click += new System.EventHandler(this.miJuego_uc_Click);
            // 
            // miJuego_uc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_eliminarJuego);
            this.Controls.Add(this.btn_jugar);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBoxGame);
            this.Name = "miJuego_uc";
            this.Size = new System.Drawing.Size(159, 255);
            this.Load += new System.EventHandler(this.miJuego_uc_Load);
            this.Click += new System.EventHandler(this.miJuego_uc_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGame;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btn_jugar;
        private System.Windows.Forms.Button btn_eliminarJuego;
    }
}
