namespace appJuegos
{
    partial class DetallesJuegoForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DetallesJuegoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::appJuegos.Properties.Resources.video_games_blizzard_entertainment_ice_blizzard_wallpaper_preview;
            this.ClientSize = new System.Drawing.Size(750, 624);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DetallesJuegoForm";
            this.Text = "Detalles del Juego";
            this.Load += new System.EventHandler(this.DetallesJuegoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
