namespace LM830GUI.LM830RFN2
{
    partial class LM830frmEntregarPremio
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
            this.LM830lblDni = new System.Windows.Forms.Label();
            this.LM830txtDni = new System.Windows.Forms.TextBox();
            this.LM830btnBuscar = new System.Windows.Forms.Button();
            this.LM830btnTodos = new System.Windows.Forms.Button();
            this.LM830lblAutorizados = new System.Windows.Forms.Label();
            this.LM830dgvAutorizados = new System.Windows.Forms.DataGridView();
            this.LM830grpDetalle = new System.Windows.Forms.GroupBox();
            this.LM830lblClienteDatos = new System.Windows.Forms.Label();
            this.LM830lblPremioDatos = new System.Windows.Forms.Label();
            this.LM830lblSaldoDatos = new System.Windows.Forms.Label();
            this.LM830btnEntregar = new System.Windows.Forms.Button();
            this.LM830btnVolver = new System.Windows.Forms.Button();
            this.LM830pnlTitulo.SuspendLayout();
            this.LM830grpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvAutorizados)).BeginInit();
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
            this.LM830lblTitulo.Text = "Entregar premio";
            // 
            // lblDni
            // 
            this.LM830lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblDni.Location = new System.Drawing.Point(20, 66);
            this.LM830lblDni.Name = "LM830lblDni";
            this.LM830lblDni.Size = new System.Drawing.Size(40, 20);
            this.LM830lblDni.TabIndex = 2;
            this.LM830lblDni.Text = "DNI";
            // 
            // txtDni
            // 
            this.LM830txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtDni.MaxLength = 8;
            this.LM830txtDni.Location = new System.Drawing.Point(65, 63);
            this.LM830txtDni.Name = "LM830txtDni";
            this.LM830txtDni.Size = new System.Drawing.Size(130, 22);
            this.LM830txtDni.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.LM830btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnBuscar.UseVisualStyleBackColor = false;
            this.LM830btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnBuscar.ForeColor = System.Drawing.Color.White;
            this.LM830btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnBuscar.FlatAppearance.BorderSize = 0;
            this.LM830btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnBuscar.Location = new System.Drawing.Point(205, 59);
            this.LM830btnBuscar.Name = "LM830btnBuscar";
            this.LM830btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.LM830btnBuscar.TabIndex = 4;
            this.LM830btnBuscar.Text = "Buscar";
            this.LM830btnBuscar.Click += new System.EventHandler(this.LM830btnBuscar_Click);
            // 
            // btnTodos
            // 
            this.LM830btnTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnTodos.UseVisualStyleBackColor = true;
            this.LM830btnTodos.Location = new System.Drawing.Point(315, 59);
            this.LM830btnTodos.Name = "LM830btnTodos";
            this.LM830btnTodos.Size = new System.Drawing.Size(100, 30);
            this.LM830btnTodos.TabIndex = 5;
            this.LM830btnTodos.Text = "Ver todos";
            this.LM830btnTodos.Click += new System.EventHandler(this.LM830btnTodos_Click);
            // 
            // lblAutorizados
            // 
            this.LM830lblAutorizados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblAutorizados.Location = new System.Drawing.Point(20, 100);
            this.LM830lblAutorizados.Name = "LM830lblAutorizados";
            this.LM830lblAutorizados.Size = new System.Drawing.Size(500, 20);
            this.LM830lblAutorizados.TabIndex = 6;
            this.LM830lblAutorizados.Text = "Canjes autorizados para entregar";
            // 
            // dgvAutorizados
            // 
            this.LM830dgvAutorizados.AllowUserToAddRows = false;
            this.LM830dgvAutorizados.AllowUserToDeleteRows = false;
            this.LM830dgvAutorizados.ReadOnly = true;
            this.LM830dgvAutorizados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LM830dgvAutorizados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LM830dgvAutorizados.MultiSelect = false;
            this.LM830dgvAutorizados.RowHeadersVisible = false;
            this.LM830dgvAutorizados.BackgroundColor = System.Drawing.Color.White;
            this.LM830dgvAutorizados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LM830dgvAutorizados.EnableHeadersVisualStyles = false;
            this.LM830dgvAutorizados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.LM830dgvAutorizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LM830dgvAutorizados.Location = new System.Drawing.Point(20, 125);
            this.LM830dgvAutorizados.Name = "LM830dgvAutorizados";
            this.LM830dgvAutorizados.Size = new System.Drawing.Size(820, 250);
            this.LM830dgvAutorizados.TabIndex = 7;
            this.LM830dgvAutorizados.SelectionChanged += new System.EventHandler(this.LM830dgvAutorizados_SelectionChanged);
            // 
            // grpDetalle
            // 
            this.LM830grpDetalle.Controls.Add(this.LM830lblClienteDatos);
            this.LM830grpDetalle.Controls.Add(this.LM830lblPremioDatos);
            this.LM830grpDetalle.Controls.Add(this.LM830lblSaldoDatos);
            this.LM830grpDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830grpDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830grpDetalle.Location = new System.Drawing.Point(20, 385);
            this.LM830grpDetalle.Name = "LM830grpDetalle";
            this.LM830grpDetalle.Size = new System.Drawing.Size(820, 115);
            this.LM830grpDetalle.TabIndex = 8;
            this.LM830grpDetalle.Text = "Detalle";
            // 
            // lblClienteDatos
            // 
            this.LM830lblClienteDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblClienteDatos.Location = new System.Drawing.Point(15, 25);
            this.LM830lblClienteDatos.Name = "LM830lblClienteDatos";
            this.LM830lblClienteDatos.Size = new System.Drawing.Size(790, 20);
            this.LM830lblClienteDatos.TabIndex = 9;
            this.LM830lblClienteDatos.Text = "-";
            // 
            // lblPremioDatos
            // 
            this.LM830lblPremioDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblPremioDatos.Location = new System.Drawing.Point(15, 55);
            this.LM830lblPremioDatos.Name = "LM830lblPremioDatos";
            this.LM830lblPremioDatos.Size = new System.Drawing.Size(790, 20);
            this.LM830lblPremioDatos.TabIndex = 10;
            this.LM830lblPremioDatos.Text = "-";
            // 
            // lblSaldoDatos
            // 
            this.LM830lblSaldoDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblSaldoDatos.Location = new System.Drawing.Point(15, 85);
            this.LM830lblSaldoDatos.Name = "LM830lblSaldoDatos";
            this.LM830lblSaldoDatos.Size = new System.Drawing.Size(790, 20);
            this.LM830lblSaldoDatos.TabIndex = 11;
            this.LM830lblSaldoDatos.Text = "-";
            // 
            // btnEntregar
            // 
            this.LM830btnEntregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnEntregar.UseVisualStyleBackColor = false;
            this.LM830btnEntregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnEntregar.ForeColor = System.Drawing.Color.White;
            this.LM830btnEntregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnEntregar.FlatAppearance.BorderSize = 0;
            this.LM830btnEntregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnEntregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnEntregar.Location = new System.Drawing.Point(560, 545);
            this.LM830btnEntregar.Name = "LM830btnEntregar";
            this.LM830btnEntregar.Size = new System.Drawing.Size(160, 30);
            this.LM830btnEntregar.TabIndex = 12;
            this.LM830btnEntregar.Text = "Entregar premio";
            this.LM830btnEntregar.Click += new System.EventHandler(this.LM830btnEntregar_Click);
            // 
            // btnVolver
            // 
            this.LM830btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnVolver.UseVisualStyleBackColor = true;
            this.LM830btnVolver.Location = new System.Drawing.Point(730, 545);
            this.LM830btnVolver.Name = "LM830btnVolver";
            this.LM830btnVolver.Size = new System.Drawing.Size(110, 30);
            this.LM830btnVolver.TabIndex = 13;
            this.LM830btnVolver.Text = "Volver";
            this.LM830btnVolver.Click += new System.EventHandler(this.LM830btnVolver_Click);
            // 
            // frmEntregarPremio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 600);
            this.Controls.Add(this.LM830pnlTitulo);
            this.Controls.Add(this.LM830lblDni);
            this.Controls.Add(this.LM830txtDni);
            this.Controls.Add(this.LM830btnBuscar);
            this.Controls.Add(this.LM830btnTodos);
            this.Controls.Add(this.LM830lblAutorizados);
            this.Controls.Add(this.LM830dgvAutorizados);
            this.Controls.Add(this.LM830grpDetalle);
            this.Controls.Add(this.LM830btnEntregar);
            this.Controls.Add(this.LM830btnVolver);
            this.AcceptButton = this.LM830btnBuscar;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LM830frmEntregarPremio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entregar premio";
            this.Load += new System.EventHandler(this.LM830frmEntregarPremio_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LM830frmEntregarPremio_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvAutorizados)).EndInit();
            this.LM830pnlTitulo.ResumeLayout(false);
            this.LM830pnlTitulo.PerformLayout();
            this.LM830grpDetalle.ResumeLayout(false);
            this.LM830grpDetalle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LM830pnlTitulo;
        private System.Windows.Forms.Label LM830lblTitulo;
        private System.Windows.Forms.Label LM830lblDni;
        private System.Windows.Forms.TextBox LM830txtDni;
        private System.Windows.Forms.Button LM830btnBuscar;
        private System.Windows.Forms.Button LM830btnTodos;
        private System.Windows.Forms.Label LM830lblAutorizados;
        private System.Windows.Forms.DataGridView LM830dgvAutorizados;
        private System.Windows.Forms.GroupBox LM830grpDetalle;
        private System.Windows.Forms.Label LM830lblClienteDatos;
        private System.Windows.Forms.Label LM830lblPremioDatos;
        private System.Windows.Forms.Label LM830lblSaldoDatos;
        private System.Windows.Forms.Button LM830btnEntregar;
        private System.Windows.Forms.Button LM830btnVolver;
    }
}
