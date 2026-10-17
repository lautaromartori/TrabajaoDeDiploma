#nullable enable
using BE.RFN2;
using BLL.RFN2;
using GUI.Comprobantes;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI.RFN2
{
    public partial class frmEntregarPremio : Form, IObserver
    {
        private readonly CanjeBLL _canjeBLL = new CanjeBLL();
        private List<Canje> _autorizados = new List<Canje>();
        private string? _filtroDni;

        public frmEntregarPremio()
        {
            InitializeComponent();
        }

        private void frmEntregarPremio_Load(object sender, EventArgs e)
        {
            LanguageManager.Instance.AgregarObservador(this);
            Estilo.Aplicar(this);
            Actualizar(LanguageManager.Instance);
            CargarAutorizados();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            if (dni.Length > 0 && !Regex.IsMatch(dni, @"^\d{7,8}$"))
            {
                MessageBox.Show(T("RFN1_DniInvalido"), T("RFN2_EntregarPremio"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _filtroDni = dni.Length == 0 ? null : dni;
            CargarAutorizados();
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            txtDni.Clear();
            _filtroDni = null;
            CargarAutorizados();
        }

        private void CargarAutorizados()
        {
            try
            {
                _autorizados = _canjeBLL.ListarAutorizados(_filtroDni);
                dgvAutorizados.DataSource = _autorizados.Select(k => new
                {
                    Canje = k.NroCanje,
                    Fecha = k.FechaSolicitud.ToString("dd/MM/yyyy HH:mm"),
                    Cliente = k.Cliente.NombreCompleto,
                    DNI = k.Cliente.Dni,
                    Premio = k.Premio.Nombre,
                    Puntos = k.PuntosRequeridos.ToString("N0"),
                    Stock = k.Premio.Stock
                }).ToList();
                MostrarDetalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Canje? Seleccionado()
        {
            if (dgvAutorizados.CurrentRow == null) return null;
            int i = dgvAutorizados.CurrentRow.Index;
            return i >= 0 && i < _autorizados.Count ? _autorizados[i] : null;
        }

        private void dgvAutorizados_SelectionChanged(object sender, EventArgs e) => MostrarDetalle();

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
            lblPremioDatos.Text = $"{T("RFN2_Premio")}: {k.Premio.Nombre} - {k.PuntosRequeridos:N0} pts - Stock {k.Premio.Stock}";
            lblSaldoDatos.Text = $"{T("RFN1_SaldoVigente")}: {saldo} pts";
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            Canje? k = Seleccionado();
            if (k == null)
            {
                MessageBox.Show(T("RFN2_SeleccioneCanje"), T("RFN2_EntregarPremio"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"{T("RFN2_ConfirmarEntrega")} {k.Premio.Nombre} - {k.Cliente.NombreCompleto}?", T("RFN2_EntregarPremio"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int saldoRestante;
            try
            {
                saldoRestante = _canjeBLL.Entregar(k);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                CargarAutorizados();
                return;
            }

            string vencimientos = string.Join(Environment.NewLine,
                k.Detalle.Select(d => $"   {d.PuntosDescontados:N0} pts - {T("RFN2_Vence")} {d.Lote.FechaVencimiento:dd/MM/yyyy}"));
            string comprobante = $"{T("RFN2_ComprobanteCanje")}: {k.NroCanje}{Environment.NewLine}" +
                                 $"{T("RFN2_Premio")}: {k.Premio.Nombre}{Environment.NewLine}" +
                                 $"{T("RFN2_PuntosDescontados")}: {k.PuntosRequeridos:N0}{Environment.NewLine}" +
                                 $"{vencimientos}{Environment.NewLine}" +
                                 $"{T("RFN2_SaldoRestante")}: {saldoRestante:N0}{Environment.NewLine}{Environment.NewLine}" +
                                 T("RFN2_PreguntaPdf");

            if (MessageBox.Show(comprobante, T("RFN2_ComprobanteCanje"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string? ruta = GeneradorPDF.ElegirRuta(this, "Canje_" + k.NroCanje);
                if (ruta != null)
                {
                    try
                    {
                        GeneradorPDF.ComprobanteCanje(k, saldoRestante, ruta);
                        GeneradorPDF.Abrir(ruta);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            CargarAutorizados();
        }

        private void btnVolver_Click(object sender, EventArgs e) => Close();

        private void frmEntregarPremio_FormClosed(object sender, FormClosedEventArgs e)
        {
            LanguageManager.Instance.EliminarObservador(this);
            Navegacion.MostrarMenu();
        }

        private static string T(string clave) => LanguageManager.Instance.GetTraduction(clave);

        public void Actualizar(LanguageManager lenguaje)
        {
            Text = lenguaje.GetTraduction("RFN2_EntregarPremio");
            lblTitulo.Text = Text;
            lblDni.Text = lenguaje.GetTraduction("RFN1_Dni");
            btnBuscar.Text = lenguaje.GetTraduction("RFN1_Buscar");
            btnTodos.Text = lenguaje.GetTraduction("RFN2_VerTodos");
            lblAutorizados.Text = lenguaje.GetTraduction("RFN2_CanjesAutorizados");
            grpDetalle.Text = lenguaje.GetTraduction("RFN1_Detalle");
            btnEntregar.Text = lenguaje.GetTraduction("RFN2_EntregarPremio");
            btnVolver.Text = lenguaje.GetTraduction("RFN1_Volver");
            MostrarDetalle();
        }
    }
}
