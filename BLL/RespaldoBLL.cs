using LM830DAL;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LM830BLL
{
    public class LM830RespaldoBLL
    {
        LM830RespaldoDAL LM830DAL;
        LM830BitacoraBLL LM830bitacoraBLL;

        public LM830RespaldoBLL()
        {
            LM830DAL = new LM830RespaldoDAL();
            LM830bitacoraBLL = new LM830BitacoraBLL();
        }

        public string LM830GenerarNombreArchivo()
        {
            string LM830fechaHora = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            return $"LeMarchant_DB_{LM830fechaHora}.bak";
        }

        public List<string> LM830ObtenerListaBackups()
        {
            string LM830rutaCarpetaPrograma = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");

            if (!Directory.Exists(LM830rutaCarpetaPrograma))
            {
                Directory.CreateDirectory(LM830rutaCarpetaPrograma);
            }

            DirectoryInfo LM830directorio = new DirectoryInfo(LM830rutaCarpetaPrograma);

            FileInfo[] LM830archivosBak = LM830directorio.GetFiles("*.bak")
                                               .OrderByDescending(LM830f => LM830f.CreationTime)
                                               .ToArray();

            List<string> LM830nombresDeArchivos = new List<string>();
            foreach (FileInfo LM830archivo in LM830archivosBak)
            {
                LM830nombresDeArchivos.Add(LM830archivo.Name);
            }

            return LM830nombresDeArchivos;
        }

        public string LM830ObtenerRutaBakcup(string LM830nombreArchivo)
        {
            string LM830carpetaBackups = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
            return Path.Combine(LM830carpetaBackups, LM830nombreArchivo);
        }

        public string LM830RealizarBackup(string LM830carpetaDestino)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(LM830carpetaDestino))
                    throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV14"));

                if (!Directory.Exists(LM830carpetaDestino))
                    throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV15"));

                string LM830nombreArchivo = LM830GenerarNombreArchivo();
                string LM830rutaCompleta = Path.Combine(LM830carpetaDestino, LM830nombreArchivo);

                LM830DAL.LM830GenerarBackup(LM830rutaCompleta);
                LM830RegistrarEvento("Backup generado exitosamente: " + LM830nombreArchivo, 1);

                return LM830rutaCompleta;
            }
            catch (Exception LM830ex)
            {
                LM830RegistrarEvento("Error al generar Backup: " + LM830ex.Message, 4);
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV16"), LM830ex);
            }
        }

        public void LM830RealizarRestore(string LM830rutaArchivoBackup)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(LM830rutaArchivoBackup))
                    throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV17"));

                if (!File.Exists(LM830rutaArchivoBackup))
                    throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV18"));

                if (!LM830rutaArchivoBackup.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
                    throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV19"));

                if (!LM830DAL.LM830ValidarArchivoBackup(LM830rutaArchivoBackup))
                    throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV20"));

                LM830DAL.LM830RestaurarBackup(LM830rutaArchivoBackup);
                LM830RegistrarEvento("Restore ejecutado desde: " + Path.GetFileName(LM830rutaArchivoBackup), 1);
            }
            catch (Exception LM830ex)
            {
                LM830RegistrarEvento("Error al ejecutar Restore: " + LM830ex.Message, 4);
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV21"), LM830ex);
            }
        }

        private void LM830RegistrarEvento(string LM830descripcion, int LM830criticidad)
        {
            try
            {
                string LM830login = LM830SessionManager.LM830Instance?.LM830UsuarioActual()?.LM830Username ?? "Sistema";
                LM830Bitacora LM830evento = new LM830Bitacora
                {
                    LM830Login = LM830login,
                    LM830Modulo = "Respaldos",
                    LM830Evento = LM830descripcion,
                    LM830Criticidad = LM830criticidad
                };
                LM830bitacoraBLL.LM830RegistrarEvento(LM830evento);
            }
            catch { }
        }
    }
}
