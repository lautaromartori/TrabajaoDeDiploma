namespace LM830GUI
{
    partial class LM830FormBackup
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
            System.ComponentModel.ComponentResourceManager LM830resources = new System.ComponentModel.ComponentResourceManager(typeof(LM830FormBackup));
            this.LM830lblPath = new System.Windows.Forms.Label();
            this.LM830txtPath = new System.Windows.Forms.TextBox();
            this.LM830btnExaminar = new System.Windows.Forms.Button();
            this.LM830btnGenerar = new System.Windows.Forms.Button();
            this.LM830btnVolverDV = new System.Windows.Forms.Button();
            this.LM830panel1 = new System.Windows.Forms.Panel();
            this.LM830BarraTitulo = new System.Windows.Forms.Panel();
            this.LM830btnCerrar = new System.Windows.Forms.PictureBox();
            this.LM830btnMinimizar = new System.Windows.Forms.PictureBox();
            this.LM830panel3 = new System.Windows.Forms.Panel();
            this.LM830lblTitulo = new System.Windows.Forms.Label();
            this.LM830panel1.SuspendLayout();
            this.LM830BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnMinimizar)).BeginInit();
            this.LM830panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.LM830lblPath.AutoSize = true;
            this.LM830lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblPath.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LM830lblPath.Location = new System.Drawing.Point(14, 20);
            this.LM830lblPath.Name = "LM830lblPath";
            this.LM830lblPath.Size = new System.Drawing.Size(46, 20);
            this.LM830lblPath.TabIndex = 1;
            this.LM830lblPath.Text = "Path";
            // 
            // txtPath
            // 
            this.LM830txtPath.Location = new System.Drawing.Point(76, 11);
            this.LM830txtPath.Multiline = true;
            this.LM830txtPath.Name = "LM830txtPath";
            this.LM830txtPath.Size = new System.Drawing.Size(236, 39);
            this.LM830txtPath.TabIndex = 2;
            // 
            // btnExaminar
            // 
            this.LM830btnExaminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnExaminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LM830btnExaminar.Location = new System.Drawing.Point(18, 14);
            this.LM830btnExaminar.Name = "LM830btnExaminar";
            this.LM830btnExaminar.Size = new System.Drawing.Size(293, 38);
            this.LM830btnExaminar.TabIndex = 3;
            this.LM830btnExaminar.Text = "Examinar";
            this.LM830btnExaminar.UseVisualStyleBackColor = false;
            this.LM830btnExaminar.Click += new System.EventHandler(this.LM830btnExaminar_Click);
            // 
            // btnGenerar
            // 
            this.LM830btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnGenerar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LM830btnGenerar.Location = new System.Drawing.Point(18, 58);
            this.LM830btnGenerar.Name = "LM830btnGenerar";
            this.LM830btnGenerar.Size = new System.Drawing.Size(293, 40);
            this.LM830btnGenerar.TabIndex = 4;
            this.LM830btnGenerar.Text = "Generar";
            this.LM830btnGenerar.UseVisualStyleBackColor = false;
            this.LM830btnGenerar.Click += new System.EventHandler(this.LM830btnGenerar_Click);
            // 
            // btnVolverDV
            // 
            this.LM830btnVolverDV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnVolverDV.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LM830btnVolverDV.Location = new System.Drawing.Point(18, 104);
            this.LM830btnVolverDV.Name = "LM830btnVolverDV";
            this.LM830btnVolverDV.Size = new System.Drawing.Size(293, 38);
            this.LM830btnVolverDV.TabIndex = 5;
            this.LM830btnVolverDV.Text = "Volver";
            this.LM830btnVolverDV.UseVisualStyleBackColor = true;
            this.LM830btnVolverDV.Click += new System.EventHandler(this.LM830btnVolver_Click);
            // 
            // panel1
            // 
            this.LM830panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830panel1.Controls.Add(this.LM830lblPath);
            this.LM830panel1.Controls.Add(this.LM830txtPath);
            this.LM830panel1.Location = new System.Drawing.Point(29, 117);
            this.LM830panel1.Name = "LM830panel1";
            this.LM830panel1.Size = new System.Drawing.Size(327, 61);
            this.LM830panel1.TabIndex = 6;
            // 
            // BarraTitulo
            // 
            this.LM830BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830BarraTitulo.Controls.Add(this.LM830btnCerrar);
            this.LM830BarraTitulo.Controls.Add(this.LM830btnMinimizar);
            this.LM830BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LM830BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.LM830BarraTitulo.Name = "LM830BarraTitulo";
            this.LM830BarraTitulo.Size = new System.Drawing.Size(382, 43);
            this.LM830BarraTitulo.TabIndex = 9;
            this.LM830BarraTitulo.Paint += new System.Windows.Forms.PaintEventHandler(this.LM830panel2_Paint);
            this.LM830BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LM830BarraTitulo_MouseDown);
            this.LM830BarraTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LM830BarraTitulo_MouseMove);
            this.LM830BarraTitulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LM830BarraTitulo_MouseUp);
            // 
            // btnCerrar
            // 
            this.LM830btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LM830btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnCerrar.Image = ((System.Drawing.Image)(LM830resources.GetObject("btnCerrar.Image")));
            this.LM830btnCerrar.Location = new System.Drawing.Point(354, 4);
            this.LM830btnCerrar.Name = "LM830btnCerrar";
            this.LM830btnCerrar.Size = new System.Drawing.Size(25, 35);
            this.LM830btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LM830btnCerrar.TabIndex = 5;
            this.LM830btnCerrar.TabStop = false;
            // 
            // btnMinimizar
            // 
            this.LM830btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LM830btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnMinimizar.Image = ((System.Drawing.Image)(LM830resources.GetObject("btnMinimizar.Image")));
            this.LM830btnMinimizar.Location = new System.Drawing.Point(326, 4);
            this.LM830btnMinimizar.Name = "LM830btnMinimizar";
            this.LM830btnMinimizar.Size = new System.Drawing.Size(25, 35);
            this.LM830btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LM830btnMinimizar.TabIndex = 3;
            this.LM830btnMinimizar.TabStop = false;
            // 
            // panel3
            // 
            this.LM830panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830panel3.Controls.Add(this.LM830btnGenerar);
            this.LM830panel3.Controls.Add(this.LM830btnExaminar);
            this.LM830panel3.Controls.Add(this.LM830btnVolverDV);
            this.LM830panel3.Location = new System.Drawing.Point(29, 204);
            this.LM830panel3.Name = "LM830panel3";
            this.LM830panel3.Size = new System.Drawing.Size(327, 160);
            this.LM830panel3.TabIndex = 10;
            // 
            // lblTitulo
            // 
            this.LM830lblTitulo.AutoSize = true;
            this.LM830lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LM830lblTitulo.Location = new System.Drawing.Point(139, 64);
            this.LM830lblTitulo.Name = "LM830lblTitulo";
            this.LM830lblTitulo.Size = new System.Drawing.Size(99, 29);
            this.LM830lblTitulo.TabIndex = 0;
            this.LM830lblTitulo.Text = "Backup";
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(382, 384);
            this.Controls.Add(this.LM830panel3);
            this.Controls.Add(this.LM830BarraTitulo);
            this.Controls.Add(this.LM830panel1);
            this.Controls.Add(this.LM830lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LM830FormBackup";
            this.Text = "FormBackup";
            this.Load += new System.EventHandler(this.LM830FormBackup_Load);
            this.LM830panel1.ResumeLayout(false);
            this.LM830panel1.PerformLayout();
            this.LM830BarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnMinimizar)).EndInit();
            this.LM830panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LM830lblPath;
        private System.Windows.Forms.TextBox LM830txtPath;
        private System.Windows.Forms.Button LM830btnExaminar;
        private System.Windows.Forms.Button LM830btnGenerar;
        private System.Windows.Forms.Button LM830btnVolverDV;
        private System.Windows.Forms.Panel LM830panel1;
        private System.Windows.Forms.Panel LM830BarraTitulo;
        private System.Windows.Forms.PictureBox LM830btnCerrar;
        private System.Windows.Forms.PictureBox LM830btnMinimizar;
        private System.Windows.Forms.Panel LM830panel3;
        private System.Windows.Forms.Label LM830lblTitulo;
    }
}