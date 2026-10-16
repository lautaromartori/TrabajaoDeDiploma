namespace GUI.RFN1
{
    partial class frmResolverReclamos
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
            this.lblVentaDatos = new System.Windows.Forms.Label();
            this.lblClienteDatos = new System.Windows.Forms.Label();
            this.lblMotivoReclamo = new System.Windows.Forms.Label();
            this.lblMotivoResolucion = new System.Windows.Forms.Label();
            this.txtMotivoResolucion = new System.Windows.Forms.TextBox();
            this.btnAprobar = new System.Windows.Forms.Button();
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
            this.pnlTitulo.BackColor = System.Drawing.Color.Maroon;
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
            this.lblTitulo.Text = "Resolver reclamos";
            // 
            // lblPendientes
            // 
            this.lblPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendientes.Location = new System.Drawing.Point(20, 60);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(300, 20);
            this.lblPendientes.TabIndex = 2;
            this.lblPendientes.Text = "Reclamos pendientes";
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
            this.dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendientes.Location = new System.Drawing.Point(20, 85);
            this.dgvPendientes.Name = "dgvPendientes";
            this.dgvPendientes.Size = new System.Drawing.Size(820, 220);
            this.dgvPendientes.TabIndex = 3;
            this.dgvPendientes.SelectionChanged += new System.EventHandler(this.dgvPendientes_SelectionChanged);
            // 
            // grpDetalle
            // 
            this.grpDetalle.Controls.Add(this.lblVentaDatos);
            this.grpDetalle.Controls.Add(this.lblClienteDatos);
            this.grpDetalle.Controls.Add(this.lblMotivoReclamo);
            this.grpDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.grpDetalle.Location = new System.Drawing.Point(20, 315);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Size = new System.Drawing.Size(820, 130);
            this.grpDetalle.TabIndex = 4;
            this.grpDetalle.Text = "Detalle";
            // 
            // lblVentaDatos
            // 
            this.lblVentaDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentaDatos.Location = new System.Drawing.Point(15, 25);
            this.lblVentaDatos.Name = "lblVentaDatos";
            this.lblVentaDatos.Size = new System.Drawing.Size(790, 20);
            this.lblVentaDatos.TabIndex = 5;
            this.lblVentaDatos.Text = "-";
            // 
            // lblClienteDatos
            // 
            this.lblClienteDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteDatos.Location = new System.Drawing.Point(15, 55);
            this.lblClienteDatos.Name = "lblClienteDatos";
            this.lblClienteDatos.Size = new System.Drawing.Size(790, 20);
            this.lblClienteDatos.TabIndex = 6;
            this.lblClienteDatos.Text = "-";
            // 
            // lblMotivoReclamo
            // 
            this.lblMotivoReclamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivoReclamo.Location = new System.Drawing.Point(15, 85);
            this.lblMotivoReclamo.Name = "lblMotivoReclamo";
            this.lblMotivoReclamo.Size = new System.Drawing.Size(790, 20);
            this.lblMotivoReclamo.TabIndex = 7;
            this.lblMotivoReclamo.Text = "-";
            // 
            // lblMotivoResolucion
            // 
            this.lblMotivoResolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivoResolucion.Location = new System.Drawing.Point(20, 455);
            this.lblMotivoResolucion.Name = "lblMotivoResolucion";
            this.lblMotivoResolucion.Size = new System.Drawing.Size(400, 20);
            this.lblMotivoResolucion.TabIndex = 8;
            this.lblMotivoResolucion.Text = "Motivo de la resolución (obligatorio para rechazar)";
            // 
            // txtMotivoResolucion
            // 
            this.txtMotivoResolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivoResolucion.Multiline = true;
            this.txtMotivoResolucion.MaxLength = 200;
            this.txtMotivoResolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivoResolucion.Location = new System.Drawing.Point(20, 480);
            this.txtMotivoResolucion.Name = "txtMotivoResolucion";
            this.txtMotivoResolucion.Size = new System.Drawing.Size(820, 70);
            this.txtMotivoResolucion.TabIndex = 9;
            // 
            // btnAprobar
            // 
            this.btnAprobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAprobar.UseVisualStyleBackColor = false;
            this.btnAprobar.BackColor = System.Drawing.Color.Maroon;
            this.btnAprobar.ForeColor = System.Drawing.Color.White;
            this.btnAprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprobar.Location = new System.Drawing.Point(480, 585);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(115, 30);
            this.btnAprobar.TabIndex = 10;
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Location = new System.Drawing.Point(605, 585);
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
            this.btnVolver.Location = new System.Drawing.Point(730, 585);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(110, 30);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmResolverReclamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(860, 640);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblPendientes);
            this.Controls.Add(this.dgvPendientes);
            this.Controls.Add(this.grpDetalle);
            this.Controls.Add(this.lblMotivoResolucion);
            this.Controls.Add(this.txtMotivoResolucion);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmResolverReclamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resolver reclamos";
            this.Load += new System.EventHandler(this.frmResolverReclamos_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmResolverReclamos_FormClosed);
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
        private System.Windows.Forms.Label lblVentaDatos;
        private System.Windows.Forms.Label lblClienteDatos;
        private System.Windows.Forms.Label lblMotivoReclamo;
        private System.Windows.Forms.Label lblMotivoResolucion;
        private System.Windows.Forms.TextBox txtMotivoResolucion;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Button btnVolver;
    }
}
