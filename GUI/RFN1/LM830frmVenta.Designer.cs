namespace LM830GUI.LM830RFN1
{
    partial class LM830frmVenta
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
            this.LM830grpProducto = new System.Windows.Forms.GroupBox();
            this.LM830lblProducto = new System.Windows.Forms.Label();
            this.LM830txtProducto = new System.Windows.Forms.TextBox();
            this.LM830btnBuscarProducto = new System.Windows.Forms.Button();
            this.LM830lblProductoDatos = new System.Windows.Forms.Label();
            this.LM830lblCantidad = new System.Windows.Forms.Label();
            this.LM830nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.LM830btnAgregar = new System.Windows.Forms.Button();
            this.LM830dgvProductos = new System.Windows.Forms.DataGridView();
            this.LM830dgvItems = new System.Windows.Forms.DataGridView();
            this.LM830btnQuitar = new System.Windows.Forms.Button();
            this.LM830lblTotalTitulo = new System.Windows.Forms.Label();
            this.LM830lblTotal = new System.Windows.Forms.Label();
            this.LM830lblPuntosTitulo = new System.Windows.Forms.Label();
            this.LM830lblPuntos = new System.Windows.Forms.Label();
            this.LM830btnCerrarVenta = new System.Windows.Forms.Button();
            this.LM830btnVolver = new System.Windows.Forms.Button();
            this.LM830pnlTitulo.SuspendLayout();
            this.LM830grpCliente.SuspendLayout();
            this.LM830grpProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LM830nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.LM830pnlTitulo.Controls.Add(this.LM830lblTitulo);
            this.LM830pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LM830pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.LM830pnlTitulo.Name = "LM830pnlTitulo";
            this.LM830pnlTitulo.Size = new System.Drawing.Size(820, 45);
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
            this.LM830lblTitulo.Text = "Registrar venta";
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
            this.LM830grpCliente.Size = new System.Drawing.Size(780, 70);
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
            this.LM830lblCliente.Size = new System.Drawing.Size(430, 20);
            this.LM830lblCliente.TabIndex = 6;
            this.LM830lblCliente.Text = "Venta sin cliente identificado";
            // 
            // grpProducto
            // 
            this.LM830grpProducto.Controls.Add(this.LM830lblProducto);
            this.LM830grpProducto.Controls.Add(this.LM830txtProducto);
            this.LM830grpProducto.Controls.Add(this.LM830btnBuscarProducto);
            this.LM830grpProducto.Controls.Add(this.LM830lblProductoDatos);
            this.LM830grpProducto.Controls.Add(this.LM830lblCantidad);
            this.LM830grpProducto.Controls.Add(this.LM830nudCantidad);
            this.LM830grpProducto.Controls.Add(this.LM830btnAgregar);
            this.LM830grpProducto.Controls.Add(this.LM830dgvProductos);
            this.LM830grpProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830grpProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830grpProducto.Location = new System.Drawing.Point(20, 140);
            this.LM830grpProducto.Name = "LM830grpProducto";
            this.LM830grpProducto.Size = new System.Drawing.Size(780, 230);
            this.LM830grpProducto.TabIndex = 7;
            this.LM830grpProducto.Text = "Producto";
            // 
            // lblProducto
            // 
            this.LM830lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblProducto.Location = new System.Drawing.Point(15, 30);
            this.LM830lblProducto.Name = "LM830lblProducto";
            this.LM830lblProducto.Size = new System.Drawing.Size(70, 20);
            this.LM830lblProducto.TabIndex = 8;
            this.LM830lblProducto.Text = "Producto";
            // 
            // txtProducto
            // 
            this.LM830txtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtProducto.Location = new System.Drawing.Point(90, 27);
            this.LM830txtProducto.Name = "LM830txtProducto";
            this.LM830txtProducto.Size = new System.Drawing.Size(230, 22);
            this.LM830txtProducto.TabIndex = 9;
            this.LM830txtProducto.TextChanged += new System.EventHandler(this.LM830txtProducto_TextChanged);
            // 
            // btnBuscarProducto
            // 
            this.LM830btnBuscarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnBuscarProducto.UseVisualStyleBackColor = true;
            this.LM830btnBuscarProducto.Location = new System.Drawing.Point(330, 23);
            this.LM830btnBuscarProducto.Name = "LM830btnBuscarProducto";
            this.LM830btnBuscarProducto.Size = new System.Drawing.Size(80, 30);
            this.LM830btnBuscarProducto.TabIndex = 10;
            this.LM830btnBuscarProducto.Text = "Buscar";
            this.LM830btnBuscarProducto.Click += new System.EventHandler(this.LM830btnBuscarProducto_Click);
            // 
            // lblProductoDatos
            // 
            this.LM830lblProductoDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblProductoDatos.Location = new System.Drawing.Point(420, 30);
            this.LM830lblProductoDatos.Name = "LM830lblProductoDatos";
            this.LM830lblProductoDatos.Size = new System.Drawing.Size(200, 20);
            this.LM830lblProductoDatos.TabIndex = 11;
            this.LM830lblProductoDatos.Text = "-";
            // 
            // lblCantidad
            // 
            this.LM830lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblCantidad.Location = new System.Drawing.Point(625, 30);
            this.LM830lblCantidad.Name = "LM830lblCantidad";
            this.LM830lblCantidad.Size = new System.Drawing.Size(35, 20);
            this.LM830lblCantidad.TabIndex = 12;
            this.LM830lblCantidad.Text = "Cant.";
            // 
            // nudCantidad
            // 
            this.LM830nudCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.LM830nudCantidad.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            this.LM830nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.LM830nudCantidad.Location = new System.Drawing.Point(665, 27);
            this.LM830nudCantidad.Name = "LM830nudCantidad";
            this.LM830nudCantidad.Size = new System.Drawing.Size(55, 22);
            this.LM830nudCantidad.TabIndex = 13;
            // 
            // btnAgregar
            // 
            this.LM830btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnAgregar.UseVisualStyleBackColor = false;
            this.LM830btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnAgregar.ForeColor = System.Drawing.Color.White;
            this.LM830btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnAgregar.FlatAppearance.BorderSize = 0;
            this.LM830btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnAgregar.Location = new System.Drawing.Point(725, 23);
            this.LM830btnAgregar.Name = "LM830btnAgregar";
            this.LM830btnAgregar.Size = new System.Drawing.Size(45, 30);
            this.LM830btnAgregar.TabIndex = 14;
            this.LM830btnAgregar.Text = "+";
            this.LM830btnAgregar.Click += new System.EventHandler(this.LM830btnAgregar_Click);
            // 
            // dgvProductos
            // 
            this.LM830dgvProductos.AllowUserToAddRows = false;
            this.LM830dgvProductos.AllowUserToDeleteRows = false;
            this.LM830dgvProductos.ReadOnly = true;
            this.LM830dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LM830dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LM830dgvProductos.MultiSelect = false;
            this.LM830dgvProductos.RowHeadersVisible = false;
            this.LM830dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.LM830dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LM830dgvProductos.EnableHeadersVisualStyles = false;
            this.LM830dgvProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.LM830dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LM830dgvProductos.Location = new System.Drawing.Point(15, 60);
            this.LM830dgvProductos.Name = "LM830dgvProductos";
            this.LM830dgvProductos.Size = new System.Drawing.Size(750, 160);
            this.LM830dgvProductos.TabIndex = 15;
            this.LM830dgvProductos.SelectionChanged += new System.EventHandler(this.LM830dgvProductos_SelectionChanged);
            this.LM830dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LM830dgvProductos_CellDoubleClick);
            // 
            // dgvItems
            // 
            this.LM830dgvItems.AllowUserToAddRows = false;
            this.LM830dgvItems.AllowUserToDeleteRows = false;
            this.LM830dgvItems.ReadOnly = true;
            this.LM830dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LM830dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LM830dgvItems.MultiSelect = false;
            this.LM830dgvItems.RowHeadersVisible = false;
            this.LM830dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.LM830dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LM830dgvItems.EnableHeadersVisualStyles = false;
            this.LM830dgvItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.LM830dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LM830dgvItems.Location = new System.Drawing.Point(20, 380);
            this.LM830dgvItems.Name = "LM830dgvItems";
            this.LM830dgvItems.Size = new System.Drawing.Size(780, 220);
            this.LM830dgvItems.TabIndex = 16;
            // 
            // btnQuitar
            // 
            this.LM830btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnQuitar.UseVisualStyleBackColor = true;
            this.LM830btnQuitar.Location = new System.Drawing.Point(20, 607);
            this.LM830btnQuitar.Name = "LM830btnQuitar";
            this.LM830btnQuitar.Size = new System.Drawing.Size(120, 30);
            this.LM830btnQuitar.TabIndex = 17;
            this.LM830btnQuitar.Text = "Quitar ítem";
            this.LM830btnQuitar.Click += new System.EventHandler(this.LM830btnQuitar_Click);
            // 
            // lblTotalTitulo
            // 
            this.LM830lblTotalTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblTotalTitulo.Location = new System.Drawing.Point(470, 610);
            this.LM830lblTotalTitulo.Name = "LM830lblTotalTitulo";
            this.LM830lblTotalTitulo.Size = new System.Drawing.Size(60, 20);
            this.LM830lblTotalTitulo.TabIndex = 18;
            this.LM830lblTotalTitulo.Text = "Total:";
            // 
            // lblTotal
            // 
            this.LM830lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblTotal.Location = new System.Drawing.Point(530, 610);
            this.LM830lblTotal.Name = "LM830lblTotal";
            this.LM830lblTotal.Size = new System.Drawing.Size(120, 20);
            this.LM830lblTotal.TabIndex = 19;
            this.LM830lblTotal.Text = "$ 0,00";
            // 
            // lblPuntosTitulo
            // 
            this.LM830lblPuntosTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblPuntosTitulo.Location = new System.Drawing.Point(650, 610);
            this.LM830lblPuntosTitulo.Name = "LM830lblPuntosTitulo";
            this.LM830lblPuntosTitulo.Size = new System.Drawing.Size(55, 20);
            this.LM830lblPuntosTitulo.TabIndex = 20;
            this.LM830lblPuntosTitulo.Text = "Puntos:";
            // 
            // lblPuntos
            // 
            this.LM830lblPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblPuntos.Location = new System.Drawing.Point(710, 610);
            this.LM830lblPuntos.Name = "LM830lblPuntos";
            this.LM830lblPuntos.Size = new System.Drawing.Size(90, 20);
            this.LM830lblPuntos.TabIndex = 21;
            this.LM830lblPuntos.Text = "0";
            // 
            // btnCerrarVenta
            // 
            this.LM830btnCerrarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnCerrarVenta.UseVisualStyleBackColor = false;
            this.LM830btnCerrarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnCerrarVenta.ForeColor = System.Drawing.Color.White;
            this.LM830btnCerrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnCerrarVenta.FlatAppearance.BorderSize = 0;
            this.LM830btnCerrarVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnCerrarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnCerrarVenta.Location = new System.Drawing.Point(560, 700);
            this.LM830btnCerrarVenta.Name = "LM830btnCerrarVenta";
            this.LM830btnCerrarVenta.Size = new System.Drawing.Size(120, 30);
            this.LM830btnCerrarVenta.TabIndex = 22;
            this.LM830btnCerrarVenta.Text = "Cerrar venta";
            this.LM830btnCerrarVenta.Click += new System.EventHandler(this.LM830btnCerrarVenta_Click);
            // 
            // btnVolver
            // 
            this.LM830btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnVolver.UseVisualStyleBackColor = true;
            this.LM830btnVolver.Location = new System.Drawing.Point(690, 700);
            this.LM830btnVolver.Name = "LM830btnVolver";
            this.LM830btnVolver.Size = new System.Drawing.Size(110, 30);
            this.LM830btnVolver.TabIndex = 23;
            this.LM830btnVolver.Text = "Volver";
            this.LM830btnVolver.Click += new System.EventHandler(this.LM830btnVolver_Click);
            // 
            // frmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(820, 750);
            this.Controls.Add(this.LM830pnlTitulo);
            this.Controls.Add(this.LM830grpCliente);
            this.Controls.Add(this.LM830grpProducto);
            this.Controls.Add(this.LM830dgvItems);
            this.Controls.Add(this.LM830btnQuitar);
            this.Controls.Add(this.LM830lblTotalTitulo);
            this.Controls.Add(this.LM830lblTotal);
            this.Controls.Add(this.LM830lblPuntosTitulo);
            this.Controls.Add(this.LM830lblPuntos);
            this.Controls.Add(this.LM830btnCerrarVenta);
            this.Controls.Add(this.LM830btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LM830frmVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar venta";
            this.Load += new System.EventHandler(this.LM830frmVenta_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LM830frmVenta_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.LM830nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvItems)).EndInit();
            this.LM830pnlTitulo.ResumeLayout(false);
            this.LM830pnlTitulo.PerformLayout();
            this.LM830grpCliente.ResumeLayout(false);
            this.LM830grpCliente.PerformLayout();
            this.LM830grpProducto.ResumeLayout(false);
            this.LM830grpProducto.PerformLayout();
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
        private System.Windows.Forms.GroupBox LM830grpProducto;
        private System.Windows.Forms.Label LM830lblProducto;
        private System.Windows.Forms.TextBox LM830txtProducto;
        private System.Windows.Forms.Button LM830btnBuscarProducto;
        private System.Windows.Forms.Label LM830lblProductoDatos;
        private System.Windows.Forms.Label LM830lblCantidad;
        private System.Windows.Forms.NumericUpDown LM830nudCantidad;
        private System.Windows.Forms.Button LM830btnAgregar;
        private System.Windows.Forms.DataGridView LM830dgvProductos;
        private System.Windows.Forms.DataGridView LM830dgvItems;
        private System.Windows.Forms.Button LM830btnQuitar;
        private System.Windows.Forms.Label LM830lblTotalTitulo;
        private System.Windows.Forms.Label LM830lblTotal;
        private System.Windows.Forms.Label LM830lblPuntosTitulo;
        private System.Windows.Forms.Label LM830lblPuntos;
        private System.Windows.Forms.Button LM830btnCerrarVenta;
        private System.Windows.Forms.Button LM830btnVolver;
    }
}
