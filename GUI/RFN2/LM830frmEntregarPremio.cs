#nullable enable
using LM830BE.LM830RFN2;
using LM830BLL.LM830RFN2;
using LM830GUI.LM830Comprobantes;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LM830GUI.LM830RFN2
{
    public partial class LM830frmEntregarPremio : Form, LM830IObserver
    {
        private const int LM830EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private readonly LM830CanjeBLL LM830_canjeBLL = new LM830CanjeBLL();
        private List<LM830Canje> LM830_autorizados = new List<LM830Canje>();
        private string? LM830_filtroDni;

        public LM830frmEntregarPremio()
        {
            InitializeComponent();
        }

        private void LM830frmEntregarPremio_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Estilo.LM830Aplicar(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
            LM830CargarAutorizados();
        }

        private void LM830btnBuscar_Click(object LM830sender, EventArgs LM830e)
        {
            string LM830dni = LM830txtDni.Text.Trim();
            if (LM830dni.Length > 0 && !Regex.IsMatch(LM830dni, @"^\d{7,8}$"))
            {
                MessageBox.Show(LM830T("RFN1_DniInvalido"), LM830T("RFN2_EntregarPremio"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LM830_filtroDni = LM830dni.Length == 0 ? null : LM830dni;
            LM830CargarAutorizados();
        }

        private void LM830btnTodos_Click(object LM830sender, EventArgs LM830e)
        {
            LM830txtDni.Clear();
            LM830_filtroDni = null;
            LM830CargarAutorizados();
        }

        private void LM830CargarAutorizados()
        {
            try
            {
                LM830_autorizados = LM830_canjeBLL.LM830ListarAutorizados(LM830_filtroDni);
                LM830dgvAutorizados.DataSource = LM830_autorizados.Select(LM830k => new
                {
                    Canje = LM830k.LM830NroCanje,
                    Fecha = LM830k.LM830FechaSolicitud.ToString("dd/MM/yyyy HH:mm"),
                    Cliente = LM830k.LM830Cliente.LM830NombreCompleto,
                    DNI = LM830k.LM830Cliente.LM830Dni,
                    Premio = LM830k.LM830Premio.LM830Nombre,
                    Puntos = LM830k.LM830PuntosRequeridos.ToString("N0"),
                    Stock = LM830k.LM830Premio.LM830Stock
                }).ToList();
                LM830MostrarDetalle();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private LM830Canje? LM830Seleccionado()
        {
            if (LM830dgvAutorizados.CurrentRow == null) return null;
            int LM830i = LM830dgvAutorizados.CurrentRow.Index;
            return LM830i >= 0 && LM830i < LM830_autorizados.Count ? LM830_autorizados[LM830i] : null;
        }

        private void LM830dgvAutorizados_SelectionChanged(object LM830sender, EventArgs LM830e) => LM830MostrarDetalle();

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
            LM830lblPremioDatos.Text = $"{LM830T("RFN2_Premio")}: {LM830k.LM830Premio.LM830Nombre} - {LM830k.LM830PuntosRequeridos:N0} pts - Stock {LM830k.LM830Premio.LM830Stock}";
            LM830lblSaldoDatos.Text = $"{LM830T("RFN1_SaldoVigente")}: {LM830saldo} pts";
        }

        private void LM830btnEntregar_Click(object LM830sender, EventArgs LM830e)
        {
            LM830Canje? LM830k = LM830Seleccionado();
            if (LM830k == null)
            {
                MessageBox.Show(LM830T("RFN2_SeleccioneCanje"), LM830T("RFN2_EntregarPremio"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"{LM830T("RFN2_ConfirmarEntrega")} {LM830k.LM830Premio.LM830Nombre} - {LM830k.LM830Cliente.LM830NombreCompleto}?", LM830T("RFN2_EntregarPremio"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int LM830saldoRestante;
            try
            {
                LM830saldoRestante = LM830_canjeBLL.LM830Entregar(LM830k);
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                LM830CargarAutorizados();
                return;
            }

            string LM830vencimientos = string.Join(Environment.NewLine,
                LM830k.LM830Detalle.Select(LM830d => $"   {LM830d.LM830PuntosDescontados:N0} pts - {LM830T("RFN2_Vence")} {LM830d.LM830Lote.LM830FechaVencimiento:dd/MM/yyyy}"));
            string LM830comprobante = $"{LM830T("RFN2_ComprobanteCanje")}: {LM830k.LM830NroCanje}{Environment.NewLine}" +
                                 $"{LM830T("RFN2_Premio")}: {LM830k.LM830Premio.LM830Nombre}{Environment.NewLine}" +
                                 $"{LM830T("RFN2_PuntosDescontados")}: {LM830k.LM830PuntosRequeridos:N0}{Environment.NewLine}" +
                                 $"{LM830vencimientos}{Environment.NewLine}" +
                                 $"{LM830T("RFN2_SaldoRestante")}: {LM830saldoRestante:N0}{Environment.NewLine}{Environment.NewLine}" +
                                 LM830T("RFN2_PreguntaPdf");

            if (MessageBox.Show(LM830comprobante, LM830T("RFN2_ComprobanteCanje"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string? LM830ruta = LM830GeneradorPDF.LM830ElegirRuta(this, "Canje_" + LM830k.LM830NroCanje);
                if (LM830ruta != null)
                {
                    try
                    {
                        LM830GeneradorPDF.LM830ComprobanteCanje(LM830k, LM830saldoRestante, LM830ruta);
                        LM830GeneradorPDF.LM830Abrir(LM830ruta);
                    }
                    catch (Exception LM830ex)
                    {
                        MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            LM830CargarAutorizados();
        }

        private void LM830btnVolver_Click(object LM830sender, EventArgs LM830e) => Close();

        private void LM830frmEntregarPremio_FormClosed(object LM830sender, FormClosedEventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830EliminarObservador(this);
            LM830Navegacion.LM830MostrarMenu();
        }

        private static string LM830T(string LM830clave) => LM830LanguageManager.LM830Instance.LM830GetTraduction(LM830clave);

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            Text = LM830lenguaje.LM830GetTraduction("RFN2_EntregarPremio");
            LM830lblTitulo.Text = Text;
            LM830lblDni.Text = LM830lenguaje.LM830GetTraduction("RFN1_Dni");
            LM830btnBuscar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Buscar");
            LM830btnTodos.Text = LM830lenguaje.LM830GetTraduction("RFN2_VerTodos");
            LM830lblAutorizados.Text = LM830lenguaje.LM830GetTraduction("RFN2_CanjesAutorizados");
            LM830grpDetalle.Text = LM830lenguaje.LM830GetTraduction("RFN1_Detalle");
            LM830btnEntregar.Text = LM830lenguaje.LM830GetTraduction("RFN2_EntregarPremio");
            LM830btnVolver.Text = LM830lenguaje.LM830GetTraduction("RFN1_Volver");
            SendMessage(LM830txtDni.Handle, LM830EM_SETCUEBANNER, (IntPtr)1, LM830lenguaje.LM830GetTraduction("RFN1_PH_Dni"));
            LM830MostrarDetalle();
        }
    }
}
