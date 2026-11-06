using LM830BE.LM830RFN1;
using LM830BE.LM830RFN2;
using LM830DAL.LM830RFN1;
using Microsoft.Data.SqlClient;
using LM830Servicios;
using System;
using System.Collections.Generic;

namespace LM830DAL.LM830RFN2
{
    public class LM830CanjeDAL : LM830AbstractDAL<LM830Canje>
    {
        private const string LM830SELECT_CANJE = @"SELECT k.idCanje, k.nroCanje, k.puntosRequeridos, k.valorReferencia, k.fechaSolicitud, k.estado,
                                                     k.dniVendedor, k.dniSupervisor, k.motivoResolucion, k.fechaResolucion, k.fechaEntrega,
                                                     k.dniAnulacion, k.motivoAnulacion, k.fechaAnulacion, k.DVH,
                                                     c.idCliente, c.dni, c.nombre, c.apellido, c.email, c.telefono, c.fechaInscripcion, c.DVH,
                                                     n.idNivel, n.nombre, n.puntosMinimos, n.multiplicador,
                                                     p.idPremio, p.nombre, p.descripcion, p.puntosRequeridos, p.stock, p.valorReferencia,
                                                     ISNULL(u.Nombre + ' ' + u.Apellido, k.dniVendedor)
                                              FROM Canje k
                                              INNER JOIN Cliente c ON c.idCliente = k.idCliente
                                              INNER JOIN Nivel n ON n.idNivel = c.idNivel
                                              INNER JOIN Premio p ON p.idPremio = k.idPremio
                                              LEFT JOIN Usuario u ON u.DNI = k.dniVendedor";

        public void LM830Insertar(LM830Canje LM830k)
        {
            LM830_sqlserver.Open();
            SqlTransaction LM830tx = LM830_sqlserver.BeginTransaction();
            try
            {
                using (var LM830cmd = new SqlCommand(@"INSERT INTO Canje (nroCanje, idCliente, idPremio, puntosRequeridos, valorReferencia, fechaSolicitud,
                                                                      estado, dniVendedor, DVH)
                                                  VALUES (@nroTmp, @idCliente, @idPremio, @puntos, @valor, @fecha, @estado, @dniVendedor, '');
                                                  SELECT CAST(SCOPE_IDENTITY() AS int);", LM830_sqlserver, LM830tx))
                {
                    LM830cmd.Parameters.AddWithValue("@nroTmp", "T" + Guid.NewGuid().ToString("N").Substring(0, 19));
                    LM830cmd.Parameters.AddWithValue("@idCliente", LM830k.LM830Cliente.LM830IdCliente);
                    LM830cmd.Parameters.AddWithValue("@idPremio", LM830k.LM830Premio.LM830IdPremio);
                    LM830cmd.Parameters.AddWithValue("@puntos", LM830k.LM830PuntosRequeridos);
                    LM830cmd.Parameters.AddWithValue("@valor", LM830k.LM830ValorReferencia);
                    LM830cmd.Parameters.AddWithValue("@fecha", LM830k.LM830FechaSolicitud);
                    LM830cmd.Parameters.AddWithValue("@estado", LM830k.LM830Estado.LM830ATexto());
                    LM830cmd.Parameters.AddWithValue("@dniVendedor", LM830k.LM830Vendedor.LM830DNI);
                    LM830k.LM830IdCanje = (int)LM830cmd.ExecuteScalar();
                }

                LM830k.LM830NroCanje = "C-" + LM830k.LM830IdCanje.ToString("D8");
                LM830k.LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830k.LM830CadenaDVH());
                using (var LM830cmd = new SqlCommand("UPDATE Canje SET nroCanje = @nro, DVH = @dvh WHERE idCanje = @id", LM830_sqlserver, LM830tx))
                {
                    LM830cmd.Parameters.AddWithValue("@nro", LM830k.LM830NroCanje);
                    LM830cmd.Parameters.AddWithValue("@dvh", LM830k.LM830DVH);
                    LM830cmd.Parameters.AddWithValue("@id", LM830k.LM830IdCanje);
                    LM830cmd.ExecuteNonQuery();
                }

                LM830tx.Commit();
            }
            catch
            {
                LM830tx.Rollback();
                throw;
            }
            finally
            {
                LM830_sqlserver.Close();
            }
        }

