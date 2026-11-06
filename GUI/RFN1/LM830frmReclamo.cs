#nullable enable
using LM830BE.LM830RFN1;
using LM830BLL.LM830RFN1;
using LM830Servicios;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LM830GUI.LM830RFN1
{
    public partial class LM830frmReclamo : Form, LM830IObserver
    {
        private const int LM830EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private readonly LM830ReclamoBLL LM830_reclamoBLL = new LM830ReclamoBLL();
        private readonly LM830VentaBLL LM830_ventaBLL = new LM830VentaBLL();
        private readonly LM830ClienteBLL LM830_clienteBLL = new LM830ClienteBLL();

        private LM830Cliente? LM830_cliente;
        private LM830Venta? LM830_venta;
        private bool LM830_ventaValida;

        public LM830frmReclamo()
        {
            InitializeComponent();
        }

        private void LM830frmReclamo_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Estilo.LM830Aplicar(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
            LM830Limpiar();
        }

        private void LM830Limpiar()
        {
            LM830_cliente = null;
            LM830txtDni.Clear();
            LM830lblCliente.Text = "-";
            LM830LimpiarVenta();
            LM830txtNroComprobante.Clear();
            LM830txtMotivo.Clear();
            LM830txtDni.Select();
        }

        private void LM830LimpiarVenta()
        {
            LM830_venta = null;
            LM830_ventaValida = false;
            LM830lblVentaDatos.Text = "-";
            LM830lblPuntos.Text = "-";
            LM830dgvDetalle.DataSource = null;
        }

        private void LM830btnBuscarCliente_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                string LM830dni = LM830txtDni.Text.Trim();
                if (!Regex.IsMatch(LM830dni, @"^\d{7,8}$"))
                {
                    MessageBox.Show(LM830T("RFN1_DniInvalido"), LM830T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LM830Cliente? LM830cliente = LM830_clienteBLL.LM830Buscar(LM830dni);
                if (LM830cliente == null)
                {
                    MessageBox.Show(LM830T("RFN1_ClienteNoInscriptoReclamo"), LM830T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (var LM830frm = new LM830frmRegistrarCliente(LM830dni))
                    {
                        if (LM830frm.ShowDialog(this) == DialogResult.OK) LM830cliente = LM830frm.LM830ClienteRegistrado;
                    }
                    if (LM830cliente == null) return;
                }

                LM830_cliente = LM830cliente;
                LM830lblCliente.Text = $"{LM830cliente.LM830NombreCompleto} - {LM830T("RFN1_Nivel")} {LM830cliente.LM830Nivel.LM830Nombre}";
                if (LM830_venta != null) LM830MostrarVenta();
                LM830txtNroComprobante.Select();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830btnBuscarVenta_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                LM830LimpiarVenta();
                if (LM830_cliente == null)
                {
                    MessageBox.Show(LM830T("RFN1_PrimeroCliente"), LM830T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LM830_venta = LM830_ventaBLL.LM830ObtenerPorNro(LM830txtNroComprobante.Text);
                if (LM830_venta == null)
                {
                    MessageBox.Show(LM830T("RFN1_VentaNoExiste"), LM830T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                LM830MostrarVenta();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830MostrarVenta()
        {
            if (LM830_venta == null || LM830_cliente == null) return;

            LM830txtNroComprobante.Text = LM830_venta.LM830NroComprobante;
            LM830lblVentaDatos.Text = $"{LM830_venta.LM830Fecha:dd/MM/yyyy HH:mm} - $ {LM830_venta.LM830Total:N2}";
            LM830dgvDetalle.DataSource = LM830_venta.LM830Detalle.Select(LM830d => new
            {
                Producto = LM830d.LM830Producto.LM830Nombre,
                Cantidad = LM830d.LM830Cantidad,
                Subtotal = LM830d.LM830Subtotal.ToString("N2")
            }).ToList();

            LM830_ventaValida = LM830_reclamoBLL.LM830Validar(LM830_venta);
            if (!LM830_ventaValida)
            {
                LM830lblPuntos.Text = "-";
                MessageBox.Show(LM830_reclamoBLL.LM830MensajeValidacion, LM830T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int LM830puntos = LM830_reclamoBLL.LM830CalcularPuntosReclamo(LM830_venta, LM830_cliente);
            LM830lblPuntos.Text = LM830puntos.ToString("N0");
            LM830txtMotivo.Select();
        }

        private void LM830btnRegistrarReclamo_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_cliente == null || LM830_venta == null || !LM830_ventaValida)
            {
                MessageBox.Show(LM830T("RFN1_CompletarReclamo"), LM830T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (LM830txtMotivo.Text.Trim().Length == 0)
            {
                MessageBox.Show(LM830T("RFN1_MotivoObligatorio"), LM830T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LM830txtMotivo.Select();
                return;
            }

            try
            {
                var LM830reclamo = new LM830Reclamo { LM830Cliente = LM830_cliente, LM830Venta = LM830_venta, LM830Motivo = LM830txtMotivo.Text };
                LM830_reclamoBLL.LM830Registrar(LM830reclamo);
                MessageBox.Show($"{LM830T("RFN1_ReclamoRegistrado")} #{LM830reclamo.LM830IdReclamo} ({LM830reclamo.LM830PuntosReclamados:N0} {LM830T("RFN1_Puntos")}).",
                    LM830T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                LM830Limpiar();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LM830btnVolver_Click(object LM830sender, EventArgs LM830e) => Close();

        private void LM830frmReclamo_FormClosed(object LM830sender, FormClosedEventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830EliminarObservador(this);
            LM830Navegacion.LM830MostrarMenu();
        }

        private static string LM830T(string LM830clave) => LM830LanguageManager.LM830Instance.LM830GetTraduction(LM830clave);

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            Text = LM830lenguaje.LM830GetTraduction("RFN1_RegistrarReclamo");
            LM830lblTitulo.Text = Text;
            LM830grpCliente.Text = LM830lenguaje.LM830GetTraduction("RFN1_Cliente");
            LM830lblDni.Text = LM830lenguaje.LM830GetTraduction("RFN1_Dni");
            LM830btnBuscarCliente.Text = LM830lenguaje.LM830GetTraduction("RFN1_BuscarCliente");
            LM830grpVenta.Text = LM830lenguaje.LM830GetTraduction("RFN1_Compra");
            LM830lblComprobante.Text = LM830lenguaje.LM830GetTraduction("RFN1_NroComprobante");
            LM830btnBuscarVenta.Text = LM830lenguaje.LM830GetTraduction("RFN1_Buscar");
            LM830lblPuntosTitulo.Text = LM830lenguaje.LM830GetTraduction("RFN1_PuntosCorresponderian");
            LM830lblMotivo.Text = LM830lenguaje.LM830GetTraduction("RFN1_MotivoReclamo");
            LM830btnRegistrarReclamo.Text = LM830lenguaje.LM830GetTraduction("RFN1_RegistrarReclamo");
            LM830btnVolver.Text = LM830lenguaje.LM830GetTraduction("RFN1_Volver");
            SendMessage(LM830txtDni.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN1_PH_Dni"));
            SendMessage(LM830txtNroComprobante.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN1_PH_NroComprobante"));
        }
    }
}
