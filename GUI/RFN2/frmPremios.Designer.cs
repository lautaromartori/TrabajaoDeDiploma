namespace GUI.RFN2
{
    partial class frmPremios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblSaldoTitulo = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblComprometidosTitulo = new System.Windows.Forms.Label();
            this.lblComprometidos = new System.Windows.Forms.Label();
            this.lblDisponibleTitulo = new System.Windows.Forms.Label();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.lblPremios = new System.Windows.Forms.Label();
            this.dgvPremios = new System.Windows.Forms.DataGridView();
            this.lblUmbral = new System.Windows.Forms.Label();
            this.btnRegistrarCanje = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pnlTitulo.SuspendLayout();
            this.grpCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPremios)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(780, 45);
            this.pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Premios canjeables";
            // 
            // grpCliente
            // 
            this.grpCliente.Controls.Add(this.lblDni);
            this.grpCliente.Controls.Add(this.txtDni);
            this.grpCliente.Controls.Add(this.btnBuscarCliente);
            this.grpCliente.Controls.Add(this.lblCliente);
            this.grpCliente.Controls.Add(this.lblSaldoTitulo);
            this.grpCliente.Controls.Add(this.lblSaldo);
            this.grpCliente.Controls.Add(this.lblComprometidosTitulo);
            this.grpCliente.Controls.Add(this.lblComprometidos);
            this.grpCliente.Controls.Add(this.lblDisponibleTitulo);
            this.grpCliente.Controls.Add(this.lblDisponible);
            this.grpCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.grpCliente.Location = new System.Drawing.Point(20, 60);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(740, 100);
            this.grpCliente.TabIndex = 2;
            this.grpCliente.Text = "Cliente";
            // 
            // lblDni
            // 
            this.lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDni.Location = new System.Drawing.Point(15, 30);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(40, 20);
            this.lblDni.TabIndex = 3;
            this.lblDni.Text = "DNI";
            // 
            // txtDni
            // 
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDni.MaxLength = 8;
            this.txtDni.Location = new System.Drawing.Point(60, 27);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(130, 22);
            this.txtDni.TabIndex = 4;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.btnBuscarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCliente.Location = new System.Drawing.Point(200, 23);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(120, 30);
            this.btnBuscarCliente.TabIndex = 5;
            this.btnBuscarCliente.Text = "Buscar cliente";
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(335, 30);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(390, 20);
            this.lblCliente.TabIndex = 6;
            this.lblCliente.Text = "-";
            // 
            // lblSaldoTitulo
            // 
            this.lblSaldoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoTitulo.Location = new System.Drawing.Point(15, 65);
            this.lblSaldoTitulo.Name = "lblSaldoTitulo";
            this.lblSaldoTitulo.Size = new System.Drawing.Size(100, 20);
            this.lblSaldoTitulo.TabIndex = 7;
            this.lblSaldoTitulo.Text = "Saldo vigente:";
            // 
            // lblSaldo
            // 
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(120, 65);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(110, 20);
            this.lblSaldo.TabIndex = 8;
            this.lblSaldo.Text = "-";
            // 
            // lblComprometidosTitulo
            // 
            this.lblComprometidosTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComprometidosTitulo.Location = new System.Drawing.Point(240, 65);
            this.lblComprometidosTitulo.Name = "lblComprometidosTitulo";
            this.lblComprometidosTitulo.Size = new System.Drawing.Size(120, 20);
            this.lblComprometidosTitulo.TabIndex = 9;
            this.lblComprometidosTitulo.Text = "Comprometidos:";
            // 
            // lblComprometidos
            // 
            this.lblComprometidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComprometidos.Location = new System.Drawing.Point(365, 65);
            this.lblComprometidos.Name = "lblComprometidos";
            this.lblComprometidos.Size = new System.Drawing.Size(110, 20);
            this.lblComprometidos.TabIndex = 10;
            this.lblComprometidos.Text = "-";
            // 
            // lblDisponibleTitulo
            // 
            this.lblDisponibleTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponibleTitulo.Location = new System.Drawing.Point(485, 65);
            this.lblDisponibleTitulo.Name = "lblDisponibleTitulo";
            this.lblDisponibleTitulo.Size = new System.Drawing.Size(90, 20);
            this.lblDisponibleTitulo.TabIndex = 11;
            this.lblDisponibleTitulo.Text = "Disponible:";
            // 
            // lblDisponible
            // 
            this.lblDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponible.Location = new System.Drawing.Point(580, 65);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Size = new System.Drawing.Size(140, 20);
            this.lblDisponible.TabIndex = 12;
            this.lblDisponible.Text = "-";
            // 
            // lblPremios
            // 
            this.lblPremios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPremios.Location = new System.Drawing.Point(20, 170);
            this.lblPremios.Name = "lblPremios";
            this.lblPremios.Size = new System.Drawing.Size(500, 20);
            this.lblPremios.TabIndex = 13;
            this.lblPremios.Text = "Premios que puede canjear";
            // 
            // dgvPremios
            // 
            this.dgvPremios.AllowUserToAddRows = false;
            this.dgvPremios.AllowUserToDeleteRows = false;
            this.dgvPremios.ReadOnly = true;
            this.dgvPremios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPremios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPremios.MultiSelect = false;
            this.dgvPremios.RowHeadersVisible = false;
            this.dgvPremios.BackgroundColor = System.Drawing.Color.White;
            this.dgvPremios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvPremios.EnableHeadersVisualStyles = false;
            this.dgvPremios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.dgvPremios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPremios.Location = new System.Drawing.Point(20, 195);
            this.dgvPremios.Name = "dgvPremios";
            this.dgvPremios.Size = new System.Drawing.Size(740, 310);
            this.dgvPremios.TabIndex = 14;
            // 
            // lblUmbral
            // 
            this.lblUmbral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUmbral.ForeColor = System.Drawing.Color.DimGray;
            this.lblUmbral.Location = new System.Drawing.Point(20, 512);
            this.lblUmbral.Name = "lblUmbral";
            this.lblUmbral.Size = new System.Drawing.Size(740, 36);
            this.lblUmbral.TabIndex = 15;
            this.lblUmbral.Text = "";
            // 
            // btnRegistrarCanje
            // 
            this.btnRegistrarCanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarCanje.UseVisualStyleBackColor = false;
            this.btnRegistrarCanje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnRegistrarCanje.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarCanje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarCanje.FlatAppearance.BorderSize = 0;
            this.btnRegistrarCanje.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnRegistrarCanje.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarCanje.Location = new System.Drawing.Point(490, 565);
            this.btnRegistrarCanje.Name = "btnRegistrarCanje";
            this.btnRegistrarCanje.Size = new System.Drawing.Size(160, 30);
            this.btnRegistrarCanje.TabIndex = 16;
            this.btnRegistrarCanje.Text = "Registrar canje";
            this.btnRegistrarCanje.Click += new System.EventHandler(this.btnRegistrarCanje_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Location = new System.Drawing.Point(660, 565);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 30);
            this.btnVolver.TabIndex = 17;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmPremios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 620);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.grpCliente);
            this.Controls.Add(this.lblPremios);
            this.Controls.Add(this.dgvPremios);
            this.Controls.Add(this.lblUmbral);
            this.Controls.Add(this.btnRegistrarCanje);
            this.Controls.Add(this.btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPremios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Premios canjeables";
            this.Load += new System.EventHandler(this.frmPremios_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPremios_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPremios)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblSaldoTitulo;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblComprometidosTitulo;
        private System.Windows.Forms.Label lblComprometidos;
        private System.Windows.Forms.Label lblDisponibleTitulo;
        private System.Windows.Forms.Label lblDisponible;
        private System.Windows.Forms.Label lblPremios;
        private System.Windows.Forms.DataGridView dgvPremios;
        private System.Windows.Forms.Label lblUmbral;
        private System.Windows.Forms.Button btnRegistrarCanje;
        private System.Windows.Forms.Button btnVolver;
    }
}
