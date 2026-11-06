namespace LM830GUI.LM830RFN1
{
    partial class LM830frmResolverReclamos
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
            this.LM830lblPendientes = new System.Windows.Forms.Label();
            this.LM830dgvPendientes = new System.Windows.Forms.DataGridView();
            this.LM830grpDetalle = new System.Windows.Forms.GroupBox();
            this.LM830lblVentaDatos = new System.Windows.Forms.Label();
            this.LM830lblClienteDatos = new System.Windows.Forms.Label();
            this.LM830lblMotivoReclamo = new System.Windows.Forms.Label();
            this.LM830lblMotivoResolucion = new System.Windows.Forms.Label();
            this.LM830txtMotivoResolucion = new System.Windows.Forms.TextBox();
            this.LM830btnAprobar = new System.Windows.Forms.Button();
            this.LM830btnRechazar = new System.Windows.Forms.Button();
            this.LM830btnVolver = new System.Windows.Forms.Button();
            this.LM830pnlTitulo.SuspendLayout();
            this.LM830grpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.LM830pnlTitulo.Controls.Add(this.LM830lblTitulo);
            this.LM830pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LM830pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.LM830pnlTitulo.Name = "LM830pnlTitulo";
            this.LM830pnlTitulo.Size = new System.Drawing.Size(860, 45);
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
            this.LM830lblTitulo.Text = "Resolver reclamos";
            // 
            // lblPendientes
            // 
            this.LM830lblPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblPendientes.Location = new System.Drawing.Point(20, 60);
            this.LM830lblPendientes.Name = "LM830lblPendientes";
            this.LM830lblPendientes.Size = new System.Drawing.Size(300, 20);
            this.LM830lblPendientes.TabIndex = 2;
            this.LM830lblPendientes.Text = "Reclamos pendientes";
            // 
            // dgvPendientes
            // 
            this.LM830dgvPendientes.AllowUserToAddRows = false;
            this.LM830dgvPendientes.AllowUserToDeleteRows = false;
            this.LM830dgvPendientes.ReadOnly = true;
            this.LM830dgvPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LM830dgvPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LM830dgvPendientes.MultiSelect = false;
            this.LM830dgvPendientes.RowHeadersVisible = false;
            this.LM830dgvPendientes.BackgroundColor = System.Drawing.Color.White;
            this.LM830dgvPendientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LM830dgvPendientes.EnableHeadersVisualStyles = false;
            this.LM830dgvPendientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.LM830dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LM830dgvPendientes.Location = new System.Drawing.Point(20, 85);
            this.LM830dgvPendientes.Name = "LM830dgvPendientes";
            this.LM830dgvPendientes.Size = new System.Drawing.Size(820, 220);
            this.LM830dgvPendientes.TabIndex = 3;
            this.LM830dgvPendientes.SelectionChanged += new System.EventHandler(this.LM830dgvPendientes_SelectionChanged);
            // 
            // grpDetalle
            // 
            this.LM830grpDetalle.Controls.Add(this.LM830lblVentaDatos);
            this.LM830grpDetalle.Controls.Add(this.LM830lblClienteDatos);
            this.LM830grpDetalle.Controls.Add(this.LM830lblMotivoReclamo);
            this.LM830grpDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830grpDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830grpDetalle.Location = new System.Drawing.Point(20, 315);
            this.LM830grpDetalle.Name = "LM830grpDetalle";
            this.LM830grpDetalle.Size = new System.Drawing.Size(820, 130);
            this.LM830grpDetalle.TabIndex = 4;
            this.LM830grpDetalle.Text = "Detalle";
            // 
            // lblVentaDatos
            // 
            this.LM830lblVentaDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblVentaDatos.Location = new System.Drawing.Point(15, 25);
            this.LM830lblVentaDatos.Name = "LM830lblVentaDatos";
            this.LM830lblVentaDatos.Size = new System.Drawing.Size(790, 20);
            this.LM830lblVentaDatos.TabIndex = 5;
            this.LM830lblVentaDatos.Text = "-";
            // 
            // lblClienteDatos
            // 
            this.LM830lblClienteDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblClienteDatos.Location = new System.Drawing.Point(15, 55);
            this.LM830lblClienteDatos.Name = "LM830lblClienteDatos";
            this.LM830lblClienteDatos.Size = new System.Drawing.Size(790, 20);
            this.LM830lblClienteDatos.TabIndex = 6;
            this.LM830lblClienteDatos.Text = "-";
            // 
            // lblMotivoReclamo
            // 
            this.LM830lblMotivoReclamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblMotivoReclamo.Location = new System.Drawing.Point(15, 85);
            this.LM830lblMotivoReclamo.Name = "LM830lblMotivoReclamo";
            this.LM830lblMotivoReclamo.Size = new System.Drawing.Size(790, 20);
            this.LM830lblMotivoReclamo.TabIndex = 7;
            this.LM830lblMotivoReclamo.Text = "-";
            // 
            // lblMotivoResolucion
            // 
            this.LM830lblMotivoResolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblMotivoResolucion.Location = new System.Drawing.Point(20, 455);
            this.LM830lblMotivoResolucion.Name = "LM830lblMotivoResolucion";
            this.LM830lblMotivoResolucion.Size = new System.Drawing.Size(400, 20);
            this.LM830lblMotivoResolucion.TabIndex = 8;
            this.LM830lblMotivoResolucion.Text = "Motivo de la resolución (obligatorio para rechazar)";
            // 
            // txtMotivoResolucion
            // 
            this.LM830txtMotivoResolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtMotivoResolucion.Multiline = true;
            this.LM830txtMotivoResolucion.MaxLength = 200;
            this.LM830txtMotivoResolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LM830txtMotivoResolucion.Location = new System.Drawing.Point(20, 480);
            this.LM830txtMotivoResolucion.Name = "LM830txtMotivoResolucion";
            this.LM830txtMotivoResolucion.Size = new System.Drawing.Size(820, 70);
            this.LM830txtMotivoResolucion.TabIndex = 9;
            // 
            // btnAprobar
            // 
            this.LM830btnAprobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnAprobar.UseVisualStyleBackColor = false;
            this.LM830btnAprobar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnAprobar.ForeColor = System.Drawing.Color.White;
            this.LM830btnAprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnAprobar.FlatAppearance.BorderSize = 0;
            this.LM830btnAprobar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnAprobar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnAprobar.Location = new System.Drawing.Point(480, 585);
            this.LM830btnAprobar.Name = "LM830btnAprobar";
            this.LM830btnAprobar.Size = new System.Drawing.Size(115, 30);
            this.LM830btnAprobar.TabIndex = 10;
            this.LM830btnAprobar.Text = "Aprobar";
            this.LM830btnAprobar.Click += new System.EventHandler(this.LM830btnAprobar_Click);
            // 
            // btnRechazar
            // 
            this.LM830btnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnRechazar.UseVisualStyleBackColor = true;
            this.LM830btnRechazar.Location = new System.Drawing.Point(605, 585);
            this.LM830btnRechazar.Name = "LM830btnRechazar";
            this.LM830btnRechazar.Size = new System.Drawing.Size(115, 30);
            this.LM830btnRechazar.TabIndex = 11;
            this.LM830btnRechazar.Text = "Rechazar";
            this.LM830btnRechazar.Click += new System.EventHandler(this.LM830btnRechazar_Click);
            // 
            // btnVolver
            // 
            this.LM830btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnVolver.UseVisualStyleBackColor = true;
            this.LM830btnVolver.Location = new System.Drawing.Point(730, 585);
            this.LM830btnVolver.Name = "LM830btnVolver";
            this.LM830btnVolver.Size = new System.Drawing.Size(110, 30);
            this.LM830btnVolver.TabIndex = 12;
            this.LM830btnVolver.Text = "Volver";
            this.LM830btnVolver.Click += new System.EventHandler(this.LM830btnVolver_Click);
            // 
            // frmResolverReclamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 640);
            this.Controls.Add(this.LM830pnlTitulo);
            this.Controls.Add(this.LM830lblPendientes);
            this.Controls.Add(this.LM830dgvPendientes);
            this.Controls.Add(this.LM830grpDetalle);
            this.Controls.Add(this.LM830lblMotivoResolucion);
            this.Controls.Add(this.LM830txtMotivoResolucion);
            this.Controls.Add(this.LM830btnAprobar);
            this.Controls.Add(this.LM830btnRechazar);
            this.Controls.Add(this.LM830btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LM830frmResolverReclamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resolver reclamos";
            this.Load += new System.EventHandler(this.LM830frmResolverReclamos_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LM830frmResolverReclamos_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvPendientes)).EndInit();
            this.LM830pnlTitulo.ResumeLayout(false);
            this.LM830pnlTitulo.PerformLayout();
            this.LM830grpDetalle.ResumeLayout(false);
            this.LM830grpDetalle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LM830pnlTitulo;
        private System.Windows.Forms.Label LM830lblTitulo;
        private System.Windows.Forms.Label LM830lblPendientes;
        private System.Windows.Forms.DataGridView LM830dgvPendientes;
        private System.Windows.Forms.GroupBox LM830grpDetalle;
        private System.Windows.Forms.Label LM830lblVentaDatos;
        private System.Windows.Forms.Label LM830lblClienteDatos;
        private System.Windows.Forms.Label LM830lblMotivoReclamo;
        private System.Windows.Forms.Label LM830lblMotivoResolucion;
        private System.Windows.Forms.TextBox LM830txtMotivoResolucion;
        private System.Windows.Forms.Button LM830btnAprobar;
        private System.Windows.Forms.Button LM830btnRechazar;
        private System.Windows.Forms.Button LM830btnVolver;
    }
}
