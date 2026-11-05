using LM830BLL;
using LM830Servicios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LM830GUI
{
    public partial class LM830FormBackup : Form,LM830IObserver
    {
        int LM830posX, LM830posY;
        bool LM830arrastrando = false;
        LM830RespaldoBLL LM830bll;

        public LM830FormBackup()
        {
            InitializeComponent();
            LM830bll = new LM830RespaldoBLL();
        }

        private void LM830btnExaminar_Click(object LM830sender, EventArgs LM830e)
        {
            using (FolderBrowserDialog LM830dialogo = new FolderBrowserDialog())
            {
                LM830dialogo.Description = "Seleccione la carpeta donde se guardará el Backup";
                if (LM830dialogo.ShowDialog() == DialogResult.OK)
                    LM830txtPath.Text = LM830dialogo.SelectedPath;
            }
        }

        private void LM830btnGenerar_Click(object LM830sender, EventArgs LM830e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(LM830txtPath.Text))
                {
                    MessageBox.Show(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextBP1"),
                        LM830LanguageManager.LM830Instance.LM830GetTraduction("TextBP2"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                LM830btnGenerar.Enabled = false;

                string LM830rutaGenerada = LM830bll.LM830RealizarBackup(LM830txtPath.Text);

                MessageBox.Show($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("TextBP3")}:\n" + LM830rutaGenerada,
                    LM830LanguageManager.LM830Instance.LM830GetTraduction("TextBP4"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception LM830ex)
            {
                MessageBox.Show($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("TextBP5")}\n" + LM830ex.Message,
                    LM830LanguageManager.LM830Instance.LM830GetTraduction("ErrorP"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                LM830btnGenerar.Enabled = true;
            }
        }

        private void LM830btnVolver_Click(object LM830sender, EventArgs LM830e)
        {
            LM830Navegacion.LM830VolverAlMenu(this);
        }

        private void LM830FormBackup_Load(object LM830sender, EventArgs LM830e)
        {
            LM830LanguageManager.LM830Instance.LM830AgregarObservador(this);
            LM830Actualizar(LM830LanguageManager.LM830Instance);
        }

        private void LM830panel2_Paint(object LM830sender, PaintEventArgs LM830e)
        {
        }

        private void LM830btnCerrar_Click(object LM830sender, EventArgs LM830e)
        {
            Application.Exit();
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

        public void LM830Actualizar(LM830LanguageManager LM830lenguaje)
        {
            LM830lblTitulo.Text= LM830lenguaje.LM830GetTraduction("lblTitulo");
            LM830lblPath.Text = LM830lenguaje.LM830GetTraduction("lblPath");
            LM830btnExaminar.Text = LM830lenguaje.LM830GetTraduction("btnExaminar");
            LM830btnGenerar.Text = LM830lenguaje.LM830GetTraduction("btnGenerar");
            LM830btnVolverDV.Text = LM830lenguaje.LM830GetTraduction("btnVolverDV");
        }
    }
}
