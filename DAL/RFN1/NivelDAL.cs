using BE.RFN1;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace DAL.RFN1
{
    public class NivelDAL : AbstractDAL<Nivel>
    {
        // El nivel inicial es el de menor puntaje mínimo (Bronce).
        public Nivel ObtenerInicial()
        {
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = @"SELECT TOP 1 idNivel, nombre, puntosMinimos, multiplicador
                                            FROM Nivel ORDER BY puntosMinimos ASC";
                _sqlserver.Open();
                using (SqlDataReader reader = _sqlcommand.ExecuteReader())
                {
                    if (reader.Read()) return Mapear(reader);
                }
                throw new Exception("No hay niveles cargados en la base de datos.");
            }
            finally
            {
                _sqlserver.Close();
            }
        }

        public List<Nivel> Listar()
        {
            var lista = new List<Nivel>();
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = @"SELECT idNivel, nombre, puntosMinimos, multiplicador
                                            FROM Nivel ORDER BY puntosMinimos ASC";
                _sqlserver.Open();
                using (SqlDataReader reader = _sqlcommand.ExecuteReader())
                {
                    while (reader.Read()) lista.Add(Mapear(reader));
                }
            }
            finally
            {
                _sqlserver.Close();
            }
            return lista;
        }

        private static Nivel Mapear(SqlDataReader r) => new Nivel
        {
            IdNivel = r.GetInt32(0),
            Nombre = r.GetString(1),
            PuntosMinimos = r.GetInt32(2),
            Multiplicador = r.GetDecimal(3)
        };
    }
}
