namespace LM830GUI
{
    partial class LM830Login
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
            System.ComponentModel.ComponentResourceManager LM830resources = new System.ComponentModel.ComponentResourceManager(typeof(LM830Login));
            this.LM830lblUsuario = new System.Windows.Forms.Label();
            this.LM830lblContraseña = new System.Windows.Forms.Label();
            this.LM830txtUsuario = new System.Windows.Forms.TextBox();
            this.LM830txtContraseña = new System.Windows.Forms.TextBox();
            this.LM830btnLogin = new System.Windows.Forms.Button();
            this.LM830panel1 = new System.Windows.Forms.Panel();
            this.LM830btnCerrar = new System.Windows.Forms.PictureBox();
            this.LM830btnMinimizar = new System.Windows.Forms.PictureBox();
            this.LM830pbMostrarClave = new System.Windows.Forms.PictureBox();
            this.LM830pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LM830panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830pbMostrarClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.LM830lblUsuario.AutoSize = true;
            this.LM830lblUsuario.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblUsuario.ForeColor = System.Drawing.Color.White;
            this.LM830lblUsuario.Location = new System.Drawing.Point(62, 207);
            this.LM830lblUsuario.Name = "LM830lblUsuario";
            this.LM830lblUsuario.Size = new System.Drawing.Size(86, 24);
            this.LM830lblUsuario.TabIndex = 0;
            this.LM830lblUsuario.Text = "Usuario:";
            // 
            // lblContraseña
            // 
            this.LM830lblContraseña.AutoSize = true;
            this.LM830lblContraseña.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblContraseña.ForeColor = System.Drawing.Color.White;
            this.LM830lblContraseña.Location = new System.Drawing.Point(62, 277);
            this.LM830lblContraseña.Name = "LM830lblContraseña";
            this.LM830lblContraseña.Size = new System.Drawing.Size(135, 24);
            this.LM830lblContraseña.TabIndex = 1;
            this.LM830lblContraseña.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            this.LM830txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtUsuario.Location = new System.Drawing.Point(66, 234);
            this.LM830txtUsuario.Multiline = true;
            this.LM830txtUsuario.Name = "LM830txtUsuario";
            this.LM830txtUsuario.Size = new System.Drawing.Size(219, 40);
            this.LM830txtUsuario.TabIndex = 2;
            this.LM830txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LM830txtUsuario_KeyPress);
            // 
            // txtContraseña
            // 
            this.LM830txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtContraseña.Location = new System.Drawing.Point(66, 304);
            this.LM830txtContraseña.Multiline = true;
            this.LM830txtContraseña.Name = "LM830txtContraseña";
            this.LM830txtContraseña.PasswordChar = '*';
            this.LM830txtContraseña.Size = new System.Drawing.Size(219, 40);
            this.LM830txtContraseña.TabIndex = 3;
            this.LM830txtContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LM830txtContraseña_KeyPress);
            // 
            // btnLogin
            // 
            this.LM830btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnLogin.FlatAppearance.BorderSize = 0;
            this.LM830btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnLogin.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnLogin.ForeColor = System.Drawing.Color.White;
            this.LM830btnLogin.Location = new System.Drawing.Point(66, 368);
            this.LM830btnLogin.Name = "LM830btnLogin";
            this.LM830btnLogin.Size = new System.Drawing.Size(219, 40);
            this.LM830btnLogin.TabIndex = 5;
            this.LM830btnLogin.Text = "Iniciar sesion";
            this.LM830btnLogin.UseVisualStyleBackColor = false;
            this.LM830btnLogin.Click += new System.EventHandler(this.LM830btnLogin_Click);
            // 
            // panel1
            // 
            this.LM830panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830panel1.Controls.Add(this.LM830btnCerrar);
            this.LM830panel1.Controls.Add(this.LM830btnMinimizar);
            this.LM830panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.LM830panel1.Location = new System.Drawing.Point(0, 0);
            this.LM830panel1.Name = "LM830panel1";
            this.LM830panel1.Size = new System.Drawing.Size(355, 43);
            this.LM830panel1.TabIndex = 6;
            this.LM830panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LM830panel1_MouseDown);
            this.LM830panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LM830panel1_MouseMove);
            this.LM830panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LM830panel1_MouseUp);
            // 
            // btnCerrar
            // 
            this.LM830btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LM830btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnCerrar.Image = ((System.Drawing.Image)(LM830resources.GetObject("btnCerrar.Image")));
            this.LM830btnCerrar.Location = new System.Drawing.Point(327, 4);
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
            this.LM830btnMinimizar.Location = new System.Drawing.Point(299, 4);
            this.LM830btnMinimizar.Name = "LM830btnMinimizar";
            this.LM830btnMinimizar.Size = new System.Drawing.Size(25, 35);
            this.LM830btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LM830btnMinimizar.TabIndex = 3;
            this.LM830btnMinimizar.TabStop = false;
            this.LM830btnMinimizar.Click += new System.EventHandler(this.LM830btnMinimizar_Click);
            // 
            // pbMostrarClave
            // 
            this.LM830pbMostrarClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830pbMostrarClave.Image = global::LM830GUI.Properties.Resources.OjoAbierto;
            this.LM830pbMostrarClave.Location = new System.Drawing.Point(292, 304);
            this.LM830pbMostrarClave.Name = "LM830pbMostrarClave";
            this.LM830pbMostrarClave.Size = new System.Drawing.Size(41, 40);
            this.LM830pbMostrarClave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LM830pbMostrarClave.TabIndex = 8;
            this.LM830pbMostrarClave.TabStop = false;
            this.LM830pbMostrarClave.Click += new System.EventHandler(this.LM830pbMostrarClave_Click);
            // 
            // pictureBox1
            // 
            this.LM830pictureBox1.Image = ((System.Drawing.Image)(LM830resources.GetObject("pictureBox1.Image")));
            this.LM830pictureBox1.Location = new System.Drawing.Point(0, 40);
            this.LM830pictureBox1.Name = "LM830pictureBox1";
            this.LM830pictureBox1.Size = new System.Drawing.Size(387, 176);
            this.LM830pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LM830pictureBox1.TabIndex = 4;
            this.LM830pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(355, 496);
            this.Controls.Add(this.LM830pbMostrarClave);
            this.Controls.Add(this.LM830panel1);
            this.Controls.Add(this.LM830btnLogin);
            this.Controls.Add(this.LM830txtContraseña);
            this.Controls.Add(this.LM830txtUsuario);
            this.Controls.Add(this.LM830lblContraseña);
            this.Controls.Add(this.LM830lblUsuario);
            this.Controls.Add(this.LM830pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LM830Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LM830Login_Load);
            this.LM830panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830pbMostrarClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LM830lblUsuario;
        private System.Windows.Forms.Label LM830lblContraseña;
        private System.Windows.Forms.TextBox LM830txtUsuario;
        private System.Windows.Forms.TextBox LM830txtContraseña;
        private System.Windows.Forms.PictureBox LM830pictureBox1;
        private System.Windows.Forms.Button LM830btnLogin;
        private System.Windows.Forms.Panel LM830panel1;
        private System.Windows.Forms.PictureBox LM830btnCerrar;
        private System.Windows.Forms.PictureBox LM830btnMinimizar;
        private System.Windows.Forms.PictureBox LM830pbMostrarClave;
    }
}