        public int LM830PuntosComprometidos(int LM830idCliente)
        {
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = @"SELECT ISNULL(SUM(puntosRequeridos), 0) FROM Canje
                                            WHERE idCliente = @id AND estado IN ('pendiente', 'autorizado')";
                LM830_sqlcommand.Parameters.AddWithValue("@id", LM830idCliente);
                LM830_sqlserver.Open();
                return Convert.ToInt32(LM830_sqlcommand.ExecuteScalar());
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public List<LM830Canje> LM830ListarPorEstado(LM830EstadoCanje LM830estado, string? LM830dniCliente)
        {
            var LM830lista = new List<LM830Canje>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = LM830SELECT_CANJE + @"
                    WHERE k.estado = @estado AND (@dni IS NULL OR c.dni = @dni)
                    ORDER BY k.fechaSolicitud";
                LM830_sqlcommand.Parameters.AddWithValue("@estado", LM830estado.LM830ATexto());
                LM830_sqlcommand.Parameters.AddWithValue("@dni", (object?)LM830dniCliente ?? DBNull.Value);
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

        public LM830Canje? LM830ObtenerPorNro(string LM830nro)
        {
            LM830Canje? LM830canje = null;
            try
            {
                LM830_sqlserver.Open();
                using (var LM830cmd = new SqlCommand(LM830SELECT_CANJE + " WHERE k.nroCanje = @nro", LM830_sqlserver))
                {
                    LM830cmd.Parameters.AddWithValue("@nro", LM830nro);
                    using (SqlDataReader LM830r = LM830cmd.ExecuteReader())
                    {
                        if (LM830r.Read()) LM830canje = LM830Mapear(LM830r);
                    }
                }
                if (LM830canje != null) LM830canje.LM830Detalle = LM830ObtenerDetalle(LM830canje.LM830IdCanje);
            }
            finally
            {
                LM830_sqlserver.Close();
            }
            return LM830canje;
        }

        private List<LM830DetalleCanje> LM830ObtenerDetalle(int LM830idCanje)
        {
            var LM830lista = new List<LM830DetalleCanje>();
            using (var LM830cmd = new SqlCommand(@"SELECT d.idDetalleCanje, d.idCanje, d.puntosDescontados, d.DVH,
                                                     l.idLote, l.idCliente, l.idVenta, l.idReclamo, l.puntosOriginales, l.puntosDisponibles,
                                                     l.fechaAcreditacion, l.fechaVencimiento, l.origen, l.DVH
                                              FROM DetalleCanje d
                                              INNER JOIN LotePuntos l ON l.idLote = d.idLote
                                              WHERE d.idCanje = @id
                                              ORDER BY l.fechaVencimiento, l.idLote", LM830_sqlserver))
            {
                LM830cmd.Parameters.AddWithValue("@id", LM830idCanje);
                using (SqlDataReader LM830r = LM830cmd.ExecuteReader())
                {
                    while (LM830r.Read())
                    {
                        LM830lista.Add(new LM830DetalleCanje
                        {
                            LM830IdDetalleCanje = LM830r.GetInt32(0),
                            LM830IdCanje = LM830r.GetInt32(1),
                            LM830PuntosDescontados = LM830r.GetInt32(2),
                            LM830DVH = LM830r.GetString(3),
                            LM830Lote = new LM830LotePuntos
                            {
                                LM830IdLote = LM830r.GetInt32(4),
                                LM830IdCliente = LM830r.GetInt32(5),
                                LM830IdVenta = LM830r.IsDBNull(6) ? (int?)null : LM830r.GetInt32(6),
                                LM830Reclamo = LM830r.IsDBNull(7) ? null : new LM830Reclamo { LM830IdReclamo = LM830r.GetInt32(7) },
                                LM830PuntosOriginales = LM830r.GetInt32(8),
                                LM830PuntosDisponibles = LM830r.GetInt32(9),
                                LM830FechaAcreditacion = LM830r.GetDateTime(10),
                                LM830FechaVencimiento = LM830r.GetDateTime(11),
                                LM830Origen = LM830EnumTexto.LM830DesdeTexto<LM830OrigenPuntos>(LM830r.GetString(12)),
                                LM830DVH = LM830r.GetString(13)
                            }
                        });
                    }
                }
            }
            return LM830lista;
        }

        public void LM830Resolver(LM830Canje LM830k)
        {
            try
            {
                LM830k.LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830k.LM830CadenaDVH());
                LM830_sqlserver.Open();
                using (var LM830cmd = new SqlCommand(@"UPDATE Canje
                                                  SET estado = @estado, dniSupervisor = @dniSupervisor, motivoResolucion = @motivo,
                                                      fechaResolucion = @fecha, DVH = @dvh
                                                  WHERE idCanje = @id AND estado = 'pendiente'", LM830_sqlserver))
                {
                    LM830cmd.Parameters.AddWithValue("@estado", LM830k.LM830Estado.LM830ATexto());
                    LM830cmd.Parameters.AddWithValue("@dniSupervisor", (object?)LM830k.LM830Supervisor?.LM830DNI ?? DBNull.Value);
                    LM830cmd.Parameters.AddWithValue("@motivo", (object?)LM830k.LM830MotivoResolucion ?? DBNull.Value);
                    LM830cmd.Parameters.AddWithValue("@fecha", (object?)LM830k.LM830FechaResolucion ?? DBNull.Value);
                    LM830cmd.Parameters.AddWithValue("@dvh", LM830k.LM830DVH);
                    LM830cmd.Parameters.AddWithValue("@id", LM830k.LM830IdCanje);
                    if (LM830cmd.ExecuteNonQuery() == 0)
                        throw new Exception("El canje ya fue resuelto por otro usuario.");
                }
            }
            finally
            {
                LM830_sqlserver.Close();
            }
        }

        public void LM830Entregar(LM830Canje LM830k, List<(LM830LotePuntos LM830Lote, int LM830Anterior)> LM830lotes)
        {
            LM830_sqlserver.Open();
            SqlTransaction LM830tx = LM830_sqlserver.BeginTransaction();
            try
            {
                LM830PremioDAL.LM830DescontarStock(LM830k.LM830Premio, LM830_sqlserver, LM830tx);

                foreach (var LM830item in LM830lotes)
                {
                    LM830LoteDAL.LM830ActualizarDisponibles(LM830item.LM830Lote, LM830item.LM830Anterior, LM830_sqlserver, LM830tx);
                }

                foreach (LM830DetalleCanje LM830d in LM830k.LM830Detalle)
                {
                    LM830d.LM830IdCanje = LM830k.LM830IdCanje;
                    using (var LM830cmd = new SqlCommand(@"INSERT INTO DetalleCanje (idCanje, idLote, puntosDescontados, DVH)
                                                      VALUES (@idCanje, @idLote, @puntos, '');
                                                      SELECT CAST(SCOPE_IDENTITY() AS int);", LM830_sqlserver, LM830tx))
                    {
                        LM830cmd.Parameters.AddWithValue("@idCanje", LM830d.LM830IdCanje);
                        LM830cmd.Parameters.AddWithValue("@idLote", LM830d.LM830Lote.LM830IdLote);
                        LM830cmd.Parameters.AddWithValue("@puntos", LM830d.LM830PuntosDescontados);
                        LM830d.LM830IdDetalleCanje = (int)LM830cmd.ExecuteScalar();
                    }

                    LM830d.LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830d.LM830CadenaDVH());
                    using (var LM830cmd = new SqlCommand("UPDATE DetalleCanje SET DVH = @dvh WHERE idDetalleCanje = @id", LM830_sqlserver, LM830tx))
                    {
                        LM830cmd.Parameters.AddWithValue("@dvh", LM830d.LM830DVH);
                        LM830cmd.Parameters.AddWithValue("@id", LM830d.LM830IdDetalleCanje);
                        LM830cmd.ExecuteNonQuery();
                    }
                }

                LM830k.LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830k.LM830CadenaDVH());
                using (var LM830cmd = new SqlCommand(@"UPDATE Canje SET estado = @estado, fechaEntrega = @fecha, DVH = @dvh
                                                  WHERE idCanje = @id AND estado = 'autorizado'", LM830_sqlserver, LM830tx))
                {
                    LM830cmd.Parameters.AddWithValue("@estado", LM830k.LM830Estado.LM830ATexto());
                    LM830cmd.Parameters.AddWithValue("@fecha", (object?)LM830k.LM830FechaEntrega ?? DBNull.Value);
                    LM830cmd.Parameters.AddWithValue("@dvh", LM830k.LM830DVH);
                    LM830cmd.Parameters.AddWithValue("@id", LM830k.LM830IdCanje);
                    if (LM830cmd.ExecuteNonQuery() == 0)
                        throw new Exception("El canje ya no está autorizado para entregar.");
                }

                LM830tx.Commit();
            }
            catch
            {
                LM830tx.Rollback();
                throw;
            }
            finally
            {
                LM830_sqlserver.Close();
            }
        }

        public void LM830Anular(LM830Canje LM830k, List<(LM830LotePuntos LM830Lote, int LM830Anterior)> LM830lotes)
        {
            LM830_sqlserver.Open();
            SqlTransaction LM830tx = LM830_sqlserver.BeginTransaction();
            try
            {
                foreach (var LM830item in LM830lotes)
                {
                    LM830LoteDAL.LM830ActualizarDisponibles(LM830item.LM830Lote, LM830item.LM830Anterior, LM830_sqlserver, LM830tx);
                }

                LM830PremioDAL.LM830ReintegrarStock(LM830k.LM830Premio, LM830_sqlserver, LM830tx);

                LM830k.LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830k.LM830CadenaDVH());
                using (var LM830cmd = new SqlCommand(@"UPDATE Canje
                                                  SET estado = @estado, dniAnulacion = @dni, motivoAnulacion = @motivo,
                                                      fechaAnulacion = @fecha, DVH = @dvh
                                                  WHERE idCanje = @id AND estado = 'entregado'", LM830_sqlserver, LM830tx))
                {
                    LM830cmd.Parameters.AddWithValue("@estado", LM830k.LM830Estado.LM830ATexto());
                    LM830cmd.Parameters.AddWithValue("@dni", (object?)LM830k.LM830SupervisorAnulacion?.LM830DNI ?? DBNull.Value);
                    LM830cmd.Parameters.AddWithValue("@motivo", (object?)LM830k.LM830MotivoAnulacion ?? DBNull.Value);
                    LM830cmd.Parameters.AddWithValue("@fecha", (object?)LM830k.LM830FechaAnulacion ?? DBNull.Value);
                    LM830cmd.Parameters.AddWithValue("@dvh", LM830k.LM830DVH);
                    LM830cmd.Parameters.AddWithValue("@id", LM830k.LM830IdCanje);
                    if (LM830cmd.ExecuteNonQuery() == 0)
                        throw new Exception("El canje ya fue anulado.");
                }

                LM830tx.Commit();
            }
            catch
            {
                LM830tx.Rollback();
                throw;
            }
            finally
            {
                LM830_sqlserver.Close();
            }
        }

        public List<LM830Canje> LM830ListarParaDV()
        {
            var LM830lista = new List<LM830Canje>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = @"SELECT idCanje, nroCanje, idCliente, idPremio, puntosRequeridos, valorReferencia, fechaSolicitud,
                                                   estado, dniVendedor, dniSupervisor, motivoResolucion, fechaResolucion, fechaEntrega,
                                                   dniAnulacion, motivoAnulacion, fechaAnulacion, DVH
                                            FROM Canje ORDER BY idCanje";
                LM830_sqlserver.Open();
                using (SqlDataReader LM830r = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830r.Read())
                    {
                        LM830lista.Add(new LM830Canje
                        {
                            LM830IdCanje = LM830r.GetInt32(0),
                            LM830NroCanje = LM830r.GetString(1),
                            LM830Cliente = new LM830Cliente { LM830IdCliente = LM830r.GetInt32(2) },
                            LM830Premio = new LM830Premio { LM830IdPremio = LM830r.GetInt32(3) },
                            LM830PuntosRequeridos = LM830r.GetInt32(4),
                            LM830ValorReferencia = LM830r.GetDecimal(5),
                            LM830FechaSolicitud = LM830r.GetDateTime(6),
                            LM830Estado = LM830EnumTexto.LM830DesdeTexto<LM830EstadoCanje>(LM830r.GetString(7)),
                            LM830Vendedor = new LM830Usuario { LM830DNI = LM830r.GetString(8) },
                            LM830Supervisor = LM830r.IsDBNull(9) ? null : new LM830Usuario { LM830DNI = LM830r.GetString(9) },
                            LM830MotivoResolucion = LM830r.IsDBNull(10) ? null : LM830r.GetString(10),
                            LM830FechaResolucion = LM830r.IsDBNull(11) ? (DateTime?)null : LM830r.GetDateTime(11),
                            LM830FechaEntrega = LM830r.IsDBNull(12) ? (DateTime?)null : LM830r.GetDateTime(12),
                            LM830SupervisorAnulacion = LM830r.IsDBNull(13) ? null : new LM830Usuario { LM830DNI = LM830r.GetString(13) },
                            LM830MotivoAnulacion = LM830r.IsDBNull(14) ? null : LM830r.GetString(14),
                            LM830FechaAnulacion = LM830r.IsDBNull(15) ? (DateTime?)null : LM830r.GetDateTime(15),
                            LM830DVH = LM830r.GetString(16)
                        });
                    }
                }
            }
            finally
            {
                LM830_sqlserver.Close();
            }
            return LM830lista;
        }

        public List<LM830DetalleCanje> LM830ListarDetalleParaDV()
        {
            var LM830lista = new List<LM830DetalleCanje>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = @"SELECT idDetalleCanje, idCanje, idLote, puntosDescontados, DVH
                                            FROM DetalleCanje ORDER BY idDetalleCanje";
                LM830_sqlserver.Open();
                using (SqlDataReader LM830r = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830r.Read())
                    {
                        LM830lista.Add(new LM830DetalleCanje
                        {
                            LM830IdDetalleCanje = LM830r.GetInt32(0),
                            LM830IdCanje = LM830r.GetInt32(1),
                            LM830Lote = new LM830LotePuntos { LM830IdLote = LM830r.GetInt32(2) },
                            LM830PuntosDescontados = LM830r.GetInt32(3),
                            LM830DVH = LM830r.GetString(4)
                        });
                    }
                }
            }
            finally
            {
                LM830_sqlserver.Close();
            }
            return LM830lista;
        }

        public void LM830ActualizarDVH(int LM830idCanje, string LM830dvh) =>
            LM830EjecutarUpdateDVH("UPDATE Canje SET DVH = @dvh WHERE idCanje = @id", LM830idCanje, LM830dvh);

        public void LM830ActualizarDVHDetalle(int LM830idDetalleCanje, string LM830dvh) =>
            LM830EjecutarUpdateDVH("UPDATE DetalleCanje SET DVH = @dvh WHERE idDetalleCanje = @id", LM830idDetalleCanje, LM830dvh);

        private void LM830EjecutarUpdateDVH(string LM830sql, int LM830id, string LM830dvh)
        {
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = LM830sql;
                LM830_sqlcommand.Parameters.AddWithValue("@dvh", LM830dvh);
                LM830_sqlcommand.Parameters.AddWithValue("@id", LM830id);
                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        private static LM830Canje LM830Mapear(SqlDataReader LM830r) => new LM830Canje
        {
            LM830IdCanje = LM830r.GetInt32(0),
            LM830NroCanje = LM830r.GetString(1),
            LM830PuntosRequeridos = LM830r.GetInt32(2),
            LM830ValorReferencia = LM830r.GetDecimal(3),
            LM830FechaSolicitud = LM830r.GetDateTime(4),
            LM830Estado = LM830EnumTexto.LM830DesdeTexto<LM830EstadoCanje>(LM830r.GetString(5)),
            LM830Vendedor = new LM830Usuario { LM830DNI = LM830r.GetString(6), LM830Nombre = LM830r.GetString(33) },
            LM830Supervisor = LM830r.IsDBNull(7) ? null : new LM830Usuario { LM830DNI = LM830r.GetString(7) },
            LM830MotivoResolucion = LM830r.IsDBNull(8) ? null : LM830r.GetString(8),
            LM830FechaResolucion = LM830r.IsDBNull(9) ? (DateTime?)null : LM830r.GetDateTime(9),
            LM830FechaEntrega = LM830r.IsDBNull(10) ? (DateTime?)null : LM830r.GetDateTime(10),
            LM830SupervisorAnulacion = LM830r.IsDBNull(11) ? null : new LM830Usuario { LM830DNI = LM830r.GetString(11) },
            LM830MotivoAnulacion = LM830r.IsDBNull(12) ? null : LM830r.GetString(12),
            LM830FechaAnulacion = LM830r.IsDBNull(13) ? (DateTime?)null : LM830r.GetDateTime(13),
            LM830DVH = LM830r.GetString(14),
            LM830Cliente = new LM830Cliente
            {
                LM830IdCliente = LM830r.GetInt32(15),
                LM830Dni = LM830r.GetString(16),
                LM830Nombre = LM830r.GetString(17),
                LM830Apellido = LM830r.GetString(18),
                LM830Email = LM830r.GetString(19),
                LM830Telefono = LM830r.GetString(20),
                LM830FechaInscripcion = LM830r.GetDateTime(21),
                LM830DVH = LM830r.GetString(22),
                LM830Nivel = new LM830Nivel
                {
                    LM830IdNivel = LM830r.GetInt32(23),
                    LM830Nombre = LM830r.GetString(24),
                    LM830PuntosMinimos = LM830r.GetInt32(25),
                    LM830Multiplicador = LM830r.GetDecimal(26)
                }
            },
            LM830Premio = new LM830Premio
            {
                LM830IdPremio = LM830r.GetInt32(27),
                LM830Nombre = LM830r.GetString(28),
                LM830Descripcion = LM830r.GetString(29),
                LM830PuntosRequeridos = LM830r.GetInt32(30),
                LM830Stock = LM830r.GetInt32(31),
                LM830ValorReferencia = LM830r.GetDecimal(32)
            }
        };
    }
}
