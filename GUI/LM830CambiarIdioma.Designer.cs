namespace LM830GUI
{
    partial class LM830CambiarIdioma
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
            System.ComponentModel.ComponentResourceManager LM830resources = new System.ComponentModel.ComponentResourceManager(typeof(LM830CambiarIdioma));
            this.LM830cbIdiomas = new System.Windows.Forms.ComboBox();
            this.LM830btnCambiarCI = new System.Windows.Forms.Button();
            this.LM830button1 = new System.Windows.Forms.Button();
            this.LM830panel1 = new System.Windows.Forms.Panel();
            this.LM830btnCerrar = new System.Windows.Forms.PictureBox();
            this.LM830btnMaximizar = new System.Windows.Forms.PictureBox();
            this.LM830btnMinimizar = new System.Windows.Forms.PictureBox();
            this.LM830panel2 = new System.Windows.Forms.Panel();
            this.LM830panel3 = new System.Windows.Forms.Panel();
            this.LM830lblCambiarIdioma = new System.Windows.Forms.Label();
            this.LM830panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnMinimizar)).BeginInit();
            this.LM830panel2.SuspendLayout();
            this.LM830panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbIdiomas
            // 
            this.LM830cbIdiomas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830cbIdiomas.FormattingEnabled = true;
            this.LM830cbIdiomas.Location = new System.Drawing.Point(52, 69);
            this.LM830cbIdiomas.Name = "LM830cbIdiomas";
            this.LM830cbIdiomas.Size = new System.Drawing.Size(200, 32);
            this.LM830cbIdiomas.TabIndex = 1;
            // 
            // btnCambiarCI
            // 
            this.LM830btnCambiarCI.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LM830btnCambiarCI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnCambiarCI.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LM830btnCambiarCI.Location = new System.Drawing.Point(52, 130);
            this.LM830btnCambiarCI.Name = "LM830btnCambiarCI";
            this.LM830btnCambiarCI.Size = new System.Drawing.Size(200, 37);
            this.LM830btnCambiarCI.TabIndex = 2;
            this.LM830btnCambiarCI.Text = "Cambiar";
            this.LM830btnCambiarCI.UseVisualStyleBackColor = true;
            this.LM830btnCambiarCI.Click += new System.EventHandler(this.LM830btnCambiar_Click);
            // 
            // button1
            // 
            this.LM830button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LM830button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LM830button1.Location = new System.Drawing.Point(52, 211);
            this.LM830button1.Name = "LM830button1";
            this.LM830button1.Size = new System.Drawing.Size(200, 37);
            this.LM830button1.TabIndex = 3;
            this.LM830button1.Text = "Salir";
            this.LM830button1.UseVisualStyleBackColor = true;
            this.LM830button1.Click += new System.EventHandler(this.LM830button1_Click);
            // 
            // panel1
            // 
            this.LM830panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830panel1.Controls.Add(this.LM830btnCerrar);
            this.LM830panel1.Controls.Add(this.LM830btnMaximizar);
            this.LM830panel1.Controls.Add(this.LM830btnMinimizar);
            this.LM830panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.LM830panel1.Location = new System.Drawing.Point(0, 0);
            this.LM830panel1.Name = "LM830panel1";
            this.LM830panel1.Size = new System.Drawing.Size(399, 41);
            this.LM830panel1.TabIndex = 33;
            this.LM830panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LM830BarraTitulo_MouseDown);
            this.LM830panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LM830BarraTitulo_MouseMove);
            this.LM830panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LM830BarraTitulo_MouseUp);
            // 
            // btnCerrar
            // 
            this.LM830btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LM830btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnCerrar.Image = ((System.Drawing.Image)(LM830resources.GetObject("btnCerrar.Image")));
            this.LM830btnCerrar.Location = new System.Drawing.Point(371, 3);
            this.LM830btnCerrar.Name = "LM830btnCerrar";
            this.LM830btnCerrar.Size = new System.Drawing.Size(25, 35);
            this.LM830btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LM830btnCerrar.TabIndex = 8;
            this.LM830btnCerrar.TabStop = false;
            // 
            // btnMaximizar
            // 
            this.LM830btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LM830btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnMaximizar.Image = ((System.Drawing.Image)(LM830resources.GetObject("btnMaximizar.Image")));
            this.LM830btnMaximizar.Location = new System.Drawing.Point(340, 3);
            this.LM830btnMaximizar.Name = "LM830btnMaximizar";
            this.LM830btnMaximizar.Size = new System.Drawing.Size(25, 35);
            this.LM830btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LM830btnMaximizar.TabIndex = 7;
            this.LM830btnMaximizar.TabStop = false;
            // 
            // btnMinimizar
            // 
            this.LM830btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LM830btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnMinimizar.Image = ((System.Drawing.Image)(LM830resources.GetObject("btnMinimizar.Image")));
            this.LM830btnMinimizar.Location = new System.Drawing.Point(309, 3);
            this.LM830btnMinimizar.Name = "LM830btnMinimizar";
            this.LM830btnMinimizar.Size = new System.Drawing.Size(25, 35);
            this.LM830btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LM830btnMinimizar.TabIndex = 6;
            this.LM830btnMinimizar.TabStop = false;
            // 
            // panel2
            // 
            this.LM830panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830panel2.Controls.Add(this.LM830panel3);
            this.LM830panel2.Controls.Add(this.LM830button1);
            this.LM830panel2.Controls.Add(this.LM830btnCambiarCI);
            this.LM830panel2.Controls.Add(this.LM830cbIdiomas);
            this.LM830panel2.Location = new System.Drawing.Point(43, 67);
            this.LM830panel2.Name = "LM830panel2";
            this.LM830panel2.Size = new System.Drawing.Size(306, 286);
            this.LM830panel2.TabIndex = 34;
            // 
            // panel3
            // 
            this.LM830panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LM830panel3.Controls.Add(this.LM830lblCambiarIdioma);
            this.LM830panel3.Location = new System.Drawing.Point(0, 0);
            this.LM830panel3.Name = "LM830panel3";
            this.LM830panel3.Size = new System.Drawing.Size(306, 49);
            this.LM830panel3.TabIndex = 4;
            // 
            // lblCambiarIdioma
            // 
            this.LM830lblCambiarIdioma.AutoSize = true;
            this.LM830lblCambiarIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblCambiarIdioma.ForeColor = System.Drawing.SystemColors.Control;
            this.LM830lblCambiarIdioma.Location = new System.Drawing.Point(35, 6);
            this.LM830lblCambiarIdioma.Name = "LM830lblCambiarIdioma";
            this.LM830lblCambiarIdioma.Size = new System.Drawing.Size(236, 33);
            this.LM830lblCambiarIdioma.TabIndex = 22;
            this.LM830lblCambiarIdioma.Text = "Cambiar Idioma";
            this.LM830lblCambiarIdioma.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CambiarIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(399, 393);
            this.Controls.Add(this.LM830panel2);
            this.Controls.Add(this.LM830panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LM830CambiarIdioma";
            this.Text = "CambiarIdioma";
            this.Load += new System.EventHandler(this.LM830CambiarIdioma_Load);
            this.LM830panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnMinimizar)).EndInit();
            this.LM830panel2.ResumeLayout(false);
            this.LM830panel3.ResumeLayout(false);
            this.LM830panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox LM830cbIdiomas;
        private System.Windows.Forms.Button LM830btnCambiarCI;
        private System.Windows.Forms.Button LM830button1;
        private System.Windows.Forms.Panel LM830panel1;
        private System.Windows.Forms.PictureBox LM830btnCerrar;
        private System.Windows.Forms.PictureBox LM830btnMaximizar;
        private System.Windows.Forms.PictureBox LM830btnMinimizar;
        private System.Windows.Forms.Panel LM830panel2;
        private System.Windows.Forms.Panel LM830panel3;
        private System.Windows.Forms.Label LM830lblCambiarIdioma;
    }
}