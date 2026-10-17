#nullable enable
using BE.RFN1;
using BLL.RFN1;
using Servicios;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI.RFN1
{
    public partial class frmReclamo : Form, IObserver
    {
        private readonly ReclamoBLL _reclamoBLL = new ReclamoBLL();
        private readonly VentaBLL _ventaBLL = new VentaBLL();
        private readonly ClienteBLL _clienteBLL = new ClienteBLL();

        private Cliente? _cliente;
        private Venta? _venta;
        private bool _ventaValida;

        public frmReclamo()
        {
            InitializeComponent();
        }

        private void frmReclamo_Load(object sender, EventArgs e)
        {
            LanguageManager.Instance.AgregarObservador(this);
            Estilo.Aplicar(this);
            Actualizar(LanguageManager.Instance);
            Limpiar();
        }

        private void Limpiar()
        {
            _cliente = null;
            txtDni.Clear();
            lblCliente.Text = "-";
            LimpiarVenta();
            txtNroComprobante.Clear();
            txtMotivo.Clear();
            txtDni.Select();
        }

        private void LimpiarVenta()
        {
            _venta = null;
            _ventaValida = false;
            lblVentaDatos.Text = "-";
            lblPuntos.Text = "-";
            dgvDetalle.DataSource = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = txtDni.Text.Trim();
                if (!Regex.IsMatch(dni, @"^\d{7,8}$"))
                {
                    MessageBox.Show(T("RFN1_DniInvalido"), T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cliente? cliente = _clienteBLL.Buscar(dni);
                if (cliente == null)
                {
                    MessageBox.Show(T("RFN1_ClienteNoInscriptoReclamo"), T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (var frm = new frmRegistrarCliente(dni))
                    {
                        if (frm.ShowDialog(this) == DialogResult.OK) cliente = frm.ClienteRegistrado;
                    }
                    if (cliente == null) return;
                }

                _cliente = cliente;
                lblCliente.Text = $"{cliente.NombreCompleto} - {T("RFN1_Nivel")} {cliente.Nivel.Nombre}";
                if (_venta != null) MostrarVenta();
                txtNroComprobante.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarVenta();
                if (_cliente == null)
                {
                    MessageBox.Show(T("RFN1_PrimeroCliente"), T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _venta = _ventaBLL.ObtenerPorNro(txtNroComprobante.Text);
                if (_venta == null)
                {
                    MessageBox.Show(T("RFN1_VentaNoExiste"), T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MostrarVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarVenta()
        {
            if (_venta == null || _cliente == null) return;

            txtNroComprobante.Text = _venta.NroComprobante;
            lblVentaDatos.Text = $"{_venta.Fecha:dd/MM/yyyy HH:mm} - $ {_venta.Total:N2}";
            dgvDetalle.DataSource = _venta.Detalle.Select(d => new
            {
                Producto = d.Producto.Nombre,
                Cantidad = d.Cantidad,
                Subtotal = d.Subtotal.ToString("N2")
            }).ToList();

            _ventaValida = _reclamoBLL.Validar(_venta);
            if (!_ventaValida)
            {
                lblPuntos.Text = "-";
                MessageBox.Show(_reclamoBLL.MensajeValidacion, T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int puntos = _reclamoBLL.CalcularPuntosReclamo(_venta, _cliente);
            lblPuntos.Text = puntos.ToString("N0");
            txtMotivo.Select();
        }

        private void btnRegistrarReclamo_Click(object sender, EventArgs e)
        {
            if (_cliente == null || _venta == null || !_ventaValida)
            {
                MessageBox.Show(T("RFN1_CompletarReclamo"), T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMotivo.Text.Trim().Length == 0)
            {
                MessageBox.Show(T("RFN1_MotivoObligatorio"), T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivo.Select();
                return;
            }

            try
            {
                var reclamo = new Reclamo { Cliente = _cliente, Venta = _venta, Motivo = txtMotivo.Text };
                _reclamoBLL.Registrar(reclamo);
                MessageBox.Show($"{T("RFN1_ReclamoRegistrado")} #{reclamo.IdReclamo} ({reclamo.PuntosReclamados:N0} {T("RFN1_Puntos")}).",
                    T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("RFN1_RegistrarReclamo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e) => Close();

        private void frmReclamo_FormClosed(object sender, FormClosedEventArgs e)
        {
            LanguageManager.Instance.EliminarObservador(this);
            Navegacion.MostrarMenu();
        }

        private static string T(string clave) => LanguageManager.Instance.GetTraduction(clave);

        public void Actualizar(LanguageManager lenguaje)
        {
            Text = lenguaje.GetTraduction("RFN1_RegistrarReclamo");
            lblTitulo.Text = Text;
            grpCliente.Text = lenguaje.GetTraduction("RFN1_Cliente");
            lblDni.Text = lenguaje.GetTraduction("RFN1_Dni");
            btnBuscarCliente.Text = lenguaje.GetTraduction("RFN1_BuscarCliente");
            grpVenta.Text = lenguaje.GetTraduction("RFN1_Compra");
            lblComprobante.Text = lenguaje.GetTraduction("RFN1_NroComprobante");
            btnBuscarVenta.Text = lenguaje.GetTraduction("RFN1_Buscar");
            lblPuntosTitulo.Text = lenguaje.GetTraduction("RFN1_PuntosCorresponderian");
            lblMotivo.Text = lenguaje.GetTraduction("RFN1_MotivoReclamo");
            btnRegistrarReclamo.Text = lenguaje.GetTraduction("RFN1_RegistrarReclamo");
            btnVolver.Text = lenguaje.GetTraduction("RFN1_Volver");
        }
    }
}
