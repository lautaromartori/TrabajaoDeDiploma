namespace LM830GUI
{
    partial class LM830frmReparacionDV
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
            System.ComponentModel.ComponentResourceManager LM830resources = new System.ComponentModel.ComponentResourceManager(typeof(LM830frmReparacionDV));
            this.LM830lstInconsistencias = new System.Windows.Forms.ListBox();
            this.LM830panel1 = new System.Windows.Forms.Panel();
            this.LM830lblErrorDV = new System.Windows.Forms.Label();
            this.LM830panel3 = new System.Windows.Forms.Panel();
            this.LM830groupBox1 = new System.Windows.Forms.GroupBox();
            this.LM830btnCancelardv = new System.Windows.Forms.Button();
            this.LM830lblForzar = new System.Windows.Forms.Label();
            this.LM830lblSelecVers = new System.Windows.Forms.Label();
            this.LM830btnRestaurar = new System.Windows.Forms.Button();
            this.LM830lstBackups = new System.Windows.Forms.ListBox();
            this.LM830btnRecalcularDV = new System.Windows.Forms.Button();
            this.LM830lblModuloReparacion = new System.Windows.Forms.Label();
            this.LM830panel2 = new System.Windows.Forms.Panel();
            this.LM830btnMaximizar = new System.Windows.Forms.PictureBox();
            this.LM830btnMinimizar = new System.Windows.Forms.PictureBox();
            this.LM830panel1.SuspendLayout();
            this.LM830panel3.SuspendLayout();
            this.LM830groupBox1.SuspendLayout();
            this.LM830panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnMinimizar)).BeginInit();
            this.SuspendLayout();
            // 
            // lstInconsistencias
            // 
            this.LM830lstInconsistencias.FormattingEnabled = true;
            this.LM830lstInconsistencias.Location = new System.Drawing.Point(16, 38);
            this.LM830lstInconsistencias.Name = "LM830lstInconsistencias";
            this.LM830lstInconsistencias.Size = new System.Drawing.Size(668, 95);
            this.LM830lstInconsistencias.TabIndex = 1;
            // 
            // panel1
            // 
            this.LM830panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830panel1.Controls.Add(this.LM830lblErrorDV);
            this.LM830panel1.Controls.Add(this.LM830lstInconsistencias);
            this.LM830panel1.Location = new System.Drawing.Point(30, 77);
            this.LM830panel1.Name = "LM830panel1";
            this.LM830panel1.Size = new System.Drawing.Size(700, 148);
            this.LM830panel1.TabIndex = 2;
            // 
            // lblErrorDV
            // 
            this.LM830lblErrorDV.AutoSize = true;
            this.LM830lblErrorDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblErrorDV.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LM830lblErrorDV.Location = new System.Drawing.Point(216, 7);
            this.LM830lblErrorDV.Name = "LM830lblErrorDV";
            this.LM830lblErrorDV.Size = new System.Drawing.Size(262, 24);
            this.LM830lblErrorDV.TabIndex = 2;
            this.LM830lblErrorDV.Text = "Inconsistencias Detectadas";
            // 
            // panel3
            // 
            this.LM830panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830panel3.Controls.Add(this.LM830groupBox1);
            this.LM830panel3.Controls.Add(this.LM830lblModuloReparacion);
            this.LM830panel3.Location = new System.Drawing.Point(30, 249);
            this.LM830panel3.Name = "LM830panel3";
            this.LM830panel3.Size = new System.Drawing.Size(700, 388);
            this.LM830panel3.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.LM830groupBox1.Controls.Add(this.LM830btnCancelardv);
            this.LM830groupBox1.Controls.Add(this.LM830lblForzar);
            this.LM830groupBox1.Controls.Add(this.LM830lblSelecVers);
            this.LM830groupBox1.Controls.Add(this.LM830btnRestaurar);
            this.LM830groupBox1.Controls.Add(this.LM830lstBackups);
            this.LM830groupBox1.Controls.Add(this.LM830btnRecalcularDV);
            this.LM830groupBox1.Location = new System.Drawing.Point(29, 43);
            this.LM830groupBox1.Name = "LM830groupBox1";
            this.LM830groupBox1.Size = new System.Drawing.Size(641, 321);
            this.LM830groupBox1.TabIndex = 4;
            this.LM830groupBox1.TabStop = false;
            // 
            // btnCancelardv
            // 
            this.LM830btnCancelardv.Location = new System.Drawing.Point(348, 261);
            this.LM830btnCancelardv.Name = "LM830btnCancelardv";
            this.LM830btnCancelardv.Size = new System.Drawing.Size(254, 42);
            this.LM830btnCancelardv.TabIndex = 7;
            this.LM830btnCancelardv.Text = "Cancelar";
            this.LM830btnCancelardv.UseVisualStyleBackColor = true;
            this.LM830btnCancelardv.Click += new System.EventHandler(this.LM830btnCancelar_Click);
            // 
            // lblForzar
            // 
            this.LM830lblForzar.AutoSize = true;
            this.LM830lblForzar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblForzar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LM830lblForzar.Location = new System.Drawing.Point(48, 37);
            this.LM830lblForzar.Name = "LM830lblForzar";
            this.LM830lblForzar.Size = new System.Drawing.Size(251, 16);
            this.LM830lblForzar.TabIndex = 6;
            this.LM830lblForzar.Text = "Forzar nuevos digitos verificadores";
            // 
            // lblSelecVers
            // 
            this.LM830lblSelecVers.AutoSize = true;
            this.LM830lblSelecVers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblSelecVers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LM830lblSelecVers.Location = new System.Drawing.Point(48, 116);
            this.LM830lblSelecVers.Name = "LM830lblSelecVers";
            this.LM830lblSelecVers.Size = new System.Drawing.Size(173, 16);
            this.LM830lblSelecVers.TabIndex = 5;
            this.LM830lblSelecVers.Text = "Seleccione una version:";
            // 
            // btnRestaurar
            // 
            this.LM830btnRestaurar.Location = new System.Drawing.Point(348, 135);
            this.LM830btnRestaurar.Name = "LM830btnRestaurar";
            this.LM830btnRestaurar.Size = new System.Drawing.Size(254, 42);
            this.LM830btnRestaurar.TabIndex = 4;
            this.LM830btnRestaurar.Text = "Restaurar Version Anterior";
            this.LM830btnRestaurar.UseVisualStyleBackColor = true;
            this.LM830btnRestaurar.Click += new System.EventHandler(this.LM830btnRestaurar_Click);
            // 
            // lstBackups
            // 
            this.LM830lstBackups.FormattingEnabled = true;
            this.LM830lstBackups.Location = new System.Drawing.Point(51, 135);
            this.LM830lstBackups.Name = "LM830lstBackups";
            this.LM830lstBackups.Size = new System.Drawing.Size(281, 108);
            this.LM830lstBackups.TabIndex = 3;
            // 
            // btnRecalcularDV
            // 
            this.LM830btnRecalcularDV.Location = new System.Drawing.Point(51, 56);
            this.LM830btnRecalcularDV.Name = "LM830btnRecalcularDV";
            this.LM830btnRecalcularDV.Size = new System.Drawing.Size(551, 44);
            this.LM830btnRecalcularDV.TabIndex = 0;
            this.LM830btnRecalcularDV.Text = "Recalcular Digito Verificadores";
            this.LM830btnRecalcularDV.UseVisualStyleBackColor = true;
            this.LM830btnRecalcularDV.Click += new System.EventHandler(this.LM830btnRecalcularDV_Click);
            // 
            // lblModuloReparacion
            // 
            this.LM830lblModuloReparacion.AutoSize = true;
            this.LM830lblModuloReparacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblModuloReparacion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LM830lblModuloReparacion.Location = new System.Drawing.Point(237, 10);
            this.LM830lblModuloReparacion.Name = "LM830lblModuloReparacion";
            this.LM830lblModuloReparacion.Size = new System.Drawing.Size(216, 24);
            this.LM830lblModuloReparacion.TabIndex = 3;
            this.LM830lblModuloReparacion.Text = "Modulo de reparacion";
            // 
            // panel2
            // 
            this.LM830panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830panel2.Controls.Add(this.LM830btnMaximizar);
            this.LM830panel2.Controls.Add(this.LM830btnMinimizar);
            this.LM830panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.LM830panel2.Location = new System.Drawing.Point(0, 0);
            this.LM830panel2.Name = "LM830panel2";
            this.LM830panel2.Size = new System.Drawing.Size(763, 41);
            this.LM830panel2.TabIndex = 33;
            this.LM830panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LM830BarraTitulo_MouseDown);
            this.LM830panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LM830BarraTitulo_MouseMove);
            this.LM830panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LM830BarraTitulo_MouseUp);
            // 
            // btnMaximizar
            // 
            this.LM830btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LM830btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnMaximizar.Image = ((System.Drawing.Image)(LM830resources.GetObject("btnMaximizar.Image")));
            this.LM830btnMaximizar.Location = new System.Drawing.Point(726, 3);
            this.LM830btnMaximizar.Name = "LM830btnMaximizar";
            this.LM830btnMaximizar.Size = new System.Drawing.Size(25, 35);
            this.LM830btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LM830btnMaximizar.TabIndex = 7;
            this.LM830btnMaximizar.TabStop = false;
            this.LM830btnMaximizar.Click += new System.EventHandler(this.LM830btnMaximizar_Click);
            // 
            // btnMinimizar
            // 
            this.LM830btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LM830btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnMinimizar.Image = ((System.Drawing.Image)(LM830resources.GetObject("btnMinimizar.Image")));
            this.LM830btnMinimizar.Location = new System.Drawing.Point(695, 3);
            this.LM830btnMinimizar.Name = "LM830btnMinimizar";
            this.LM830btnMinimizar.Size = new System.Drawing.Size(25, 35);
            this.LM830btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LM830btnMinimizar.TabIndex = 6;
            this.LM830btnMinimizar.TabStop = false;
            this.LM830btnMinimizar.Click += new System.EventHandler(this.LM830btnMinimizar_Click);
            // 
            // frmReparacionDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(763, 654);
            this.Controls.Add(this.LM830panel2);
            this.Controls.Add(this.LM830panel3);
            this.Controls.Add(this.LM830panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LM830frmReparacionDV";
            this.Text = "   ";
            this.Load += new System.EventHandler(this.LM830frmReparacionDV_Load);
            this.LM830panel1.ResumeLayout(false);
            this.LM830panel1.PerformLayout();
            this.LM830panel3.ResumeLayout(false);
            this.LM830panel3.PerformLayout();
            this.LM830groupBox1.ResumeLayout(false);
            this.LM830groupBox1.PerformLayout();
            this.LM830panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830btnMinimizar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LM830lstInconsistencias;
        private System.Windows.Forms.Panel LM830panel1;
        private System.Windows.Forms.Label LM830lblErrorDV;
        private System.Windows.Forms.Panel LM830panel3;
        private System.Windows.Forms.GroupBox LM830groupBox1;
        private System.Windows.Forms.ListBox LM830lstBackups;
        private System.Windows.Forms.Button LM830btnRecalcularDV;
        private System.Windows.Forms.Label LM830lblModuloReparacion;
        private System.Windows.Forms.Label LM830lblSelecVers;
        private System.Windows.Forms.Button LM830btnRestaurar;
        private System.Windows.Forms.Label LM830lblForzar;
        private System.Windows.Forms.Button LM830btnCancelardv;
        private System.Windows.Forms.Panel LM830panel2;
        private System.Windows.Forms.PictureBox LM830btnMaximizar;
        private System.Windows.Forms.PictureBox LM830btnMinimizar;
    }
}