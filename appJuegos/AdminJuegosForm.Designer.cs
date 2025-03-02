namespace appJuegos
{
    partial class AdminJuegosForm
    {
        public System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.DataGridView dataGridViewJuegos;
        public System.Windows.Forms.Button btnAgregarJuego;
        public System.Windows.Forms.Button btnCerrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminJuegosForm));
            this.dataGridViewJuegos = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAgregarJuego = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btn_adminUsu = new System.Windows.Forms.Button();
            this.panelBuscar = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJuegos)).BeginInit();
            this.panelBuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewJuegos
            // 
            this.dataGridViewJuegos.AllowUserToAddRows = false;
            this.dataGridViewJuegos.AllowUserToDeleteRows = false;
            this.dataGridViewJuegos.AllowUserToResizeColumns = false;
            this.dataGridViewJuegos.AllowUserToResizeRows = false;
            this.dataGridViewJuegos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJuegos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnEditar,
            this.btnEliminar});
            this.dataGridViewJuegos.Location = new System.Drawing.Point(39, 100);
            this.dataGridViewJuegos.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewJuegos.Name = "dataGridViewJuegos";
            this.dataGridViewJuegos.ReadOnly = true;
            this.dataGridViewJuegos.RowHeadersVisible = false;
            this.dataGridViewJuegos.RowHeadersWidth = 62;
            this.dataGridViewJuegos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewJuegos.Size = new System.Drawing.Size(727, 326);
            this.dataGridViewJuegos.TabIndex = 0;
            this.dataGridViewJuegos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewJuegos_CellContentClick);
            // 
            // btnEditar
            // 
            this.btnEditar.HeaderText = "Editar";
            this.btnEditar.MinimumWidth = 8;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.ReadOnly = true;
            this.btnEditar.Text = "✏️";
            this.btnEditar.UseColumnTextForButtonValue = true;
            this.btnEditar.Width = 80;
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "Eliminar";
            this.btnEliminar.MinimumWidth = 8;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ReadOnly = true;
            this.btnEliminar.Text = "❌";
            this.btnEliminar.UseColumnTextForButtonValue = true;
            this.btnEliminar.Width = 80;
            // 
            // btnAgregarJuego
            // 
            this.btnAgregarJuego.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.btnAgregarJuego.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnAgregarJuego.Location = new System.Drawing.Point(42, 446);
            this.btnAgregarJuego.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarJuego.Name = "btnAgregarJuego";
            this.btnAgregarJuego.Size = new System.Drawing.Size(114, 35);
            this.btnAgregarJuego.TabIndex = 1;
            this.btnAgregarJuego.Text = "Añadir Juego";
            this.btnAgregarJuego.UseVisualStyleBackColor = false;
            this.btnAgregarJuego.Click += new System.EventHandler(this.btnAgregarJuego_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnCerrar.Location = new System.Drawing.Point(692, 446);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(74, 35);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(37, 30);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(143, 26);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Videojuegos";
            // 
            // btn_adminUsu
            // 
            this.btn_adminUsu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.btn_adminUsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adminUsu.Location = new System.Drawing.Point(251, 25);
            this.btn_adminUsu.Margin = new System.Windows.Forms.Padding(2);
            this.btn_adminUsu.Name = "btn_adminUsu";
            this.btn_adminUsu.Size = new System.Drawing.Size(184, 41);
            this.btn_adminUsu.TabIndex = 8;
            this.btn_adminUsu.Text = "Administrar Usuarios";
            this.btn_adminUsu.UseVisualStyleBackColor = false;
            this.btn_adminUsu.Click += new System.EventHandler(this.btn_adminUsu_Click);
            // 
            // panelBuscar
            // 
            this.panelBuscar.Controls.Add(this.txtBuscar);
            this.panelBuscar.Controls.Add(this.btnBuscar);
            this.panelBuscar.Location = new System.Drawing.Point(557, 65);
            this.panelBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.panelBuscar.Name = "panelBuscar";
            this.panelBuscar.Size = new System.Drawing.Size(209, 22);
            this.panelBuscar.TabIndex = 9;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(0, 0);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(184, 20);
            this.txtBuscar.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(188, -1);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(28, 20);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // AdminJuegosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(42)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(797, 492);
            this.Controls.Add(this.panelBuscar);
            this.Controls.Add(this.btn_adminUsu);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAgregarJuego);
            this.Controls.Add(this.dataGridViewJuegos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminJuegosForm";
            this.Text = "Administrador de Juegos";
            this.Load += new System.EventHandler(this.AdminJuegosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJuegos)).EndInit();
            this.panelBuscar.ResumeLayout(false);
            this.panelBuscar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridViewButtonColumn btnEditar;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btn_adminUsu;
        private System.Windows.Forms.Panel panelBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
    }
}
