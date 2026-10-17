#nullable enable
using BE.RFN2;
using BLL.RFN2;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI.RFN2
{
    public partial class frmAutorizarCanjes : Form, IObserver
    {
        private readonly CanjeBLL _canjeBLL = new CanjeBLL();
        private List<Canje> _pendientes = new List<Canje>();

        public frmAutorizarCanjes()
        {
            InitializeComponent();
        }

        private void frmAutorizarCanjes_Load(object sender, EventArgs e)
        {
            LanguageManager.Instance.AgregarObservador(this);
            Estilo.Aplicar(this);
            Actualizar(LanguageManager.Instance);
            CargarPendientes();
        }

        private void CargarPendientes()
        {
            try
            {
                _pendientes = _canjeBLL.ListarPendientes();
                dgvPendientes.DataSource = _pendientes.Select(k => new
                {
                    Fecha = k.FechaSolicitud.ToString("dd/MM/yyyy HH:mm"),
                    Canje = k.NroCanje,
                    Cliente = k.Cliente.NombreCompleto,
                    Premio = k.Premio.Nombre,
                    Puntos = k.PuntosRequeridos.ToString("N0"),
                    Valor = "$ " + k.ValorReferencia.ToString("N2"),
                    Vendedor = k.Vendedor.Nombre
                }).ToList();
                txtMotivo.Clear();
                MostrarDetalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Canje? Seleccionado()
        {
            if (dgvPendientes.CurrentRow == null) return null;
            int i = dgvPendientes.CurrentRow.Index;
            return i >= 0 && i < _pendientes.Count ? _pendientes[i] : null;
        }

        private void dgvPendientes_SelectionChanged(object sender, EventArgs e) => MostrarDetalle();

        private void MostrarDetalle()
        {
            Canje? k = Seleccionado();
            if (k == null)
            {
                lblClienteDatos.Text = "-";
                lblPremioDatos.Text = "-";
                lblSaldoDatos.Text = "-";
                return;
            }

            string saldo = "-";
            try { saldo = _canjeBLL.SaldoVigente(k.Cliente).ToString("N0"); } catch { }

            lblClienteDatos.Text = $"{T("RFN1_Cliente")}: {k.Cliente.NombreCompleto} (DNI {k.Cliente.Dni}) - {T("RFN1_Nivel")} {k.Cliente.Nivel.Nombre}";
            lblPremioDatos.Text = $"{T("RFN2_Premio")}: {k.Premio.Nombre} - {k.PuntosRequeridos:N0} pts - {T("RFN2_ValorReferencia")} $ {k.ValorReferencia:N2} - Stock {k.Premio.Stock}";
            lblSaldoDatos.Text = $"{T("RFN1_SaldoVigente")}: {saldo} pts";
        }

        private void btnAutorizar_Click(object sender, EventArgs e) => Decidir(true);

        private void btnRechazar_Click(object sender, EventArgs e) => Decidir(false);

        private void Decidir(bool autorizar)
        {
            Canje? k = Seleccionado();
            if (k == null)
            {
                MessageBox.Show(T("RFN2_SeleccioneCanje"), T("RFN2_AutorizarCanjes"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!autorizar && txtMotivo.Text.Trim().Length == 0)
            {
                MessageBox.Show(T("RFN2_MotivoRechazo"), T("RFN2_AutorizarCanjes"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivo.Select();
                return;
            }

            string accion = autorizar ? T("RFN2_Autorizar") : T("RFN1_Rechazar");
            if (MessageBox.Show($"{accion} {T("RFN2_ElCanje")} {k.NroCanje} ({k.Premio.Nombre})?", T("RFN2_AutorizarCanjes"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _canjeBLL.Resolver(k, autorizar, txtMotivo.Text);
                MessageBox.Show(autorizar ? T("RFN2_CanjeAutorizadoOk") : T("RFN2_CanjeRechazadoOk"), T("RFN2_AutorizarCanjes"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarPendientes();
        }

        private void btnVolver_Click(object sender, EventArgs e) => Close();

        private void frmAutorizarCanjes_FormClosed(object sender, FormClosedEventArgs e)
        {
            LanguageManager.Instance.EliminarObservador(this);
            Navegacion.MostrarMenu();
        }

        private static string T(string clave) => LanguageManager.Instance.GetTraduction(clave);

        public void Actualizar(LanguageManager lenguaje)
        {
            Text = lenguaje.GetTraduction("RFN2_AutorizarCanjes");
            lblTitulo.Text = Text;
            lblPendientes.Text = lenguaje.GetTraduction("RFN2_CanjesPendientes");
            grpDetalle.Text = lenguaje.GetTraduction("RFN1_Detalle");
            lblMotivo.Text = lenguaje.GetTraduction("RFN2_MotivoObligatorioRechazo");
            btnAutorizar.Text = lenguaje.GetTraduction("RFN2_Autorizar");
            btnRechazar.Text = lenguaje.GetTraduction("RFN1_Rechazar");
            btnVolver.Text = lenguaje.GetTraduction("RFN1_Volver");
            MostrarDetalle();
        }
    }
}
