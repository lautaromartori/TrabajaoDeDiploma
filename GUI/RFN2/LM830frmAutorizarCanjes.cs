#nullable enable
using LM830BE.LM830RFN2;
using LM830BLL.LM830RFN2;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LM830GUI.LM830RFN2
{
    public partial class LM830frmAutorizarCanjes : Form, LM830IObserver
    {
        private readonly LM830CanjeBLL LM830_canjeBLL = new LM830CanjeBLL();
        private List<LM830Canje> LM830_pendientes = new List<LM830Canje>();

        public LM830frmAutorizarCanjes()
        {
            InitializeComponent();
        }

        private void LM830frmAutorizarCanjes_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Estilo.LM830Aplicar(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
            LM830CargarPendientes();
        }

        private void LM830CargarPendientes()
        {
            try
            {
                LM830_pendientes = LM830_canjeBLL.LM830ListarPendientes();
                LM830dgvPendientes.DataSource = LM830_pendientes.Select(LM830k => new
                {
                    Fecha = LM830k.LM830FechaSolicitud.ToString("dd/MM/yyyy HH:mm"),
                    Canje = LM830k.LM830NroCanje,
                    Cliente = LM830k.LM830Cliente.LM830NombreCompleto,
                    Premio = LM830k.LM830Premio.LM830Nombre,
                    Puntos = LM830k.LM830PuntosRequeridos.ToString("N0"),
                    Valor = "$ " + LM830k.LM830ValorReferencia.ToString("N2"),
                    Vendedor = LM830k.LM830Vendedor.LM830Nombre
                }).ToList();
                LM830txtMotivo.Clear();
                LM830MostrarDetalle();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private LM830Canje? LM830Seleccionado()
        {
            if (LM830dgvPendientes.CurrentRow == null) return null;
            int LM830i = LM830dgvPendientes.CurrentRow.Index;
            return LM830i >= 0 && LM830i < LM830_pendientes.Count ? LM830_pendientes[LM830i] : null;
        }

        private void LM830dgvPendientes_SelectionChanged(object LM830sender, EventArgs LM830e) => LM830MostrarDetalle();

        private void LM830MostrarDetalle()
        {
            LM830Canje? LM830k = LM830Seleccionado();
            if (LM830k == null)
            {
                LM830lblClienteDatos.Text = "-";
                LM830lblPremioDatos.Text = "-";
                LM830lblSaldoDatos.Text = "-";
                return;
            }

            string LM830saldo = "-";
            try { LM830saldo = LM830_canjeBLL.LM830SaldoVigente(LM830k.LM830Cliente).ToString("N0"); } catch { }

            LM830lblClienteDatos.Text = $"{LM830T("RFN1_Cliente")}: {LM830k.LM830Cliente.LM830NombreCompleto} (DNI {LM830k.LM830Cliente.LM830Dni}) - {LM830T("RFN1_Nivel")} {LM830k.LM830Cliente.LM830Nivel.LM830Nombre}";
            LM830lblPremioDatos.Text = $"{LM830T("RFN2_Premio")}: {LM830k.LM830Premio.LM830Nombre} - {LM830k.LM830PuntosRequeridos:N0} pts - {LM830T("RFN2_ValorReferencia")} $ {LM830k.LM830ValorReferencia:N2} - Stock {LM830k.LM830Premio.LM830Stock}";
            LM830lblSaldoDatos.Text = $"{LM830T("RFN1_SaldoVigente")}: {LM830saldo} pts";
        }

        private void LM830btnAutorizar_Click(object LM830sender, EventArgs LM830e) => LM830Decidir(true);

        private void LM830btnRechazar_Click(object LM830sender, EventArgs LM830e) => LM830Decidir(false);

        private void LM830Decidir(bool LM830autorizar)
        {
            LM830Canje? LM830k = LM830Seleccionado();
            if (LM830k == null)
            {
                MessageBox.Show(LM830T("RFN2_SeleccioneCanje"), LM830T("RFN2_AutorizarCanjes"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!LM830autorizar && LM830txtMotivo.Text.Trim().Length == 0)
            {
                MessageBox.Show(LM830T("RFN2_MotivoRechazo"), LM830T("RFN2_AutorizarCanjes"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LM830txtMotivo.Select();
                return;
            }

            string LM830accion = LM830autorizar ? LM830T("RFN2_Autorizar") : LM830T("RFN1_Rechazar");
            if (MessageBox.Show($"{LM830accion} {LM830T("RFN2_ElCanje")} {LM830k.LM830NroCanje} ({LM830k.LM830Premio.LM830Nombre})?", LM830T("RFN2_AutorizarCanjes"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                LM830_canjeBLL.LM830Resolver(LM830k, LM830autorizar, LM830txtMotivo.Text);
                MessageBox.Show(LM830autorizar ? LM830T("RFN2_CanjeAutorizadoOk") : LM830T("RFN2_CanjeRechazadoOk"), LM830T("RFN2_AutorizarCanjes"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LM830CargarPendientes();
        }

        private void LM830btnVolver_Click(object LM830sender, EventArgs LM830e) => Close();

        private void LM830frmAutorizarCanjes_FormClosed(object LM830sender, FormClosedEventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830EliminarObservador(this);
            LM830Navegacion.LM830MostrarMenu();
        }

        private static string LM830T(string LM830clave) => LM830LanguageManager.LM830Instance.LM830GetTraduction(LM830clave);

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            Text = LM830lenguaje.LM830GetTraduction("RFN2_AutorizarCanjes");
            LM830lblTitulo.Text = Text;
            LM830lblPendientes.Text = LM830lenguaje.LM830GetTraduction("RFN2_CanjesPendientes");
            LM830grpDetalle.Text = LM830lenguaje.LM830GetTraduction("RFN1_Detalle");
            LM830lblMotivo.Text = LM830lenguaje.LM830GetTraduction("RFN2_MotivoObligatorioRechazo");
            LM830btnAutorizar.Text = LM830lenguaje.LM830GetTraduction("RFN2_Autorizar");
            LM830btnRechazar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Rechazar");
            LM830btnVolver.Text = LM830lenguaje.LM830GetTraduction("RFN1_Volver");
            LM830MostrarDetalle();
        }
    }
}
