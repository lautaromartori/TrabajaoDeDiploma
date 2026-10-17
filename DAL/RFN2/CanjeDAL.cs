using BE.RFN1;
using BE.RFN2;
using DAL.RFN1;
using Microsoft.Data.SqlClient;
using Servicios;
using System;
using System.Collections.Generic;

namespace DAL.RFN2
{
    public class CanjeDAL : AbstractDAL<Canje>
    {
        private const string SELECT_CANJE = @"SELECT k.idCanje, k.nroCanje, k.puntosRequeridos, k.valorReferencia, k.fechaSolicitud, k.estado,
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

        public void Insertar(Canje k)
        {
            _sqlserver.Open();
            SqlTransaction tx = _sqlserver.BeginTransaction();
            try
            {
                using (var cmd = new SqlCommand(@"INSERT INTO Canje (nroCanje, idCliente, idPremio, puntosRequeridos, valorReferencia, fechaSolicitud,
                                                                      estado, dniVendedor, DVH)
                                                  VALUES (@nroTmp, @idCliente, @idPremio, @puntos, @valor, @fecha, @estado, @dniVendedor, '');
                                                  SELECT CAST(SCOPE_IDENTITY() AS int);", _sqlserver, tx))
                {
                    cmd.Parameters.AddWithValue("@nroTmp", "T" + Guid.NewGuid().ToString("N").Substring(0, 19));
                    cmd.Parameters.AddWithValue("@idCliente", k.Cliente.IdCliente);
                    cmd.Parameters.AddWithValue("@idPremio", k.Premio.IdPremio);
                    cmd.Parameters.AddWithValue("@puntos", k.PuntosRequeridos);
                    cmd.Parameters.AddWithValue("@valor", k.ValorReferencia);
                    cmd.Parameters.AddWithValue("@fecha", k.FechaSolicitud);
                    cmd.Parameters.AddWithValue("@estado", k.Estado.ToString());
                    cmd.Parameters.AddWithValue("@dniVendedor", k.Vendedor.DNI);
                    k.IdCanje = (int)cmd.ExecuteScalar();
                }

                k.NroCanje = "C-" + k.IdCanje.ToString("D8");
                k.DVH = DigitoVerificador.CalcularDVH(k.CadenaDVH());
                using (var cmd = new SqlCommand("UPDATE Canje SET nroCanje = @nro, DVH = @dvh WHERE idCanje = @id", _sqlserver, tx))
                {
                    cmd.Parameters.AddWithValue("@nro", k.NroCanje);
                    cmd.Parameters.AddWithValue("@dvh", k.DVH);
                    cmd.Parameters.AddWithValue("@id", k.IdCanje);
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
            finally
            {
                _sqlserver.Close();
            }
        }

        public int PuntosComprometidos(int idCliente)
        {
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = @"SELECT ISNULL(SUM(puntosRequeridos), 0) FROM Canje
                                            WHERE idCliente = @id AND estado IN ('pendiente', 'autorizado')";
                _sqlcommand.Parameters.AddWithValue("@id", idCliente);
                _sqlserver.Open();
                return Convert.ToInt32(_sqlcommand.ExecuteScalar());
            }
            finally
            {
                _sqlcommand.Parameters.Clear();
                _sqlserver.Close();
            }
        }

        public List<Canje> ListarPorEstado(EstadoCanje estado, string? dniCliente)
        {
            var lista = new List<Canje>();
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = SELECT_CANJE + @"
                    WHERE k.estado = @estado AND (@dni IS NULL OR c.dni = @dni)
                    ORDER BY k.fechaSolicitud";
                _sqlcommand.Parameters.AddWithValue("@estado", estado.ToString());
                _sqlcommand.Parameters.AddWithValue("@dni", (object?)dniCliente ?? DBNull.Value);
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

        public Canje? ObtenerPorNro(string nro)
        {
            Canje? canje = null;
            try
            {
                _sqlserver.Open();
                using (var cmd = new SqlCommand(SELECT_CANJE + " WHERE k.nroCanje = @nro", _sqlserver))
                {
                    cmd.Parameters.AddWithValue("@nro", nro);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read()) canje = Mapear(r);
                    }
                }
                if (canje != null) canje.Detalle = ObtenerDetalle(canje.IdCanje);
            }
            finally
            {
                _sqlserver.Close();
            }
            return canje;
        }

        private List<DetalleCanje> ObtenerDetalle(int idCanje)
        {
            var lista = new List<DetalleCanje>();
            using (var cmd = new SqlCommand(@"SELECT d.idDetalleCanje, d.idCanje, d.puntosDescontados, d.DVH,
                                                     l.idLote, l.idCliente, l.idVenta, l.idReclamo, l.puntosOriginales, l.puntosDisponibles,
                                                     l.fechaAcreditacion, l.fechaVencimiento, l.origen, l.DVH
                                              FROM DetalleCanje d
                                              INNER JOIN LotePuntos l ON l.idLote = d.idLote
                                              WHERE d.idCanje = @id
                                              ORDER BY l.fechaVencimiento, l.idLote", _sqlserver))
            {
                cmd.Parameters.AddWithValue("@id", idCanje);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new DetalleCanje
                        {
                            IdDetalleCanje = r.GetInt32(0),
                            IdCanje = r.GetInt32(1),
                            PuntosDescontados = r.GetInt32(2),
                            DVH = r.GetString(3),
                            Lote = new LotePuntos
                            {
                                IdLote = r.GetInt32(4),
                                IdCliente = r.GetInt32(5),
                                IdVenta = r.IsDBNull(6) ? (int?)null : r.GetInt32(6),
                                Reclamo = r.IsDBNull(7) ? null : new Reclamo { IdReclamo = r.GetInt32(7) },
                                PuntosOriginales = r.GetInt32(8),
                                PuntosDisponibles = r.GetInt32(9),
                                FechaAcreditacion = r.GetDateTime(10),
                                FechaVencimiento = r.GetDateTime(11),
                                Origen = (OrigenPuntos)Enum.Parse(typeof(OrigenPuntos), r.GetString(12)),
                                DVH = r.GetString(13)
                            }
                        });
                    }
                }
            }
            return lista;
        }

