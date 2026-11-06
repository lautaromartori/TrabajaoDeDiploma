using Microsoft.Data.SqlClient;
using System;
using System.IO;

namespace LM830DAL
{
    public class LM830Respaldo
    {
    }

    public class LM830RespaldoDAL : LM830AbstractDAL<LM830Respaldo>
    {
        private const string LM830NombreBaseDatos = "LeMarchant_DB";

        public LM830RespaldoDAL() { }

        public void LM830GenerarBackup(string LM830rutaCompletaArchivo)
        {
            try
            {
                string LM830carpeta = Path.GetDirectoryName(LM830rutaCompletaArchivo);
                if (!string.IsNullOrEmpty(LM830carpeta) && !Directory.Exists(LM830carpeta))
                    Directory.CreateDirectory(LM830carpeta);

                LM830_sqlcommand.CommandText = $@"BACKUP DATABASE [{LM830NombreBaseDatos}]
                                              TO DISK = @Ruta
                                              WITH FORMAT, INIT, NAME = @NombreRespaldo,
                                              SKIP, NOREWIND, NOUNLOAD, STATS = 10";
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.Parameters.AddWithValue("@Ruta", LM830rutaCompletaArchivo);
                LM830_sqlcommand.Parameters.AddWithValue("@NombreRespaldo", $"Backup {LM830NombreBaseDatos} - Full");
                LM830_sqlcommand.CommandTimeout = 0;

                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (Exception LM830ex)
            {
                throw new Exception("No se pudo generar el respaldo de la base de datos.", LM830ex);
            }
            finally
            {
                LM830_sqlserver.Close();
            }
        }

        public void LM830RestaurarBackup(string LM830rutaCompletaArchivo)
        {
            SqlConnection LM830connMaster = new SqlConnection(
                "Data Source=.;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True");

            try
            {
                if (!File.Exists(LM830rutaCompletaArchivo))
                    throw new FileNotFoundException("No se encontró el archivo de respaldo indicado.", LM830rutaCompletaArchivo);

                LM830connMaster.Open();
                SqlCommand LM830cmd = new SqlCommand();
                LM830cmd.Connection = LM830connMaster;
                LM830cmd.CommandTimeout = 0;

                LM830cmd.CommandText = $@"
            SELECT session_id FROM sys.dm_exec_sessions
            WHERE database_id = DB_ID('{LM830NombreBaseDatos}')";

                var LM830sesiones = new System.Collections.Generic.List<int>();
                using (SqlDataReader LM830reader = LM830cmd.ExecuteReader())
                    while (LM830reader.Read())
                        LM830sesiones.Add(LM830reader.GetInt16(0));

                foreach (int LM830sid in LM830sesiones)
                {
                    LM830cmd.CommandText = $"KILL {LM830sid}";
                    try { LM830cmd.ExecuteNonQuery(); } catch { }
                }

                LM830cmd.CommandText = $@"RESTORE DATABASE [{LM830NombreBaseDatos}]
                              FROM DISK = @Ruta
                              WITH REPLACE, STATS = 10";
                LM830cmd.Parameters.Clear();
                LM830cmd.Parameters.AddWithValue("@Ruta", LM830rutaCompletaArchivo);
                LM830cmd.ExecuteNonQuery();
            }
            catch (Exception LM830ex)
            {
                throw new Exception("No se pudo restaurar la base de datos.", LM830ex);
            }
            finally
            {
                LM830connMaster.Close();
            }
        }
        public bool LM830ValidarArchivoBackup(string LM830rutaCompletaArchivo)
        {
            try
            {
                if (!File.Exists(LM830rutaCompletaArchivo))
                    return false;

                LM830_sqlcommand.CommandText = "RESTORE VERIFYONLY FROM DISK = @Ruta";
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.Parameters.AddWithValue("@Ruta", LM830rutaCompletaArchivo);
                LM830_sqlcommand.CommandTimeout = 0;

                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception LM830ex)
            {
                throw new Exception("El archivo seleccionado no es un respaldo válido de SQL Server.", LM830ex);
            }
            finally
            {
                LM830_sqlserver.Close();
            }
        }
    }
}
