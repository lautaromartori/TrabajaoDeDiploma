namespace LM830GUI
{
    partial class LM830FrmConexionInicial
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
            this.LM830cmbServidor = new System.Windows.Forms.ComboBox();
            this.LM830btnBuscar = new System.Windows.Forms.Button();
            this.LM830btnConectar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbServidor
            // 
            this.LM830cmbServidor.FormattingEnabled = true;
            this.LM830cmbServidor.Location = new System.Drawing.Point(35, 26);
            this.LM830cmbServidor.Name = "LM830cmbServidor";
            this.LM830cmbServidor.Size = new System.Drawing.Size(155, 21);
            this.LM830cmbServidor.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.LM830btnBuscar.Location = new System.Drawing.Point(34, 85);
            this.LM830btnBuscar.Name = "LM830btnBuscar";
            this.LM830btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.LM830btnBuscar.TabIndex = 2;
            this.LM830btnBuscar.Text = "Buscar";
            this.LM830btnBuscar.UseVisualStyleBackColor = true;
            this.LM830btnBuscar.Click += new System.EventHandler(this.LM830btnBuscar_Click);
            // 
            // btnConectar
            // 
            this.LM830btnConectar.Location = new System.Drawing.Point(115, 85);
            this.LM830btnConectar.Name = "LM830btnConectar";
            this.LM830btnConectar.Size = new System.Drawing.Size(75, 23);
            this.LM830btnConectar.TabIndex = 3;
            this.LM830btnConectar.Text = "Conectar";
            this.LM830btnConectar.UseVisualStyleBackColor = true;
            this.LM830btnConectar.Click += new System.EventHandler(this.LM830btnConectar_Click);
            // 
            // FrmConexionInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 163);
            this.Controls.Add(this.LM830btnConectar);
            this.Controls.Add(this.LM830btnBuscar);
            this.Controls.Add(this.LM830cmbServidor);
            this.Name = "LM830FrmConexionInicial";
            this.Text = "FrmConexionInicial";
            this.Load += new System.EventHandler(this.LM830FrmConexionInicial_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox LM830cmbServidor;
        private System.Windows.Forms.Button LM830btnBuscar;
        private System.Windows.Forms.Button LM830btnConectar;
    }
}