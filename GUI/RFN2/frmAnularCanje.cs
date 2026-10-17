#nullable enable
using BE.RFN2;
using BLL.RFN2;
using Servicios;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI.RFN2
{
    public partial class frmAnularCanje : Form, IObserver
    {
        private readonly CanjeBLL _canjeBLL = new CanjeBLL();
        private Canje? _canje;

        public frmAnularCanje()
        {
            InitializeComponent();
        }

        private void frmAnularCanje_Load(object sender, EventArgs e)
        {
            LanguageManager.Instance.AgregarObservador(this);
            Estilo.Aplicar(this);
            Actualizar(LanguageManager.Instance);
            Mostrar();
            txtNroCanje.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _canje = _canjeBLL.ObtenerPorNro(txtNroCanje.Text);
                if (_canje == null)
                {
                    Mostrar();
                    MessageBox.Show(T("RFN2_CanjeNoExiste"), T("RFN2_AnularCanje"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNroCanje.SelectAll();
                    txtNroCanje.Select();
                    return;
                }
                txtNroCanje.Text = _canje.NroCanje;
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Mostrar()
        {
            Canje? k = _canje;
            if (k == null)
            {
                lblClienteDatos.Text = "-";
                lblPremioDatos.Text = "-";
                lblEntregaDatos.Text = "-";
                lblEstadoDatos.Text = "-";
                dgvLotes.DataSource = null;
                btnAnular.Enabled = false;
                return;
            }

            lblClienteDatos.Text = $"{T("RFN1_Cliente")}: {k.Cliente.NombreCompleto} (DNI {k.Cliente.Dni})";
            lblPremioDatos.Text = $"{T("RFN2_Premio")}: {k.Premio.Nombre} - {k.PuntosRequeridos:N0} pts";
            lblEntregaDatos.Text = k.FechaEntrega.HasValue
                ? $"{T("RFN2_FechaEntrega")}: {k.FechaEntrega.Value:dd/MM/yyyy HH:mm}"
                : $"{T("RFN2_FechaSolicitud")}: {k.FechaSolicitud:dd/MM/yyyy HH:mm}";

            string estado = $"{T("RFN2_Estado")}: {T("RFN2_Estado_" + k.Estado)}";
            bool anulable = k.Estado == EstadoCanje.entregado && _canjeBLL.DentroDelPlazoDeAnulacion(k);
            if (k.Estado == EstadoCanje.entregado && !anulable) estado += " - " + T("RFN2_FueraDePlazo");
            if (k.Estado == EstadoCanje.anulado && k.MotivoAnulacion != null) estado += " - " + k.MotivoAnulacion;
            lblEstadoDatos.Text = estado;
            lblEstadoDatos.ForeColor = anulable ? Estilo.VerdeOscuro : System.Drawing.Color.Firebrick;

            dgvLotes.DataSource = k.Detalle.Select(d => new
            {
                Lote = d.Lote.IdLote,
                Acreditado = d.Lote.FechaAcreditacion.ToString("dd/MM/yyyy"),
                Vence = d.Lote.FechaVencimiento.ToString("dd/MM/yyyy"),
                Descontados = d.PuntosDescontados.ToString("N0")
            }).ToList();
            btnAnular.Enabled = anulable;
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (_canje == null) return;
            if (txtMotivo.Text.Trim().Length == 0)
            {
                MessageBox.Show(T("RFN2_MotivoAnulacion"), T("RFN2_AnularCanje"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivo.Select();
                return;
            }
            if (MessageBox.Show($"{T("RFN2_ConfirmarAnulacion")} {_canje.NroCanje}?", T("RFN2_AnularCanje"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int reintegrados = _canjeBLL.Anular(_canje, txtMotivo.Text);
                MessageBox.Show($"{T("RFN2_CanjeAnulado")} {reintegrados:N0} pts.", T("RFN2_AnularCanje"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMotivo.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try { _canje = _canjeBLL.ObtenerPorNro(_canje.NroCanje); } catch { }
            Mostrar();
        }

        private void btnVolver_Click(object sender, EventArgs e) => Close();

        private void frmAnularCanje_FormClosed(object sender, FormClosedEventArgs e)
        {
            LanguageManager.Instance.EliminarObservador(this);
            Navegacion.MostrarMenu();
        }

        private static string T(string clave) => LanguageManager.Instance.GetTraduction(clave);

        public void Actualizar(LanguageManager lenguaje)
        {
            Text = lenguaje.GetTraduction("RFN2_AnularCanje");
            lblTitulo.Text = Text;
            lblNro.Text = lenguaje.GetTraduction("RFN2_NroCanje");
            btnBuscar.Text = lenguaje.GetTraduction("RFN1_Buscar");
            grpCanje.Text = lenguaje.GetTraduction("RFN2_Canje");
            lblLotes.Text = lenguaje.GetTraduction("RFN2_PuntosPorVencimiento");
            lblMotivo.Text = lenguaje.GetTraduction("RFN2_MotivoDeAnulacion");
            btnAnular.Text = lenguaje.GetTraduction("RFN2_AnularCanje");
            btnVolver.Text = lenguaje.GetTraduction("RFN1_Volver");
            Mostrar();
        }
    }
}
