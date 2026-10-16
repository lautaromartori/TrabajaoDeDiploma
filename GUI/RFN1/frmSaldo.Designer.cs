namespace GUI.RFN1
{
    partial class frmSaldo
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
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.lblClienteDatos = new System.Windows.Forms.Label();
            this.lblNivelTitulo = new System.Windows.Forms.Label();
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblSaldoTitulo = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblLotes = new System.Windows.Forms.Label();
            this.dgvLotes = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pnlTitulo.SuspendLayout();
            this.grpCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.BackColor = System.Drawing.Color.Maroon;
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(640, 45);
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
            this.lblTitulo.Text = "Consultar saldo";
            // 
            // lblDni
            // 
            this.lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDni.Location = new System.Drawing.Point(30, 70);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(60, 20);
            this.lblDni.TabIndex = 2;
            this.lblDni.Text = "DNI";
            // 
            // txtDni
            // 
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDni.MaxLength = 8;
            this.txtDni.Location = new System.Drawing.Point(95, 68);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(180, 22);
            this.txtDni.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.BackColor = System.Drawing.Color.Maroon;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(290, 64);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // grpCliente
            // 
            this.grpCliente.Controls.Add(this.lblClienteDatos);
            this.grpCliente.Controls.Add(this.lblNivelTitulo);
            this.grpCliente.Controls.Add(this.lblNivel);
            this.grpCliente.Controls.Add(this.lblSaldoTitulo);
            this.grpCliente.Controls.Add(this.lblSaldo);
            this.grpCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.grpCliente.Location = new System.Drawing.Point(30, 110);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(580, 95);
            this.grpCliente.TabIndex = 5;
            this.grpCliente.Text = "Cliente";
            // 
            // lblClienteDatos
            // 
            this.lblClienteDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteDatos.Location = new System.Drawing.Point(15, 25);
            this.lblClienteDatos.Name = "lblClienteDatos";
            this.lblClienteDatos.Size = new System.Drawing.Size(550, 20);
            this.lblClienteDatos.TabIndex = 6;
            this.lblClienteDatos.Text = "-";
            // 
            // lblNivelTitulo
            // 
            this.lblNivelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivelTitulo.Location = new System.Drawing.Point(15, 55);
            this.lblNivelTitulo.Name = "lblNivelTitulo";
            this.lblNivelTitulo.Size = new System.Drawing.Size(60, 20);
            this.lblNivelTitulo.TabIndex = 7;
            this.lblNivelTitulo.Text = "Nivel:";
            // 
            // lblNivel
            // 
            this.lblNivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivel.Location = new System.Drawing.Point(80, 55);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(150, 20);
            this.lblNivel.TabIndex = 8;
            this.lblNivel.Text = "-";
            // 
            // lblSaldoTitulo
            // 
            this.lblSaldoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoTitulo.Location = new System.Drawing.Point(260, 55);
            this.lblSaldoTitulo.Name = "lblSaldoTitulo";
            this.lblSaldoTitulo.Size = new System.Drawing.Size(110, 20);
            this.lblSaldoTitulo.TabIndex = 9;
            this.lblSaldoTitulo.Text = "Saldo vigente:";
            // 
            // lblSaldo
            // 
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(375, 55);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(150, 20);
            this.lblSaldo.TabIndex = 10;
            this.lblSaldo.Text = "-";
            // 
            // lblLotes
            // 
            this.lblLotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotes.Location = new System.Drawing.Point(30, 215);
            this.lblLotes.Name = "lblLotes";
            this.lblLotes.Size = new System.Drawing.Size(400, 20);
            this.lblLotes.TabIndex = 11;
            this.lblLotes.Text = "Puntos por vencer";
            // 
            // dgvLotes
            // 
            this.dgvLotes.AllowUserToAddRows = false;
            this.dgvLotes.AllowUserToDeleteRows = false;
            this.dgvLotes.ReadOnly = true;
            this.dgvLotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLotes.MultiSelect = false;
            this.dgvLotes.RowHeadersVisible = false;
            this.dgvLotes.BackgroundColor = System.Drawing.Color.White;
            this.dgvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotes.Location = new System.Drawing.Point(30, 240);
            this.dgvLotes.Name = "dgvLotes";
            this.dgvLotes.Size = new System.Drawing.Size(580, 210);
            this.dgvLotes.TabIndex = 12;
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Location = new System.Drawing.Point(500, 465);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(110, 30);
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(640, 520);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.grpCliente);
            this.Controls.Add(this.lblLotes);
            this.Controls.Add(this.dgvLotes);
            this.Controls.Add(this.btnVolver);
            this.AcceptButton = this.btnBuscar;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSaldo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar saldo";
            this.Load += new System.EventHandler(this.frmSaldo_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSaldo_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.Label lblClienteDatos;
        private System.Windows.Forms.Label lblNivelTitulo;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label lblSaldoTitulo;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblLotes;
        private System.Windows.Forms.DataGridView dgvLotes;
        private System.Windows.Forms.Button btnVolver;
    }
}
