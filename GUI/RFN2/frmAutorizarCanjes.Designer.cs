namespace GUI.RFN2
{
    partial class frmAutorizarCanjes
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
            this.lblPendientes = new System.Windows.Forms.Label();
            this.dgvPendientes = new System.Windows.Forms.DataGridView();
            this.grpDetalle = new System.Windows.Forms.GroupBox();
            this.lblClienteDatos = new System.Windows.Forms.Label();
            this.lblPremioDatos = new System.Windows.Forms.Label();
            this.lblSaldoDatos = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnAutorizar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pnlTitulo.SuspendLayout();
            this.grpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(860, 45);
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
            this.lblTitulo.Text = "Autorizar canjes";
            // 
            // lblPendientes
            // 
            this.lblPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendientes.Location = new System.Drawing.Point(20, 60);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(400, 20);
            this.lblPendientes.TabIndex = 2;
            this.lblPendientes.Text = "Canjes pendientes de autorización";
            // 
            // dgvPendientes
            // 
            this.dgvPendientes.AllowUserToAddRows = false;
            this.dgvPendientes.AllowUserToDeleteRows = false;
            this.dgvPendientes.ReadOnly = true;
            this.dgvPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendientes.MultiSelect = false;
            this.dgvPendientes.RowHeadersVisible = false;
            this.dgvPendientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPendientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvPendientes.EnableHeadersVisualStyles = false;
            this.dgvPendientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendientes.Location = new System.Drawing.Point(20, 85);
            this.dgvPendientes.Name = "dgvPendientes";
            this.dgvPendientes.Size = new System.Drawing.Size(820, 220);
            this.dgvPendientes.TabIndex = 3;
            this.dgvPendientes.SelectionChanged += new System.EventHandler(this.dgvPendientes_SelectionChanged);
            // 
            // grpDetalle
            // 
            this.grpDetalle.Controls.Add(this.lblClienteDatos);
            this.grpDetalle.Controls.Add(this.lblPremioDatos);
            this.grpDetalle.Controls.Add(this.lblSaldoDatos);
            this.grpDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.grpDetalle.Location = new System.Drawing.Point(20, 315);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Size = new System.Drawing.Size(820, 115);
            this.grpDetalle.TabIndex = 4;
            this.grpDetalle.Text = "Detalle";
            // 
            // lblClienteDatos
            // 
            this.lblClienteDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteDatos.Location = new System.Drawing.Point(15, 25);
            this.lblClienteDatos.Name = "lblClienteDatos";
            this.lblClienteDatos.Size = new System.Drawing.Size(790, 20);
            this.lblClienteDatos.TabIndex = 5;
            this.lblClienteDatos.Text = "-";
            // 
            // lblPremioDatos
            // 
            this.lblPremioDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPremioDatos.Location = new System.Drawing.Point(15, 55);
            this.lblPremioDatos.Name = "lblPremioDatos";
            this.lblPremioDatos.Size = new System.Drawing.Size(790, 20);
            this.lblPremioDatos.TabIndex = 6;
            this.lblPremioDatos.Text = "-";
            // 
            // lblSaldoDatos
            // 
            this.lblSaldoDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoDatos.Location = new System.Drawing.Point(15, 85);
            this.lblSaldoDatos.Name = "lblSaldoDatos";
            this.lblSaldoDatos.Size = new System.Drawing.Size(790, 20);
            this.lblSaldoDatos.TabIndex = 7;
            this.lblSaldoDatos.Text = "-";
            // 
            // lblMotivo
            // 
            this.lblMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.Location = new System.Drawing.Point(20, 440);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(500, 20);
            this.lblMotivo.TabIndex = 8;
            this.lblMotivo.Text = "Motivo (obligatorio para rechazar)";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.Multiline = true;
            this.txtMotivo.MaxLength = 200;
            this.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivo.Location = new System.Drawing.Point(20, 465);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(820, 70);
            this.txtMotivo.TabIndex = 9;
            // 
            // btnAutorizar
            // 
            this.btnAutorizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutorizar.UseVisualStyleBackColor = false;
            this.btnAutorizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnAutorizar.ForeColor = System.Drawing.Color.White;
            this.btnAutorizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutorizar.FlatAppearance.BorderSize = 0;
            this.btnAutorizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnAutorizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutorizar.Location = new System.Drawing.Point(480, 565);
            this.btnAutorizar.Name = "btnAutorizar";
            this.btnAutorizar.Size = new System.Drawing.Size(115, 30);
            this.btnAutorizar.TabIndex = 10;
            this.btnAutorizar.Text = "Autorizar";
            this.btnAutorizar.Click += new System.EventHandler(this.btnAutorizar_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Location = new System.Drawing.Point(605, 565);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(115, 30);
            this.btnRechazar.TabIndex = 11;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Location = new System.Drawing.Point(730, 565);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(110, 30);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmAutorizarCanjes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 620);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblPendientes);
            this.Controls.Add(this.dgvPendientes);
            this.Controls.Add(this.grpDetalle);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.btnAutorizar);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAutorizarCanjes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorizar canjes";
            this.Load += new System.EventHandler(this.frmAutorizarCanjes_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAutorizarCanjes_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpDetalle.ResumeLayout(false);
            this.grpDetalle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.DataGridView dgvPendientes;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.Label lblClienteDatos;
        private System.Windows.Forms.Label lblPremioDatos;
        private System.Windows.Forms.Label lblSaldoDatos;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnAutorizar;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Button btnVolver;
    }
}
