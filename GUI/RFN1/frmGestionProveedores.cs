using BE.RFN1;
using BLL.RFN1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.RFN1
{
    public partial class frmGestionProveedores : Form
    {
        private readonly ProveedorBLL _proveedorBLL;

        public frmGestionProveedores()
        {
            InitializeComponent();
            _proveedorBLL = new ProveedorBLL();
            dgvProveedores.AutoGenerateColumns = true;
            CargarProveedores();
        }

        private void frmGestionProveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            try
            {
                dgvProveedores.DataSource = null;
                dgvProveedores.DataSource = _proveedorBLL.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtRazonSocial.Clear();
            txtCuit.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor nuevo = new Proveedor
                {
                    RazonSocial = txtRazonSocial.Text.Trim(),
                    Cuit = txtCuit.Text.Trim()
                };

                _proveedorBLL.Guardar(nuevo);
                MessageBox.Show("Proveedor registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProveedores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
