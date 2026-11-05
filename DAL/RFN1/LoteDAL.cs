using LM830BE.LM830RFN1;
using Microsoft.Data.SqlClient;
using LM830Servicios;
using System;
using System.Collections.Generic;

namespace LM830DAL.LM830RFN1
{
    public class LM830LoteDAL : LM830AbstractDAL<LM830LotePuntos>
    {
        private const string LM830SELECT_LOTE = @"SELECT idLote, idCliente, idVenta, idReclamo, puntosOriginales, puntosDisponibles,
                                                    fechaAcreditacion, fechaVencimiento, origen, DVH
                                             FROM LotePuntos";

        public List<LM830LotePuntos> LM830ObtenerPorCliente(int LM830id)
        {
            var LM830lista = new List<LM830LotePuntos>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = LM830SELECT_LOTE + " WHERE idCliente = @id ORDER BY fechaVencimiento, idLote";
                LM830_sqlcommand.Parameters.AddWithValue("@id", LM830id);
                LM830_sqlserver.Open();
                using (SqlDataReader LM830r = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830r.Read()) LM830lista.Add(LM830Mapear(LM830r));
                }
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
            return LM830lista;
        }

        internal static void LM830Insertar(LM830LotePuntos LM830l, SqlConnection LM830cn, SqlTransaction LM830tx)
        {
            using (var LM830cmd = new SqlCommand(@"INSERT INTO LotePuntos (idCliente, idVenta, idReclamo, puntosOriginales, puntosDisponibles,
                                                                      fechaAcreditacion, fechaVencimiento, origen, DVH)
                                              VALUES (@idCliente, @idVenta, @idReclamo, @orig, @disp, @fAcred, @fVenc, @origen, '');
                                              SELECT CAST(SCOPE_IDENTITY() AS int);", LM830cn, LM830tx))
            {
                LM830cmd.Parameters.AddWithValue("@idCliente", LM830l.LM830IdCliente);
                LM830cmd.Parameters.AddWithValue("@idVenta", (object?)LM830l.LM830IdVenta ?? DBNull.Value);
                LM830cmd.Parameters.AddWithValue("@idReclamo", (object?)LM830l.LM830IdReclamo ?? DBNull.Value);
                LM830cmd.Parameters.AddWithValue("@orig", LM830l.LM830PuntosOriginales);
                LM830cmd.Parameters.AddWithValue("@disp", LM830l.LM830PuntosDisponibles);
                LM830cmd.Parameters.AddWithValue("@fAcred", LM830l.LM830FechaAcreditacion.Date);
                LM830cmd.Parameters.AddWithValue("@fVenc", LM830l.LM830FechaVencimiento.Date);
                LM830cmd.Parameters.AddWithValue("@origen", LM830l.LM830Origen.LM830ATexto());
                LM830l.LM830IdLote = (int)LM830cmd.ExecuteScalar();
            }

            LM830l.LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830l.LM830CadenaDVH());
            using (var LM830cmd = new SqlCommand("UPDATE LotePuntos SET DVH = @dvh WHERE idLote = @id", LM830cn, LM830tx))
            {
                LM830cmd.Parameters.AddWithValue("@dvh", LM830l.LM830DVH);
                LM830cmd.Parameters.AddWithValue("@id", LM830l.LM830IdLote);
                LM830cmd.ExecuteNonQuery();
            }
        }

        internal static void LM830ActualizarDisponibles(LM830LotePuntos LM830l, int LM830disponiblesAnteriores, SqlConnection LM830cn, SqlTransaction LM830tx)
        {
            LM830l.LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830l.LM830CadenaDVH());
            using (var LM830cmd = new SqlCommand(@"UPDATE LotePuntos SET puntosDisponibles = @disp, DVH = @dvh
                                              WHERE idLote = @id AND puntosDisponibles = @anterior", LM830cn, LM830tx))
            {
                LM830cmd.Parameters.AddWithValue("@disp", LM830l.LM830PuntosDisponibles);
                LM830cmd.Parameters.AddWithValue("@dvh", LM830l.LM830DVH);
                LM830cmd.Parameters.AddWithValue("@id", LM830l.LM830IdLote);
                LM830cmd.Parameters.AddWithValue("@anterior", LM830disponiblesAnteriores);
                if (LM830cmd.ExecuteNonQuery() == 0)
                    throw new Exception("Los puntos del cliente cambiaron mientras se procesaba la operación. Vuelva a intentarlo.");
            }
        }

        public List<LM830LotePuntos> LM830ListarParaDV()
        {
            var LM830lista = new List<LM830LotePuntos>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = LM830SELECT_LOTE + " ORDER BY idLote";
                LM830_sqlserver.Open();
                using (SqlDataReader LM830r = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830r.Read()) LM830lista.Add(LM830Mapear(LM830r));
                }
            }
            finally
            {
                LM830_sqlserver.Close();
            }
            return LM830lista;
        }

        public void LM830ActualizarDVH(int LM830idLote, string LM830dvh)
        {
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = "UPDATE LotePuntos SET DVH = @dvh WHERE idLote = @id";
                LM830_sqlcommand.Parameters.AddWithValue("@dvh", LM830dvh);
                LM830_sqlcommand.Parameters.AddWithValue("@id", LM830idLote);
                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        private static LM830LotePuntos LM830Mapear(SqlDataReader LM830r) => new LM830LotePuntos
        {
            LM830IdLote = LM830r.GetInt32(0),
            LM830IdCliente = LM830r.GetInt32(1),
            LM830IdVenta = LM830r.IsDBNull(2) ? (int?)null : LM830r.GetInt32(2),
            LM830Reclamo = LM830r.IsDBNull(3) ? null : new LM830Reclamo { LM830IdReclamo = LM830r.GetInt32(3) },
            LM830PuntosOriginales = LM830r.GetInt32(4),
            LM830PuntosDisponibles = LM830r.GetInt32(5),
            LM830FechaAcreditacion = LM830r.GetDateTime(6),
            LM830FechaVencimiento = LM830r.GetDateTime(7),
            LM830Origen = LM830EnumTexto.LM830DesdeTexto<LM830OrigenPuntos>(LM830r.GetString(8)),
            LM830DVH = LM830r.GetString(9)
        };
    }
}
