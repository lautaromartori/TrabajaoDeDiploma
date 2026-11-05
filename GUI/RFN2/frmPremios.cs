#nullable enable
using LM830BE.LM830RFN1;
using LM830BE.LM830RFN2;
using LM830BLL.LM830RFN1;
using LM830BLL.LM830RFN2;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LM830GUI.LM830RFN2
{
    public partial class LM830frmPremios : Form, LM830IObserver
    {
        private const int LM830EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private readonly LM830ClienteBLL LM830_clienteBLL = new LM830ClienteBLL();
        private readonly LM830PremioBLL LM830_premioBLL = new LM830PremioBLL();
        private readonly LM830CanjeBLL LM830_canjeBLL = new LM830CanjeBLL();

        private LM830Cliente? LM830_cliente;
        private List<LM830Premio> LM830_premios = new List<LM830Premio>();

        public LM830frmPremios()
        {
            InitializeComponent();
        }

        private void LM830frmPremios_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Estilo.LM830Aplicar(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
            LM830btnRegistrarCanje.Enabled = LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830TienePermiso("Registrar Canje");
            LM830LimpiarCliente();
            LM830txtDni.Select();
        }

        private void LM830btnBuscarCliente_Click(object LM830sender, EventArgs LM830e)
        {
            string LM830dni = LM830txtDni.Text.Trim();
            if (!Regex.IsMatch(LM830dni, @"^\d{7,8}$"))
            {
                MessageBox.Show(LM830T("RFN1_DniInvalido"), LM830T("RFN2_PremiosCanjeables"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LM830txtDni.Select();
                return;
            }

            try
            {
                LM830_cliente = LM830_clienteBLL.LM830Buscar(LM830dni);
                if (LM830_cliente == null)
                {
                    LM830LimpiarCliente();
                    MessageBox.Show(LM830T("RFN1_ClienteNoInscripto"), LM830T("RFN2_PremiosCanjeables"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LM830CargarPremios();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830CargarPremios()
        {
            if (LM830_cliente == null) return;

            int LM830saldo = LM830_canjeBLL.LM830SaldoVigente(LM830_cliente);
            int LM830comprometidos = LM830_canjeBLL.LM830PuntosComprometidos(LM830_cliente);
            int LM830disponible = Math.Max(0, LM830saldo - LM830comprometidos);

            LM830lblCliente.Text = $"{LM830_cliente.LM830NombreCompleto} - {LM830T("RFN1_Nivel")} {LM830_cliente.LM830Nivel.LM830Nombre}";
            LM830lblSaldo.Text = LM830saldo.ToString("N0") + " pts";
            LM830lblComprometidos.Text = LM830comprometidos.ToString("N0") + " pts";
            LM830lblDisponible.Text = LM830disponible.ToString("N0") + " pts";

            LM830_premios = LM830_premioBLL.LM830ListarCanjeables(LM830disponible);
            LM830dgvPremios.DataSource = LM830_premios.Select(LM830p => new
            {
                Premio = LM830p.LM830Nombre,
                Descripción = LM830p.LM830Descripcion,
                Puntos = LM830p.LM830PuntosRequeridos.ToString("N0"),
                Stock = LM830p.LM830Stock,
                Valor = "$ " + LM830p.LM830ValorReferencia.ToString("N2"),
                Autorización = LM830_premioBLL.LM830RequiereAutorizacion(LM830p) ? LM830T("RFN2_RequiereSupervisor") : LM830T("RFN2_Automatica")
            }).ToList();

            if (LM830_premios.Count == 0)
                LM830lblPremios.Text = LM830T("RFN2_SinPremios");
            else
                LM830lblPremios.Text = LM830T("RFN2_PremiosQuePuede");
        }

        private void LM830LimpiarCliente()
        {
            LM830_cliente = null;
            LM830_premios = new List<LM830Premio>();
            LM830dgvPremios.DataSource = null;
            LM830lblCliente.Text = "-";
            LM830lblSaldo.Text = "-";
            LM830lblComprometidos.Text = "-";
            LM830lblDisponible.Text = "-";
            LM830lblPremios.Text = LM830T("RFN2_PremiosQuePuede");
            try
            {
                LM830lblUmbral.Text = $"{LM830T("RFN2_InfoUmbral")} $ {LM830ProgramaPuntosBLL.LM830Obtener().LM830UmbralAutorizacion:N2}.";
            }
            catch
            {
                LM830lblUmbral.Text = "";
            }
        }

        private LM830Premio? LM830Seleccionado()
        {
            if (LM830dgvPremios.CurrentRow == null) return null;
            int LM830i = LM830dgvPremios.CurrentRow.Index;
            return LM830i >= 0 && LM830i < LM830_premios.Count ? LM830_premios[LM830i] : null;
        }

        private void LM830btnRegistrarCanje_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_cliente == null)
            {
                MessageBox.Show(LM830T("RFN1_PrimeroCliente"), LM830T("RFN2_RegistrarCanje"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LM830Premio? LM830premio = LM830Seleccionado();
            if (LM830premio == null)
            {
                MessageBox.Show(LM830T("RFN2_SeleccionePremio"), LM830T("RFN2_RegistrarCanje"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"{LM830T("RFN2_ConfirmarCanje")} {LM830premio.LM830Nombre} ({LM830premio.LM830PuntosRequeridos:N0} pts) - {LM830_cliente.LM830NombreCompleto}?",
                    LM830T("RFN2_RegistrarCanje"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                LM830Canje LM830canje = LM830_canjeBLL.LM830RegistrarSolicitud(LM830_cliente, LM830premio);
                string LM830estado = LM830canje.LM830Estado == LM830EstadoCanje.LM830autorizado ? LM830T("RFN2_CanjeAutorizado") : LM830T("RFN2_CanjePendiente");
                MessageBox.Show($"{LM830T("RFN2_CanjeRegistrado")} {LM830canje.LM830NroCanje}.{Environment.NewLine}{LM830estado}",
                    LM830T("RFN2_RegistrarCanje"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("RFN2_RegistrarCanje"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try { LM830CargarPremios(); } catch { }
        }

        private void LM830btnVolver_Click(object LM830sender, EventArgs LM830e) => Close();

        private void LM830frmPremios_FormClosed(object LM830sender, FormClosedEventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830EliminarObservador(this);
            LM830Navegacion.LM830MostrarMenu();
        }

        private static string LM830T(string LM830clave) => LM830LanguageManager.LM830Instance.LM830GetTraduction(LM830clave);

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            Text = LM830lenguaje.LM830GetTraduction("RFN2_PremiosCanjeables");
            LM830lblTitulo.Text = Text;
            LM830grpCliente.Text = LM830lenguaje.LM830GetTraduction("RFN1_Cliente");
            LM830lblDni.Text = LM830lenguaje.LM830GetTraduction("RFN1_Dni");
            LM830btnBuscarCliente.Text = LM830lenguaje.LM830GetTraduction("RFN1_BuscarCliente");
            LM830lblSaldoTitulo.Text = LM830lenguaje.LM830GetTraduction("RFN1_SaldoVigente") + ":";
            LM830lblComprometidosTitulo.Text = LM830lenguaje.LM830GetTraduction("RFN2_Comprometidos") + ":";
            LM830lblDisponibleTitulo.Text = LM830lenguaje.LM830GetTraduction("RFN2_Disponible") + ":";
            LM830btnRegistrarCanje.Text = LM830lenguaje.LM830GetTraduction("RFN2_RegistrarCanje");
            LM830btnVolver.Text = LM830lenguaje.LM830GetTraduction("RFN1_Volver");
            SendMessage(LM830txtDni.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN1_PH_Dni"));
            if (LM830_cliente == null) LM830lblPremios.Text = LM830lenguaje.LM830GetTraduction("RFN2_PremiosQuePuede");
        }
    }
}
