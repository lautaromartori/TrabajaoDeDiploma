using System.Windows.Forms;

namespace LM830GUI
{
    internal static class LM830Navegacion
    {
        public static void LM830VolverAlMenu(Form LM830actual)
        {
            LM830MostrarMenu();
            LM830actual.Close();
        }

        public static void LM830MostrarMenu()
        {
            Form LM830menu = Application.OpenForms["LM830Menu"];
            if (LM830menu != null)
                LM830menu.Show();
            else
                new LM830Menu().Show();
        }
    }
}
