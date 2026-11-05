using LM830BLL;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LM830GUI
{
    public partial class LM830frmReparacionDV : Form,LM830IObserver
    {
        int LM830posX, LM830posY;
        bool LM830arrastrando = false;
        LM830DigitoVerificadorBLL LM830DVBLL;
        LM830RespaldoBLL LM830backupBLL;
        public LM830frmReparacionDV()
        {
            InitializeComponent();
        }

        private void LM830btnRecalcularDV_Click(object LM830sender, EventArgs LM830e)
        {
            if (MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV1"), LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV2"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    LM830DVBLL.LM830RecalcularDVV_General();
                }
                catch (Exception LM830ex)
                {
                    MessageBox.Show(LM830ex.Message, LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LM830SessionManager.LM830Instance.LM830Desloguear();
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV3"), LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV2"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                LM830Login LM830login = new LM830Login();
                LM830login.Show();
            }
        }

        private void LM830btnRestaurar_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                if (LM830lstBackups.SelectedItem == null)
                {
                    MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV4"), LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV5"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                LM830backupBLL.LM830RealizarRestore(LM830backupBLL.LM830ObtenerRutaBakcup(LM830lstBackups.SelectedItem.ToString()));
                MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV6"), LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV7"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                LM830SessionManager.LM830Instance.LM830Desloguear();
                this.Close();
                LM830Login LM830login = new LM830Login();
                LM830login.Show();
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV8")} {LM830ex.Message}", LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LM830frmReparacionDV_Load(object LM830sender, EventArgs LM830e)
        {
            LM830DVBLL = new LM830DigitoVerificadorBLL();
            LM830backupBLL = new LM830RespaldoBLL();
            LM830listarIncocistencias();
            LM830listarBackups();
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
        }
        private void LM830listarIncocistencias()
        {
            LM830lstInconsistencias.Items.Clear();
            List<string> LM830auditoria = LM830DVBLL.LM830EjecutarAuditoriaDetalladaCompleta();

            foreach (string LM830inconsistencia in LM830auditoria)
            {
                LM830lstInconsistencias.Items.Add(LM830inconsistencia);
            }
        }
        private void LM830listarBackups()
        {
            try
            {
                LM830lstBackups.Items.Clear();

                List<string> LM830listaDeBackups = LM830backupBLL.LM830ObtenerListaBackups();

                if (LM830listaDeBackups.Count == 0)
                {
                    MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV9"), LM830LanguageManager.LM830Instance.LM830GetTraduction("Informacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (string LM830backup in LM830listaDeBackups)
                {
                    LM830lstBackups.Items.Add(LM830backup);
                }
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV10")} {LM830ex.Message}", LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LM830btnCancelar_Click(object LM830sender, EventArgs LM830e)
        {
            if (MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV11"), LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV12"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LM830SessionManager.LM830Instance.LM830Desloguear();
                this.Close();
                LM830Login LM830login = new LM830Login();
                LM830login.Show();
            }
        }

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            LM830lblErrorDV.Text = LM830lenguaje.LM830GetTraduction("lblErrorDV");
            LM830lblModuloReparacion.Text = LM830lenguaje.LM830GetTraduction("lblModuloReparacion");
            LM830lblForzar.Text = LM830lenguaje.LM830GetTraduction("lblForzar");
            LM830btnRecalcularDV.Text = LM830lenguaje.LM830GetTraduction("btnRecalcularDV");
            LM830btnRestaurar.Text = LM830lenguaje.LM830GetTraduction("btnRestaurar");
            LM830lblSelecVers.Text = LM830lenguaje.LM830GetTraduction("lblSelecVers");
            LM830btnCancelardv.Text = LM830lenguaje.LM830GetTraduction("btnCancelardv");
        }

        private void LM830BarraTitulo_MouseDown(object LM830sender, MouseEventArgs LM830e)
        {
            if (LM830e.Button == MouseButtons.Left)
            {
                LM830arrastrando = true;
                LM830posX = LM830e.X;
                LM830posY = LM830e.Y;
            }
        }
        private void LM830BarraTitulo_MouseMove(object LM830sender, MouseEventArgs LM830e)
        {
            if (LM830arrastrando)
            {
                this.Location = new Point(this.Location.X + (LM830e.X - LM830posX), this.Location.Y + (LM830e.Y - LM830posY));
            }
        }

        private void LM830btnMaximizar_Click(object LM830sender, EventArgs LM830e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void LM830btnMinimizar_Click(object LM830sender, EventArgs LM830e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LM830BarraTitulo_MouseUp(object LM830sender, MouseEventArgs LM830e)
        {
            LM830arrastrando = false;
        }
    }
}
