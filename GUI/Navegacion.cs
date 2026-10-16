using System.Windows.Forms;

namespace GUI
{
    // Vuelve al menú reutilizando la instancia que ya está abierta (oculta).
    // Antes varias pantallas hacían "new Menu()" cada vez y quedaban menús ocultos acumulados.
    internal static class Navegacion
    {
        public static void VolverAlMenu(Form actual)
        {
            MostrarMenu();
            actual.Close();
        }

        // Para usar desde FormClosed (el form ya se está cerrando).
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
