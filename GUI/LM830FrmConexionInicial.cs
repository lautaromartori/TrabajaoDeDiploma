using Microsoft.Data.SqlClient;
using LM830Servicios;
using System;
using System.Windows.Forms;

namespace LM830GUI
{
    public partial class LM830FrmConexionInicial : Form
    {
        private const string LM830BASE_DATOS = "LeMarchant_DB";

        public LM830FrmConexionInicial()
        {
            InitializeComponent();
        }

        private void LM830FrmConexionInicial_Load(object LM830sender, EventArgs LM830e)
        {
            LM830btnBuscar_Click(LM830sender, LM830e);
        }

        private void LM830btnBuscar_Click(object LM830sender, EventArgs LM830e)
        {
            Cursor = Cursors.WaitCursor;
            LM830cmbServidor.Items.Clear();

            var LM830instancias = LM830SqlInstanceFinder.LM830ObtenerInstancias();
            foreach (var LM830instancia in LM830instancias)
                LM830cmbServidor.Items.Add(LM830instancia);

            if (LM830cmbServidor.Items.Count > 0)
                LM830cmbServidor.SelectedIndex = 0;

            Cursor = Cursors.Default;
        }

        private void LM830btnConectar_Click(object LM830sender, EventArgs LM830e)
        {
            string LM830servidor = LM830cmbServidor.Text.Trim();

            if (string.IsNullOrEmpty(LM830servidor))
            {
                MessageBox.Show("Seleccioná o escribí un servidor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string LM830cadenaConexion = $"Data Source={LM830servidor};Initial Catalog={LM830BASE_DATOS};Integrated Security=True;TrustServerCertificate=True";

            try
            {
                using (SqlConnection LM830conexion = new SqlConnection(LM830cadenaConexion))
                {
                    LM830conexion.Open();
                }

                LM830ConexionConfig.LM830GuardarCadenaConexion(LM830cadenaConexion);

                MessageBox.Show("Conexión exitosa. Configuración guardada.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show($"No se pudo conectar:\n{LM830ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
