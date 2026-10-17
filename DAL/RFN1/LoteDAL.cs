using BE.RFN1;
using Microsoft.Data.SqlClient;
using Servicios;
using System;
using System.Collections.Generic;

namespace DAL.RFN1
{
    public class LoteDAL : AbstractDAL<LotePuntos>
    {
        private const string SELECT_LOTE = @"SELECT idLote, idCliente, idVenta, idReclamo, puntosOriginales, puntosDisponibles,
                                                    fechaAcreditacion, fechaVencimiento, origen, DVH
                                             FROM LotePuntos";

        public List<LotePuntos> ObtenerPorCliente(int id)
        {
            var lista = new List<LotePuntos>();
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = SELECT_LOTE + " WHERE idCliente = @id ORDER BY fechaVencimiento, idLote";
                _sqlcommand.Parameters.AddWithValue("@id", id);
                _sqlserver.Open();
                using (SqlDataReader r = _sqlcommand.ExecuteReader())
                {
                    while (r.Read()) lista.Add(Mapear(r));
                }
            }
            finally
            {
                _sqlcommand.Parameters.Clear();
                _sqlserver.Close();
            }
            return lista;
        }

        internal static void Insertar(LotePuntos l, SqlConnection cn, SqlTransaction tx)
        {
            using (var cmd = new SqlCommand(@"INSERT INTO LotePuntos (idCliente, idVenta, idReclamo, puntosOriginales, puntosDisponibles,
                                                                      fechaAcreditacion, fechaVencimiento, origen, DVH)
                                              VALUES (@idCliente, @idVenta, @idReclamo, @orig, @disp, @fAcred, @fVenc, @origen, '');
                                              SELECT CAST(SCOPE_IDENTITY() AS int);", cn, tx))
            {
                cmd.Parameters.AddWithValue("@idCliente", l.IdCliente);
                cmd.Parameters.AddWithValue("@idVenta", (object?)l.IdVenta ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idReclamo", (object?)l.IdReclamo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@orig", l.PuntosOriginales);
                cmd.Parameters.AddWithValue("@disp", l.PuntosDisponibles);
                cmd.Parameters.AddWithValue("@fAcred", l.FechaAcreditacion.Date);
                cmd.Parameters.AddWithValue("@fVenc", l.FechaVencimiento.Date);
                cmd.Parameters.AddWithValue("@origen", l.Origen.ToString());
                l.IdLote = (int)cmd.ExecuteScalar();
            }

            l.DVH = DigitoVerificador.CalcularDVH(l.CadenaDVH());
            using (var cmd = new SqlCommand("UPDATE LotePuntos SET DVH = @dvh WHERE idLote = @id", cn, tx))
            {
                cmd.Parameters.AddWithValue("@dvh", l.DVH);
                cmd.Parameters.AddWithValue("@id", l.IdLote);
                cmd.ExecuteNonQuery();
            }
        }

        internal static void ActualizarDisponibles(LotePuntos l, int disponiblesAnteriores, SqlConnection cn, SqlTransaction tx)
        {
            l.DVH = DigitoVerificador.CalcularDVH(l.CadenaDVH());
            using (var cmd = new SqlCommand(@"UPDATE LotePuntos SET puntosDisponibles = @disp, DVH = @dvh
                                              WHERE idLote = @id AND puntosDisponibles = @anterior", cn, tx))
            {
                cmd.Parameters.AddWithValue("@disp", l.PuntosDisponibles);
                cmd.Parameters.AddWithValue("@dvh", l.DVH);
                cmd.Parameters.AddWithValue("@id", l.IdLote);
                cmd.Parameters.AddWithValue("@anterior", disponiblesAnteriores);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new Exception("Los puntos del cliente cambiaron mientras se procesaba la operación. Vuelva a intentarlo.");
            }
        }

        public List<LotePuntos> ListarParaDV()
        {
            var lista = new List<LotePuntos>();
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = SELECT_LOTE + " ORDER BY idLote";
                _sqlserver.Open();
                using (SqlDataReader r = _sqlcommand.ExecuteReader())
                {
                    while (r.Read()) lista.Add(Mapear(r));
                }
            }
            finally
            {
                _sqlserver.Close();
            }
            return lista;
        }

        public void ActualizarDVH(int idLote, string dvh)
        {
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = "UPDATE LotePuntos SET DVH = @dvh WHERE idLote = @id";
                _sqlcommand.Parameters.AddWithValue("@dvh", dvh);
                _sqlcommand.Parameters.AddWithValue("@id", idLote);
                _sqlserver.Open();
                _sqlcommand.ExecuteNonQuery();
            }
            finally
            {
                _sqlcommand.Parameters.Clear();
                _sqlserver.Close();
            }
        }

        private static LotePuntos Mapear(SqlDataReader r) => new LotePuntos
        {
            IdLote = r.GetInt32(0),
            IdCliente = r.GetInt32(1),
            IdVenta = r.IsDBNull(2) ? (int?)null : r.GetInt32(2),
            Reclamo = r.IsDBNull(3) ? null : new Reclamo { IdReclamo = r.GetInt32(3) },
            PuntosOriginales = r.GetInt32(4),
            PuntosDisponibles = r.GetInt32(5),
            FechaAcreditacion = r.GetDateTime(6),
            FechaVencimiento = r.GetDateTime(7),
            Origen = (OrigenPuntos)Enum.Parse(typeof(OrigenPuntos), r.GetString(8)),
            DVH = r.GetString(9)
        };
    }
}
