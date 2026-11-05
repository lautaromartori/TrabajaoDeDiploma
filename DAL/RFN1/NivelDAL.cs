using LM830BE.LM830RFN1;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace LM830DAL.LM830RFN1
{
    public class LM830NivelDAL : LM830AbstractDAL<LM830Nivel>
    {
        public LM830Nivel LM830ObtenerInicial()
        {
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = @"SELECT TOP 1 idNivel, nombre, puntosMinimos, multiplicador
                                            FROM Nivel ORDER BY puntosMinimos ASC";
                LM830_sqlserver.Open();
                using (SqlDataReader LM830reader = LM830_sqlcommand.ExecuteReader())
                {
                    if (LM830reader.Read()) return LM830Mapear(LM830reader);
                }
                throw new Exception("No hay niveles cargados en la base de datos.");
            }
            finally
            {
                LM830_sqlserver.Close();
            }
        }

        public List<LM830Nivel> LM830Listar()
        {
            var LM830lista = new List<LM830Nivel>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = @"SELECT idNivel, nombre, puntosMinimos, multiplicador
                                            FROM Nivel ORDER BY puntosMinimos ASC";
                LM830_sqlserver.Open();
                using (SqlDataReader LM830reader = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830reader.Read()) LM830lista.Add(LM830Mapear(LM830reader));
                }
            }
            finally
            {
                LM830_sqlserver.Close();
            }
            return LM830lista;
        }

        private static LM830Nivel LM830Mapear(SqlDataReader LM830r) => new LM830Nivel
        {
            LM830IdNivel = LM830r.GetInt32(0),
            LM830Nombre = LM830r.GetString(1),
            LM830PuntosMinimos = LM830r.GetInt32(2),
            LM830Multiplicador = LM830r.GetDecimal(3)
        };
    }
}
