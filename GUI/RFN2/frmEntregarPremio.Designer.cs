namespace GUI.RFN2
{
    partial class frmEntregarPremio
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
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnTodos = new System.Windows.Forms.Button();
            this.lblAutorizados = new System.Windows.Forms.Label();
            this.dgvAutorizados = new System.Windows.Forms.DataGridView();
            this.grpDetalle = new System.Windows.Forms.GroupBox();
            this.lblClienteDatos = new System.Windows.Forms.Label();
            this.lblPremioDatos = new System.Windows.Forms.Label();
            this.lblSaldoDatos = new System.Windows.Forms.Label();
            this.btnEntregar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pnlTitulo.SuspendLayout();
            this.grpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutorizados)).BeginInit();
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
            this.lblTitulo.Text = "Entregar premio";
            // 
            // lblDni
            // 
            this.lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDni.Location = new System.Drawing.Point(20, 66);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(40, 20);
            this.lblDni.TabIndex = 2;
            this.lblDni.Text = "DNI";
            // 
            // txtDni
            // 
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDni.MaxLength = 8;
            this.txtDni.Location = new System.Drawing.Point(65, 63);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(130, 22);
            this.txtDni.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Location = new System.Drawing.Point(205, 59);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnTodos
            // 
            this.btnTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Location = new System.Drawing.Point(315, 59);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(100, 30);
            this.btnTodos.TabIndex = 5;
            this.btnTodos.Text = "Ver todos";
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // lblAutorizados
            // 
            this.lblAutorizados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutorizados.Location = new System.Drawing.Point(20, 100);
            this.lblAutorizados.Name = "lblAutorizados";
            this.lblAutorizados.Size = new System.Drawing.Size(500, 20);
            this.lblAutorizados.TabIndex = 6;
            this.lblAutorizados.Text = "Canjes autorizados para entregar";
            // 
            // dgvAutorizados
            // 
            this.dgvAutorizados.AllowUserToAddRows = false;
            this.dgvAutorizados.AllowUserToDeleteRows = false;
            this.dgvAutorizados.ReadOnly = true;
            this.dgvAutorizados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAutorizados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAutorizados.MultiSelect = false;
            this.dgvAutorizados.RowHeadersVisible = false;
            this.dgvAutorizados.BackgroundColor = System.Drawing.Color.White;
            this.dgvAutorizados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvAutorizados.EnableHeadersVisualStyles = false;
            this.dgvAutorizados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.dgvAutorizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutorizados.Location = new System.Drawing.Point(20, 125);
            this.dgvAutorizados.Name = "dgvAutorizados";
            this.dgvAutorizados.Size = new System.Drawing.Size(820, 250);
            this.dgvAutorizados.TabIndex = 7;
            this.dgvAutorizados.SelectionChanged += new System.EventHandler(this.dgvAutorizados_SelectionChanged);
            // 
            // grpDetalle
            // 
            this.grpDetalle.Controls.Add(this.lblClienteDatos);
            this.grpDetalle.Controls.Add(this.lblPremioDatos);
            this.grpDetalle.Controls.Add(this.lblSaldoDatos);
            this.grpDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.grpDetalle.Location = new System.Drawing.Point(20, 385);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Size = new System.Drawing.Size(820, 115);
            this.grpDetalle.TabIndex = 8;
            this.grpDetalle.Text = "Detalle";
            // 
            // lblClienteDatos
            // 
            this.lblClienteDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteDatos.Location = new System.Drawing.Point(15, 25);
            this.lblClienteDatos.Name = "lblClienteDatos";
            this.lblClienteDatos.Size = new System.Drawing.Size(790, 20);
            this.lblClienteDatos.TabIndex = 9;
            this.lblClienteDatos.Text = "-";
            // 
            // lblPremioDatos
            // 
            this.lblPremioDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPremioDatos.Location = new System.Drawing.Point(15, 55);
            this.lblPremioDatos.Name = "lblPremioDatos";
            this.lblPremioDatos.Size = new System.Drawing.Size(790, 20);
            this.lblPremioDatos.TabIndex = 10;
            this.lblPremioDatos.Text = "-";
            // 
            // lblSaldoDatos
            // 
            this.lblSaldoDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoDatos.Location = new System.Drawing.Point(15, 85);
            this.lblSaldoDatos.Name = "lblSaldoDatos";
            this.lblSaldoDatos.Size = new System.Drawing.Size(790, 20);
            this.lblSaldoDatos.TabIndex = 11;
            this.lblSaldoDatos.Text = "-";
            // 
            // btnEntregar
            // 
            this.btnEntregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntregar.UseVisualStyleBackColor = false;
            this.btnEntregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnEntregar.ForeColor = System.Drawing.Color.White;
            this.btnEntregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntregar.FlatAppearance.BorderSize = 0;
            this.btnEntregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnEntregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntregar.Location = new System.Drawing.Point(560, 545);
            this.btnEntregar.Name = "btnEntregar";
            this.btnEntregar.Size = new System.Drawing.Size(160, 30);
            this.btnEntregar.TabIndex = 12;
            this.btnEntregar.Text = "Entregar premio";
            this.btnEntregar.Click += new System.EventHandler(this.btnEntregar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Location = new System.Drawing.Point(730, 545);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(110, 30);
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmEntregarPremio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 600);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.lblAutorizados);
            this.Controls.Add(this.dgvAutorizados);
            this.Controls.Add(this.grpDetalle);
            this.Controls.Add(this.btnEntregar);
            this.Controls.Add(this.btnVolver);
            this.AcceptButton = this.btnBuscar;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmEntregarPremio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entregar premio";
            this.Load += new System.EventHandler(this.frmEntregarPremio_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEntregarPremio_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutorizados)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpDetalle.ResumeLayout(false);
            this.grpDetalle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.Label lblAutorizados;
        private System.Windows.Forms.DataGridView dgvAutorizados;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.Label lblClienteDatos;
        private System.Windows.Forms.Label lblPremioDatos;
        private System.Windows.Forms.Label lblSaldoDatos;
        private System.Windows.Forms.Button btnEntregar;
        private System.Windows.Forms.Button btnVolver;
    }
}
