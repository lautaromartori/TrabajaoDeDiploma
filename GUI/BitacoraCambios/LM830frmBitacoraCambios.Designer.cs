namespace LM830GUI.LM830BitacoraCambios
{
    partial class LM830frmBitacoraCambios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer LM830components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.LM830lblFiltro = new System.Windows.Forms.Label();
            this.LM830txtFiltro = new System.Windows.Forms.TextBox();
            this.LM830lblDesde = new System.Windows.Forms.Label();
            this.LM830dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.LM830lblHasta = new System.Windows.Forms.Label();
            this.LM830dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.LM830btnBuscar = new System.Windows.Forms.Button();
            this.LM830dgvVersiones = new System.Windows.Forms.DataGridView();
            this.LM830btnLimpiar = new System.Windows.Forms.Button();
            this.LM830btnRestaurar = new System.Windows.Forms.Button();
            this.LM830btnVolver = new System.Windows.Forms.Button();
            this.LM830pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvVersiones)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.LM830pnlTitulo.Controls.Add(this.LM830lblTitulo);
            this.LM830pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LM830pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.LM830pnlTitulo.Name = "LM830pnlTitulo";
            this.LM830pnlTitulo.Size = new System.Drawing.Size(900, 45);
            this.LM830pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.LM830lblTitulo.AutoSize = true;
            this.LM830lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblTitulo.ForeColor = System.Drawing.Color.White;
            this.LM830lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.LM830lblTitulo.Name = "LM830lblTitulo";
            this.LM830lblTitulo.TabIndex = 1;
            this.LM830lblTitulo.Text = "Bitácora de cambios";
            // 
            // lblFiltro
            // 
            this.LM830lblFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblFiltro.Location = new System.Drawing.Point(30, 62);
            this.LM830lblFiltro.Name = "LM830lblFiltro";
            this.LM830lblFiltro.Size = new System.Drawing.Size(120, 20);
            this.LM830lblFiltro.TabIndex = 4;
            this.LM830lblFiltro.Text = "DNI";
            // 
            // lblDesde
            // 
            this.LM830lblDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblDesde.Location = new System.Drawing.Point(310, 62);
            this.LM830lblDesde.Name = "LM830lblDesde";
            this.LM830lblDesde.Size = new System.Drawing.Size(55, 20);
            this.LM830lblDesde.TabIndex = 6;
            this.LM830lblDesde.Text = "Desde";
            // 
            // lblHasta
            // 
            this.LM830lblHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblHasta.Location = new System.Drawing.Point(495, 62);
            this.LM830lblHasta.Name = "LM830lblHasta";
            this.LM830lblHasta.Size = new System.Drawing.Size(50, 20);
            this.LM830lblHasta.TabIndex = 8;
            this.LM830lblHasta.Text = "Hasta";
            // 
            // txtFiltro
            // 
            this.LM830txtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtFiltro.Location = new System.Drawing.Point(155, 60);
            this.LM830txtFiltro.Name = "LM830txtFiltro";
            this.LM830txtFiltro.Size = new System.Drawing.Size(140, 22);
            this.LM830txtFiltro.TabIndex = 5;
            // 
            // dtpDesde
            // 
            this.LM830dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.LM830dtpDesde.Location = new System.Drawing.Point(365, 60);
            this.LM830dtpDesde.Name = "LM830dtpDesde";
            this.LM830dtpDesde.Size = new System.Drawing.Size(115, 22);
            this.LM830dtpDesde.TabIndex = 7;
            // 
            // dtpHasta
            // 
            this.LM830dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.LM830dtpHasta.Location = new System.Drawing.Point(545, 60);
            this.LM830dtpHasta.Name = "LM830dtpHasta";
            this.LM830dtpHasta.Size = new System.Drawing.Size(115, 22);
            this.LM830dtpHasta.TabIndex = 9;
            // 
            // btnBuscar
            // 
            this.LM830btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnBuscar.FlatAppearance.BorderSize = 0;
            this.LM830btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnBuscar.ForeColor = System.Drawing.Color.White;
            this.LM830btnBuscar.Location = new System.Drawing.Point(675, 56);
            this.LM830btnBuscar.Name = "LM830btnBuscar";
            this.LM830btnBuscar.Size = new System.Drawing.Size(95, 30);
            this.LM830btnBuscar.TabIndex = 10;
            this.LM830btnBuscar.Text = "Buscar";
            this.LM830btnBuscar.UseVisualStyleBackColor = false;
            this.LM830btnBuscar.Click += new System.EventHandler(this.LM830btnBuscar_Click);
            // 
            // dgvVersiones
            // 
            this.LM830dgvVersiones.AllowUserToAddRows = false;
            this.LM830dgvVersiones.AllowUserToDeleteRows = false;
            this.LM830dgvVersiones.ReadOnly = true;
            this.LM830dgvVersiones.MultiSelect = false;
            this.LM830dgvVersiones.RowHeadersVisible = false;
            this.LM830dgvVersiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LM830dgvVersiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LM830dgvVersiones.BackgroundColor = System.Drawing.Color.White;
            this.LM830dgvVersiones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LM830dgvVersiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LM830dgvVersiones.Location = new System.Drawing.Point(30, 102);
            this.LM830dgvVersiones.Name = "LM830dgvVersiones";
            this.LM830dgvVersiones.Size = new System.Drawing.Size(840, 368);
            this.LM830dgvVersiones.TabIndex = 12;
            // 
            // btnLimpiar
            // 
            this.LM830btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnLimpiar.FlatAppearance.BorderSize = 0;
            this.LM830btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.LM830btnLimpiar.Location = new System.Drawing.Point(780, 56);
            this.LM830btnLimpiar.Name = "LM830btnLimpiar";
            this.LM830btnLimpiar.Size = new System.Drawing.Size(90, 30);
            this.LM830btnLimpiar.TabIndex = 11;
            this.LM830btnLimpiar.Text = "Limpiar";
            this.LM830btnLimpiar.UseVisualStyleBackColor = false;
            this.LM830btnLimpiar.Click += new System.EventHandler(this.LM830btnLimpiar_Click);
            // 
            // btnRestaurar
            // 
            this.LM830btnRestaurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnRestaurar.FlatAppearance.BorderSize = 0;
            this.LM830btnRestaurar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnRestaurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnRestaurar.ForeColor = System.Drawing.Color.White;
            this.LM830btnRestaurar.Location = new System.Drawing.Point(30, 485);
            this.LM830btnRestaurar.Name = "LM830btnRestaurar";
            this.LM830btnRestaurar.Size = new System.Drawing.Size(180, 30);
            this.LM830btnRestaurar.TabIndex = 13;
            this.LM830btnRestaurar.Text = "Restaurar versión";
            this.LM830btnRestaurar.UseVisualStyleBackColor = false;
            this.LM830btnRestaurar.Click += new System.EventHandler(this.LM830btnRestaurar_Click);
            // 
            // btnVolver
            // 
            this.LM830btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnVolver.FlatAppearance.BorderSize = 0;
            this.LM830btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnVolver.ForeColor = System.Drawing.Color.White;
            this.LM830btnVolver.Location = new System.Drawing.Point(740, 485);
            this.LM830btnVolver.Name = "LM830btnVolver";
            this.LM830btnVolver.Size = new System.Drawing.Size(130, 30);
            this.LM830btnVolver.TabIndex = 14;
            this.LM830btnVolver.Text = "Volver";
            this.LM830btnVolver.UseVisualStyleBackColor = false;
            this.LM830btnVolver.Click += new System.EventHandler(this.LM830btnVolver_Click);
            // 
            // frmBitacoraCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 535);
            this.Controls.Add(this.LM830btnVolver);
            this.Controls.Add(this.LM830btnRestaurar);
            this.Controls.Add(this.LM830dgvVersiones);
            this.Controls.Add(this.LM830btnLimpiar);
            this.Controls.Add(this.LM830btnBuscar);
            this.Controls.Add(this.LM830dtpHasta);
            this.Controls.Add(this.LM830lblHasta);
            this.Controls.Add(this.LM830dtpDesde);
            this.Controls.Add(this.LM830lblDesde);
            this.Controls.Add(this.LM830txtFiltro);
            this.Controls.Add(this.LM830lblFiltro);
            this.Controls.Add(this.LM830pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LM830frmBitacoraCambios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitácora de cambios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LM830frmBitacoraCambios_FormClosed);
            this.Load += new System.EventHandler(this.LM830frmBitacoraCambios_Load);
            this.LM830pnlTitulo.ResumeLayout(false);
            this.LM830pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvVersiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel LM830pnlTitulo;
        private System.Windows.Forms.Label LM830lblTitulo;
        private System.Windows.Forms.Label LM830lblFiltro;
        private System.Windows.Forms.TextBox LM830txtFiltro;
        private System.Windows.Forms.Label LM830lblDesde;
        private System.Windows.Forms.DateTimePicker LM830dtpDesde;
        private System.Windows.Forms.Label LM830lblHasta;
        private System.Windows.Forms.DateTimePicker LM830dtpHasta;
        private System.Windows.Forms.Button LM830btnBuscar;
        private System.Windows.Forms.DataGridView LM830dgvVersiones;
        private System.Windows.Forms.Button LM830btnLimpiar;
        private System.Windows.Forms.Button LM830btnRestaurar;
        private System.Windows.Forms.Button LM830btnVolver;
    }
}
