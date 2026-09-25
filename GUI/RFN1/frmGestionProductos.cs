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
    public partial class frmGestionProductos : Form
    {
        private readonly ProductoBLL _productoBLL;

        public frmGestionProductos()
        {
            InitializeComponent();
            _productoBLL = new ProductoBLL();

            // Habilitar autogeneración y cargar datos directamente en el constructor
            dgvProductos.AutoGenerateColumns = true;
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = _productoBLL.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmGestionProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

      

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtPrecioCosto.Text = "0.00";
            txtImpuestoPorcentaje.Text = "0.00";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtPrecioCosto.Text, out decimal precioCosto))
                {
                    MessageBox.Show("Ingrese un precio de costo válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtImpuestoPorcentaje.Text, out decimal impuesto))
                {
                    MessageBox.Show("Ingrese un impuesto válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Producto nuevo = new Producto
                {
                    Nombre = txtNombre.Text.Trim(),
                    PrecioCosto = precioCosto,
                    ImpuestoPorcentaje = impuesto
                };

                _productoBLL.Guardar(nuevo);
                MessageBox.Show("Producto registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarProductos();
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
