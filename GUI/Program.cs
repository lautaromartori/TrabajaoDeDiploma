using LM830GUI.LM830RFN1;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LM830GUI
{
    internal static class LM830Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!LM830ConexionConfig.LM830ExisteConfiguracion())
            {
                LM830FrmConexionInicial LM830frmConfig = new LM830FrmConexionInicial();
                DialogResult LM830resultado = LM830frmConfig.ShowDialog();

                if (LM830resultado != DialogResult.OK)
                {
                    return;
                }
            }

            Application.Run(new LM830Login());
        }
    }
}
