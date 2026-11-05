#nullable enable
using LM830BE.LM830RFN2;
using LM830BLL.LM830RFN2;
using LM830Servicios;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LM830GUI.LM830RFN2
{
    public partial class LM830frmAnularCanje : Form, LM830IObserver
    {
        private const int LM830EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private readonly LM830CanjeBLL LM830_canjeBLL = new LM830CanjeBLL();
        private LM830Canje? LM830_canje;

        public LM830frmAnularCanje()
        {
            InitializeComponent();
        }

        private void LM830frmAnularCanje_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Estilo.LM830Aplicar(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
            LM830Mostrar();
            LM830txtNroCanje.Select();
        }

        private void LM830btnBuscar_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                LM830_canje = LM830_canjeBLL.LM830ObtenerPorNro(LM830txtNroCanje.Text);
                if (LM830_canje == null)
                {
                    LM830Mostrar();
                    MessageBox.Show(LM830T("RFN2_CanjeNoExiste"), LM830T("RFN2_AnularCanje"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LM830txtNroCanje.SelectAll();
                    LM830txtNroCanje.Select();
                    return;
                }
                LM830txtNroCanje.Text = LM830_canje.LM830NroCanje;
                LM830Mostrar();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830Mostrar()
        {
            LM830Canje? LM830k = LM830_canje;
            if (LM830k == null)
            {
                LM830lblClienteDatos.Text = "-";
                LM830lblPremioDatos.Text = "-";
                LM830lblEntregaDatos.Text = "-";
                LM830lblEstadoDatos.Text = "-";
                LM830dgvLotes.DataSource = null;
                LM830btnAnular.Enabled = false;
                return;
            }

            LM830lblClienteDatos.Text = $"{LM830T("RFN1_Cliente")}: {LM830k.LM830Cliente.LM830NombreCompleto} (DNI {LM830k.LM830Cliente.LM830Dni})";
            LM830lblPremioDatos.Text = $"{LM830T("RFN2_Premio")}: {LM830k.LM830Premio.LM830Nombre} - {LM830k.LM830PuntosRequeridos:N0} pts";
            LM830lblEntregaDatos.Text = LM830k.LM830FechaEntrega.HasValue
                ? $"{LM830T("RFN2_FechaEntrega")}: {LM830k.LM830FechaEntrega.Value:dd/MM/yyyy HH:mm}"
                : $"{LM830T("RFN2_FechaSolicitud")}: {LM830k.LM830FechaSolicitud:dd/MM/yyyy HH:mm}";

            string LM830estado = $"{LM830T("RFN2_Estado")}: {LM830T("RFN2_Estado_" + LM830k.LM830Estado.LM830ATexto())}";
            bool LM830anulable = LM830k.LM830Estado == LM830EstadoCanje.LM830entregado && LM830_canjeBLL.LM830DentroDelPlazoDeAnulacion(LM830k);
            if (LM830k.LM830Estado == LM830EstadoCanje.LM830entregado && !LM830anulable) LM830estado += " - " + LM830T("RFN2_FueraDePlazo");
            if (LM830k.LM830Estado == LM830EstadoCanje.LM830anulado && LM830k.LM830MotivoAnulacion != null) LM830estado += " - " + LM830k.LM830MotivoAnulacion;
            LM830lblEstadoDatos.Text = LM830estado;
            LM830lblEstadoDatos.ForeColor = LM830anulable ? LM830Estilo.LM830VerdeOscuro : System.Drawing.Color.Firebrick;

            LM830dgvLotes.DataSource = LM830k.LM830Detalle.Select(LM830d => new
            {
                Lote = LM830d.LM830Lote.LM830IdLote,
                Acreditado = LM830d.LM830Lote.LM830FechaAcreditacion.ToString("dd/MM/yyyy"),
                Vence = LM830d.LM830Lote.LM830FechaVencimiento.ToString("dd/MM/yyyy"),
                Descontados = LM830d.LM830PuntosDescontados.ToString("N0")
            }).ToList();
            LM830btnAnular.Enabled = LM830anulable;
        }

        private void LM830btnAnular_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830_canje == null) return;
            if (LM830txtMotivo.Text.Trim().Length == 0)
            {
                MessageBox.Show(LM830T("RFN2_MotivoAnulacion"), LM830T("RFN2_AnularCanje"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LM830txtMotivo.Select();
                return;
            }
            if (MessageBox.Show($"{LM830T("RFN2_ConfirmarAnulacion")} {LM830_canje.LM830NroCanje}?", LM830T("RFN2_AnularCanje"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int LM830reintegrados = LM830_canjeBLL.LM830Anular(LM830_canje, LM830txtMotivo.Text);
                MessageBox.Show($"{LM830T("RFN2_CanjeAnulado")} {LM830reintegrados:N0} pts.", LM830T("RFN2_AnularCanje"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LM830txtMotivo.Clear();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try { LM830_canje = LM830_canjeBLL.LM830ObtenerPorNro(LM830_canje.LM830NroCanje); } catch { }
            LM830Mostrar();
        }

        private void LM830btnVolver_Click(object LM830sender, EventArgs LM830e) => Close();

        private void LM830frmAnularCanje_FormClosed(object LM830sender, FormClosedEventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830EliminarObservador(this);
            LM830Navegacion.LM830MostrarMenu();
        }

        private static string LM830T(string LM830clave) => LM830LanguageManager.LM830Instance.LM830GetTraduction(LM830clave);

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            Text = LM830lenguaje.LM830GetTraduction("RFN2_AnularCanje");
            LM830lblTitulo.Text = Text;
            LM830lblNro.Text = LM830lenguaje.LM830GetTraduction("RFN2_NroCanje");
            LM830btnBuscar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Buscar");
            LM830grpCanje.Text = LM830lenguaje.LM830GetTraduction("RFN2_Canje");
            LM830lblLotes.Text = LM830lenguaje.LM830GetTraduction("RFN2_PuntosPorVencimiento");
            LM830lblMotivo.Text = LM830lenguaje.LM830GetTraduction("RFN2_MotivoDeAnulacion");
            LM830btnAnular.Text = LM830lenguaje.LM830GetTraduction("RFN2_AnularCanje");
            LM830btnVolver.Text = LM830lenguaje.LM830GetTraduction("RFN1_Volver");
            SendMessage(LM830txtNroCanje.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN2_PH_NroCanje"));
            LM830Mostrar();
        }
    }
}
