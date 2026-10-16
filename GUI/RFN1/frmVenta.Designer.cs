namespace GUI.RFN1
{
    partial class frmVenta
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
            this.grpProducto = new System.Windows.Forms.GroupBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.lblProductoDatos = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPuntosTitulo = new System.Windows.Forms.Label();
            this.lblPuntos = new System.Windows.Forms.Label();
            this.btnCerrarVenta = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pnlTitulo.SuspendLayout();
            this.grpCliente.SuspendLayout();
            this.grpProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.BackColor = System.Drawing.Color.Maroon;
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(820, 45);
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
            this.lblTitulo.Text = "Registrar venta";
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
            this.grpCliente.Size = new System.Drawing.Size(780, 70);
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
            this.lblCliente.Size = new System.Drawing.Size(430, 20);
            this.lblCliente.TabIndex = 6;
            this.lblCliente.Text = "Venta sin cliente identificado";
            // 
            // grpProducto
            // 
            this.grpProducto.Controls.Add(this.lblProducto);
            this.grpProducto.Controls.Add(this.txtProducto);
            this.grpProducto.Controls.Add(this.btnBuscarProducto);
            this.grpProducto.Controls.Add(this.lblProductoDatos);
            this.grpProducto.Controls.Add(this.lblCantidad);
            this.grpProducto.Controls.Add(this.nudCantidad);
            this.grpProducto.Controls.Add(this.btnAgregar);
            this.grpProducto.Controls.Add(this.dgvProductos);
            this.grpProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.grpProducto.Location = new System.Drawing.Point(20, 140);
            this.grpProducto.Name = "grpProducto";
            this.grpProducto.Size = new System.Drawing.Size(780, 230);
            this.grpProducto.TabIndex = 7;
            this.grpProducto.Text = "Producto";
            // 
            // lblProducto
            // 
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(15, 30);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(70, 20);
            this.lblProducto.TabIndex = 8;
            this.lblProducto.Text = "Producto";
            // 
            // txtProducto
            // 
            this.txtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducto.Location = new System.Drawing.Point(90, 27);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(230, 22);
            this.txtProducto.TabIndex = 9;
            this.txtProducto.TextChanged += new System.EventHandler(this.txtProducto_TextChanged);
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Location = new System.Drawing.Point(330, 23);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(80, 30);
            this.btnBuscarProducto.TabIndex = 10;
            this.btnBuscarProducto.Text = "Buscar";
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // lblProductoDatos
            // 
            this.lblProductoDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductoDatos.Location = new System.Drawing.Point(420, 30);
            this.lblProductoDatos.Name = "lblProductoDatos";
            this.lblProductoDatos.Size = new System.Drawing.Size(200, 20);
            this.lblProductoDatos.TabIndex = 11;
            this.lblProductoDatos.Text = "-";
            // 
            // lblCantidad
            // 
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(625, 30);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(35, 20);
            this.lblCantidad.TabIndex = 12;
            this.lblCantidad.Text = "Cant.";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudCantidad.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            this.nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudCantidad.Location = new System.Drawing.Point(665, 27);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(55, 22);
            this.nudCantidad.TabIndex = 13;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.BackColor = System.Drawing.Color.Maroon;
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(725, 23);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(45, 30);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "+";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(15, 60);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(750, 160);
            this.dgvProductos.TabIndex = 15;
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.ReadOnly = true;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.MultiSelect = false;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(20, 380);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(780, 220);
            this.dgvItems.TabIndex = 16;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Location = new System.Drawing.Point(20, 607);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(120, 30);
            this.btnQuitar.TabIndex = 17;
            this.btnQuitar.Text = "Quitar ítem";
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTitulo.Location = new System.Drawing.Point(470, 610);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(60, 20);
            this.lblTotalTitulo.TabIndex = 18;
            this.lblTotalTitulo.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(530, 610);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 20);
            this.lblTotal.TabIndex = 19;
            this.lblTotal.Text = "$ 0,00";
            // 
            // lblPuntosTitulo
            // 
            this.lblPuntosTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntosTitulo.Location = new System.Drawing.Point(650, 610);
            this.lblPuntosTitulo.Name = "lblPuntosTitulo";
            this.lblPuntosTitulo.Size = new System.Drawing.Size(55, 20);
            this.lblPuntosTitulo.TabIndex = 20;
            this.lblPuntosTitulo.Text = "Puntos:";
            // 
            // lblPuntos
            // 
            this.lblPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntos.Location = new System.Drawing.Point(710, 610);
            this.lblPuntos.Name = "lblPuntos";
            this.lblPuntos.Size = new System.Drawing.Size(90, 20);
            this.lblPuntos.TabIndex = 21;
            this.lblPuntos.Text = "0";
            // 
            // btnCerrarVenta
            // 
            this.btnCerrarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarVenta.UseVisualStyleBackColor = false;
            this.btnCerrarVenta.BackColor = System.Drawing.Color.Maroon;
            this.btnCerrarVenta.ForeColor = System.Drawing.Color.White;
            this.btnCerrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarVenta.Location = new System.Drawing.Point(560, 700);
            this.btnCerrarVenta.Name = "btnCerrarVenta";
            this.btnCerrarVenta.Size = new System.Drawing.Size(120, 30);
            this.btnCerrarVenta.TabIndex = 22;
            this.btnCerrarVenta.Text = "Cerrar venta";
            this.btnCerrarVenta.Click += new System.EventHandler(this.btnCerrarVenta_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Location = new System.Drawing.Point(690, 700);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(110, 30);
            this.btnVolver.TabIndex = 23;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(820, 750);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.grpCliente);
            this.Controls.Add(this.grpProducto);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.lblTotalTitulo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblPuntosTitulo);
            this.Controls.Add(this.lblPuntos);
            this.Controls.Add(this.btnCerrarVenta);
            this.Controls.Add(this.btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar venta";
            this.Load += new System.EventHandler(this.frmVenta_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVenta_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.grpProducto.ResumeLayout(false);
            this.grpProducto.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Label lblProductoDatos;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPuntosTitulo;
        private System.Windows.Forms.Label lblPuntos;
        private System.Windows.Forms.Button btnCerrarVenta;
        private System.Windows.Forms.Button btnVolver;
    }
}