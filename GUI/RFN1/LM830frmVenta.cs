#nullable enable
using LM830BE.LM830RFN1;
using LM830BLL.LM830RFN1;
using LM830GUI.LM830Comprobantes;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LM830GUI.LM830RFN1
{
    public partial class LM830frmVenta : Form, LM830IObserver
    {
        private const int LM830EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private readonly LM830VentaBLL LM830_ventaBLL = new LM830VentaBLL();
        private readonly LM830ClienteBLL LM830_clienteBLL = new LM830ClienteBLL();
        private readonly LM830ProductoBLL LM830_productoBLL = new LM830ProductoBLL();
        private readonly LM830LoteBLL LM830_loteBLL = new LM830LoteBLL();
        private readonly LM830ComprobanteBLL LM830_comprobanteBLL = new LM830ComprobanteBLL();

        private LM830Producto? LM830_productoEncontrado;
        private List<LM830Producto> LM830_catalogo = new List<LM830Producto>();
        private List<LM830Producto> LM830_filtrados = new List<LM830Producto>();
        private bool LM830_cargandoCatalogo;

        public LM830frmVenta()
        {
            InitializeComponent();
        }

        private void LM830frmVenta_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Estilo.LM830Aplicar(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
            try
            {
                LM830_catalogo = LM830_productoBLL.LM830Listar();
                var LM830nombres = new AutoCompleteStringCollection();
                LM830nombres.AddRange(LM830_catalogo.Select(LM830p => LM830p.LM830Nombre).ToArray());
                LM830txtProducto.AutoCompleteCustomSource = LM830nombres;
                LM830txtProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                LM830txtProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LM830NuevaVenta();
            LM830MostrarCatalogo();
        }

        private void LM830MostrarCatalogo()
        {
            string LM830filtro = LM830txtProducto.Text.Trim();
            List<LM830Producto> LM830lista = LM830filtro.Length == 0
                ? LM830_catalogo
                : LM830_catalogo.Where(LM830p => LM830p.LM830Nombre.IndexOf(LM830filtro, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            LM830_cargandoCatalogo = true;
            LM830_filtrados = LM830lista;
            LM830dgvProductos.DataSource = LM830lista.Select(LM830p => new
            {
                Producto = LM830p.LM830Nombre,
                Categoria = LM830p.LM830Categoria.LM830Nombre,
                Precio = LM830p.LM830Precio.ToString("N2"),
                Multiplicador = LM830p.LM830Categoria.LM830Multiplicador.ToString("0.00")
            }).ToList();
            LM830dgvProductos.ClearSelection();
            LM830_cargandoCatalogo = false;
        }

        private LM830Producto? LM830ProductoSeleccionado()
        {
            if (LM830dgvProductos.CurrentRow == null || !LM830dgvProductos.CurrentRow.Selected) return null;
            int LM830i = LM830dgvProductos.CurrentRow.Index;
            return LM830i >= 0 && LM830i < LM830_filtrados.Count ? LM830_filtrados[LM830i] : null;
        }

        private void LM830txtProducto_TextChanged(object LM830sender, EventArgs LM830e)
        {
            if (LM830_productoEncontrado != null && string.Equals(LM830txtProducto.Text, LM830_productoEncontrado.LM830Nombre, StringComparison.Ordinal))
                return;
            LM830_productoEncontrado = null;
            LM830lblProductoDatos.Text = "-";
            LM830MostrarCatalogo();
        }

        private void LM830dgvProductos_SelectionChanged(object LM830sender, EventArgs LM830e)
        {
            if (LM830_cargandoCatalogo) return;
            LM830Producto? LM830p = LM830ProductoSeleccionado();
            if (LM830p == null) return;
            LM830_productoEncontrado = LM830p;
            LM830txtProducto.Text = LM830p.LM830Nombre;
            LM830lblProductoDatos.Text = $"$ {LM830p.LM830Precio:N2} - {LM830p.LM830Categoria.LM830Nombre}";
        }

        private void LM830dgvProductos_CellDoubleClick(object LM830sender, DataGridViewCellEventArgs LM830e)
        {
            if (LM830e.RowIndex < 0) return;
            LM830dgvProductos_SelectionChanged(LM830sender, EventArgs.Empty);
            LM830btnAgregar_Click(LM830sender, EventArgs.Empty);
        }

        private void LM830NuevaVenta()
        {
            LM830_ventaBLL.LM830NuevaVenta(null);
            LM830_productoEncontrado = null;
            LM830txtDni.Clear();
            LM830txtProducto.Clear();
            LM830nudCantidad.Value = 1;
            LM830lblProductoDatos.Text = "-";
            LM830MostrarCliente();
            LM830RefrescarItems();
            LM830txtDni.Select();
        }

        private void LM830btnBuscarCliente_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                string LM830dni = LM830txtDni.Text.Trim();
                if (LM830dni.Length == 0)
                {
                    LM830_ventaBLL.LM830AsignarCliente(null);
                    LM830MostrarCliente();
                    return;
                }
                if (!Regex.IsMatch(LM830dni, @"^\d{7,8}$"))
                {
                    MessageBox.Show(LM830T("RFN1_DniInvalido"), LM830T("RFN1_RegistrarVenta"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LM830Cliente? LM830cliente = LM830_clienteBLL.LM830Buscar(LM830dni);
                if (LM830cliente == null)
                {
                    if (MessageBox.Show(LM830T("RFN1_PreguntaInscribir"), LM830T("RFN1_RegistrarVenta"),
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var LM830frm = new LM830frmRegistrarCliente(LM830dni))
                        {
                            if (LM830frm.ShowDialog(this) == DialogResult.OK) LM830cliente = LM830frm.LM830ClienteRegistrado;
                        }
                    }
                }

                LM830_ventaBLL.LM830AsignarCliente(LM830cliente);
                LM830MostrarCliente();
                LM830RefrescarItems();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830MostrarCliente()
        {
            LM830Cliente? LM830c = LM830_ventaBLL.LM830VentaActual.LM830Cliente;
            LM830lblCliente.Text = LM830c == null
                ? LM830T("RFN1_VentaSinCliente")
                : $"{LM830c.LM830NombreCompleto} - {LM830T("RFN1_Nivel")} {LM830c.LM830Nivel.LM830Nombre}";
        }

        private void LM830btnBuscarProducto_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                LM830_productoEncontrado = LM830_productoBLL.LM830Buscar(LM830txtProducto.Text);
                if (LM830_productoEncontrado == null)
                {
                    LM830lblProductoDatos.Text = "-";
                    MessageBox.Show(LM830T("RFN1_ProductoNoExiste"), LM830T("RFN1_RegistrarVenta"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LM830txtProducto.SelectAll();
                    LM830txtProducto.Select();
                    return;
                }
                LM830txtProducto.Text = LM830_productoEncontrado.LM830Nombre;
                LM830lblProductoDatos.Text = $"$ {LM830_productoEncontrado.LM830Precio:N2} - {LM830_productoEncontrado.LM830Categoria.LM830Nombre}";
                LM830nudCantidad.Select();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830btnAgregar_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                if (LM830_productoEncontrado == null || !string.Equals(LM830txtProducto.Text.Trim(), LM830_productoEncontrado.LM830Nombre, StringComparison.OrdinalIgnoreCase))
                {
                    LM830btnBuscarProducto_Click(LM830sender, LM830e);
                    if (LM830_productoEncontrado == null) return;
                }

                LM830_ventaBLL.LM830AgregarItem(new LM830DetalleVenta { LM830Producto = LM830_productoEncontrado, LM830Cantidad = (int)LM830nudCantidad.Value });
                LM830RefrescarItems();

                LM830_productoEncontrado = null;
                LM830txtProducto.Clear();
                LM830lblProductoDatos.Text = "-";
                LM830nudCantidad.Value = 1;
                LM830txtProducto.Select();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("RFN1_RegistrarVenta"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LM830btnQuitar_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830dgvItems.CurrentRow == null) return;
            int LM830indice = LM830dgvItems.CurrentRow.Index;
            if (LM830indice >= 0 && LM830indice < LM830_ventaBLL.LM830VentaActual.LM830Detalle.Count)
            {
                LM830_ventaBLL.LM830QuitarItem(LM830_ventaBLL.LM830VentaActual.LM830Detalle[LM830indice]);
                LM830RefrescarItems();
            }
        }

        private void LM830RefrescarItems()
        {
            LM830Venta LM830v = LM830_ventaBLL.LM830VentaActual;
            int LM830puntos = 0;
            try
            {
                LM830puntos = LM830_ventaBLL.LM830CalcularPuntos(LM830v, LM830v.LM830Cliente);
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LM830dgvItems.DataSource = LM830v.LM830Detalle.Select(LM830d => new
            {
                Producto = LM830d.LM830Producto.LM830Nombre,
                Categoria = LM830d.LM830Producto.LM830Categoria.LM830Nombre,
                Cantidad = LM830d.LM830Cantidad,
                Precio = LM830d.LM830PrecioUnitario.ToString("N2"),
                Subtotal = LM830d.LM830Subtotal.ToString("N2"),
                Puntos = LM830d.LM830PuntosCalculados
            }).ToList();

            LM830lblTotal.Text = "$ " + LM830v.LM830Total.ToString("N2");
            LM830lblPuntos.Text = LM830puntos.ToString("N0");
        }

        private void LM830btnCerrarVenta_Click(object LM830sender, EventArgs LM830e)
        {
            LM830Venta LM830v = LM830_ventaBLL.LM830VentaActual;
            if (LM830v.LM830Detalle.Count == 0)
            {
                MessageBox.Show(LM830T("RFN1_VentaSinItems"), LM830T("RFN1_RegistrarVenta"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"{LM830T("RFN1_ConfirmarPago")} $ {LM830v.LM830Total:N2}?", LM830T("RFN1_RegistrarVenta"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                LM830_ventaBLL.LM830RegistrarVenta(LM830v);
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string LM830comprobante = $"{LM830T("RFN1_Comprobante")}: {LM830v.LM830NroComprobante}{Environment.NewLine}" +
                                 $"{LM830T("RFN1_Total")}: $ {LM830v.LM830Total:N2}";
            if (LM830v.LM830Cliente != null)
            {
                int LM830saldo = 0;
                try { LM830saldo = LM830_loteBLL.LM830ConsultarSaldo(LM830v.LM830Cliente); } catch { }
                LM830comprobante += $"{Environment.NewLine}{LM830T("RFN1_Cliente")}: {LM830v.LM830Cliente.LM830NombreCompleto}" +
                               $"{Environment.NewLine}{LM830T("RFN1_PuntosAcreditados")}: {LM830v.LM830PuntosAcreditados:N0}" +
                               $"{Environment.NewLine}{LM830T("RFN1_SaldoVigente")}: {LM830saldo:N0}" +
                               $"{Environment.NewLine}{LM830T("RFN1_Nivel")}: {LM830v.LM830Cliente.LM830Nivel.LM830Nombre}";
            }
            LM830comprobante += $"{Environment.NewLine}{Environment.NewLine}{LM830T("CMP_PreguntaPdf")}";
            bool LM830imprimir = MessageBox.Show(LM830comprobante, LM830T("RFN1_Comprobante"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
            if (LM830imprimir) LM830GenerarPdf(LM830v);

            if (LM830_ventaBLL.LM830NivelAnterior != null && LM830v.LM830Cliente != null)
            {
                MessageBox.Show($"{LM830T("RFN1_CambioNivel")} {LM830_ventaBLL.LM830NivelAnterior.LM830Nombre} -> {LM830v.LM830Cliente.LM830Nivel.LM830Nombre}",
                    LM830T("RFN1_RegistrarVenta"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LM830NuevaVenta();
        }

        private void LM830GenerarPdf(LM830Venta LM830v)
        {
            string? LM830ruta = LM830GeneradorPDF.LM830ElegirRuta(this, "Comprobante_" + LM830v.LM830NroComprobante);
            if (LM830ruta == null) return;
            try
            {
                LM830ComprobanteVenta LM830c = LM830_comprobanteBLL.LM830Armar(LM830v);
                LM830GeneradorPDF.LM830ComprobanteVenta(LM830c, LM830ruta);
                LM830_comprobanteBLL.LM830RegistrarImpresion(LM830v.LM830NroComprobante, LM830ruta);
                LM830GeneradorPDF.LM830Abrir(LM830ruta);
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830btnVolver_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_ventaBLL.LM830VentaActual.LM830Detalle.Count > 0 &&
                MessageBox.Show(LM830T("RFN1_DescartarVenta"), LM830T("RFN1_RegistrarVenta"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            Close();
        }

        private void LM830frmVenta_FormClosed(object LM830sender, FormClosedEventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830EliminarObservador(this);
            LM830Navegacion.LM830MostrarMenu();
        }

        private static string LM830T(string LM830clave) => LM830LanguageManager.LM830Instance.LM830GetTraduction(LM830clave);

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            Text = LM830lenguaje.LM830GetTraduction("RFN1_RegistrarVenta");
            LM830lblTitulo.Text = Text;
            LM830grpCliente.Text = LM830lenguaje.LM830GetTraduction("RFN1_Cliente");
            LM830lblDni.Text = LM830lenguaje.LM830GetTraduction("RFN1_Dni");
            LM830btnBuscarCliente.Text = LM830lenguaje.LM830GetTraduction("RFN1_BuscarCliente");
            LM830grpProducto.Text = LM830lenguaje.LM830GetTraduction("RFN1_Producto");
            LM830lblProducto.Text = LM830lenguaje.LM830GetTraduction("RFN1_Producto");
            LM830btnBuscarProducto.Text = LM830lenguaje.LM830GetTraduction("RFN1_Buscar");
            LM830lblCantidad.Text = LM830lenguaje.LM830GetTraduction("RFN1_Cant");
            LM830btnQuitar.Text = LM830lenguaje.LM830GetTraduction("RFN1_QuitarItem");
            LM830lblTotalTitulo.Text = LM830lenguaje.LM830GetTraduction("RFN1_Total") + ":";
            LM830lblPuntosTitulo.Text = LM830lenguaje.LM830GetTraduction("RFN1_Puntos") + ":";
            LM830btnCerrarVenta.Text = LM830lenguaje.LM830GetTraduction("RFN1_CerrarVenta");
            LM830btnVolver.Text = LM830lenguaje.LM830GetTraduction("RFN1_Volver");
            LM830MostrarCliente();
            SendMessage(LM830txtDni.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN1_PH_Dni"));
            SendMessage(LM830txtProducto.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN1_PH_Producto"));
        }
    }
}
