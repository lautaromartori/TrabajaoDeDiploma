namespace LM830GUI.LM830RFN1
{
    partial class LM830frmComprobantes
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
            this.LM830lblNro = new System.Windows.Forms.Label();
            this.LM830txtNro = new System.Windows.Forms.TextBox();
            this.LM830btnBuscar = new System.Windows.Forms.Button();
            this.LM830btnImportar = new System.Windows.Forms.Button();
            this.LM830grpDatos = new System.Windows.Forms.GroupBox();
            this.LM830lblNroDatos = new System.Windows.Forms.Label();
            this.LM830lblFechaDatos = new System.Windows.Forms.Label();
            this.LM830lblClienteDatos = new System.Windows.Forms.Label();
            this.LM830lblTotalesDatos = new System.Windows.Forms.Label();
            this.LM830lblOrigen = new System.Windows.Forms.Label();
            this.LM830dgvItems = new System.Windows.Forms.DataGridView();
            this.LM830btnPdf = new System.Windows.Forms.Button();
            this.LM830btnXml = new System.Windows.Forms.Button();
            this.LM830btnJson = new System.Windows.Forms.Button();
            this.LM830btnVolver = new System.Windows.Forms.Button();
            this.LM830pnlTitulo.SuspendLayout();
            this.LM830grpDatos.SuspendLayout();
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
            this.LM830lblTitulo.Text = "Comprobantes";
            // 
            // lblNro
            // 
            this.LM830lblNro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblNro.Location = new System.Drawing.Point(20, 65);
            this.LM830lblNro.Name = "LM830lblNro";
            this.LM830lblNro.Size = new System.Drawing.Size(120, 20);
            this.LM830lblNro.TabIndex = 2;
            this.LM830lblNro.Text = "Nro. comprobante";
            // 
            // txtNro
            // 
            this.LM830txtNro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830txtNro.MaxLength = 20;
            this.LM830txtNro.Location = new System.Drawing.Point(145, 62);
            this.LM830txtNro.Name = "LM830txtNro";
            this.LM830txtNro.Size = new System.Drawing.Size(160, 22);
            this.LM830txtNro.TabIndex = 3;
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
            this.LM830btnBuscar.Location = new System.Drawing.Point(315, 58);
            this.LM830btnBuscar.Name = "LM830btnBuscar";
            this.LM830btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.LM830btnBuscar.TabIndex = 4;
            this.LM830btnBuscar.Text = "Buscar";
            this.LM830btnBuscar.Click += new System.EventHandler(this.LM830btnBuscar_Click);
            // 
            // btnImportar
            // 
            this.LM830btnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnImportar.UseVisualStyleBackColor = true;
            this.LM830btnImportar.Location = new System.Drawing.Point(580, 58);
            this.LM830btnImportar.Name = "LM830btnImportar";
            this.LM830btnImportar.Size = new System.Drawing.Size(220, 30);
            this.LM830btnImportar.TabIndex = 5;
            this.LM830btnImportar.Text = "Abrir archivo (XML / JSON)";
            this.LM830btnImportar.Click += new System.EventHandler(this.LM830btnImportar_Click);
            // 
            // grpDatos
            // 
            this.LM830grpDatos.Controls.Add(this.LM830lblNroDatos);
            this.LM830grpDatos.Controls.Add(this.LM830lblFechaDatos);
            this.LM830grpDatos.Controls.Add(this.LM830lblClienteDatos);
            this.LM830grpDatos.Controls.Add(this.LM830lblTotalesDatos);
            this.LM830grpDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830grpDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830grpDatos.Location = new System.Drawing.Point(20, 100);
            this.LM830grpDatos.Name = "LM830grpDatos";
            this.LM830grpDatos.Size = new System.Drawing.Size(780, 125);
            this.LM830grpDatos.TabIndex = 6;
            this.LM830grpDatos.Text = "Comprobante";
            // 
            // lblNroDatos
            // 
            this.LM830lblNroDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblNroDatos.Location = new System.Drawing.Point(15, 25);
            this.LM830lblNroDatos.Name = "LM830lblNroDatos";
            this.LM830lblNroDatos.Size = new System.Drawing.Size(750, 20);
            this.LM830lblNroDatos.TabIndex = 7;
            this.LM830lblNroDatos.Text = "-";
            // 
            // lblFechaDatos
            // 
            this.LM830lblFechaDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblFechaDatos.Location = new System.Drawing.Point(15, 50);
            this.LM830lblFechaDatos.Name = "LM830lblFechaDatos";
            this.LM830lblFechaDatos.Size = new System.Drawing.Size(750, 20);
            this.LM830lblFechaDatos.TabIndex = 8;
            this.LM830lblFechaDatos.Text = "-";
            // 
            // lblClienteDatos
            // 
            this.LM830lblClienteDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblClienteDatos.Location = new System.Drawing.Point(15, 75);
            this.LM830lblClienteDatos.Name = "LM830lblClienteDatos";
            this.LM830lblClienteDatos.Size = new System.Drawing.Size(750, 20);
            this.LM830lblClienteDatos.TabIndex = 9;
            this.LM830lblClienteDatos.Text = "-";
            // 
            // lblTotalesDatos
            // 
            this.LM830lblTotalesDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblTotalesDatos.Location = new System.Drawing.Point(15, 100);
            this.LM830lblTotalesDatos.Name = "LM830lblTotalesDatos";
            this.LM830lblTotalesDatos.Size = new System.Drawing.Size(750, 20);
            this.LM830lblTotalesDatos.TabIndex = 10;
            this.LM830lblTotalesDatos.Text = "-";
            // 
            // lblOrigen
            // 
            this.LM830lblOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830lblOrigen.ForeColor = System.Drawing.Color.DimGray;
            this.LM830lblOrigen.Location = new System.Drawing.Point(20, 232);
            this.LM830lblOrigen.Name = "LM830lblOrigen";
            this.LM830lblOrigen.Size = new System.Drawing.Size(780, 20);
            this.LM830lblOrigen.TabIndex = 11;
            this.LM830lblOrigen.Text = "";
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
            this.LM830dgvItems.Location = new System.Drawing.Point(20, 255);
            this.LM830dgvItems.Name = "LM830dgvItems";
            this.LM830dgvItems.Size = new System.Drawing.Size(780, 315);
            this.LM830dgvItems.TabIndex = 12;
            // 
            // btnPdf
            // 
            this.LM830btnPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnPdf.UseVisualStyleBackColor = false;
            this.LM830btnPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.LM830btnPdf.ForeColor = System.Drawing.Color.White;
            this.LM830btnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LM830btnPdf.FlatAppearance.BorderSize = 0;
            this.LM830btnPdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.LM830btnPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LM830btnPdf.Location = new System.Drawing.Point(20, 595);
            this.LM830btnPdf.Name = "LM830btnPdf";
            this.LM830btnPdf.Size = new System.Drawing.Size(150, 30);
            this.LM830btnPdf.TabIndex = 13;
            this.LM830btnPdf.Text = "Generar PDF";
            this.LM830btnPdf.Click += new System.EventHandler(this.LM830btnPdf_Click);
            // 
            // btnXml
            // 
            this.LM830btnXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnXml.UseVisualStyleBackColor = true;
            this.LM830btnXml.Location = new System.Drawing.Point(180, 595);
            this.LM830btnXml.Name = "LM830btnXml";
            this.LM830btnXml.Size = new System.Drawing.Size(150, 30);
            this.LM830btnXml.TabIndex = 14;
            this.LM830btnXml.Text = "Exportar XML";
            this.LM830btnXml.Click += new System.EventHandler(this.LM830btnXml_Click);
            // 
            // btnJson
            // 
            this.LM830btnJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnJson.UseVisualStyleBackColor = true;
            this.LM830btnJson.Location = new System.Drawing.Point(340, 595);
            this.LM830btnJson.Name = "LM830btnJson";
            this.LM830btnJson.Size = new System.Drawing.Size(150, 30);
            this.LM830btnJson.TabIndex = 15;
            this.LM830btnJson.Text = "Exportar JSON";
            this.LM830btnJson.Click += new System.EventHandler(this.LM830btnJson_Click);
            // 
            // btnVolver
            // 
            this.LM830btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LM830btnVolver.UseVisualStyleBackColor = true;
            this.LM830btnVolver.Location = new System.Drawing.Point(690, 595);
            this.LM830btnVolver.Name = "LM830btnVolver";
            this.LM830btnVolver.Size = new System.Drawing.Size(110, 30);
            this.LM830btnVolver.TabIndex = 16;
            this.LM830btnVolver.Text = "Volver";
            this.LM830btnVolver.Click += new System.EventHandler(this.LM830btnVolver_Click);
            // 
            // frmComprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(820, 650);
            this.Controls.Add(this.LM830pnlTitulo);
            this.Controls.Add(this.LM830lblNro);
            this.Controls.Add(this.LM830txtNro);
            this.Controls.Add(this.LM830btnBuscar);
            this.Controls.Add(this.LM830btnImportar);
            this.Controls.Add(this.LM830grpDatos);
            this.Controls.Add(this.LM830lblOrigen);
            this.Controls.Add(this.LM830dgvItems);
            this.Controls.Add(this.LM830btnPdf);
            this.Controls.Add(this.LM830btnXml);
            this.Controls.Add(this.LM830btnJson);
            this.Controls.Add(this.LM830btnVolver);
            this.AcceptButton = this.LM830btnBuscar;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LM830frmComprobantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprobantes";
            this.Load += new System.EventHandler(this.LM830frmComprobantes_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LM830frmComprobantes_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.LM830dgvItems)).EndInit();
            this.LM830pnlTitulo.ResumeLayout(false);
            this.LM830pnlTitulo.PerformLayout();
            this.LM830grpDatos.ResumeLayout(false);
            this.LM830grpDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LM830pnlTitulo;
        private System.Windows.Forms.Label LM830lblTitulo;
        private System.Windows.Forms.Label LM830lblNro;
        private System.Windows.Forms.TextBox LM830txtNro;
        private System.Windows.Forms.Button LM830btnBuscar;
        private System.Windows.Forms.Button LM830btnImportar;
        private System.Windows.Forms.GroupBox LM830grpDatos;
        private System.Windows.Forms.Label LM830lblNroDatos;
        private System.Windows.Forms.Label LM830lblFechaDatos;
        private System.Windows.Forms.Label LM830lblClienteDatos;
        private System.Windows.Forms.Label LM830lblTotalesDatos;
        private System.Windows.Forms.Label LM830lblOrigen;
        private System.Windows.Forms.DataGridView LM830dgvItems;
        private System.Windows.Forms.Button LM830btnPdf;
        private System.Windows.Forms.Button LM830btnXml;
        private System.Windows.Forms.Button LM830btnJson;
        private System.Windows.Forms.Button LM830btnVolver;
    }
}
