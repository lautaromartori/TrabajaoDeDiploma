namespace GUI.RFN1
{
    partial class frmReclamo
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
            this.grpVenta = new System.Windows.Forms.GroupBox();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.txtNroComprobante = new System.Windows.Forms.TextBox();
            this.btnBuscarVenta = new System.Windows.Forms.Button();
            this.lblVentaDatos = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.lblPuntosTitulo = new System.Windows.Forms.Label();
            this.lblPuntos = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnRegistrarReclamo = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pnlTitulo.SuspendLayout();
            this.grpCliente.SuspendLayout();
            this.grpVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.BackColor = System.Drawing.Color.Maroon;
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(720, 45);
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
            this.lblTitulo.Text = "Registrar reclamo";
            // 
            // grpCliente
            // 
            this.grpCliente.Controls.Add(this.lblDni);
            this.grpCliente.Controls.Add(this.txtDni);
            this.grpCliente.Controls.Add(this.btnBuscarCliente);
            this.grpCliente.Controls.Add(this.lblCliente);
            this.grpCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.grpCliente.Location = new System.Drawing.Point(20, 60);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(680, 70);
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
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
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
            this.lblCliente.Size = new System.Drawing.Size(330, 20);
            this.lblCliente.TabIndex = 6;
            this.lblCliente.Text = "-";
            // 
            // grpVenta
            // 
            this.grpVenta.Controls.Add(this.lblComprobante);
            this.grpVenta.Controls.Add(this.txtNroComprobante);
            this.grpVenta.Controls.Add(this.btnBuscarVenta);
            this.grpVenta.Controls.Add(this.lblVentaDatos);
            this.grpVenta.Controls.Add(this.dgvDetalle);
            this.grpVenta.Controls.Add(this.lblPuntosTitulo);
            this.grpVenta.Controls.Add(this.lblPuntos);
            this.grpVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.grpVenta.Location = new System.Drawing.Point(20, 140);
            this.grpVenta.Name = "grpVenta";
            this.grpVenta.Size = new System.Drawing.Size(680, 260);
            this.grpVenta.TabIndex = 7;
            this.grpVenta.Text = "Compra";
            // 
            // lblComprobante
            // 
            this.lblComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComprobante.Location = new System.Drawing.Point(15, 30);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(110, 20);
            this.lblComprobante.TabIndex = 8;
            this.lblComprobante.Text = "Nro. comprobante";
            // 
            // txtNroComprobante
            // 
            this.txtNroComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroComprobante.MaxLength = 20;
            this.txtNroComprobante.Location = new System.Drawing.Point(130, 27);
            this.txtNroComprobante.Name = "txtNroComprobante";
            this.txtNroComprobante.Size = new System.Drawing.Size(160, 22);
            this.txtNroComprobante.TabIndex = 9;
            // 
            // btnBuscarVenta
            // 
            this.btnBuscarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarVenta.UseVisualStyleBackColor = true;
            this.btnBuscarVenta.Location = new System.Drawing.Point(300, 23);
            this.btnBuscarVenta.Name = "btnBuscarVenta";
            this.btnBuscarVenta.Size = new System.Drawing.Size(90, 30);
            this.btnBuscarVenta.TabIndex = 10;
            this.btnBuscarVenta.Text = "Buscar";
            this.btnBuscarVenta.Click += new System.EventHandler(this.btnBuscarVenta_Click);
            // 
            // lblVentaDatos
            // 
            this.lblVentaDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentaDatos.Location = new System.Drawing.Point(400, 30);
            this.lblVentaDatos.Name = "lblVentaDatos";
            this.lblVentaDatos.Size = new System.Drawing.Size(270, 20);
            this.lblVentaDatos.TabIndex = 11;
            this.lblVentaDatos.Text = "-";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(15, 60);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(650, 150);
            this.dgvDetalle.TabIndex = 12;
            // 
            // lblPuntosTitulo
            // 
            this.lblPuntosTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntosTitulo.Location = new System.Drawing.Point(15, 222);
            this.lblPuntosTitulo.Name = "lblPuntosTitulo";
            this.lblPuntosTitulo.Size = new System.Drawing.Size(200, 20);
            this.lblPuntosTitulo.TabIndex = 13;
            this.lblPuntosTitulo.Text = "Puntos que corresponderían:";
            // 
            // lblPuntos
            // 
            this.lblPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntos.Location = new System.Drawing.Point(220, 222);
            this.lblPuntos.Name = "lblPuntos";
            this.lblPuntos.Size = new System.Drawing.Size(100, 20);
            this.lblPuntos.TabIndex = 14;
            this.lblPuntos.Text = "-";
            // 
            // lblMotivo
            // 
            this.lblMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.Location = new System.Drawing.Point(20, 410);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(200, 20);
            this.lblMotivo.TabIndex = 15;
            this.lblMotivo.Text = "Motivo del reclamo";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.Multiline = true;
            this.txtMotivo.MaxLength = 200;
            this.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivo.Location = new System.Drawing.Point(20, 435);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(680, 90);
            this.txtMotivo.TabIndex = 16;
            // 
            // btnRegistrarReclamo
            // 
            this.btnRegistrarReclamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarReclamo.UseVisualStyleBackColor = false;
            this.btnRegistrarReclamo.BackColor = System.Drawing.Color.Maroon;
            this.btnRegistrarReclamo.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarReclamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarReclamo.Location = new System.Drawing.Point(430, 585);
            this.btnRegistrarReclamo.Name = "btnRegistrarReclamo";
            this.btnRegistrarReclamo.Size = new System.Drawing.Size(150, 30);
            this.btnRegistrarReclamo.TabIndex = 17;
            this.btnRegistrarReclamo.Text = "Registrar reclamo";
            this.btnRegistrarReclamo.Click += new System.EventHandler(this.btnRegistrarReclamo_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Location = new System.Drawing.Point(590, 585);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(110, 30);
            this.btnVolver.TabIndex = 18;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmReclamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(720, 640);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.grpCliente);
            this.Controls.Add(this.grpVenta);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.btnRegistrarReclamo);
            this.Controls.Add(this.btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmReclamo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar reclamo";
            this.Load += new System.EventHandler(this.frmReclamo_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReclamo_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.grpVenta.ResumeLayout(false);
            this.grpVenta.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpVenta;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.TextBox txtNroComprobante;
        private System.Windows.Forms.Button btnBuscarVenta;
        private System.Windows.Forms.Label lblVentaDatos;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label lblPuntosTitulo;
        private System.Windows.Forms.Label lblPuntos;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnRegistrarReclamo;
        private System.Windows.Forms.Button btnVolver;
    }
}
