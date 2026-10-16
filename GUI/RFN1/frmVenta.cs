#nullable enable
using BE.RFN1;
using BLL.RFN1;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI.RFN1
{
    // CU-N01-003 Registrar venta. Punto de extensión: cliente no inscripto -> «extend» CU-N01-001.
    public partial class frmVenta : Form, IObserver
    {
        private readonly VentaBLL _ventaBLL = new VentaBLL();
        private readonly ClienteBLL _clienteBLL = new ClienteBLL();
        private readonly ProductoBLL _productoBLL = new ProductoBLL();
        private readonly LoteBLL _loteBLL = new LoteBLL();

        private Producto? _productoEncontrado;
        private List<Producto> _catalogo = new List<Producto>();
        private List<Producto> _filtrados = new List<Producto>();
        private bool _cargandoCatalogo;

        public frmVenta()
        {
            InitializeComponent();
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            LanguageManager.Instance.AgregarObservador(this);
            Actualizar(LanguageManager.Instance);
            try
            {
                _catalogo = _productoBLL.Listar();
                var nombres = new AutoCompleteStringCollection();
                nombres.AddRange(_catalogo.Select(p => p.Nombre).ToArray());
                txtProducto.AutoCompleteCustomSource = nombres;
                txtProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            NuevaVenta();
            MostrarCatalogo();
        }

        // Grilla de productos: muestra el catálogo y se filtra mientras se escribe el nombre.
        private void MostrarCatalogo()
        {
            string filtro = txtProducto.Text.Trim();
            List<Producto> lista = filtro.Length == 0
                ? _catalogo
                : _catalogo.Where(p => p.Nombre.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            _cargandoCatalogo = true;
            _filtrados = lista;
            dgvProductos.DataSource = lista.Select(p => new
            {
                Producto = p.Nombre,
                Categoria = p.Categoria.Nombre,
                Precio = p.Precio.ToString("N2"),
                Multiplicador = p.Categoria.Multiplicador.ToString("0.00")
            }).ToList();
            dgvProductos.ClearSelection();
            _cargandoCatalogo = false;
        }

        private Producto? ProductoSeleccionado()
        {
            if (dgvProductos.CurrentRow == null || !dgvProductos.CurrentRow.Selected) return null;
            int i = dgvProductos.CurrentRow.Index;
            return i >= 0 && i < _filtrados.Count ? _filtrados[i] : null;
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            // Si el texto lo puso la selección de la grilla, no se vuelve a filtrar.
            if (_productoEncontrado != null && string.Equals(txtProducto.Text, _productoEncontrado.Nombre, StringComparison.Ordinal))
                return;
            _productoEncontrado = null;
            lblProductoDatos.Text = "-";
            MostrarCatalogo();
        }

        // Elegir un producto en la grilla equivale a buscarlo (pasos 3-4).
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargandoCatalogo) return;
            Producto? p = ProductoSeleccionado();
            if (p == null) return;
            _productoEncontrado = p;
            txtProducto.Text = p.Nombre;
            lblProductoDatos.Text = $"$ {p.Precio:N2} - {p.Categoria.Nombre}";
        }

        // Doble clic en un producto: lo agrega con la cantidad indicada.
        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvProductos_SelectionChanged(sender, EventArgs.Empty);
            btnAgregar_Click(sender, EventArgs.Empty);
        }

        private void NuevaVenta()
        {
            _ventaBLL.NuevaVenta(null);
            _productoEncontrado = null;
            txtDni.Clear();
            txtProducto.Clear();
            nudCantidad.Value = 1;
            lblProductoDatos.Text = "-";
            MostrarCliente();
            RefrescarItems();
            txtDni.Select();
        }

        // Paso 2: buscar cliente. DNI vacío = el cliente no participa (flujo 2.1).
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = txtDni.Text.Trim();
                if (dni.Length == 0)
                {
                    _ventaBLL.AsignarCliente(null);
                    MostrarCliente();
                    return;
                }
                if (!Regex.IsMatch(dni, @"^\d{7,8}$"))
                {
                    MessageBox.Show(T("RFN1_DniInvalido"), T("RFN1_RegistrarVenta"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cliente? cliente = _clienteBLL.Buscar(dni);
                if (cliente == null)
                {
                    // Flujo 2.2 (punto de extensión): si acepta inscribirse se ejecuta CU-N01-001.
                    if (MessageBox.Show(T("RFN1_PreguntaInscribir"), T("RFN1_RegistrarVenta"),
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var frm = new frmRegistrarCliente(dni))
                        {
                            if (frm.ShowDialog(this) == DialogResult.OK) cliente = frm.ClienteRegistrado;
                        }
                    }
                }

                _ventaBLL.AsignarCliente(cliente);
                MostrarCliente();
                RefrescarItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarCliente()
        {
            Cliente? c = _ventaBLL.VentaActual.Cliente;
            lblCliente.Text = c == null
                ? T("RFN1_VentaSinCliente")
                : $"{c.NombreCompleto} - {T("RFN1_Nivel")} {c.Nivel.Nombre}";
        }

        // Pasos 3-4
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                _productoEncontrado = _productoBLL.Buscar(txtProducto.Text);
                if (_productoEncontrado == null)
                {
                    // Flujo 4.1
                    lblProductoDatos.Text = "-";
                    MessageBox.Show(T("RFN1_ProductoNoExiste"), T("RFN1_RegistrarVenta"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProducto.SelectAll();
                    txtProducto.Select();
                    return;
                }
                txtProducto.Text = _productoEncontrado.Nombre;
                lblProductoDatos.Text = $"$ {_productoEncontrado.Precio:N2} - {_productoEncontrado.Categoria.Nombre}";
                nudCantidad.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Pasos 5-7
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_productoEncontrado == null || !string.Equals(txtProducto.Text.Trim(), _productoEncontrado.Nombre, StringComparison.OrdinalIgnoreCase))
                {
                    btnBuscarProducto_Click(sender, e);
                    if (_productoEncontrado == null) return;
                }

                _ventaBLL.AgregarItem(new DetalleVenta { Producto = _productoEncontrado, Cantidad = (int)nudCantidad.Value });
                RefrescarItems();

                _productoEncontrado = null;
                txtProducto.Clear();
                lblProductoDatos.Text = "-";
                nudCantidad.Value = 1;
                txtProducto.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("RFN1_RegistrarVenta"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvItems.CurrentRow == null) return;
            int indice = dgvItems.CurrentRow.Index;
            if (indice >= 0 && indice < _ventaBLL.VentaActual.Detalle.Count)
            {
                _ventaBLL.QuitarItem(_ventaBLL.VentaActual.Detalle[indice]);
                RefrescarItems();
            }
        }

        // Paso 8: los puntos se recalculan cada vez que cambian los ítems o el cliente.
        private void RefrescarItems()
        {
            Venta v = _ventaBLL.VentaActual;
            int puntos = 0;
            try
            {
                puntos = _ventaBLL.CalcularPuntos(v, v.Cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvItems.DataSource = v.Detalle.Select(d => new
            {
                Producto = d.Producto.Nombre,
                Categoria = d.Producto.Categoria.Nombre,
                Cantidad = d.Cantidad,
                Precio = d.PrecioUnitario.ToString("N2"),
                Subtotal = d.Subtotal.ToString("N2"),
                Puntos = d.PuntosCalculados
            }).ToList();

            lblTotal.Text = "$ " + v.Total.ToString("N2");
            lblPuntos.Text = puntos.ToString("N0");
        }

        // Pasos 9-12
        private void btnCerrarVenta_Click(object sender, EventArgs e)
        {
            Venta v = _ventaBLL.VentaActual;
            if (v.Detalle.Count == 0)
            {
                // Flujo 9.1
                MessageBox.Show(T("RFN1_VentaSinItems"), T("RFN1_RegistrarVenta"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"{T("RFN1_ConfirmarPago")} $ {v.Total:N2}?", T("RFN1_RegistrarVenta"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _ventaBLL.RegistrarVenta(v);
            }
            catch (Exception ex)
            {
                // Flujo 10.1: se revirtió la transacción.
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string comprobante = $"{T("RFN1_Comprobante")}: {v.NroComprobante}{Environment.NewLine}" +
                                 $"{T("RFN1_Total")}: $ {v.Total:N2}";
            if (v.Cliente != null)
            {
                int saldo = 0;
                try { saldo = _loteBLL.ConsultarSaldo(v.Cliente); } catch { }
                comprobante += $"{Environment.NewLine}{T("RFN1_Cliente")}: {v.Cliente.NombreCompleto}" +
                               $"{Environment.NewLine}{T("RFN1_PuntosAcreditados")}: {v.PuntosAcreditados:N0}" +
                               $"{Environment.NewLine}{T("RFN1_SaldoVigente")}: {saldo:N0}" +
                               $"{Environment.NewLine}{T("RFN1_Nivel")}: {v.Cliente.Nivel.Nombre}";
            }
            MessageBox.Show(comprobante, T("RFN1_Comprobante"), MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (_ventaBLL.NivelAnterior != null && v.Cliente != null)
            {
                // Flujo 10.3
                MessageBox.Show($"{T("RFN1_CambioNivel")} {_ventaBLL.NivelAnterior.Nombre} -> {v.Cliente.Nivel.Nombre}",
                    T("RFN1_RegistrarVenta"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            NuevaVenta();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (_ventaBLL.VentaActual.Detalle.Count > 0 &&
                MessageBox.Show(T("RFN1_DescartarVenta"), T("RFN1_RegistrarVenta"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            Close();
        }

        private void frmVenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            LanguageManager.Instance.EliminarObservador(this);
            Navegacion.MostrarMenu();
        }

        private static string T(string clave) => LanguageManager.Instance.GetTraduction(clave);

        public void Actualizar(LanguageManager lenguaje)
        {
            Text = lenguaje.GetTraduction("RFN1_RegistrarVenta");
            lblTitulo.Text = Text;
            grpCliente.Text = lenguaje.GetTraduction("RFN1_Cliente");
            lblDni.Text = lenguaje.GetTraduction("RFN1_Dni");
            btnBuscarCliente.Text = lenguaje.GetTraduction("RFN1_BuscarCliente");
            grpProducto.Text = lenguaje.GetTraduction("RFN1_Producto");
            lblProducto.Text = lenguaje.GetTraduction("RFN1_Producto");
            btnBuscarProducto.Text = lenguaje.GetTraduction("RFN1_Buscar");
            lblCantidad.Text = lenguaje.GetTraduction("RFN1_Cant");
            btnQuitar.Text = lenguaje.GetTraduction("RFN1_QuitarItem");
            lblTotalTitulo.Text = lenguaje.GetTraduction("RFN1_Total") + ":";
            lblPuntosTitulo.Text = lenguaje.GetTraduction("RFN1_Puntos") + ":";
            btnCerrarVenta.Text = lenguaje.GetTraduction("RFN1_CerrarVenta");
            btnVolver.Text = lenguaje.GetTraduction("RFN1_Volver");
            MostrarCliente();
        }
    }
}