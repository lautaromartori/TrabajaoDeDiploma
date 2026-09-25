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
    public partial class frmRegistrarCompra : Form
    {
        private Factura _facturaActual;
        private readonly FacturaBLL _facturaBLL;
        private readonly ProveedorBLL _proveedorBLL;
        private readonly ProductoBLL _productoBLL;

        private List<Proveedor> _listaProveedores;
        private List<Producto> _listaProductos;

        public frmRegistrarCompra()
        {
            InitializeComponent();

            _facturaActual = new Factura();
            _facturaBLL = new FacturaBLL();
            _proveedorBLL = new ProveedorBLL();
            _productoBLL = new ProductoBLL();

            ConfigurarControles();
            CargarCatalogos();
        }

        private void ConfigurarControles()
        {
            
            dgvDetalles.AutoGenerateColumns = true;
            dgvProveedores.AutoGenerateColumns = true;
            dgvProductos.AutoGenerateColumns = true;

            cmbTipoComprobante.Items.Clear();
            cmbTipoComprobante.Items.Add("Factura A");
            cmbTipoComprobante.Items.Add("Factura B");
            cmbTipoComprobante.Items.Add("Factura C");
            cmbTipoComprobante.SelectedIndex = 0;

            txtImpuestosFactura.ReadOnly = true;
            txtTotalFactura.ReadOnly = true;
            txtRazonSocial.ReadOnly = true;
            txtCuit.ReadOnly = true;
        }

        private void CargarCatalogos()
        {
            try
            {
                _listaProveedores = _proveedorBLL.Listar() ?? new List<Proveedor>();
                dgvProveedores.DataSource = null;
                dgvProveedores.DataSource = _listaProveedores;

                _listaProductos = _productoBLL.Listar() ?? new List<Producto>();
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = _listaProductos;

                if (_listaProveedores.Count > 0)
                {
                    SeleccionarProveedorActual(_listaProveedores[0]);
                }

                if (_listaProductos.Count > 0)
                {
                    SeleccionarProductoActual(_listaProductos[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar catálogos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarProveedorActual(Proveedor prov)
        {
            if (prov != null)
            {
                _facturaActual.Proveedor = prov;
                txtRazonSocial.Text = prov.RazonSocial;
                txtCuit.Text = prov.Cuit;
            }
        }

        private void SeleccionarProductoActual(Producto prod)
        {
            if (prod != null)
            {
                txtPrecioUnitario.Text = prod.PrecioCosto.ToString("N2");
            }
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow != null && dgvProveedores.CurrentRow.DataBoundItem is Proveedor prov)
            {
                SeleccionarProveedorActual(prov);
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.DataBoundItem is Producto prod)
            {
                SeleccionarProductoActual(prod);
            }
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            using (frmGestionProveedores formProv = new frmGestionProveedores())
            {
                formProv.ShowDialog();
                CargarCatalogos();
            }
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            using (frmGestionProductos formProd = new frmGestionProductos())
            {
                formProd.ShowDialog();
                CargarCatalogos();
            }
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null || !(dgvProductos.CurrentRow.DataBoundItem is Producto productoSeleccionado))
            {
                MessageBox.Show("Seleccione un producto del catálogo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrecioUnitario.Text, out decimal precioUnitario) || precioUnitario <= 0)
            {
                MessageBox.Show("Ingrese un precio unitario válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)numCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal baseImponible = cantidad * precioUnitario;
            decimal impuestoItem = baseImponible * (productoSeleccionado.ImpuestoPorcentaje / 100m);
            decimal subtotalItem = baseImponible + impuestoItem;

            DetalleFactura detalle = new DetalleFactura
            {
                Producto = productoSeleccionado,
                Cantidad = cantidad,
                PrecioUnitario = precioUnitario,
                Impuestos = impuestoItem,
                Subtotal = subtotalItem
            };

            _facturaActual.Detalles.Add(detalle);
            RefrescarGrillaYTotales();
        }

        private void btnQuitarItem_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow != null)
            {
                int index = dgvDetalles.CurrentRow.Index;
                if (index >= 0 && index < _facturaActual.Detalles.Count)
                {
                    _facturaActual.Detalles.RemoveAt(index);
                    RefrescarGrillaYTotales();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila del detalle para quitar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefrescarGrillaYTotales()
        {
            _facturaActual.Impuestos = _facturaActual.Detalles.Sum(d => d.Impuestos);
            _facturaActual.Total = _facturaActual.Detalles.Sum(d => d.Subtotal);

         
            txtImpuestosFactura.Text = _facturaActual.Impuestos.ToString("C2");
            txtTotalFactura.Text = _facturaActual.Total.ToString("C2");

            dgvDetalles.Columns.Clear();
            dgvDetalles.AutoGenerateColumns = true;

          
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = _facturaActual.Detalles.Select(d => new
            {
                IdProducto = d.Producto?.Id,
                Producto = d.Producto?.Nombre,
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario,
                Impuestos = d.Impuestos,
                Subtotal = d.Subtotal
            }).ToList();

           
            FormatearColumnasDetalle();
        }

        private void FormatearColumnasDetalle()
        {
            if (dgvDetalles.Columns["PrecioUnitario"] != null)
                dgvDetalles.Columns["PrecioUnitario"].DefaultCellStyle.Format = "N2"; 

            if (dgvDetalles.Columns["Impuestos"] != null)
                dgvDetalles.Columns["Impuestos"].DefaultCellStyle.Format = "N2";

            if (dgvDetalles.Columns["Subtotal"] != null)
                dgvDetalles.Columns["Subtotal"].DefaultCellStyle.Format = "N2";
        }

        private void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                if (_facturaActual.Proveedor == null || _facturaActual.Proveedor.Id == 0)
                {
                    MessageBox.Show("Debe seleccionar un proveedor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNumeroFactura.Text))
                {
                    MessageBox.Show("Ingrese el número de factura.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_facturaActual.Detalles.Count == 0)
                {
                    MessageBox.Show("Debe incorporar al menos un producto al detalle.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _facturaActual.NumeroFactura = txtNumeroFactura.Text.Trim();
                _facturaActual.Fecha = dtpFecha.Value;
                _facturaActual.TipoComprobante = cmbTipoComprobante.SelectedItem?.ToString();

                _facturaBLL.RegistrarFactura(_facturaActual);

                MessageBox.Show("Compra registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar la compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            _facturaActual = new Factura();
            txtNumeroFactura.Clear();
            txtRazonSocial.Clear();
            txtCuit.Clear();
            numCantidad.Value = 1;

            RefrescarGrillaYTotales();
            CargarCatalogos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
