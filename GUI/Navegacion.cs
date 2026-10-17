using System.Windows.Forms;

namespace GUI
{
    internal static class Navegacion
    {
        public static void VolverAlMenu(Form actual)
        {
            MostrarMenu();
            actual.Close();
        }

        public static void MostrarMenu()
        {
            Form menu = Application.OpenForms["Menu"];
            if (menu != null)
                menu.Show();
            else
                new Menu().Show();
        }
    }
}
