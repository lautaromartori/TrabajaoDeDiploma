namespace LM830GUI.LM830RFN2
{
    partial class LM830frmAnularCanje
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
            this.LM830lblNro = new System.Windows.Forms.Label();
            this.LM830txtNroCanje = new System.Windows.Forms.TextBox();
            this.LM830btnBuscar = new System.Windows.Forms.Button();
            this.LM830grpCanje = new System.Windows.Forms.GroupBox();
            this.LM830lblClienteDatos = new System.Windows.Forms.Label();
            this.LM830lblPremioDatos = new System.Windows.Forms.Label();
            this.LM830lblEntregaDatos = new System.Windows.Forms.Label();
            this.LM830lblEstadoDatos = new System.Windows.Forms.Label();
            this.LM830lblLotes = new System.Windows.Forms.Label();
            this.LM830dgvLotes = new System.Windows.Forms.DataGridView();
            this.LM830lblMotivo = new System.Windows.Forms.Label();
            this.LM830txtMotivo = new System.Windows.Forms.TextBox();
            this.LM830btnAnular = new System.Windows.Forms.Button();
            this.LM830btnVolver = new System.Windows.Forms.Button();
            this.LM830pnlTitulo.SuspendLayout();
            this.LM830grpCanje.SuspendLayout();
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
            this.LM830lblTitulo.Text = "Anular canje";
            // 
            // lblNro
            // 
            this.LM830lblNro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblNro.Location = new System.Drawing.Point(20, 66);
            this.LM830lblNro.Name = "LM830lblNro";
            this.LM830lblNro.Size = new System.Drawing.Size(100, 20);
            this.LM830lblNro.TabIndex = 2;
            this.LM830lblNro.Text = "Nro. de canje";
            // 
            // txtNroCanje
            // 
            this.LM830txtNroCanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtNroCanje.MaxLength = 20;
            this.LM830txtNroCanje.Location = new System.Drawing.Point(125, 63);
            this.LM830txtNroCanje.Name = "LM830txtNroCanje";
            this.LM830txtNroCanje.Size = new System.Drawing.Size(160, 22);
            this.LM830txtNroCanje.TabIndex = 3;
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
            this.LM830btnBuscar.Location = new System.Drawing.Point(295, 59);
            this.LM830btnBuscar.Name = "LM830btnBuscar";
            this.LM830btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.LM830btnBuscar.TabIndex = 4;
            this.LM830btnBuscar.Text = "Buscar";
            this.LM830btnBuscar.Click += new System.EventHandler(this.LM830btnBuscar_Click);
            // 
            // grpCanje
            // 
            this.LM830grpCanje.Controls.Add(this.LM830lblClienteDatos);
            this.LM830grpCanje.Controls.Add(this.LM830lblPremioDatos);
            this.LM830grpCanje.Controls.Add(this.LM830lblEntregaDatos);
            this.LM830grpCanje.Controls.Add(this.LM830lblEstadoDatos);
            this.LM830grpCanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830grpCanje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830grpCanje.Location = new System.Drawing.Point(20, 100);
            this.LM830grpCanje.Name = "LM830grpCanje";
            this.LM830grpCanje.Size = new System.Drawing.Size(740, 140);
            this.LM830grpCanje.TabIndex = 5;
            this.LM830grpCanje.Text = "Canje";
            // 
            // lblClienteDatos
            // 
            this.LM830lblClienteDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblClienteDatos.Location = new System.Drawing.Point(15, 25);
            this.LM830lblClienteDatos.Name = "LM830lblClienteDatos";
            this.LM830lblClienteDatos.Size = new System.Drawing.Size(710, 20);
            this.LM830lblClienteDatos.TabIndex = 6;
            this.LM830lblClienteDatos.Text = "-";
            // 
            // lblPremioDatos
            // 
            this.LM830lblPremioDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblPremioDatos.Location = new System.Drawing.Point(15, 52);
            this.LM830lblPremioDatos.Name = "LM830lblPremioDatos";
            this.LM830lblPremioDatos.Size = new System.Drawing.Size(710, 20);
            this.LM830lblPremioDatos.TabIndex = 7;
            this.LM830lblPremioDatos.Text = "-";
            // 
            // lblEntregaDatos
            // 
            this.LM830lblEntregaDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblEntregaDatos.Location = new System.Drawing.Point(15, 79);
            this.LM830lblEntregaDatos.Name = "LM830lblEntregaDatos";
            this.LM830lblEntregaDatos.Size = new System.Drawing.Size(710, 20);
            this.LM830lblEntregaDatos.TabIndex = 8;
            this.LM830lblEntregaDatos.Text = "-";
            // 
            // lblEstadoDatos
            // 
            this.LM830lblEstadoDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblEstadoDatos.Location = new System.Drawing.Point(15, 106);
            this.LM830lblEstadoDatos.Name = "LM830lblEstadoDatos";
            this.LM830lblEstadoDatos.Size = new System.Drawing.Size(710, 20);
            this.LM830lblEstadoDatos.TabIndex = 9;
            this.LM830lblEstadoDatos.Text = "-";
            // 
            // lblLotes
            // 
            this.LM830lblLotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblLotes.Location = new System.Drawing.Point(20, 250);
            this.LM830lblLotes.Name = "LM830lblLotes";
            this.LM830lblLotes.Size = new System.Drawing.Size(500, 20);
            this.LM830lblLotes.TabIndex = 10;
            this.LM830lblLotes.Text = "Puntos descontados por vencimiento";
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
            this.LM830dgvLotes.Location = new System.Drawing.Point(20, 275);
            this.LM830dgvLotes.Name = "LM830dgvLotes";
            this.LM830dgvLotes.Size = new System.Drawing.Size(740, 140);
            this.LM830dgvLotes.TabIndex = 11;
            // 
            // lblMotivo
            // 
            this.LM830lblMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblMotivo.Location = new System.Drawing.Point(20, 425);
            this.LM830lblMotivo.Name = "LM830lblMotivo";
            this.LM830lblMotivo.Size = new System.Drawing.Size(500, 20);
            this.LM830lblMotivo.TabIndex = 12;
            this.LM830lblMotivo.Text = "Motivo de la anulación";
            // 
            // txtMotivo
            // 
            this.LM830txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtMotivo.Multiline = true;
            this.LM830txtMotivo.MaxLength = 200;
            this.LM830txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LM830txtMotivo.Location = new System.Drawing.Point(20, 450);
            this.LM830txtMotivo.Name = "LM830txtMotivo";
            this.LM830txtMotivo.Size = new System.Drawing.Size(740, 80);
            this.LM830txtMotivo.TabIndex = 13;
            // 
            // btnAnular
            // 
            this.LM830btnAnular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnAnular.UseVisualStyleBackColor = false;
            this.LM830btnAnular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnAnular.ForeColor = System.Drawing.Color.White;
            this.LM830btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnAnular.FlatAppearance.BorderSize = 0;
            this.LM830btnAnular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnAnular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnAnular.Location = new System.Drawing.Point(490, 595);
            this.LM830btnAnular.Name = "LM830btnAnular";
            this.LM830btnAnular.Size = new System.Drawing.Size(150, 30);
            this.LM830btnAnular.TabIndex = 14;
            this.LM830btnAnular.Text = "Anular canje";
            this.LM830btnAnular.Click += new System.EventHandler(this.LM830btnAnular_Click);
            // 
            // btnVolver
            // 
            this.LM830btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnVolver.UseVisualStyleBackColor = true;
            this.LM830btnVolver.Location = new System.Drawing.Point(650, 595);
            this.LM830btnVolver.Name = "LM830btnVolver";
            this.LM830btnVolver.Size = new System.Drawing.Size(110, 30);
            this.LM830btnVolver.TabIndex = 15;
            this.LM830btnVolver.Text = "Volver";
            this.LM830btnVolver.Click += new System.EventHandler(this.LM830btnVolver_Click);
            // 
            // frmAnularCanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 650);
            this.Controls.Add(this.LM830pnlTitulo);
            this.Controls.Add(this.LM830lblNro);
            this.Controls.Add(this.LM830txtNroCanje);
            this.Controls.Add(this.LM830btnBuscar);
            this.Controls.Add(this.LM830grpCanje);
            this.Controls.Add(this.LM830lblLotes);
            this.Controls.Add(this.LM830dgvLotes);
            this.Controls.Add(this.LM830lblMotivo);
            this.Controls.Add(this.LM830txtMotivo);
            this.Controls.Add(this.LM830btnAnular);
            this.Controls.Add(this.LM830btnVolver);
            this.AcceptButton = this.LM830btnBuscar;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LM830frmAnularCanje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anular canje";
            this.Load += new System.EventHandler(this.LM830frmAnularCanje_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LM830frmAnularCanje_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvLotes)).EndInit();
            this.LM830pnlTitulo.ResumeLayout(false);
            this.LM830pnlTitulo.PerformLayout();
            this.LM830grpCanje.ResumeLayout(false);
            this.LM830grpCanje.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LM830pnlTitulo;
        private System.Windows.Forms.Label LM830lblTitulo;
        private System.Windows.Forms.Label LM830lblNro;
        private System.Windows.Forms.TextBox LM830txtNroCanje;
        private System.Windows.Forms.Button LM830btnBuscar;
        private System.Windows.Forms.GroupBox LM830grpCanje;
        private System.Windows.Forms.Label LM830lblClienteDatos;
        private System.Windows.Forms.Label LM830lblPremioDatos;
        private System.Windows.Forms.Label LM830lblEntregaDatos;
        private System.Windows.Forms.Label LM830lblEstadoDatos;
        private System.Windows.Forms.Label LM830lblLotes;
        private System.Windows.Forms.DataGridView LM830dgvLotes;
        private System.Windows.Forms.Label LM830lblMotivo;
        private System.Windows.Forms.TextBox LM830txtMotivo;
        private System.Windows.Forms.Button LM830btnAnular;
        private System.Windows.Forms.Button LM830btnVolver;
    }
}
