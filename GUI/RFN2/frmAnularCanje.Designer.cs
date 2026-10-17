namespace GUI.RFN2
{
    partial class frmAnularCanje
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
            this.lblNro = new System.Windows.Forms.Label();
            this.txtNroCanje = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.grpCanje = new System.Windows.Forms.GroupBox();
            this.lblClienteDatos = new System.Windows.Forms.Label();
            this.lblPremioDatos = new System.Windows.Forms.Label();
            this.lblEntregaDatos = new System.Windows.Forms.Label();
            this.lblEstadoDatos = new System.Windows.Forms.Label();
            this.lblLotes = new System.Windows.Forms.Label();
            this.dgvLotes = new System.Windows.Forms.DataGridView();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pnlTitulo.SuspendLayout();
            this.grpCanje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).BeginInit();
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
            this.lblTitulo.Text = "Anular canje";
            // 
            // lblNro
            // 
            this.lblNro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNro.Location = new System.Drawing.Point(20, 66);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(100, 20);
            this.lblNro.TabIndex = 2;
            this.lblNro.Text = "Nro. de canje";
            // 
            // txtNroCanje
            // 
            this.txtNroCanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroCanje.MaxLength = 20;
            this.txtNroCanje.Location = new System.Drawing.Point(125, 63);
            this.txtNroCanje.Name = "txtNroCanje";
            this.txtNroCanje.Size = new System.Drawing.Size(160, 22);
            this.txtNroCanje.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Location = new System.Drawing.Point(295, 59);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // grpCanje
            // 
            this.grpCanje.Controls.Add(this.lblClienteDatos);
            this.grpCanje.Controls.Add(this.lblPremioDatos);
            this.grpCanje.Controls.Add(this.lblEntregaDatos);
            this.grpCanje.Controls.Add(this.lblEstadoDatos);
            this.grpCanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCanje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.grpCanje.Location = new System.Drawing.Point(20, 100);
            this.grpCanje.Name = "grpCanje";
            this.grpCanje.Size = new System.Drawing.Size(740, 140);
            this.grpCanje.TabIndex = 5;
            this.grpCanje.Text = "Canje";
            // 
            // lblClienteDatos
            // 
            this.lblClienteDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteDatos.Location = new System.Drawing.Point(15, 25);
            this.lblClienteDatos.Name = "lblClienteDatos";
            this.lblClienteDatos.Size = new System.Drawing.Size(710, 20);
            this.lblClienteDatos.TabIndex = 6;
            this.lblClienteDatos.Text = "-";
            // 
            // lblPremioDatos
            // 
            this.lblPremioDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPremioDatos.Location = new System.Drawing.Point(15, 52);
            this.lblPremioDatos.Name = "lblPremioDatos";
            this.lblPremioDatos.Size = new System.Drawing.Size(710, 20);
            this.lblPremioDatos.TabIndex = 7;
            this.lblPremioDatos.Text = "-";
            // 
            // lblEntregaDatos
            // 
            this.lblEntregaDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntregaDatos.Location = new System.Drawing.Point(15, 79);
            this.lblEntregaDatos.Name = "lblEntregaDatos";
            this.lblEntregaDatos.Size = new System.Drawing.Size(710, 20);
            this.lblEntregaDatos.TabIndex = 8;
            this.lblEntregaDatos.Text = "-";
            // 
            // lblEstadoDatos
            // 
            this.lblEstadoDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoDatos.Location = new System.Drawing.Point(15, 106);
            this.lblEstadoDatos.Name = "lblEstadoDatos";
            this.lblEstadoDatos.Size = new System.Drawing.Size(710, 20);
            this.lblEstadoDatos.TabIndex = 9;
            this.lblEstadoDatos.Text = "-";
            // 
            // lblLotes
            // 
            this.lblLotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotes.Location = new System.Drawing.Point(20, 250);
            this.lblLotes.Name = "lblLotes";
            this.lblLotes.Size = new System.Drawing.Size(500, 20);
            this.lblLotes.TabIndex = 10;
            this.lblLotes.Text = "Puntos descontados por vencimiento";
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
            this.dgvLotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvLotes.EnableHeadersVisualStyles = false;
            this.dgvLotes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.dgvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotes.Location = new System.Drawing.Point(20, 275);
            this.dgvLotes.Name = "dgvLotes";
            this.dgvLotes.Size = new System.Drawing.Size(740, 140);
            this.dgvLotes.TabIndex = 11;
            // 
            // lblMotivo
            // 
            this.lblMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.Location = new System.Drawing.Point(20, 425);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(500, 20);
            this.lblMotivo.TabIndex = 12;
            this.lblMotivo.Text = "Motivo de la anulación";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.Multiline = true;
            this.txtMotivo.MaxLength = 200;
            this.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivo.Location = new System.Drawing.Point(20, 450);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(740, 80);
            this.txtMotivo.TabIndex = 13;
            // 
            // btnAnular
            // 
            this.btnAnular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.UseVisualStyleBackColor = false;
            this.btnAnular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnAnular.ForeColor = System.Drawing.Color.White;
            this.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnular.Location = new System.Drawing.Point(490, 595);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(150, 30);
            this.btnAnular.TabIndex = 14;
            this.btnAnular.Text = "Anular canje";
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Location = new System.Drawing.Point(650, 595);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(110, 30);
            this.btnVolver.TabIndex = 15;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmAnularCanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 650);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblNro);
            this.Controls.Add(this.txtNroCanje);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.grpCanje);
            this.Controls.Add(this.lblLotes);
            this.Controls.Add(this.dgvLotes);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btnVolver);
            this.AcceptButton = this.btnBuscar;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAnularCanje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anular canje";
            this.Load += new System.EventHandler(this.frmAnularCanje_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAnularCanje_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpCanje.ResumeLayout(false);
            this.grpCanje.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNro;
        private System.Windows.Forms.TextBox txtNroCanje;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox grpCanje;
        private System.Windows.Forms.Label lblClienteDatos;
        private System.Windows.Forms.Label lblPremioDatos;
        private System.Windows.Forms.Label lblEntregaDatos;
        private System.Windows.Forms.Label lblEstadoDatos;
        private System.Windows.Forms.Label lblLotes;
        private System.Windows.Forms.DataGridView dgvLotes;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Button btnVolver;
    }
}
