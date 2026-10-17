#nullable enable
using BE.RFN1;
using BLL.RFN1;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI.RFN1
{
    public partial class frmSaldo : Form, IObserver
    {
        private readonly ClienteBLL _clienteBLL = new ClienteBLL();
        private readonly LoteBLL _loteBLL = new LoteBLL();

        public frmSaldo()
        {
            InitializeComponent();
        }

        private void frmSaldo_Load(object sender, EventArgs e)
        {
            LanguageManager.Instance.AgregarObservador(this);
            Estilo.Aplicar(this);
            Actualizar(LanguageManager.Instance);
            LimpiarCliente();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarCliente();
                string dni = txtDni.Text.Trim();
                if (!Regex.IsMatch(dni, @"^\d{7,8}$"))
                {
                    MessageBox.Show(T("RFN1_DniInvalido"), T("RFN1_ConsultarSaldo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cliente? cliente = _clienteBLL.Buscar(dni);
                if (cliente == null)
                {
                    MessageBox.Show(T("RFN1_ClienteNoInscripto"), T("RFN1_ConsultarSaldo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int saldo = _loteBLL.ConsultarSaldo(cliente, out List<LotePuntos> lotes);

                lblClienteDatos.Text = $"{cliente.NombreCompleto}   DNI {cliente.Dni}   {cliente.Email}";
                lblNivel.Text = cliente.Nivel.Nombre;
                lblSaldo.Text = saldo.ToString("N0");
                dgvLotes.DataSource = lotes.Select(l => new
                {
                    Origen = l.Origen.ToString(),
                    Acreditado = l.FechaAcreditacion.ToString("dd/MM/yyyy"),
                    Disponibles = l.PuntosDisponibles,
                    Vence = l.FechaVencimiento.ToString("dd/MM/yyyy")
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCliente()
        {
            lblClienteDatos.Text = "-";
            lblNivel.Text = "-";
            lblSaldo.Text = "-";
            dgvLotes.DataSource = null;
        }

        private void btnVolver_Click(object sender, EventArgs e) => Close();

        private void frmSaldo_FormClosed(object sender, FormClosedEventArgs e)
        {
            LanguageManager.Instance.EliminarObservador(this);
            Navegacion.MostrarMenu();
        }

        private static string T(string clave) => LanguageManager.Instance.GetTraduction(clave);

        public void Actualizar(LanguageManager lenguaje)
        {
            Text = lenguaje.GetTraduction("RFN1_ConsultarSaldo");
            lblTitulo.Text = Text;
            lblDni.Text = lenguaje.GetTraduction("RFN1_Dni");
            btnBuscar.Text = lenguaje.GetTraduction("RFN1_Buscar");
            grpCliente.Text = lenguaje.GetTraduction("RFN1_Cliente");
            lblNivelTitulo.Text = lenguaje.GetTraduction("RFN1_Nivel") + ":";
            lblSaldoTitulo.Text = lenguaje.GetTraduction("RFN1_SaldoVigente") + ":";
            lblLotes.Text = lenguaje.GetTraduction("RFN1_PuntosPorVencer");
            btnVolver.Text = lenguaje.GetTraduction("RFN1_Volver");
        }
    }
}
