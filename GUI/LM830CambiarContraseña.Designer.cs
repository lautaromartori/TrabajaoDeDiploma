namespace LM830GUI
{
    partial class LM830CambiarContraseña
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer LM830components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool LM830disposing)
        {
            if (LM830disposing && (LM830components != null))
            {
                LM830components.Dispose();
            }
            base.Dispose(LM830disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager LM830resources = new System.ComponentModel.ComponentResourceManager(typeof(LM830CambiarContraseña));
            this.LM830panel1 = new System.Windows.Forms.Panel();
            this.LM830btnCerrar = new System.Windows.Forms.PictureBox();
            this.LM830btnMinimizar = new System.Windows.Forms.PictureBox();
            this.LM830pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LM830txtContraseña = new System.Windows.Forms.TextBox();
            this.LM830txtUsuario = new System.Windows.Forms.TextBox();
            this.LM830lblContraseñaActual = new System.Windows.Forms.Label();
            this.LM830lblUsuarioFCC = new System.Windows.Forms.Label();
            this.LM830txtNuevaContraseña = new System.Windows.Forms.TextBox();
            this.LM830lblContraseñaFCC = new System.Windows.Forms.Label();
            this.LM830btnGuardarContra = new System.Windows.Forms.Button();
            this.LM830pbMostrarClave = new System.Windows.Forms.PictureBox();
            this.LM830linkVolver = new System.Windows.Forms.LinkLabel();
            this.LM830panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830pbMostrarClave)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.LM830panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830panel1.Controls.Add(this.LM830btnCerrar);
            this.LM830panel1.Controls.Add(this.LM830btnMinimizar);
            this.LM830panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.LM830panel1.Location = new System.Drawing.Point(0, 0);
            this.LM830panel1.Name = "LM830panel1";
            this.LM830panel1.Size = new System.Drawing.Size(346, 43);
            this.LM830panel1.TabIndex = 7;
            // 
            // btnCerrar
            // 
            this.LM830btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LM830btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnCerrar.Image = ((System.Drawing.Image)(LM830resources.GetObject("btnCerrar.Image")));
            this.LM830btnCerrar.Location = new System.Drawing.Point(318, 4);
            this.LM830btnCerrar.Name = "LM830btnCerrar";
            this.LM830btnCerrar.Size = new System.Drawing.Size(25, 35);
            this.LM830btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LM830btnCerrar.TabIndex = 5;
            this.LM830btnCerrar.TabStop = false;
            this.LM830btnCerrar.Click += new System.EventHandler(this.LM830btnCerrar_Click);
            // 
            // btnMinimizar
            // 
            this.LM830btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LM830btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnMinimizar.Image = ((System.Drawing.Image)(LM830resources.GetObject("btnMinimizar.Image")));
            this.LM830btnMinimizar.Location = new System.Drawing.Point(290, 4);
            this.LM830btnMinimizar.Name = "LM830btnMinimizar";
            this.LM830btnMinimizar.Size = new System.Drawing.Size(25, 35);
            this.LM830btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LM830btnMinimizar.TabIndex = 3;
            this.LM830btnMinimizar.TabStop = false;
            this.LM830btnMinimizar.Click += new System.EventHandler(this.LM830btnMinimizar_Click);
            // 
            // pictureBox1
            // 
            this.LM830pictureBox1.Image = ((System.Drawing.Image)(LM830resources.GetObject("pictureBox1.Image")));
            this.LM830pictureBox1.Location = new System.Drawing.Point(0, 42);
            this.LM830pictureBox1.Name = "LM830pictureBox1";
            this.LM830pictureBox1.Size = new System.Drawing.Size(339, 95);
            this.LM830pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LM830pictureBox1.TabIndex = 8;
            this.LM830pictureBox1.TabStop = false;
            // 
            // txtContraseña
            // 
            this.LM830txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtContraseña.Location = new System.Drawing.Point(65, 246);
            this.LM830txtContraseña.Multiline = true;
            this.LM830txtContraseña.Name = "LM830txtContraseña";
            this.LM830txtContraseña.PasswordChar = '*';
            this.LM830txtContraseña.Size = new System.Drawing.Size(219, 40);
            this.LM830txtContraseña.TabIndex = 12;
            this.LM830txtContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LM830txtContraseña_KeyPress);
            // 
            // txtUsuario
            // 
            this.LM830txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtUsuario.Location = new System.Drawing.Point(62, 167);
            this.LM830txtUsuario.Multiline = true;
            this.LM830txtUsuario.Name = "LM830txtUsuario";
            this.LM830txtUsuario.Size = new System.Drawing.Size(219, 40);
            this.LM830txtUsuario.TabIndex = 11;
            this.LM830txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LM830txtUsuario_KeyPress);
            // 
            // lblContraseñaActual
            // 
            this.LM830lblContraseñaActual.AutoSize = true;
            this.LM830lblContraseñaActual.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblContraseñaActual.ForeColor = System.Drawing.Color.White;
            this.LM830lblContraseñaActual.Location = new System.Drawing.Point(58, 219);
            this.LM830lblContraseñaActual.Name = "LM830lblContraseñaActual";
            this.LM830lblContraseñaActual.Size = new System.Drawing.Size(208, 24);
            this.LM830lblContraseñaActual.TabIndex = 10;
            this.LM830lblContraseñaActual.Text = "Contraseña actual:";
            // 
            // lblUsuarioFCC
            // 
            this.LM830lblUsuarioFCC.AutoSize = true;
            this.LM830lblUsuarioFCC.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblUsuarioFCC.ForeColor = System.Drawing.Color.White;
            this.LM830lblUsuarioFCC.Location = new System.Drawing.Point(58, 140);
            this.LM830lblUsuarioFCC.Name = "LM830lblUsuarioFCC";
            this.LM830lblUsuarioFCC.Size = new System.Drawing.Size(86, 24);
            this.LM830lblUsuarioFCC.TabIndex = 9;
            this.LM830lblUsuarioFCC.Text = "Usuario:";
            // 
            // txtNuevaContraseña
            // 
            this.LM830txtNuevaContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtNuevaContraseña.Location = new System.Drawing.Point(62, 327);
            this.LM830txtNuevaContraseña.Multiline = true;
            this.LM830txtNuevaContraseña.Name = "LM830txtNuevaContraseña";
            this.LM830txtNuevaContraseña.PasswordChar = '*';
            this.LM830txtNuevaContraseña.Size = new System.Drawing.Size(219, 40);
            this.LM830txtNuevaContraseña.TabIndex = 14;
            this.LM830txtNuevaContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LM830txtNuevaContraseña_KeyPress);
            // 
            // lblContraseñaFCC
            // 
            this.LM830lblContraseñaFCC.AutoSize = true;
            this.LM830lblContraseñaFCC.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblContraseñaFCC.ForeColor = System.Drawing.Color.White;
            this.LM830lblContraseñaFCC.Location = new System.Drawing.Point(58, 300);
            this.LM830lblContraseñaFCC.Name = "LM830lblContraseñaFCC";
            this.LM830lblContraseñaFCC.Size = new System.Drawing.Size(135, 24);
            this.LM830lblContraseñaFCC.TabIndex = 13;
            this.LM830lblContraseñaFCC.Text = "Contraseña:";
            // 
            // btnGuardarContra
            // 
            this.LM830btnGuardarContra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnGuardarContra.FlatAppearance.BorderSize = 0;
            this.LM830btnGuardarContra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnGuardarContra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnGuardarContra.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnGuardarContra.ForeColor = System.Drawing.Color.White;
            this.LM830btnGuardarContra.Location = new System.Drawing.Point(62, 386);
            this.LM830btnGuardarContra.Name = "LM830btnGuardarContra";
            this.LM830btnGuardarContra.Size = new System.Drawing.Size(219, 40);
            this.LM830btnGuardarContra.TabIndex = 15;
            this.LM830btnGuardarContra.Text = "Guardar Contraseña";
            this.LM830btnGuardarContra.UseVisualStyleBackColor = false;
            this.LM830btnGuardarContra.Click += new System.EventHandler(this.LM830btnGuardarContra_Click);
            // 
            // pbMostrarClave
            // 
            this.LM830pbMostrarClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830pbMostrarClave.Image = global::LM830GUI.Properties.Resources.OjoAbierto;
            this.LM830pbMostrarClave.Location = new System.Drawing.Point(290, 246);
            this.LM830pbMostrarClave.Name = "LM830pbMostrarClave";
            this.LM830pbMostrarClave.Size = new System.Drawing.Size(41, 40);
            this.LM830pbMostrarClave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LM830pbMostrarClave.TabIndex = 17;
            this.LM830pbMostrarClave.TabStop = false;
            this.LM830pbMostrarClave.Click += new System.EventHandler(this.LM830pbMostrarClave_Click);
            // 
            // linkVolver
            // 
            this.LM830linkVolver.AutoSize = true;
            this.LM830linkVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830linkVolver.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(214)))), ((int)(((byte)(167)))));
            this.LM830linkVolver.Location = new System.Drawing.Point(144, 444);
            this.LM830linkVolver.Name = "LM830linkVolver";
            this.LM830linkVolver.Size = new System.Drawing.Size(49, 18);
            this.LM830linkVolver.TabIndex = 16;
            this.LM830linkVolver.TabStop = true;
            this.LM830linkVolver.Text = "Volver";
            this.LM830linkVolver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LM830linkVolver_LinkClicked);
            // 
            // CambiarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(346, 486);
            this.Controls.Add(this.LM830pbMostrarClave);
            this.Controls.Add(this.LM830linkVolver);
            this.Controls.Add(this.LM830btnGuardarContra);
            this.Controls.Add(this.LM830txtNuevaContraseña);
            this.Controls.Add(this.LM830lblContraseñaFCC);
            this.Controls.Add(this.LM830txtContraseña);
            this.Controls.Add(this.LM830txtUsuario);
            this.Controls.Add(this.LM830lblContraseñaActual);
            this.Controls.Add(this.LM830lblUsuarioFCC);
            this.Controls.Add(this.LM830pictureBox1);
            this.Controls.Add(this.LM830panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LM830CambiarContraseña";
            this.Text = "CambiarContraseña";
            this.Load += new System.EventHandler(this.LM830CambiarContraseña_Load);
            this.LM830panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830pbMostrarClave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LM830panel1;
        private System.Windows.Forms.PictureBox LM830btnCerrar;
        private System.Windows.Forms.PictureBox LM830btnMinimizar;
        private System.Windows.Forms.PictureBox LM830pictureBox1;
        private System.Windows.Forms.TextBox LM830txtContraseña;
        private System.Windows.Forms.TextBox LM830txtUsuario;
        private System.Windows.Forms.Label LM830lblContraseñaActual;
        private System.Windows.Forms.Label LM830lblUsuarioFCC;
        private System.Windows.Forms.TextBox LM830txtNuevaContraseña;
        private System.Windows.Forms.Label LM830lblContraseñaFCC;
        private System.Windows.Forms.Button LM830btnGuardarContra;
        private System.Windows.Forms.PictureBox LM830pbMostrarClave;
        private System.Windows.Forms.LinkLabel LM830linkVolver;
    }
}