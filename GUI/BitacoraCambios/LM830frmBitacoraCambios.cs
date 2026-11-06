#nullable enable
using LM830BE.LM830BitacoraCambios;
using LM830BLL.LM830BitacoraCambios;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LM830GUI.LM830BitacoraCambios
{
    // Bitácora de cambios: historial de Cliente que guardan los triggers.
    // Permite filtrar por DNI y por fechas, y volver a una versión anterior.
    public partial class LM830frmBitacoraCambios : Form, LM830IObserver
    {
        private readonly LM830BitacoraCambiosBLL LM830_bll = new LM830BitacoraCambiosBLL();
        private List<LM830BitacoraCambioCliente> LM830_versionesCliente = new List<LM830BitacoraCambioCliente>();

        public LM830frmBitacoraCambios()
        {
            InitializeComponent();
        }

        private void LM830frmBitacoraCambios_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Estilo.LM830Aplicar(this);
            LM830FiltrosPorDefecto();
            LM830Actualizar(LM830LanguageManager.LM830Instance);
            LM830Buscar();
        }

        // Sin DNI y con las versiones del último mes, igual que al abrir la pantalla.
        private void LM830FiltrosPorDefecto()
        {
            LM830txtFiltro.Clear();
            LM830dtpDesde.Value = DateTime.Today.AddMonths(-1);
            LM830dtpHasta.Value = DateTime.Today;
        }

        private void LM830btnBuscar_Click(object LM830sender, EventArgs LM830e) => LM830Buscar();

        private void LM830btnLimpiar_Click(object LM830sender, EventArgs LM830e)
        {
            LM830FiltrosPorDefecto();
            LM830Buscar();
        }

        private void LM830Buscar()
        {
            try
            {
                string LM830filtro = LM830txtFiltro.Text.Trim();
                LM830_versionesCliente = LM830_bll.LM830ListarClientes(LM830filtro, LM830dtpDesde.Value, LM830dtpHasta.Value);
                LM830dgvVersiones.DataSource = LM830_versionesCliente.Select(LM830v => new
                {
                    Fecha = LM830v.LM830FechaCambio.ToString("dd/MM/yyyy HH:mm:ss"),
                    Operacion = LM830v.LM830Operacion,
                    Usuario = LM830v.LM830Usuario,
                    DNI = LM830v.LM830Dni,
                    Nombre = LM830v.LM830Nombre,
                    Apellido = LM830v.LM830Apellido,
                    Email = LM830v.LM830Email,
                    Telefono = LM830v.LM830Telefono,
                    Nivel = LM830v.LM830IdNivel,
                    Activo = LM830v.LM830Activo ? "Sí" : "No"
                }).ToList();
                LM830dgvVersiones.ClearSelection();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830btnRestaurar_Click(object LM830sender, EventArgs LM830e)
        {
            if (LM830dgvVersiones.CurrentRow == null || !LM830dgvVersiones.CurrentRow.Selected)
            {
                MessageBox.Show(LM830T("BC_SeleccioneVersion"), LM830T("BC_Titulo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var LM830version = LM830_versionesCliente[LM830dgvVersiones.CurrentRow.Index];
            try
            {
                if (LM830version.LM830Activo) { MessageBox.Show(LM830T("BC_YaVigente"), LM830T("BC_Titulo"), MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (!LM830Confirmar($"{LM830version.LM830Dni} - {LM830version.LM830Apellido}, {LM830version.LM830Nombre}", LM830version.LM830FechaCambio)) return;
                LM830_bll.LM830RestaurarCliente(LM830version);
                MessageBox.Show(LM830T("BC_Restaurado"), LM830T("BC_Titulo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                LM830Buscar();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show(LM830ex.Message, LM830T("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool LM830Confirmar(string LM830registro, DateTime LM830fecha) =>
            MessageBox.Show($"{LM830T("BC_ConfirmarRestaurar")}{Environment.NewLine}{LM830registro}{Environment.NewLine}{LM830fecha:dd/MM/yyyy HH:mm:ss}",
                LM830T("BC_Titulo"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        private void LM830btnVolver_Click(object LM830sender, EventArgs LM830e) => Close();

        private void LM830frmBitacoraCambios_FormClosed(object LM830sender, FormClosedEventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830EliminarObservador(this);
            LM830Navegacion.LM830MostrarMenu();
        }

        private static string LM830T(string LM830clave) => LM830LanguageManager.LM830Instance.LM830GetTraduction(LM830clave);

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            Text = LM830lenguaje.LM830GetTraduction("BC_Titulo");
            LM830lblTitulo.Text = Text;
            LM830lblFiltro.Text = LM830lenguaje.LM830GetTraduction("BC_FiltroDni");
            LM830lblDesde.Text = LM830lenguaje.LM830GetTraduction("BC_Desde");
            LM830lblHasta.Text = LM830lenguaje.LM830GetTraduction("BC_Hasta");
            LM830btnBuscar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Buscar");
            LM830btnLimpiar.Text = LM830lenguaje.LM830GetTraduction("RFN1_Limpiar");
            LM830btnRestaurar.Text = LM830lenguaje.LM830GetTraduction("BC_Restaurar");
            LM830btnVolver.Text = LM830lenguaje.LM830GetTraduction("RFN1_Volver");
        }
    }
}
