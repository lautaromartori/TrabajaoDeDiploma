namespace GUI.RFN1
{
    partial class frmComprobantes
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
            this.lblNro = new System.Windows.Forms.Label();
            this.txtNro = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblNroDatos = new System.Windows.Forms.Label();
            this.lblFechaDatos = new System.Windows.Forms.Label();
            this.lblClienteDatos = new System.Windows.Forms.Label();
            this.lblTotalesDatos = new System.Windows.Forms.Label();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.btnPdf = new System.Windows.Forms.Button();
            this.btnXml = new System.Windows.Forms.Button();
            this.btnJson = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.pnlTitulo.SuspendLayout();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
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
            this.lblTitulo.Text = "Comprobantes";
            // 
            // lblNro
            // 
            this.lblNro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNro.Location = new System.Drawing.Point(20, 65);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(120, 20);
            this.lblNro.TabIndex = 2;
            this.lblNro.Text = "Nro. comprobante";
            // 
            // txtNro
            // 
            this.txtNro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNro.MaxLength = 20;
            this.txtNro.Location = new System.Drawing.Point(145, 62);
            this.txtNro.Name = "txtNro";
            this.txtNro.Size = new System.Drawing.Size(160, 22);
            this.txtNro.TabIndex = 3;
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
            this.btnBuscar.Location = new System.Drawing.Point(315, 58);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Location = new System.Drawing.Point(580, 58);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(220, 30);
            this.btnImportar.TabIndex = 5;
            this.btnImportar.Text = "Abrir archivo (XML / JSON)";
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.lblNroDatos);
            this.grpDatos.Controls.Add(this.lblFechaDatos);
            this.grpDatos.Controls.Add(this.lblClienteDatos);
            this.grpDatos.Controls.Add(this.lblTotalesDatos);
            this.grpDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.grpDatos.Location = new System.Drawing.Point(20, 100);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(780, 125);
            this.grpDatos.TabIndex = 6;
            this.grpDatos.Text = "Comprobante";
            // 
            // lblNroDatos
            // 
            this.lblNroDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroDatos.Location = new System.Drawing.Point(15, 25);
            this.lblNroDatos.Name = "lblNroDatos";
            this.lblNroDatos.Size = new System.Drawing.Size(750, 20);
            this.lblNroDatos.TabIndex = 7;
            this.lblNroDatos.Text = "-";
            // 
            // lblFechaDatos
            // 
            this.lblFechaDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDatos.Location = new System.Drawing.Point(15, 50);
            this.lblFechaDatos.Name = "lblFechaDatos";
            this.lblFechaDatos.Size = new System.Drawing.Size(750, 20);
            this.lblFechaDatos.TabIndex = 8;
            this.lblFechaDatos.Text = "-";
            // 
            // lblClienteDatos
            // 
            this.lblClienteDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteDatos.Location = new System.Drawing.Point(15, 75);
            this.lblClienteDatos.Name = "lblClienteDatos";
            this.lblClienteDatos.Size = new System.Drawing.Size(750, 20);
            this.lblClienteDatos.TabIndex = 9;
            this.lblClienteDatos.Text = "-";
            // 
            // lblTotalesDatos
            // 
            this.lblTotalesDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalesDatos.Location = new System.Drawing.Point(15, 100);
            this.lblTotalesDatos.Name = "lblTotalesDatos";
            this.lblTotalesDatos.Size = new System.Drawing.Size(750, 20);
            this.lblTotalesDatos.TabIndex = 10;
            this.lblTotalesDatos.Text = "-";
            // 
            // lblOrigen
            // 
            this.lblOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigen.ForeColor = System.Drawing.Color.DimGray;
            this.lblOrigen.Location = new System.Drawing.Point(20, 232);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(780, 20);
            this.lblOrigen.TabIndex = 11;
            this.lblOrigen.Text = "";
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
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(20, 255);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(780, 315);
            this.dgvItems.TabIndex = 12;
            // 
            // btnPdf
            // 
            this.btnPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPdf.UseVisualStyleBackColor = false;
            this.btnPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnPdf.ForeColor = System.Drawing.Color.White;
            this.btnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdf.FlatAppearance.BorderSize = 0;
            this.btnPdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPdf.Location = new System.Drawing.Point(20, 595);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(150, 30);
            this.btnPdf.TabIndex = 13;
            this.btnPdf.Text = "Generar PDF";
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // btnXml
            // 
            this.btnXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXml.UseVisualStyleBackColor = true;
            this.btnXml.Location = new System.Drawing.Point(180, 595);
            this.btnXml.Name = "btnXml";
            this.btnXml.Size = new System.Drawing.Size(150, 30);
            this.btnXml.TabIndex = 14;
            this.btnXml.Text = "Exportar XML";
            this.btnXml.Click += new System.EventHandler(this.btnXml_Click);
            // 
            // btnJson
            // 
            this.btnJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJson.UseVisualStyleBackColor = true;
            this.btnJson.Location = new System.Drawing.Point(340, 595);
            this.btnJson.Name = "btnJson";
            this.btnJson.Size = new System.Drawing.Size(150, 30);
            this.btnJson.TabIndex = 15;
            this.btnJson.Text = "Exportar JSON";
            this.btnJson.Click += new System.EventHandler(this.btnJson_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Location = new System.Drawing.Point(690, 595);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(110, 30);
            this.btnVolver.TabIndex = 16;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmComprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(820, 650);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblNro);
            this.Controls.Add(this.txtNro);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.lblOrigen);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.btnPdf);
            this.Controls.Add(this.btnXml);
            this.Controls.Add(this.btnJson);
            this.Controls.Add(this.btnVolver);
            this.AcceptButton = this.btnBuscar;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmComprobantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprobantes";
            this.Load += new System.EventHandler(this.frmComprobantes_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmComprobantes_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNro;
        private System.Windows.Forms.TextBox txtNro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblNroDatos;
        private System.Windows.Forms.Label lblFechaDatos;
        private System.Windows.Forms.Label lblClienteDatos;
        private System.Windows.Forms.Label lblTotalesDatos;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnXml;
        private System.Windows.Forms.Button btnJson;
        private System.Windows.Forms.Button btnVolver;
    }
}
