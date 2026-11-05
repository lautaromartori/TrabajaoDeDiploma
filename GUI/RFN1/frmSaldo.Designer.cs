namespace LM830GUI.LM830RFN1
{
    partial class LM830frmSaldo
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
            this.LM830lblDni = new System.Windows.Forms.Label();
            this.LM830txtDni = new System.Windows.Forms.TextBox();
            this.LM830btnBuscar = new System.Windows.Forms.Button();
            this.LM830grpCliente = new System.Windows.Forms.GroupBox();
            this.LM830lblClienteDatos = new System.Windows.Forms.Label();
            this.LM830lblNivelTitulo = new System.Windows.Forms.Label();
            this.LM830lblNivel = new System.Windows.Forms.Label();
            this.LM830lblSaldoTitulo = new System.Windows.Forms.Label();
            this.LM830lblSaldo = new System.Windows.Forms.Label();
            this.LM830lblLotes = new System.Windows.Forms.Label();
            this.LM830dgvLotes = new System.Windows.Forms.DataGridView();
            this.LM830btnVolver = new System.Windows.Forms.Button();
            this.LM830pnlTitulo.SuspendLayout();
            this.LM830grpCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvLotes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.LM830pnlTitulo.Controls.Add(this.LM830lblTitulo);
            this.LM830pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LM830pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.LM830pnlTitulo.Name = "LM830pnlTitulo";
            this.LM830pnlTitulo.Size = new System.Drawing.Size(640, 45);
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
            this.LM830lblTitulo.Text = "Consultar saldo";
            // 
            // lblDni
            // 
            this.LM830lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblDni.Location = new System.Drawing.Point(30, 70);
            this.LM830lblDni.Name = "LM830lblDni";
            this.LM830lblDni.Size = new System.Drawing.Size(60, 20);
            this.LM830lblDni.TabIndex = 2;
            this.LM830lblDni.Text = "DNI";
            // 
            // txtDni
            // 
            this.LM830txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtDni.MaxLength = 8;
            this.LM830txtDni.Location = new System.Drawing.Point(95, 68);
            this.LM830txtDni.Name = "LM830txtDni";
            this.LM830txtDni.Size = new System.Drawing.Size(180, 22);
            this.LM830txtDni.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.LM830btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnBuscar.UseVisualStyleBackColor = false;
            this.LM830btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnBuscar.ForeColor = System.Drawing.Color.White;
            this.LM830btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnBuscar.FlatAppearance.BorderSize = 0;
            this.LM830btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnBuscar.Location = new System.Drawing.Point(290, 64);
            this.LM830btnBuscar.Name = "LM830btnBuscar";
            this.LM830btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.LM830btnBuscar.TabIndex = 4;
            this.LM830btnBuscar.Text = "Buscar";
            this.LM830btnBuscar.Click += new System.EventHandler(this.LM830btnBuscar_Click);
            // 
            // grpCliente
            // 
            this.LM830grpCliente.Controls.Add(this.LM830lblClienteDatos);
            this.LM830grpCliente.Controls.Add(this.LM830lblNivelTitulo);
            this.LM830grpCliente.Controls.Add(this.LM830lblNivel);
            this.LM830grpCliente.Controls.Add(this.LM830lblSaldoTitulo);
            this.LM830grpCliente.Controls.Add(this.LM830lblSaldo);
            this.LM830grpCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830grpCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830grpCliente.Location = new System.Drawing.Point(30, 110);
            this.LM830grpCliente.Name = "LM830grpCliente";
            this.LM830grpCliente.Size = new System.Drawing.Size(580, 95);
            this.LM830grpCliente.TabIndex = 5;
            this.LM830grpCliente.Text = "Cliente";
            // 
            // lblClienteDatos
            // 
            this.LM830lblClienteDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblClienteDatos.Location = new System.Drawing.Point(15, 25);
            this.LM830lblClienteDatos.Name = "LM830lblClienteDatos";
            this.LM830lblClienteDatos.Size = new System.Drawing.Size(550, 20);
            this.LM830lblClienteDatos.TabIndex = 6;
            this.LM830lblClienteDatos.Text = "-";
            // 
            // lblNivelTitulo
            // 
            this.LM830lblNivelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblNivelTitulo.Location = new System.Drawing.Point(15, 55);
            this.LM830lblNivelTitulo.Name = "LM830lblNivelTitulo";
            this.LM830lblNivelTitulo.Size = new System.Drawing.Size(60, 20);
            this.LM830lblNivelTitulo.TabIndex = 7;
            this.LM830lblNivelTitulo.Text = "Nivel:";
            // 
            // lblNivel
            // 
            this.LM830lblNivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblNivel.Location = new System.Drawing.Point(80, 55);
            this.LM830lblNivel.Name = "LM830lblNivel";
            this.LM830lblNivel.Size = new System.Drawing.Size(150, 20);
            this.LM830lblNivel.TabIndex = 8;
            this.LM830lblNivel.Text = "-";
            // 
            // lblSaldoTitulo
            // 
            this.LM830lblSaldoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblSaldoTitulo.Location = new System.Drawing.Point(260, 55);
            this.LM830lblSaldoTitulo.Name = "LM830lblSaldoTitulo";
            this.LM830lblSaldoTitulo.Size = new System.Drawing.Size(110, 20);
            this.LM830lblSaldoTitulo.TabIndex = 9;
            this.LM830lblSaldoTitulo.Text = "Saldo vigente:";
            // 
            // lblSaldo
            // 
            this.LM830lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblSaldo.Location = new System.Drawing.Point(375, 55);
            this.LM830lblSaldo.Name = "LM830lblSaldo";
            this.LM830lblSaldo.Size = new System.Drawing.Size(150, 20);
            this.LM830lblSaldo.TabIndex = 10;
            this.LM830lblSaldo.Text = "-";
            // 
            // lblLotes
            // 
            this.LM830lblLotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblLotes.Location = new System.Drawing.Point(30, 215);
            this.LM830lblLotes.Name = "LM830lblLotes";
            this.LM830lblLotes.Size = new System.Drawing.Size(400, 20);
            this.LM830lblLotes.TabIndex = 11;
            this.LM830lblLotes.Text = "Puntos por vencer";
            // 
            // dgvLotes
            // 
            this.LM830dgvLotes.AllowUserToAddRows = false;
            this.LM830dgvLotes.AllowUserToDeleteRows = false;
            this.LM830dgvLotes.ReadOnly = true;
            this.LM830dgvLotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LM830dgvLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LM830dgvLotes.MultiSelect = false;
            this.LM830dgvLotes.RowHeadersVisible = false;
            this.LM830dgvLotes.BackgroundColor = System.Drawing.Color.White;
            this.LM830dgvLotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LM830dgvLotes.EnableHeadersVisualStyles = false;
            this.LM830dgvLotes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.LM830dgvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LM830dgvLotes.Location = new System.Drawing.Point(30, 240);
            this.LM830dgvLotes.Name = "LM830dgvLotes";
            this.LM830dgvLotes.Size = new System.Drawing.Size(580, 210);
            this.LM830dgvLotes.TabIndex = 12;
            // 
            // btnVolver
            // 
            this.LM830btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnVolver.UseVisualStyleBackColor = true;
            this.LM830btnVolver.Location = new System.Drawing.Point(500, 465);
            this.LM830btnVolver.Name = "LM830btnVolver";
            this.LM830btnVolver.Size = new System.Drawing.Size(110, 30);
            this.LM830btnVolver.TabIndex = 13;
            this.LM830btnVolver.Text = "Volver";
            this.LM830btnVolver.Click += new System.EventHandler(this.LM830btnVolver_Click);
            // 
            // frmSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(640, 520);
            this.Controls.Add(this.LM830pnlTitulo);
            this.Controls.Add(this.LM830lblDni);
            this.Controls.Add(this.LM830txtDni);
            this.Controls.Add(this.LM830btnBuscar);
            this.Controls.Add(this.LM830grpCliente);
            this.Controls.Add(this.LM830lblLotes);
            this.Controls.Add(this.LM830dgvLotes);
            this.Controls.Add(this.LM830btnVolver);
            this.AcceptButton = this.LM830btnBuscar;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LM830frmSaldo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar saldo";
            this.Load += new System.EventHandler(this.LM830frmSaldo_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LM830frmSaldo_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvLotes)).EndInit();
            this.LM830pnlTitulo.ResumeLayout(false);
            this.LM830pnlTitulo.PerformLayout();
            this.LM830grpCliente.ResumeLayout(false);
            this.LM830grpCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LM830pnlTitulo;
        private System.Windows.Forms.Label LM830lblTitulo;
        private System.Windows.Forms.Label LM830lblDni;
        private System.Windows.Forms.TextBox LM830txtDni;
        private System.Windows.Forms.Button LM830btnBuscar;
        private System.Windows.Forms.GroupBox LM830grpCliente;
        private System.Windows.Forms.Label LM830lblClienteDatos;
        private System.Windows.Forms.Label LM830lblNivelTitulo;
        private System.Windows.Forms.Label LM830lblNivel;
        private System.Windows.Forms.Label LM830lblSaldoTitulo;
        private System.Windows.Forms.Label LM830lblSaldo;
        private System.Windows.Forms.Label LM830lblLotes;
        private System.Windows.Forms.DataGridView LM830dgvLotes;
        private System.Windows.Forms.Button LM830btnVolver;
    }
}
