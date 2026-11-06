using LM830BE.LM830RFN1;
using Microsoft.Data.SqlClient;
using System;

namespace LM830DAL.LM830RFN1
{
    public class LM830ProgramaPuntosDAL : LM830AbstractDAL<LM830ProgramaPuntos>
    {
        public LM830ProgramaPuntos LM830ObtenerVigente()
        {
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = @"SELECT TOP 1 idPrograma, nombre, montoPorPunto, mesesVencimiento,
                                                   plazoReclamoDias, vigenciaDesde, umbralAutorizacion, plazoAnulacionDias
                                            FROM ProgramaPuntos
                                            WHERE vigenciaDesde <= CAST(GETDATE() AS date)
                                            ORDER BY vigenciaDesde DESC";
                LM830_sqlserver.Open();
                using (SqlDataReader LM830r = LM830_sqlcommand.ExecuteReader())
                {
                    if (LM830r.Read())
                    {
                        return new LM830ProgramaPuntos
                        {
                            LM830IdPrograma = LM830r.GetInt32(0),
                            LM830Nombre = LM830r.GetString(1),
                            LM830MontoPorPunto = LM830r.GetDecimal(2),
                            LM830MesesVencimiento = LM830r.GetInt32(3),
                            LM830PlazoReclamoDias = LM830r.GetInt32(4),
                            LM830VigenciaDesde = LM830r.GetDateTime(5),
                            LM830UmbralAutorizacion = LM830r.GetDecimal(6),
                            LM830PlazoAnulacionDias = LM830r.GetInt32(7)
                        };
                    }
                }
                throw new Exception("No hay un programa de puntos vigente cargado.");
            }
            finally
            {
                LM830_sqlserver.Close();
            }
        }
    }
}
