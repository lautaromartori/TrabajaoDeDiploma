using System;
using System.IO;

namespace LM830Servicios
{
    public static class LM830ConexionConfig
    {
        private static readonly string LM830CarpetaConfig =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LeMarchant");

        private static readonly string LM830ArchivoConfig =
            Path.Combine(LM830CarpetaConfig, "conexion.cfg");

        public static bool LM830ExisteConfiguracion()
        {
            return File.Exists(LM830ArchivoConfig);
        }

        public static void LM830GuardarCadenaConexion(string LM830cadenaConexion)
        {
            Directory.CreateDirectory(LM830CarpetaConfig);
            File.WriteAllText(LM830ArchivoConfig, LM830cadenaConexion);
        }

        public static string LM830ObtenerCadenaConexion()
        {
            if (!LM830ExisteConfiguracion())
                throw new Exception("No hay una configuración de conexión guardada.");

            return File.ReadAllText(LM830ArchivoConfig);
        }

        public static void LM830EliminarConfiguracion()
        {
            if (File.Exists(LM830ArchivoConfig))
                File.Delete(LM830ArchivoConfig);
        }
    }
}
