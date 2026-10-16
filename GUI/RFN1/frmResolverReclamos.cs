#nullable enable
using BE.RFN1;
using BLL.RFN1;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI.RFN1
{
    // CU-N01-005 Resolver reclamo (Supervisor).
    public partial class frmResolverReclamos : Form, IObserver
    {
        private readonly ReclamoBLL _reclamoBLL = new ReclamoBLL();
        private readonly LoteBLL _loteBLL = new LoteBLL();
        private List<Reclamo> _pendientes = new List<Reclamo>();

        public frmResolverReclamos()
        {
            InitializeComponent();
        }

        private void frmResolverReclamos_Load(object sender, EventArgs e)
        {
            LanguageManager.Instance.AgregarObservador(this);
            Actualizar(LanguageManager.Instance);
            CargarPendientes();
        }

        // Paso 2
        private void CargarPendientes()
        {
            try
            {
                _pendientes = _reclamoBLL.ListarPendientes();
                dgvPendientes.DataSource = _pendientes.Select(r => new
                {
                    Fecha = r.FechaReclamo.ToString("dd/MM/yyyy HH:mm"),
                    Cliente = r.Cliente.NombreCompleto,
                    Comprobante = r.Venta.NroComprobante,
                    Puntos = r.PuntosReclamados,
                    Motivo = r.Motivo
                }).ToList();
                txtMotivoResolucion.Clear();
                MostrarDetalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Reclamo? Seleccionado()
        {
            if (dgvPendientes.CurrentRow == null) return null;
            int i = dgvPendientes.CurrentRow.Index;
            return i >= 0 && i < _pendientes.Count ? _pendientes[i] : null;
        }

        private void dgvPendientes_SelectionChanged(object sender, EventArgs e) => MostrarDetalle();

        // Paso 3: detalle de la venta e historial del cliente.
        private void MostrarDetalle()
        {
            Reclamo? r = Seleccionado();
            if (r == null)
            {
                lblVentaDatos.Text = "-";
                lblClienteDatos.Text = "-";
                lblMotivoReclamo.Text = "-";
                return;
            }

            string saldo = "-";
            try { saldo = _loteBLL.ConsultarSaldo(r.Cliente).ToString("N0"); } catch { }

            lblVentaDatos.Text = $"{T("RFN1_Compra")}: {r.Venta.NroComprobante} - {r.Venta.Fecha:dd/MM/yyyy HH:mm} - $ {r.Venta.Total:N2}";
            lblClienteDatos.Text = $"{T("RFN1_Cliente")}: {r.Cliente.NombreCompleto} (DNI {r.Cliente.Dni}) - {T("RFN1_Nivel")} {r.Cliente.Nivel.Nombre} - {T("RFN1_SaldoVigente")} {saldo}";
            lblMotivoReclamo.Text = $"{T("RFN1_MotivoReclamo")}: {r.Motivo}";
        }

        private void btnAprobar_Click(object sender, EventArgs e) => Decidir(EstadoReclamo.aprobado);

        private void btnRechazar_Click(object sender, EventArgs e) => Decidir(EstadoReclamo.rechazado);

        // Pasos 4-7
        private void Decidir(EstadoReclamo decision)
        {
            Reclamo? r = Seleccionado();
            if (r == null)
            {
                MessageBox.Show(T("RFN1_SeleccioneReclamo"), T("RFN1_ResolverReclamos"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (decision == EstadoReclamo.rechazado && txtMotivoResolucion.Text.Trim().Length == 0)
            {
                // Flujo 4.2
                MessageBox.Show(T("RFN1_MotivoRechazo"), T("RFN1_ResolverReclamos"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivoResolucion.Select();
                return;
            }

            string accion = decision == EstadoReclamo.aprobado ? T("RFN1_Aprobar") : T("RFN1_Rechazar");
            if (MessageBox.Show($"{accion} {T("RFN1_ElReclamoDe")} {r.Cliente.NombreCompleto}?", T("RFN1_ResolverReclamos"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                r.Estado = decision;
                r.MotivoResolucion = txtMotivoResolucion.Text;
                _reclamoBLL.Resolver(r);
                MessageBox.Show(T("RFN1_ReclamoResuelto"), T("RFN1_ResolverReclamos"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                r.Estado = EstadoReclamo.pendiente;
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarPendientes();
        }

        private void btnVolver_Click(object sender, EventArgs e) => Close();

        private void frmResolverReclamos_FormClosed(object sender, FormClosedEventArgs e)
        {
            LanguageManager.Instance.EliminarObservador(this);
            Navegacion.MostrarMenu();
        }

        private static string T(string clave) => LanguageManager.Instance.GetTraduction(clave);

        public void Actualizar(LanguageManager lenguaje)
        {
            Text = lenguaje.GetTraduction("RFN1_ResolverReclamos");
            lblTitulo.Text = Text;
            lblPendientes.Text = lenguaje.GetTraduction("RFN1_ReclamosPendientes");
            grpDetalle.Text = lenguaje.GetTraduction("RFN1_Detalle");
            lblMotivoResolucion.Text = lenguaje.GetTraduction("RFN1_MotivoResolucion");
            btnAprobar.Text = lenguaje.GetTraduction("RFN1_Aprobar");
            btnRechazar.Text = lenguaje.GetTraduction("RFN1_Rechazar");
            btnVolver.Text = lenguaje.GetTraduction("RFN1_Volver");
        }
    }
}
