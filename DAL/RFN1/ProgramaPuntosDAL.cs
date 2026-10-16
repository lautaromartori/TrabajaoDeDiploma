using BE.RFN1;
using Microsoft.Data.SqlClient;
using System;

namespace DAL.RFN1
{
    public class ProgramaPuntosDAL : AbstractDAL<ProgramaPuntos>
    {
        // Devuelve el programa vigente: el de vigenciaDesde más reciente que ya empezó.
        public ProgramaPuntos ObtenerVigente()
        {
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = @"SELECT TOP 1 idPrograma, nombre, montoPorPunto, mesesVencimiento,
                                                   plazoReclamoDias, vigenciaDesde
                                            FROM ProgramaPuntos
                                            WHERE vigenciaDesde <= CAST(GETDATE() AS date)
                                            ORDER BY vigenciaDesde DESC";
                _sqlserver.Open();
                using (SqlDataReader r = _sqlcommand.ExecuteReader())
                {
                    if (r.Read())
                    {
                        return new ProgramaPuntos
                        {
                            IdPrograma = r.GetInt32(0),
                            Nombre = r.GetString(1),
                            MontoPorPunto = r.GetDecimal(2),
                            MesesVencimiento = r.GetInt32(3),
                            PlazoReclamoDias = r.GetInt32(4),
                            VigenciaDesde = r.GetDateTime(5)
                        };
                    }
                }
                throw new Exception("No hay un programa de puntos vigente cargado.");
            }
            finally
            {
                _sqlserver.Close();
            }
        }
    }
}
