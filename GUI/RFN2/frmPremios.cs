#nullable enable
using BE.RFN1;
using BE.RFN2;
using BLL.RFN1;
using BLL.RFN2;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI.RFN2
{
    public partial class frmPremios : Form, IObserver
    {
        private readonly ClienteBLL _clienteBLL = new ClienteBLL();
        private readonly PremioBLL _premioBLL = new PremioBLL();
        private readonly CanjeBLL _canjeBLL = new CanjeBLL();

        private Cliente? _cliente;
        private List<Premio> _premios = new List<Premio>();

        public frmPremios()
        {
            InitializeComponent();
        }

        private void frmPremios_Load(object sender, EventArgs e)
        {
            LanguageManager.Instance.AgregarObservador(this);
            Estilo.Aplicar(this);
            Actualizar(LanguageManager.Instance);
            btnRegistrarCanje.Enabled = SessionManager.Instance.UsuarioActual().TienePermiso("Registrar Canje");
            LimpiarCliente();
            txtDni.Select();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            if (!Regex.IsMatch(dni, @"^\d{7,8}$"))
            {
                MessageBox.Show(T("RFN1_DniInvalido"), T("RFN2_PremiosCanjeables"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Select();
                return;
            }

            try
            {
                _cliente = _clienteBLL.Buscar(dni);
                if (_cliente == null)
                {
                    LimpiarCliente();
                    MessageBox.Show(T("RFN1_ClienteNoInscripto"), T("RFN2_PremiosCanjeables"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CargarPremios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPremios()
        {
            if (_cliente == null) return;

            int saldo = _canjeBLL.SaldoVigente(_cliente);
            int comprometidos = _canjeBLL.PuntosComprometidos(_cliente);
            int disponible = Math.Max(0, saldo - comprometidos);

            lblCliente.Text = $"{_cliente.NombreCompleto} - {T("RFN1_Nivel")} {_cliente.Nivel.Nombre}";
            lblSaldo.Text = saldo.ToString("N0") + " pts";
            lblComprometidos.Text = comprometidos.ToString("N0") + " pts";
            lblDisponible.Text = disponible.ToString("N0") + " pts";

            _premios = _premioBLL.ListarCanjeables(disponible);
            dgvPremios.DataSource = _premios.Select(p => new
            {
                Premio = p.Nombre,
                Descripción = p.Descripcion,
                Puntos = p.PuntosRequeridos.ToString("N0"),
                Stock = p.Stock,
                Valor = "$ " + p.ValorReferencia.ToString("N2"),
                Autorización = _premioBLL.RequiereAutorizacion(p) ? T("RFN2_RequiereSupervisor") : T("RFN2_Automatica")
            }).ToList();

            if (_premios.Count == 0)
                lblPremios.Text = T("RFN2_SinPremios");
            else
                lblPremios.Text = T("RFN2_PremiosQuePuede");
        }

        private void LimpiarCliente()
        {
            _cliente = null;
            _premios = new List<Premio>();
            dgvPremios.DataSource = null;
            lblCliente.Text = "-";
            lblSaldo.Text = "-";
            lblComprometidos.Text = "-";
            lblDisponible.Text = "-";
            lblPremios.Text = T("RFN2_PremiosQuePuede");
            try
            {
                lblUmbral.Text = $"{T("RFN2_InfoUmbral")} $ {ProgramaPuntosBLL.Obtener().UmbralAutorizacion:N2}.";
            }
            catch
            {
                lblUmbral.Text = "";
            }
        }

        private Premio? Seleccionado()
        {
            if (dgvPremios.CurrentRow == null) return null;
            int i = dgvPremios.CurrentRow.Index;
            return i >= 0 && i < _premios.Count ? _premios[i] : null;
        }

        private void btnRegistrarCanje_Click(object sender, EventArgs e)
        {
            if (_cliente == null)
            {
                MessageBox.Show(T("RFN1_PrimeroCliente"), T("RFN2_RegistrarCanje"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Premio? premio = Seleccionado();
            if (premio == null)
            {
                MessageBox.Show(T("RFN2_SeleccionePremio"), T("RFN2_RegistrarCanje"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"{T("RFN2_ConfirmarCanje")} {premio.Nombre} ({premio.PuntosRequeridos:N0} pts) - {_cliente.NombreCompleto}?",
                    T("RFN2_RegistrarCanje"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                Canje canje = _canjeBLL.RegistrarSolicitud(_cliente, premio);
                string estado = canje.Estado == EstadoCanje.autorizado ? T("RFN2_CanjeAutorizado") : T("RFN2_CanjePendiente");
                MessageBox.Show($"{T("RFN2_CanjeRegistrado")} {canje.NroCanje}.{Environment.NewLine}{estado}",
                    T("RFN2_RegistrarCanje"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("RFN2_RegistrarCanje"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try { CargarPremios(); } catch { }
        }

        private void btnVolver_Click(object sender, EventArgs e) => Close();

        private void frmPremios_FormClosed(object sender, FormClosedEventArgs e)
        {
            LanguageManager.Instance.EliminarObservador(this);
            Navegacion.MostrarMenu();
        }

        private static string T(string clave) => LanguageManager.Instance.GetTraduction(clave);

        public void Actualizar(LanguageManager lenguaje)
        {
            Text = lenguaje.GetTraduction("RFN2_PremiosCanjeables");
            lblTitulo.Text = Text;
            grpCliente.Text = lenguaje.GetTraduction("RFN1_Cliente");
            lblDni.Text = lenguaje.GetTraduction("RFN1_Dni");
            btnBuscarCliente.Text = lenguaje.GetTraduction("RFN1_BuscarCliente");
            lblSaldoTitulo.Text = lenguaje.GetTraduction("RFN1_SaldoVigente") + ":";
            lblComprometidosTitulo.Text = lenguaje.GetTraduction("RFN2_Comprometidos") + ":";
            lblDisponibleTitulo.Text = lenguaje.GetTraduction("RFN2_Disponible") + ":";
            btnRegistrarCanje.Text = lenguaje.GetTraduction("RFN2_RegistrarCanje");
            btnVolver.Text = lenguaje.GetTraduction("RFN1_Volver");
            if (_cliente == null) lblPremios.Text = lenguaje.GetTraduction("RFN2_PremiosQuePuede");
        }
    }
}