        public void Resolver(Canje k)
        {
            try
            {
                k.DVH = DigitoVerificador.CalcularDVH(k.CadenaDVH());
                _sqlserver.Open();
                using (var cmd = new SqlCommand(@"UPDATE Canje
                                                  SET estado = @estado, dniSupervisor = @dniSupervisor, motivoResolucion = @motivo,
                                                      fechaResolucion = @fecha, DVH = @dvh
                                                  WHERE idCanje = @id AND estado = 'pendiente'", _sqlserver))
                {
                    cmd.Parameters.AddWithValue("@estado", k.Estado.ToString());
                    cmd.Parameters.AddWithValue("@dniSupervisor", (object?)k.Supervisor?.DNI ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@motivo", (object?)k.MotivoResolucion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fecha", (object?)k.FechaResolucion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@dvh", k.DVH);
                    cmd.Parameters.AddWithValue("@id", k.IdCanje);
                    if (cmd.ExecuteNonQuery() == 0)
                        throw new Exception("El canje ya fue resuelto por otro usuario.");
                }
            }
            finally
            {
                _sqlserver.Close();
            }
        }

        public void Entregar(Canje k, List<(LotePuntos Lote, int Anterior)> lotes)
        {
            _sqlserver.Open();
            SqlTransaction tx = _sqlserver.BeginTransaction();
            try
            {
                PremioDAL.DescontarStock(k.Premio, _sqlserver, tx);

                foreach (var item in lotes)
                {
                    LoteDAL.ActualizarDisponibles(item.Lote, item.Anterior, _sqlserver, tx);
                }

                foreach (DetalleCanje d in k.Detalle)
                {
                    d.IdCanje = k.IdCanje;
                    using (var cmd = new SqlCommand(@"INSERT INTO DetalleCanje (idCanje, idLote, puntosDescontados, DVH)
                                                      VALUES (@idCanje, @idLote, @puntos, '');
                                                      SELECT CAST(SCOPE_IDENTITY() AS int);", _sqlserver, tx))
                    {
                        cmd.Parameters.AddWithValue("@idCanje", d.IdCanje);
                        cmd.Parameters.AddWithValue("@idLote", d.Lote.IdLote);
                        cmd.Parameters.AddWithValue("@puntos", d.PuntosDescontados);
                        d.IdDetalleCanje = (int)cmd.ExecuteScalar();
                    }

                    d.DVH = DigitoVerificador.CalcularDVH(d.CadenaDVH());
                    using (var cmd = new SqlCommand("UPDATE DetalleCanje SET DVH = @dvh WHERE idDetalleCanje = @id", _sqlserver, tx))
                    {
                        cmd.Parameters.AddWithValue("@dvh", d.DVH);
                        cmd.Parameters.AddWithValue("@id", d.IdDetalleCanje);
                        cmd.ExecuteNonQuery();
                    }
                }

                k.DVH = DigitoVerificador.CalcularDVH(k.CadenaDVH());
                using (var cmd = new SqlCommand(@"UPDATE Canje SET estado = @estado, fechaEntrega = @fecha, DVH = @dvh
                                                  WHERE idCanje = @id AND estado = 'autorizado'", _sqlserver, tx))
                {
                    cmd.Parameters.AddWithValue("@estado", k.Estado.ToString());
                    cmd.Parameters.AddWithValue("@fecha", (object?)k.FechaEntrega ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@dvh", k.DVH);
                    cmd.Parameters.AddWithValue("@id", k.IdCanje);
                    if (cmd.ExecuteNonQuery() == 0)
                        throw new Exception("El canje ya no está autorizado para entregar.");
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
            finally
            {
                _sqlserver.Close();
            }
        }

        public void Anular(Canje k, List<(LotePuntos Lote, int Anterior)> lotes)
        {
            _sqlserver.Open();
            SqlTransaction tx = _sqlserver.BeginTransaction();
            try
            {
                foreach (var item in lotes)
                {
                    LoteDAL.ActualizarDisponibles(item.Lote, item.Anterior, _sqlserver, tx);
                }

                PremioDAL.ReintegrarStock(k.Premio, _sqlserver, tx);

                k.DVH = DigitoVerificador.CalcularDVH(k.CadenaDVH());
                using (var cmd = new SqlCommand(@"UPDATE Canje
                                                  SET estado = @estado, dniAnulacion = @dni, motivoAnulacion = @motivo,
                                                      fechaAnulacion = @fecha, DVH = @dvh
                                                  WHERE idCanje = @id AND estado = 'entregado'", _sqlserver, tx))
                {
                    cmd.Parameters.AddWithValue("@estado", k.Estado.ToString());
                    cmd.Parameters.AddWithValue("@dni", (object?)k.SupervisorAnulacion?.DNI ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@motivo", (object?)k.MotivoAnulacion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fecha", (object?)k.FechaAnulacion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@dvh", k.DVH);
                    cmd.Parameters.AddWithValue("@id", k.IdCanje);
                    if (cmd.ExecuteNonQuery() == 0)
                        throw new Exception("El canje ya fue anulado.");
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
            finally
            {
                _sqlserver.Close();
            }
        }

        public List<Canje> ListarParaDV()
        {
            var lista = new List<Canje>();
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = @"SELECT idCanje, nroCanje, idCliente, idPremio, puntosRequeridos, valorReferencia, fechaSolicitud,
                                                   estado, dniVendedor, dniSupervisor, motivoResolucion, fechaResolucion, fechaEntrega,
                                                   dniAnulacion, motivoAnulacion, fechaAnulacion, DVH
                                            FROM Canje ORDER BY idCanje";
                _sqlserver.Open();
                using (SqlDataReader r = _sqlcommand.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new Canje
                        {
                            IdCanje = r.GetInt32(0),
                            NroCanje = r.GetString(1),
                            Cliente = new Cliente { IdCliente = r.GetInt32(2) },
                            Premio = new Premio { IdPremio = r.GetInt32(3) },
                            PuntosRequeridos = r.GetInt32(4),
                            ValorReferencia = r.GetDecimal(5),
                            FechaSolicitud = r.GetDateTime(6),
                            Estado = (EstadoCanje)Enum.Parse(typeof(EstadoCanje), r.GetString(7)),
                            Vendedor = new Usuario { DNI = r.GetString(8) },
                            Supervisor = r.IsDBNull(9) ? null : new Usuario { DNI = r.GetString(9) },
                            MotivoResolucion = r.IsDBNull(10) ? null : r.GetString(10),
                            FechaResolucion = r.IsDBNull(11) ? (DateTime?)null : r.GetDateTime(11),
                            FechaEntrega = r.IsDBNull(12) ? (DateTime?)null : r.GetDateTime(12),
                            SupervisorAnulacion = r.IsDBNull(13) ? null : new Usuario { DNI = r.GetString(13) },
                            MotivoAnulacion = r.IsDBNull(14) ? null : r.GetString(14),
                            FechaAnulacion = r.IsDBNull(15) ? (DateTime?)null : r.GetDateTime(15),
                            DVH = r.GetString(16)
                        });
                    }
                }
            }
            finally
            {
                _sqlserver.Close();
            }
            return lista;
        }

        public List<DetalleCanje> ListarDetalleParaDV()
        {
            var lista = new List<DetalleCanje>();
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = @"SELECT idDetalleCanje, idCanje, idLote, puntosDescontados, DVH
                                            FROM DetalleCanje ORDER BY idDetalleCanje";
                _sqlserver.Open();
                using (SqlDataReader r = _sqlcommand.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new DetalleCanje
                        {
                            IdDetalleCanje = r.GetInt32(0),
                            IdCanje = r.GetInt32(1),
                            Lote = new LotePuntos { IdLote = r.GetInt32(2) },
                            PuntosDescontados = r.GetInt32(3),
                            DVH = r.GetString(4)
                        });
                    }
                }
            }
            finally
            {
                _sqlserver.Close();
            }
            return lista;
        }

        public void ActualizarDVH(int idCanje, string dvh) =>
            EjecutarUpdateDVH("UPDATE Canje SET DVH = @dvh WHERE idCanje = @id", idCanje, dvh);

        public void ActualizarDVHDetalle(int idDetalleCanje, string dvh) =>
            EjecutarUpdateDVH("UPDATE DetalleCanje SET DVH = @dvh WHERE idDetalleCanje = @id", idDetalleCanje, dvh);

        private void EjecutarUpdateDVH(string sql, int id, string dvh)
        {
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = sql;
                _sqlcommand.Parameters.AddWithValue("@dvh", dvh);
                _sqlcommand.Parameters.AddWithValue("@id", id);
                _sqlserver.Open();
                _sqlcommand.ExecuteNonQuery();
            }
            finally
            {
                _sqlcommand.Parameters.Clear();
                _sqlserver.Close();
            }
        }

        private static Canje Mapear(SqlDataReader r) => new Canje
        {
            IdCanje = r.GetInt32(0),
            NroCanje = r.GetString(1),
            PuntosRequeridos = r.GetInt32(2),
            ValorReferencia = r.GetDecimal(3),
            FechaSolicitud = r.GetDateTime(4),
            Estado = (EstadoCanje)Enum.Parse(typeof(EstadoCanje), r.GetString(5)),
            Vendedor = new Usuario { DNI = r.GetString(6), Nombre = r.GetString(33) },
            Supervisor = r.IsDBNull(7) ? null : new Usuario { DNI = r.GetString(7) },
            MotivoResolucion = r.IsDBNull(8) ? null : r.GetString(8),
            FechaResolucion = r.IsDBNull(9) ? (DateTime?)null : r.GetDateTime(9),
            FechaEntrega = r.IsDBNull(10) ? (DateTime?)null : r.GetDateTime(10),
            SupervisorAnulacion = r.IsDBNull(11) ? null : new Usuario { DNI = r.GetString(11) },
            MotivoAnulacion = r.IsDBNull(12) ? null : r.GetString(12),
            FechaAnulacion = r.IsDBNull(13) ? (DateTime?)null : r.GetDateTime(13),
            DVH = r.GetString(14),
            Cliente = new Cliente
            {
                IdCliente = r.GetInt32(15),
                Dni = r.GetString(16),
                Nombre = r.GetString(17),
                Apellido = r.GetString(18),
                Email = r.GetString(19),
                Telefono = r.GetString(20),
                FechaInscripcion = r.GetDateTime(21),
                DVH = r.GetString(22),
                Nivel = new Nivel
                {
                    IdNivel = r.GetInt32(23),
                    Nombre = r.GetString(24),
                    PuntosMinimos = r.GetInt32(25),
                    Multiplicador = r.GetDecimal(26)
                }
            },
            Premio = new Premio
            {
                IdPremio = r.GetInt32(27),
                Nombre = r.GetString(28),
                Descripcion = r.GetString(29),
                PuntosRequeridos = r.GetInt32(30),
                Stock = r.GetInt32(31),
                ValorReferencia = r.GetDecimal(32)
            }
        };
    }
}
