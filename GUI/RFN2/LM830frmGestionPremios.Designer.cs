namespace LM830GUI.LM830RFN2
{
    partial class LM830frmGestionPremios
    {
        private System.ComponentModel.IContainer LM830components = null;
        protected override void Dispose(bool LM830disposing)
        {
            if (LM830disposing && (LM830components != null))
            {
                LM830components.Dispose();
            }
            base.Dispose(LM830disposing);
        }
        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.LM830pnlTitulo = new System.Windows.Forms.Panel();
            this.LM830lblTitulo = new System.Windows.Forms.Label();
            this.LM830dgvPremios = new System.Windows.Forms.DataGridView();
            this.LM830grpDatos = new System.Windows.Forms.GroupBox();
            this.LM830lblNombre = new System.Windows.Forms.Label();
            this.LM830txtNombre = new System.Windows.Forms.TextBox();
            this.LM830lblDescripcion = new System.Windows.Forms.Label();
            this.LM830txtDescripcion = new System.Windows.Forms.TextBox();
            this.LM830lblPuntos = new System.Windows.Forms.Label();
            this.LM830nudPuntos = new System.Windows.Forms.NumericUpDown();
            this.LM830lblStock = new System.Windows.Forms.Label();
            this.LM830nudStock = new System.Windows.Forms.NumericUpDown();
            this.LM830lblValor = new System.Windows.Forms.Label();
            this.LM830nudValor = new System.Windows.Forms.NumericUpDown();
            this.LM830btnAgregar = new System.Windows.Forms.Button();
            this.LM830btnModificar = new System.Windows.Forms.Button();
            this.LM830btnEliminar = new System.Windows.Forms.Button();
            this.LM830btnLimpiar = new System.Windows.Forms.Button();
            this.LM830btnVolver = new System.Windows.Forms.Button();
            this.LM830pnlTitulo.SuspendLayout();
            this.LM830grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvPremios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830nudPuntos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830nudStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830nudValor)).BeginInit();
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
            this.LM830lblTitulo.Text = "Administrar premios";
            //
            // dgvPremios
            //
            this.LM830dgvPremios.AllowUserToAddRows = false;
            this.LM830dgvPremios.AllowUserToDeleteRows = false;
            this.LM830dgvPremios.ReadOnly = true;
            this.LM830dgvPremios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LM830dgvPremios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LM830dgvPremios.MultiSelect = false;
            this.LM830dgvPremios.RowHeadersVisible = false;
            this.LM830dgvPremios.BackgroundColor = System.Drawing.Color.White;
            this.LM830dgvPremios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LM830dgvPremios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LM830dgvPremios.Location = new System.Drawing.Point(20, 60);
            this.LM830dgvPremios.Name = "LM830dgvPremios";
            this.LM830dgvPremios.Size = new System.Drawing.Size(740, 250);
            this.LM830dgvPremios.TabIndex = 2;
            this.LM830dgvPremios.SelectionChanged += new System.EventHandler(this.LM830dgvPremios_SelectionChanged);
            //
            // grpDatos
            //
            this.LM830grpDatos.Controls.Add(this.LM830lblNombre);
            this.LM830grpDatos.Controls.Add(this.LM830txtNombre);
            this.LM830grpDatos.Controls.Add(this.LM830lblDescripcion);
            this.LM830grpDatos.Controls.Add(this.LM830txtDescripcion);
            this.LM830grpDatos.Controls.Add(this.LM830lblPuntos);
            this.LM830grpDatos.Controls.Add(this.LM830nudPuntos);
            this.LM830grpDatos.Controls.Add(this.LM830lblStock);
            this.LM830grpDatos.Controls.Add(this.LM830nudStock);
            this.LM830grpDatos.Controls.Add(this.LM830lblValor);
            this.LM830grpDatos.Controls.Add(this.LM830nudValor);
            this.LM830grpDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830grpDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830grpDatos.Location = new System.Drawing.Point(20, 320);
            this.LM830grpDatos.Name = "LM830grpDatos";
            this.LM830grpDatos.Size = new System.Drawing.Size(740, 205);
            this.LM830grpDatos.TabIndex = 3;
            this.LM830grpDatos.Text = "Datos";
            //
            // lblNombre
            //
            this.LM830lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblNombre.ForeColor = System.Drawing.Color.Black;
            this.LM830lblNombre.Location = new System.Drawing.Point(15, 33);
            this.LM830lblNombre.Name = "LM830lblNombre";
            this.LM830lblNombre.Size = new System.Drawing.Size(160, 20);
            this.LM830lblNombre.TabIndex = 4;
            this.LM830lblNombre.Text = "Nombre";
            //
            // txtNombre
            //
            this.LM830txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtNombre.Location = new System.Drawing.Point(180, 30);
            this.LM830txtNombre.Name = "LM830txtNombre";
            this.LM830txtNombre.Size = new System.Drawing.Size(400, 22);
            this.LM830txtNombre.TabIndex = 5;
            this.LM830txtNombre.MaxLength = 100;
            //
            // lblDescripcion
            //
            this.LM830lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblDescripcion.ForeColor = System.Drawing.Color.Black;
            this.LM830lblDescripcion.Location = new System.Drawing.Point(15, 68);
            this.LM830lblDescripcion.Name = "LM830lblDescripcion";
            this.LM830lblDescripcion.Size = new System.Drawing.Size(160, 20);
            this.LM830lblDescripcion.TabIndex = 6;
            this.LM830lblDescripcion.Text = "Descripción";
            //
            // txtDescripcion
            //
            this.LM830txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtDescripcion.Location = new System.Drawing.Point(180, 65);
            this.LM830txtDescripcion.Name = "LM830txtDescripcion";
            this.LM830txtDescripcion.Size = new System.Drawing.Size(540, 22);
            this.LM830txtDescripcion.TabIndex = 7;
            this.LM830txtDescripcion.MaxLength = 200;
            //
            // lblPuntos
            //
            this.LM830lblPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblPuntos.ForeColor = System.Drawing.Color.Black;
            this.LM830lblPuntos.Location = new System.Drawing.Point(15, 103);
            this.LM830lblPuntos.Name = "LM830lblPuntos";
            this.LM830lblPuntos.Size = new System.Drawing.Size(160, 20);
            this.LM830lblPuntos.TabIndex = 8;
            this.LM830lblPuntos.Text = "Puntos requeridos";
            //
            // nudPuntos
            //
            this.LM830nudPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830nudPuntos.Location = new System.Drawing.Point(180, 100);
            this.LM830nudPuntos.Name = "LM830nudPuntos";
            this.LM830nudPuntos.Size = new System.Drawing.Size(150, 22);
            this.LM830nudPuntos.TabIndex = 9;
            this.LM830nudPuntos.DecimalPlaces = 0;
            this.LM830nudPuntos.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.LM830nudPuntos.ThousandsSeparator = true;
            //
            // lblStock
            //
            this.LM830lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblStock.ForeColor = System.Drawing.Color.Black;
            this.LM830lblStock.Location = new System.Drawing.Point(15, 138);
            this.LM830lblStock.Name = "LM830lblStock";
            this.LM830lblStock.Size = new System.Drawing.Size(160, 20);
            this.LM830lblStock.TabIndex = 10;
            this.LM830lblStock.Text = "Stock";
            //
            // nudStock
            //
            this.LM830nudStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830nudStock.Location = new System.Drawing.Point(180, 135);
            this.LM830nudStock.Name = "LM830nudStock";
            this.LM830nudStock.Size = new System.Drawing.Size(150, 22);
            this.LM830nudStock.TabIndex = 11;
            this.LM830nudStock.DecimalPlaces = 0;
            this.LM830nudStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.LM830nudStock.ThousandsSeparator = true;
            //
            // lblValor
            //
            this.LM830lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblValor.ForeColor = System.Drawing.Color.Black;
            this.LM830lblValor.Location = new System.Drawing.Point(15, 173);
            this.LM830lblValor.Name = "LM830lblValor";
            this.LM830lblValor.Size = new System.Drawing.Size(160, 20);
            this.LM830lblValor.TabIndex = 12;
            this.LM830lblValor.Text = "Valor de referencia";
            //
            // nudValor
            //
            this.LM830nudValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830nudValor.Location = new System.Drawing.Point(180, 170);
            this.LM830nudValor.Name = "LM830nudValor";
            this.LM830nudValor.Size = new System.Drawing.Size(150, 22);
            this.LM830nudValor.TabIndex = 13;
            this.LM830nudValor.DecimalPlaces = 2;
            this.LM830nudValor.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.LM830nudValor.ThousandsSeparator = true;
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
            this.LM830btnAgregar.Location = new System.Drawing.Point(20, 540);
            this.LM830btnAgregar.Name = "LM830btnAgregar";
            this.LM830btnAgregar.Size = new System.Drawing.Size(120, 30);
            this.LM830btnAgregar.TabIndex = 14;
            this.LM830btnAgregar.Text = "Agregar";
            this.LM830btnAgregar.Click += new System.EventHandler(this.LM830btnAgregar_Click);
            //
            // btnModificar
            //
            this.LM830btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnModificar.UseVisualStyleBackColor = false;
            this.LM830btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnModificar.ForeColor = System.Drawing.Color.White;
            this.LM830btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnModificar.FlatAppearance.BorderSize = 0;
            this.LM830btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnModificar.Location = new System.Drawing.Point(150, 540);
            this.LM830btnModificar.Name = "LM830btnModificar";
            this.LM830btnModificar.Size = new System.Drawing.Size(120, 30);
            this.LM830btnModificar.TabIndex = 15;
            this.LM830btnModificar.Text = "Modificar";
            this.LM830btnModificar.Click += new System.EventHandler(this.LM830btnModificar_Click);
            //
            // btnEliminar
            //
            this.LM830btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnEliminar.UseVisualStyleBackColor = false;
            this.LM830btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnEliminar.ForeColor = System.Drawing.Color.White;
            this.LM830btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnEliminar.FlatAppearance.BorderSize = 0;
            this.LM830btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnEliminar.Location = new System.Drawing.Point(280, 540);
            this.LM830btnEliminar.Name = "LM830btnEliminar";
            this.LM830btnEliminar.Size = new System.Drawing.Size(120, 30);
            this.LM830btnEliminar.TabIndex = 16;
            this.LM830btnEliminar.Text = "Eliminar";
            this.LM830btnEliminar.Click += new System.EventHandler(this.LM830btnEliminar_Click);
            //
            // btnLimpiar
            //
            this.LM830btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnLimpiar.UseVisualStyleBackColor = true;
            this.LM830btnLimpiar.Location = new System.Drawing.Point(410, 540);
            this.LM830btnLimpiar.Name = "LM830btnLimpiar";
            this.LM830btnLimpiar.Size = new System.Drawing.Size(120, 30);
            this.LM830btnLimpiar.TabIndex = 17;
            this.LM830btnLimpiar.Text = "Limpiar";
            this.LM830btnLimpiar.Click += new System.EventHandler(this.LM830btnLimpiar_Click);
            //
            // btnVolver
            //
            this.LM830btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnVolver.UseVisualStyleBackColor = true;
            this.LM830btnVolver.Location = new System.Drawing.Point(660, 540);
            this.LM830btnVolver.Name = "LM830btnVolver";
            this.LM830btnVolver.Size = new System.Drawing.Size(100, 30);
            this.LM830btnVolver.TabIndex = 18;
            this.LM830btnVolver.Text = "Volver";
            this.LM830btnVolver.Click += new System.EventHandler(this.LM830btnVolver_Click);
            //
            // frmGestionPremios
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 590);
            this.Controls.Add(this.LM830pnlTitulo);
            this.Controls.Add(this.LM830dgvPremios);
            this.Controls.Add(this.LM830grpDatos);
            this.Controls.Add(this.LM830btnAgregar);
            this.Controls.Add(this.LM830btnModificar);
            this.Controls.Add(this.LM830btnEliminar);
            this.Controls.Add(this.LM830btnLimpiar);
            this.Controls.Add(this.LM830btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LM830frmGestionPremios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar premios";
            this.Load += new System.EventHandler(this.LM830frmGestionPremios_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LM830frmGestionPremios_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvPremios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830nudPuntos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830nudStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LM830nudValor)).EndInit();
            this.LM830pnlTitulo.ResumeLayout(false);
            this.LM830pnlTitulo.PerformLayout();
            this.LM830grpDatos.ResumeLayout(false);
            this.LM830grpDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LM830pnlTitulo;
        private System.Windows.Forms.Label LM830lblTitulo;
        private System.Windows.Forms.DataGridView LM830dgvPremios;
        private System.Windows.Forms.GroupBox LM830grpDatos;
        private System.Windows.Forms.Label LM830lblNombre;
        private System.Windows.Forms.TextBox LM830txtNombre;
        private System.Windows.Forms.Label LM830lblDescripcion;
        private System.Windows.Forms.TextBox LM830txtDescripcion;
        private System.Windows.Forms.Label LM830lblPuntos;
        private System.Windows.Forms.NumericUpDown LM830nudPuntos;
        private System.Windows.Forms.Label LM830lblStock;
        private System.Windows.Forms.NumericUpDown LM830nudStock;
        private System.Windows.Forms.Label LM830lblValor;
        private System.Windows.Forms.NumericUpDown LM830nudValor;
        private System.Windows.Forms.Button LM830btnAgregar;
        private System.Windows.Forms.Button LM830btnModificar;
        private System.Windows.Forms.Button LM830btnEliminar;
        private System.Windows.Forms.Button LM830btnLimpiar;
        private System.Windows.Forms.Button LM830btnVolver;
    }
}
