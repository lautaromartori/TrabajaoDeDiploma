#nullable enable
using LM830BE.LM830RFN1;
using LM830BLL.LM830RFN1;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LM830GUI.LM830RFN1
{
    public partial class LM830frmResolverReclamos : Form, LM830IObserver
    {
        private readonly LM830ReclamoBLL LM830_reclamoBLL = new LM830ReclamoBLL();
        private readonly LM830LoteBLL LM830_loteBLL = new LM830LoteBLL();
        private List<LM830Reclamo> LM830_pendientes = new List<LM830Reclamo>();

        public LM830frmResolverReclamos()
        {
            InitializeComponent();
        }

        private void LM830frmResolverReclamos_Load(object LM830sender, EventArgs LM830e)
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
                LM830_pendientes = LM830_reclamoBLL.LM830ListarPendientes();
                LM830dgvPendientes.DataSource = LM830_pendientes.Select(LM830r => new
                {
                    Fecha = LM830r.LM830FechaReclamo.ToString("dd/MM/yyyy HH:mm"),
                    Cliente = LM830r.LM830Cliente.LM830NombreCompleto,
                    Comprobante = LM830r.LM830Venta.LM830NroComprobante,
                    Puntos = LM830r.LM830PuntosReclamados,
                    Motivo = LM830r.LM830Motivo
                }).ToList();
                LM830txtMotivoResolucion.Clear();
                LM830MostrarDetalle();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private LM830Reclamo? LM830Seleccionado()
        {
            if (LM830dgvPendientes.CurrentRow == null) return null;
            int LM830i = LM830dgvPendientes.CurrentRow.Index;
            return LM830i >= 0 && LM830i < LM830_pendientes.Count ? LM830_pendientes[LM830i] : null;
        }

        private void LM830dgvPendientes_SelectionChanged(object LM830sender, EventArgs LM830e) => LM830MostrarDetalle();

        private void LM830MostrarDetalle()
        {
            LM830Reclamo? LM830r = LM830Seleccionado();
            if (LM830r == null)
            {
                LM830lblVentaDatos.Text = "-";
                LM830lblClienteDatos.Text = "-";
                LM830lblMotivoReclamo.Text = "-";
                return;
            }

            string LM830saldo = "-";
            try { LM830saldo = LM830_loteBLL.LM830ConsultarSaldo(LM830r.LM830Cliente).ToString("N0"); } catch { }

            LM830lblVentaDatos.Text = $"{LM830T("RFN1_Compra")}: {LM830r.LM830Venta.LM830NroComprobante} - {LM830r.LM830Venta.LM830Fecha:dd/MM/yyyy HH:mm} - $ {LM830r.LM830Venta.LM830Total:N2}";
            LM830lblClienteDatos.Text = $"{LM830T("RFN1_Cliente")}: {LM830r.LM830Cliente.LM830NombreCompleto} (DNI {LM830r.LM830Cliente.LM830Dni}) - {LM830T("RFN1_Nivel")} {LM830r.LM830Cliente.LM830Nivel.LM830Nombre} - {LM830T("RFN1_SaldoVigente")} {LM830saldo}";
            LM830lblMotivoReclamo.Text = $"{LM830T("RFN1_MotivoReclamo")}: {LM830r.LM830Motivo}";
        }

        private void LM830btnAprobar_Click(object LM830sender, EventArgs LM830e) => LM830Decidir(LM830EstadoReclamo.LM830aprobado);

        private void LM830btnRechazar_Click(object LM830sender, EventArgs LM830e) => LM830Decidir(LM830EstadoReclamo.LM830rechazado);

        private void LM830Decidir(LM830EstadoReclamo LM830decision)
        {
            LM830Reclamo? LM830r = LM830Seleccionado();
            if (LM830r == null)
            {
                MessageBox.Show(LM830T("RFN1_SeleccioneReclamo"), LM830T("RFN1_ResolverReclamos"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (LM830decision == LM830EstadoReclamo.LM830rechazado && LM830txtMotivoResolucion.Text.Trim().Length == 0)
            {
                MessageBox.Show(LM830T("RFN1_MotivoRechazo"), LM830T("RFN1_ResolverReclamos"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LM830txtMotivoResolucion.Select();
                return;
            }

            string LM830accion = LM830decision == LM830EstadoReclamo.LM830aprobado ? LM830T("RFN1_Aprobar") : LM830T("RFN1_Rechazar");
            if (MessageBox.Show($"{LM830accion} {LM830T("RFN1_ElReclamoDe")} {LM830r.LM830Cliente.LM830NombreCompleto}?", LM830T("RFN1_ResolverReclamos"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                LM830r.LM830Estado = LM830decision;
                LM830r.LM830MotivoResolucion = LM830txtMotivoResolucion.Text;
                LM830_reclamoBLL.LM830Resolver(LM830r);
                MessageBox.Show(LM830T("RFN1_ReclamoResuelto"), LM830T("RFN1_ResolverReclamos"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception LM830ex)
            {
                LM830r.LM830Estado = LM830EstadoReclamo.LM830pendiente;
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LM830CargarPendientes();
        }

        private void LM830btnVolver_Click(object LM830sender, EventArgs LM830e) => Close();

        private void LM830frmResolverReclamos_FormClosed(object LM830sender, FormClosedEventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830EliminarObservador(this);
            LM830Navegacion.LM830MostrarMenu();
        }

        private static string LM830T(string LM830clave) => LM830LanguageManager.LM830Instance.LM830GetTraduction(LM830clave);

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            Text = LM830lenguaje.LM830GetTraduction("RFN1_ResolverReclamos");
            LM830lblTitulo.Text = Text;
            LM830lblPendientes.Text = LM830lenguaje.LM830GetTraduction("RFN1_ReclamosPendientes");
            LM830grpDetalle.Text = LM830lenguaje.LM830GetTraduction("RFN1_Detalle");
            LM830lblMotivoResolucion.Text = LM830lenguaje.LM830GetTraduction("RFN1_MotivoResolucion");
            LM830btnAprobar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Aprobar");
            LM830btnRechazar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Rechazar");
            LM830btnVolver.Text = LM830lenguaje.LM830GetTraduction("RFN1_Volver");
        }
    }
}
