#nullable enable
using LM830BE.LM830RFN1;
using LM830BLL.LM830RFN1;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LM830GUI.LM830RFN1
{
    public partial class LM830frmSaldo : Form, LM830IObserver
    {
        private const int LM830EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private readonly LM830ClienteBLL LM830_clienteBLL = new LM830ClienteBLL();
        private readonly LM830LoteBLL LM830_loteBLL = new LM830LoteBLL();

        public LM830frmSaldo()
        {
            InitializeComponent();
        }

        private void LM830frmSaldo_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Estilo.LM830Aplicar(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
            LM830LimpiarCliente();
        }

        private void LM830btnBuscar_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                LM830LimpiarCliente();
                string LM830dni = LM830txtDni.Text.Trim();
                if (!Regex.IsMatch(LM830dni, @"^\d{7,8}$"))
                {
                    MessageBox.Show(LM830T("RFN1_DniInvalido"), LM830T("RFN1_ConsultarSaldo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LM830Cliente? LM830cliente = LM830_clienteBLL.LM830Buscar(LM830dni);
                if (LM830cliente == null)
                {
                    MessageBox.Show(LM830T("RFN1_ClienteNoInscripto"), LM830T("RFN1_ConsultarSaldo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int LM830saldo = LM830_loteBLL.LM830ConsultarSaldo(LM830cliente, out List<LM830LotePuntos> LM830lotes);

                LM830lblClienteDatos.Text = $"{LM830cliente.LM830NombreCompleto}   DNI {LM830cliente.LM830Dni}   {LM830cliente.LM830Email}";
                LM830lblNivel.Text = LM830cliente.LM830Nivel.LM830Nombre;
                LM830lblSaldo.Text = LM830saldo.ToString("N0");
                LM830dgvLotes.DataSource = LM830lotes.Select(LM830l => new
                {
                    Origen = LM830l.LM830Origen.LM830ATexto(),
                    Acreditado = LM830l.LM830FechaAcreditacion.ToString("dd/MM/yyyy"),
                    Disponibles = LM830l.LM830PuntosDisponibles,
                    Vence = LM830l.LM830FechaVencimiento.ToString("dd/MM/yyyy")
                }).ToList();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830LimpiarCliente()
        {
            LM830lblClienteDatos.Text = "-";
            LM830lblNivel.Text = "-";
            LM830lblSaldo.Text = "-";
            LM830dgvLotes.DataSource = null;
        }

        private void LM830btnVolver_Click(object LM830sender, EventArgs LM830e) => Close();

        private void LM830frmSaldo_FormClosed(object LM830sender, FormClosedEventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830EliminarObservador(this);
            LM830Navegacion.LM830MostrarMenu();
        }

        private static string LM830T(string LM830clave) => LM830LanguageManager.LM830Instance.LM830GetTraduction(LM830clave);

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            Text = LM830lenguaje.LM830GetTraduction("RFN1_ConsultarSaldo");
            LM830lblTitulo.Text = Text;
            LM830lblDni.Text = LM830lenguaje.LM830GetTraduction("RFN1_Dni");
            LM830btnBuscar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Buscar");
            LM830grpCliente.Text = LM830lenguaje.LM830GetTraduction("RFN1_Cliente");
            LM830lblNivelTitulo.Text = LM830lenguaje.LM830GetTraduction("RFN1_Nivel") + ":";
            LM830lblSaldoTitulo.Text = LM830lenguaje.LM830GetTraduction("RFN1_SaldoVigente") + ":";
            LM830lblLotes.Text = LM830lenguaje.LM830GetTraduction("RFN1_PuntosPorVencer");
            LM830btnVolver.Text = LM830lenguaje.LM830GetTraduction("RFN1_Volver");
            SendMessage(LM830txtDni.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN1_PH_Dni"));
        }
    }
}
