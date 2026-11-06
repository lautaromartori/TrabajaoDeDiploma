namespace LM830GUI.LM830RFN1
{
    partial class LM830frmReclamo
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
            this.LM830grpVenta = new System.Windows.Forms.GroupBox();
            this.LM830lblComprobante = new System.Windows.Forms.Label();
            this.LM830txtNroComprobante = new System.Windows.Forms.TextBox();
            this.LM830btnBuscarVenta = new System.Windows.Forms.Button();
            this.LM830lblVentaDatos = new System.Windows.Forms.Label();
            this.LM830dgvDetalle = new System.Windows.Forms.DataGridView();
            this.LM830lblPuntosTitulo = new System.Windows.Forms.Label();
            this.LM830lblPuntos = new System.Windows.Forms.Label();
            this.LM830lblMotivo = new System.Windows.Forms.Label();
            this.LM830txtMotivo = new System.Windows.Forms.TextBox();
            this.LM830btnRegistrarReclamo = new System.Windows.Forms.Button();
            this.LM830btnVolver = new System.Windows.Forms.Button();
            this.LM830pnlTitulo.SuspendLayout();
            this.LM830grpCliente.SuspendLayout();
            this.LM830grpVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.LM830pnlTitulo.Controls.Add(this.LM830lblTitulo);
            this.LM830pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LM830pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.LM830pnlTitulo.Name = "LM830pnlTitulo";
            this.LM830pnlTitulo.Size = new System.Drawing.Size(720, 45);
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
            this.LM830lblTitulo.Text = "Registrar reclamo";
            // 
            // grpCliente
            // 
            this.LM830grpCliente.Controls.Add(this.LM830lblDni);
            this.LM830grpCliente.Controls.Add(this.LM830txtDni);
            this.LM830grpCliente.Controls.Add(this.LM830btnBuscarCliente);
            this.LM830grpCliente.Controls.Add(this.LM830lblCliente);
            this.LM830grpCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830grpCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830grpCliente.Location = new System.Drawing.Point(20, 60);
            this.LM830grpCliente.Name = "LM830grpCliente";
            this.LM830grpCliente.Size = new System.Drawing.Size(680, 70);
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
            this.LM830btnBuscarCliente.UseVisualStyleBackColor = true;
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
            this.LM830lblCliente.Size = new System.Drawing.Size(330, 20);
            this.LM830lblCliente.TabIndex = 6;
            this.LM830lblCliente.Text = "-";
            // 
            // grpVenta
            // 
            this.LM830grpVenta.Controls.Add(this.LM830lblComprobante);
            this.LM830grpVenta.Controls.Add(this.LM830txtNroComprobante);
            this.LM830grpVenta.Controls.Add(this.LM830btnBuscarVenta);
            this.LM830grpVenta.Controls.Add(this.LM830lblVentaDatos);
            this.LM830grpVenta.Controls.Add(this.LM830dgvDetalle);
            this.LM830grpVenta.Controls.Add(this.LM830lblPuntosTitulo);
            this.LM830grpVenta.Controls.Add(this.LM830lblPuntos);
            this.LM830grpVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830grpVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830grpVenta.Location = new System.Drawing.Point(20, 140);
            this.LM830grpVenta.Name = "LM830grpVenta";
            this.LM830grpVenta.Size = new System.Drawing.Size(680, 260);
            this.LM830grpVenta.TabIndex = 7;
            this.LM830grpVenta.Text = "Compra";
            // 
            // lblComprobante
            // 
            this.LM830lblComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblComprobante.Location = new System.Drawing.Point(15, 30);
            this.LM830lblComprobante.Name = "LM830lblComprobante";
            this.LM830lblComprobante.Size = new System.Drawing.Size(110, 20);
            this.LM830lblComprobante.TabIndex = 8;
            this.LM830lblComprobante.Text = "Nro. comprobante";
            // 
            // txtNroComprobante
            // 
            this.LM830txtNroComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtNroComprobante.MaxLength = 20;
            this.LM830txtNroComprobante.Location = new System.Drawing.Point(130, 27);
            this.LM830txtNroComprobante.Name = "LM830txtNroComprobante";
            this.LM830txtNroComprobante.Size = new System.Drawing.Size(160, 22);
            this.LM830txtNroComprobante.TabIndex = 9;
            // 
            // btnBuscarVenta
            // 
            this.LM830btnBuscarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnBuscarVenta.UseVisualStyleBackColor = true;
            this.LM830btnBuscarVenta.Location = new System.Drawing.Point(300, 23);
            this.LM830btnBuscarVenta.Name = "LM830btnBuscarVenta";
            this.LM830btnBuscarVenta.Size = new System.Drawing.Size(90, 30);
            this.LM830btnBuscarVenta.TabIndex = 10;
            this.LM830btnBuscarVenta.Text = "Buscar";
            this.LM830btnBuscarVenta.Click += new System.EventHandler(this.LM830btnBuscarVenta_Click);
            // 
            // lblVentaDatos
            // 
            this.LM830lblVentaDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblVentaDatos.Location = new System.Drawing.Point(400, 30);
            this.LM830lblVentaDatos.Name = "LM830lblVentaDatos";
            this.LM830lblVentaDatos.Size = new System.Drawing.Size(270, 20);
            this.LM830lblVentaDatos.TabIndex = 11;
            this.LM830lblVentaDatos.Text = "-";
            // 
            // dgvDetalle
            // 
            this.LM830dgvDetalle.AllowUserToAddRows = false;
            this.LM830dgvDetalle.AllowUserToDeleteRows = false;
            this.LM830dgvDetalle.ReadOnly = true;
            this.LM830dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LM830dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LM830dgvDetalle.MultiSelect = false;
            this.LM830dgvDetalle.RowHeadersVisible = false;
            this.LM830dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.LM830dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LM830dgvDetalle.EnableHeadersVisualStyles = false;
            this.LM830dgvDetalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.LM830dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LM830dgvDetalle.Location = new System.Drawing.Point(15, 60);
            this.LM830dgvDetalle.Name = "LM830dgvDetalle";
            this.LM830dgvDetalle.Size = new System.Drawing.Size(650, 150);
            this.LM830dgvDetalle.TabIndex = 12;
            // 
            // lblPuntosTitulo
            // 
            this.LM830lblPuntosTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblPuntosTitulo.Location = new System.Drawing.Point(15, 222);
            this.LM830lblPuntosTitulo.Name = "LM830lblPuntosTitulo";
            this.LM830lblPuntosTitulo.Size = new System.Drawing.Size(200, 20);
            this.LM830lblPuntosTitulo.TabIndex = 13;
            this.LM830lblPuntosTitulo.Text = "Puntos que corresponderían:";
            // 
            // lblPuntos
            // 
            this.LM830lblPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblPuntos.Location = new System.Drawing.Point(220, 222);
            this.LM830lblPuntos.Name = "LM830lblPuntos";
            this.LM830lblPuntos.Size = new System.Drawing.Size(100, 20);
            this.LM830lblPuntos.TabIndex = 14;
            this.LM830lblPuntos.Text = "-";
            // 
            // lblMotivo
            // 
            this.LM830lblMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblMotivo.Location = new System.Drawing.Point(20, 410);
            this.LM830lblMotivo.Name = "LM830lblMotivo";
            this.LM830lblMotivo.Size = new System.Drawing.Size(200, 20);
            this.LM830lblMotivo.TabIndex = 15;
            this.LM830lblMotivo.Text = "Motivo del reclamo";
            // 
            // txtMotivo
            // 
            this.LM830txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtMotivo.Multiline = true;
            this.LM830txtMotivo.MaxLength = 200;
            this.LM830txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LM830txtMotivo.Location = new System.Drawing.Point(20, 435);
            this.LM830txtMotivo.Name = "LM830txtMotivo";
            this.LM830txtMotivo.Size = new System.Drawing.Size(680, 90);
            this.LM830txtMotivo.TabIndex = 16;
            // 
            // btnRegistrarReclamo
            // 
            this.LM830btnRegistrarReclamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnRegistrarReclamo.UseVisualStyleBackColor = false;
            this.LM830btnRegistrarReclamo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnRegistrarReclamo.ForeColor = System.Drawing.Color.White;
            this.LM830btnRegistrarReclamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnRegistrarReclamo.FlatAppearance.BorderSize = 0;
            this.LM830btnRegistrarReclamo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnRegistrarReclamo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnRegistrarReclamo.Location = new System.Drawing.Point(430, 585);
            this.LM830btnRegistrarReclamo.Name = "LM830btnRegistrarReclamo";
            this.LM830btnRegistrarReclamo.Size = new System.Drawing.Size(150, 30);
            this.LM830btnRegistrarReclamo.TabIndex = 17;
            this.LM830btnRegistrarReclamo.Text = "Registrar reclamo";
            this.LM830btnRegistrarReclamo.Click += new System.EventHandler(this.LM830btnRegistrarReclamo_Click);
            // 
            // btnVolver
            // 
            this.LM830btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnVolver.UseVisualStyleBackColor = true;
            this.LM830btnVolver.Location = new System.Drawing.Point(590, 585);
            this.LM830btnVolver.Name = "LM830btnVolver";
            this.LM830btnVolver.Size = new System.Drawing.Size(110, 30);
            this.LM830btnVolver.TabIndex = 18;
            this.LM830btnVolver.Text = "Volver";
            this.LM830btnVolver.Click += new System.EventHandler(this.LM830btnVolver_Click);
            // 
            // frmReclamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(720, 640);
            this.Controls.Add(this.LM830pnlTitulo);
            this.Controls.Add(this.LM830grpCliente);
            this.Controls.Add(this.LM830grpVenta);
            this.Controls.Add(this.LM830lblMotivo);
            this.Controls.Add(this.LM830txtMotivo);
            this.Controls.Add(this.LM830btnRegistrarReclamo);
            this.Controls.Add(this.LM830btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LM830frmReclamo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar reclamo";
            this.Load += new System.EventHandler(this.LM830frmReclamo_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LM830frmReclamo_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvDetalle)).EndInit();
            this.LM830pnlTitulo.ResumeLayout(false);
            this.LM830pnlTitulo.PerformLayout();
            this.LM830grpCliente.ResumeLayout(false);
            this.LM830grpCliente.PerformLayout();
            this.LM830grpVenta.ResumeLayout(false);
            this.LM830grpVenta.PerformLayout();
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
        private System.Windows.Forms.GroupBox LM830grpVenta;
        private System.Windows.Forms.Label LM830lblComprobante;
        private System.Windows.Forms.TextBox LM830txtNroComprobante;
        private System.Windows.Forms.Button LM830btnBuscarVenta;
        private System.Windows.Forms.Label LM830lblVentaDatos;
        private System.Windows.Forms.DataGridView LM830dgvDetalle;
        private System.Windows.Forms.Label LM830lblPuntosTitulo;
        private System.Windows.Forms.Label LM830lblPuntos;
        private System.Windows.Forms.Label LM830lblMotivo;
        private System.Windows.Forms.TextBox LM830txtMotivo;
        private System.Windows.Forms.Button LM830btnRegistrarReclamo;
        private System.Windows.Forms.Button LM830btnVolver;
    }
}
