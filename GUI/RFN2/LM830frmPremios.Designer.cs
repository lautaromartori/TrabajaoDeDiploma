namespace LM830GUI.LM830RFN2
{
    partial class LM830frmPremios
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
            this.LM830pnlTitulo = new System.Windows.Forms.Panel();
            this.LM830lblTitulo = new System.Windows.Forms.Label();
            this.LM830grpCliente = new System.Windows.Forms.GroupBox();
            this.LM830lblDni = new System.Windows.Forms.Label();
            this.LM830txtDni = new System.Windows.Forms.TextBox();
            this.LM830btnBuscarCliente = new System.Windows.Forms.Button();
            this.LM830lblCliente = new System.Windows.Forms.Label();
            this.LM830lblSaldoTitulo = new System.Windows.Forms.Label();
            this.LM830lblSaldo = new System.Windows.Forms.Label();
            this.LM830lblComprometidosTitulo = new System.Windows.Forms.Label();
            this.LM830lblComprometidos = new System.Windows.Forms.Label();
            this.LM830lblDisponibleTitulo = new System.Windows.Forms.Label();
            this.LM830lblDisponible = new System.Windows.Forms.Label();
            this.LM830lblPremios = new System.Windows.Forms.Label();
            this.LM830dgvPremios = new System.Windows.Forms.DataGridView();
            this.LM830lblUmbral = new System.Windows.Forms.Label();
            this.LM830btnRegistrarCanje = new System.Windows.Forms.Button();
            this.LM830btnVolver = new System.Windows.Forms.Button();
            this.LM830pnlTitulo.SuspendLayout();
            this.LM830grpCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvPremios)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.LM830pnlTitulo.Controls.Add(this.LM830lblTitulo);
            this.LM830pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LM830pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.LM830pnlTitulo.Name = "LM830pnlTitulo";
            this.LM830pnlTitulo.Size = new System.Drawing.Size(780, 45);
            this.LM830pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.LM830lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblTitulo.ForeColor = System.Drawing.Color.White;
            this.LM830lblTitulo.AutoSize = true;
            this.LM830lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.LM830lblTitulo.Name = "LM830lblTitulo";
            this.LM830lblTitulo.TabIndex = 1;
            this.LM830lblTitulo.Text = "Premios canjeables";
            // 
            // grpCliente
            // 
            this.LM830grpCliente.Controls.Add(this.LM830lblDni);
            this.LM830grpCliente.Controls.Add(this.LM830txtDni);
            this.LM830grpCliente.Controls.Add(this.LM830btnBuscarCliente);
            this.LM830grpCliente.Controls.Add(this.LM830lblCliente);
            this.LM830grpCliente.Controls.Add(this.LM830lblSaldoTitulo);
            this.LM830grpCliente.Controls.Add(this.LM830lblSaldo);
            this.LM830grpCliente.Controls.Add(this.LM830lblComprometidosTitulo);
            this.LM830grpCliente.Controls.Add(this.LM830lblComprometidos);
            this.LM830grpCliente.Controls.Add(this.LM830lblDisponibleTitulo);
            this.LM830grpCliente.Controls.Add(this.LM830lblDisponible);
            this.LM830grpCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830grpCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830grpCliente.Location = new System.Drawing.Point(20, 60);
            this.LM830grpCliente.Name = "LM830grpCliente";
            this.LM830grpCliente.Size = new System.Drawing.Size(740, 100);
            this.LM830grpCliente.TabIndex = 2;
            this.LM830grpCliente.Text = "Cliente";
            // 
            // lblDni
            // 
            this.LM830lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblDni.Location = new System.Drawing.Point(15, 30);
            this.LM830lblDni.Name = "LM830lblDni";
            this.LM830lblDni.Size = new System.Drawing.Size(40, 20);
            this.LM830lblDni.TabIndex = 3;
            this.LM830lblDni.Text = "DNI";
            // 
            // txtDni
            // 
            this.LM830txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtDni.MaxLength = 8;
            this.LM830txtDni.Location = new System.Drawing.Point(60, 27);
            this.LM830txtDni.Name = "LM830txtDni";
            this.LM830txtDni.Size = new System.Drawing.Size(130, 22);
            this.LM830txtDni.TabIndex = 4;
            // 
            // btnBuscarCliente
            // 
            this.LM830btnBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnBuscarCliente.UseVisualStyleBackColor = false;
            this.LM830btnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnBuscarCliente.ForeColor = System.Drawing.Color.White;
            this.LM830btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.LM830btnBuscarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnBuscarCliente.Location = new System.Drawing.Point(200, 23);
            this.LM830btnBuscarCliente.Name = "LM830btnBuscarCliente";
            this.LM830btnBuscarCliente.Size = new System.Drawing.Size(120, 30);
            this.LM830btnBuscarCliente.TabIndex = 5;
            this.LM830btnBuscarCliente.Text = "Buscar cliente";
            this.LM830btnBuscarCliente.Click += new System.EventHandler(this.LM830btnBuscarCliente_Click);
            // 
            // lblCliente
            // 
            this.LM830lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblCliente.Location = new System.Drawing.Point(335, 30);
            this.LM830lblCliente.Name = "LM830lblCliente";
            this.LM830lblCliente.Size = new System.Drawing.Size(390, 20);
            this.LM830lblCliente.TabIndex = 6;
            this.LM830lblCliente.Text = "-";
            // 
            // lblSaldoTitulo
            // 
            this.LM830lblSaldoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblSaldoTitulo.Location = new System.Drawing.Point(15, 65);
            this.LM830lblSaldoTitulo.Name = "LM830lblSaldoTitulo";
            this.LM830lblSaldoTitulo.Size = new System.Drawing.Size(100, 20);
            this.LM830lblSaldoTitulo.TabIndex = 7;
            this.LM830lblSaldoTitulo.Text = "Saldo vigente:";
            // 
            // lblSaldo
            // 
            this.LM830lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblSaldo.Location = new System.Drawing.Point(120, 65);
            this.LM830lblSaldo.Name = "LM830lblSaldo";
            this.LM830lblSaldo.Size = new System.Drawing.Size(110, 20);
            this.LM830lblSaldo.TabIndex = 8;
            this.LM830lblSaldo.Text = "-";
            // 
            // lblComprometidosTitulo
            // 
            this.LM830lblComprometidosTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblComprometidosTitulo.Location = new System.Drawing.Point(240, 65);
            this.LM830lblComprometidosTitulo.Name = "LM830lblComprometidosTitulo";
            this.LM830lblComprometidosTitulo.Size = new System.Drawing.Size(120, 20);
            this.LM830lblComprometidosTitulo.TabIndex = 9;
            this.LM830lblComprometidosTitulo.Text = "Comprometidos:";
            // 
            // lblComprometidos
            // 
            this.LM830lblComprometidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblComprometidos.Location = new System.Drawing.Point(365, 65);
            this.LM830lblComprometidos.Name = "LM830lblComprometidos";
            this.LM830lblComprometidos.Size = new System.Drawing.Size(110, 20);
            this.LM830lblComprometidos.TabIndex = 10;
            this.LM830lblComprometidos.Text = "-";
            // 
            // lblDisponibleTitulo
            // 
            this.LM830lblDisponibleTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblDisponibleTitulo.Location = new System.Drawing.Point(485, 65);
            this.LM830lblDisponibleTitulo.Name = "LM830lblDisponibleTitulo";
            this.LM830lblDisponibleTitulo.Size = new System.Drawing.Size(90, 20);
            this.LM830lblDisponibleTitulo.TabIndex = 11;
            this.LM830lblDisponibleTitulo.Text = "Disponible:";
            // 
            // lblDisponible
            // 
            this.LM830lblDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblDisponible.Location = new System.Drawing.Point(580, 65);
            this.LM830lblDisponible.Name = "LM830lblDisponible";
            this.LM830lblDisponible.Size = new System.Drawing.Size(140, 20);
            this.LM830lblDisponible.TabIndex = 12;
            this.LM830lblDisponible.Text = "-";
            // 
            // lblPremios
            // 
            this.LM830lblPremios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblPremios.Location = new System.Drawing.Point(20, 170);
            this.LM830lblPremios.Name = "LM830lblPremios";
            this.LM830lblPremios.Size = new System.Drawing.Size(500, 20);
            this.LM830lblPremios.TabIndex = 13;
            this.LM830lblPremios.Text = "Premios que puede canjear";
            // 
            // dgvPremios
            // 
            this.LM830dgvPremios.AllowUserToAddRows = false;
            this.LM830dgvPremios.AllowUserToDeleteRows = false;
            this.LM830dgvPremios.ReadOnly = true;
            this.LM830dgvPremios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LM830dgvPremios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LM830dgvPremios.MultiSelect = false;
            this.LM830dgvPremios.RowHeadersVisible = false;
            this.LM830dgvPremios.BackgroundColor = System.Drawing.Color.White;
            this.LM830dgvPremios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LM830dgvPremios.EnableHeadersVisualStyles = false;
            this.LM830dgvPremios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.LM830dgvPremios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LM830dgvPremios.Location = new System.Drawing.Point(20, 195);
            this.LM830dgvPremios.Name = "LM830dgvPremios";
            this.LM830dgvPremios.Size = new System.Drawing.Size(740, 310);
            this.LM830dgvPremios.TabIndex = 14;
            // 
            // lblUmbral
            // 
            this.LM830lblUmbral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblUmbral.ForeColor = System.Drawing.Color.DimGray;
            this.LM830lblUmbral.Location = new System.Drawing.Point(20, 512);
            this.LM830lblUmbral.Name = "LM830lblUmbral";
            this.LM830lblUmbral.Size = new System.Drawing.Size(740, 36);
            this.LM830lblUmbral.TabIndex = 15;
            this.LM830lblUmbral.Text = "";
            // 
            // btnRegistrarCanje
            // 
            this.LM830btnRegistrarCanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnRegistrarCanje.UseVisualStyleBackColor = false;
            this.LM830btnRegistrarCanje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnRegistrarCanje.ForeColor = System.Drawing.Color.White;
            this.LM830btnRegistrarCanje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnRegistrarCanje.FlatAppearance.BorderSize = 0;
            this.LM830btnRegistrarCanje.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnRegistrarCanje.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnRegistrarCanje.Location = new System.Drawing.Point(490, 565);
            this.LM830btnRegistrarCanje.Name = "LM830btnRegistrarCanje";
            this.LM830btnRegistrarCanje.Size = new System.Drawing.Size(160, 30);
            this.LM830btnRegistrarCanje.TabIndex = 16;
            this.LM830btnRegistrarCanje.Text = "Registrar canje";
            this.LM830btnRegistrarCanje.Click += new System.EventHandler(this.LM830btnRegistrarCanje_Click);
            // 
            // btnVolver
            // 
            this.LM830btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnVolver.UseVisualStyleBackColor = true;
            this.LM830btnVolver.Location = new System.Drawing.Point(660, 565);
            this.LM830btnVolver.Name = "LM830btnVolver";
            this.LM830btnVolver.Size = new System.Drawing.Size(100, 30);
            this.LM830btnVolver.TabIndex = 17;
            this.LM830btnVolver.Text = "Volver";
            this.LM830btnVolver.Click += new System.EventHandler(this.LM830btnVolver_Click);
            // 
            // frmPremios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 620);
            this.Controls.Add(this.LM830pnlTitulo);
            this.Controls.Add(this.LM830grpCliente);
            this.Controls.Add(this.LM830lblPremios);
            this.Controls.Add(this.LM830dgvPremios);
            this.Controls.Add(this.LM830lblUmbral);
            this.Controls.Add(this.LM830btnRegistrarCanje);
            this.Controls.Add(this.LM830btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LM830frmPremios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Premios canjeables";
            this.Load += new System.EventHandler(this.LM830frmPremios_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LM830frmPremios_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvPremios)).EndInit();
            this.LM830pnlTitulo.ResumeLayout(false);
            this.LM830pnlTitulo.PerformLayout();
            this.LM830grpCliente.ResumeLayout(false);
            this.LM830grpCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LM830pnlTitulo;
        private System.Windows.Forms.Label LM830lblTitulo;
        private System.Windows.Forms.GroupBox LM830grpCliente;
        private System.Windows.Forms.Label LM830lblDni;
        private System.Windows.Forms.TextBox LM830txtDni;
        private System.Windows.Forms.Button LM830btnBuscarCliente;
        private System.Windows.Forms.Label LM830lblCliente;
        private System.Windows.Forms.Label LM830lblSaldoTitulo;
        private System.Windows.Forms.Label LM830lblSaldo;
        private System.Windows.Forms.Label LM830lblComprometidosTitulo;
        private System.Windows.Forms.Label LM830lblComprometidos;
        private System.Windows.Forms.Label LM830lblDisponibleTitulo;
        private System.Windows.Forms.Label LM830lblDisponible;
        private System.Windows.Forms.Label LM830lblPremios;
        private System.Windows.Forms.DataGridView LM830dgvPremios;
        private System.Windows.Forms.Label LM830lblUmbral;
        private System.Windows.Forms.Button LM830btnRegistrarCanje;
        private System.Windows.Forms.Button LM830btnVolver;
    }
}
