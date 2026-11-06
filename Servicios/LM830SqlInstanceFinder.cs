using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LM830Servicios
{
    public static class LM830SqlInstanceFinder
    {
        public static List<string> LM830ObtenerInstancias()
        {
            List<string> LM830lista = new List<string>();

            try
            {
                using (RegistryKey LM830key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL"))
                {
                    if (LM830key != null)
                    {
                        foreach (string LM830instancia in LM830key.GetValueNames())
                        {
                            if (LM830instancia.Equals("MSSQLSERVER",
                                StringComparison.OrdinalIgnoreCase))
                            {
                                LM830lista.Add(Environment.MachineName);
                            }
                            else
                            {
                                LM830lista.Add(
                                    $"{Environment.MachineName}\\{LM830instancia}");
                            }
                        }
                    }
                }
            }
            catch
            {
            }

            LM830AgregarSiNoExiste(LM830lista, ".");
            LM830AgregarSiNoExiste(LM830lista, "(local)");
            LM830AgregarSiNoExiste(LM830lista, "localhost");
            LM830AgregarSiNoExiste(LM830lista, ".\\SQLEXPRESS");
            LM830AgregarSiNoExiste(LM830lista, Environment.MachineName);
            LM830AgregarSiNoExiste(LM830lista,
                $"{Environment.MachineName}\\SQLEXPRESS");

            return LM830lista
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        private static void LM830AgregarSiNoExiste(
            List<string> LM830lista,
            string LM830valor)
        {
            if (!LM830lista.Contains(LM830valor,
                StringComparer.OrdinalIgnoreCase))
            {
                LM830lista.Add(LM830valor);
            }
        }
    }
}
