using LM830BLL;
using LM830Servicios;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LM830GUI
{
    public partial class LM830FormRestore : Form,LM830IObserver
    {
        int LM830posX, LM830posY;
        bool LM830arrastrando = false;
        LM830RespaldoBLL LM830bll;

        public LM830FormRestore()
        {
            InitializeComponent();
            LM830bll = new LM830RespaldoBLL();
        }

        private void LM830btnExaminar_Click(object LM830sender, EventArgs LM830e)
        {
            using (OpenFileDialog LM830dialogo = new OpenFileDialog())
            {
                LM830dialogo.Title = "Seleccione el archivo de Backup a restaurar";
                LM830dialogo.Filter = "Archivos de Backup (*.bak)|*.bak|Todos los archivos (*.*)|*.*";
                if (LM830dialogo.ShowDialog() == DialogResult.OK)
                    LM830txtPath.Text = LM830dialogo.FileName;
            }
        }

        private void LM830btnEjecutar_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(LM830txtPath.Text))
                {
                    MessageBox.Show("Debe seleccionar un archivo de Backup para restaurar.",
                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult LM830confirmacion = MessageBox.Show(
                    "Esta operación reemplazará la base de datos actual.\n" +
                    "Archivo: " + Path.GetFileName(LM830txtPath.Text) +
                    "\n\n¿Desea continuar?",
                    "Confirmar Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (LM830confirmacion != DialogResult.Yes)
                    return;

                this.Cursor = Cursors.WaitCursor;
                LM830btnEjecutar.Enabled = false;

                LM830bll.LM830RealizarRestore(LM830txtPath.Text);

                MessageBox.Show("Restore ejecutado correctamente.",
                    "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show("No se pudo ejecutar el Restore.\n" + LM830ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                LM830btnEjecutar.Enabled = true;
            }
        }

        private void LM830btnVolver_Click(object LM830sender, EventArgs LM830e)
        {
            LM830Navegacion.LM830VolverAlMenu(this);
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

        private void LM830BarraTitulo_MouseDown(object LM830sender, MouseEventArgs LM830e)
        {
            if (LM830e.Button == MouseButtons.Left)
            {
                LM830arrastrando = true;
                LM830posX = LM830e.X;
                LM830posY = LM830e.Y;
            }
        }
        private void LM830BarraTitulo_MouseUp(object LM830sender, MouseEventArgs LM830e)
        {
            LM830arrastrando = false;
        }

        private void LM830BarraTitulo_MouseMove(object LM830sender, MouseEventArgs LM830e)
        {
            if (LM830arrastrando)
            {
                this.Location = new Point(this.Location.X + (LM830e.X - LM830posX), this.Location.Y + (LM830e.Y - LM830posY));
            }
        }

        private void LM830FormRestore_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
        }

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            LM830lblTituloRes.Text = LM830lenguaje.LM830GetTraduction("lblTituloRes");
            LM830lblPath.Text = LM830lenguaje.LM830GetTraduction("lblPath");
            LM830btnExaminar.Text = LM830lenguaje.LM830GetTraduction("btnExaminar");
            LM830btnEjecutar.Text = LM830lenguaje.LM830GetTraduction("btnEjecutar");
            LM830btnVolver.Text = LM830lenguaje.LM830GetTraduction("btnVolverDV");
        }
    }
}
