using BE.RFN1;
using Microsoft.Data.SqlClient;
using Servicios;
using System;
using System.Collections.Generic;

namespace DAL.RFN1
{
    public class ReclamoDAL : AbstractDAL<Reclamo>
    {
        public bool ExistePendiente(Venta v)
        {
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = "SELECT COUNT(1) FROM Reclamo WHERE idVenta = @idVenta AND estado = 'pendiente'";
                _sqlcommand.Parameters.AddWithValue("@idVenta", v.IdVenta);
                _sqlserver.Open();
                return Convert.ToInt32(_sqlcommand.ExecuteScalar()) > 0;
            }
            finally
            {
                _sqlcommand.Parameters.Clear();
                _sqlserver.Close();
            }
        }

        public void Insertar(Reclamo r)
        {
            _sqlserver.Open();
            SqlTransaction tx = _sqlserver.BeginTransaction();
            try
            {
                using (var cmd = new SqlCommand(@"INSERT INTO Reclamo (idCliente, idVenta, fechaReclamo, puntosReclamados, motivo, estado, dniVendedor, DVH)
                                                  VALUES (@idCliente, @idVenta, @fecha, @puntos, @motivo, @estado, @dniVendedor, '');
                                                  SELECT CAST(SCOPE_IDENTITY() AS int);", _sqlserver, tx))
                {
                    cmd.Parameters.AddWithValue("@idCliente", r.Cliente.IdCliente);
                    cmd.Parameters.AddWithValue("@idVenta", r.Venta.IdVenta);
                    cmd.Parameters.AddWithValue("@fecha", r.FechaReclamo);
                    cmd.Parameters.AddWithValue("@puntos", r.PuntosReclamados);
                    cmd.Parameters.AddWithValue("@motivo", r.Motivo);
                    cmd.Parameters.AddWithValue("@estado", r.Estado.ToString());
                    cmd.Parameters.AddWithValue("@dniVendedor", r.Vendedor.DNI);
                    r.IdReclamo = (int)cmd.ExecuteScalar();
                }

                r.DVH = DigitoVerificador.CalcularDVH(r.CadenaDVH());
                ActualizarDVH(r.IdReclamo, r.DVH, _sqlserver, tx);

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

        public List<Reclamo> ListarPendientes()
        {
            var lista = new List<Reclamo>();
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = @"SELECT r.idReclamo, r.fechaReclamo, r.puntosReclamados, r.motivo, r.estado, r.dniVendedor, r.DVH,
                                                   v.idVenta, v.nroComprobante, v.fecha, v.total, v.puntosAcreditados,
                                                   c.idCliente, c.dni, c.nombre, c.apellido, c.email, c.telefono, c.fechaInscripcion, c.DVH,
                                                   n.idNivel, n.nombre, n.puntosMinimos, n.multiplicador
                                            FROM Reclamo r
                                            INNER JOIN Venta v ON v.idVenta = r.idVenta
                                            INNER JOIN Cliente c ON c.idCliente = r.idCliente
                                            INNER JOIN Nivel n ON n.idNivel = c.idNivel
                                            WHERE r.estado = 'pendiente'
                                            ORDER BY r.fechaReclamo";
                _sqlserver.Open();
                using (SqlDataReader dr = _sqlcommand.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Reclamo
                        {
                            IdReclamo = dr.GetInt32(0),
                            FechaReclamo = dr.GetDateTime(1),
                            PuntosReclamados = dr.GetInt32(2),
                            Motivo = dr.GetString(3),
                            Estado = (EstadoReclamo)Enum.Parse(typeof(EstadoReclamo), dr.GetString(4)),
                            Vendedor = new Usuario { DNI = dr.GetString(5) },
                            DVH = dr.GetString(6),
                            Venta = new Venta
                            {
                                IdVenta = dr.GetInt32(7),
                                NroComprobante = dr.GetString(8),
                                Fecha = dr.GetDateTime(9),
                                Total = dr.GetDecimal(10),
                                PuntosAcreditados = dr.GetInt32(11)
                            },
                            Cliente = new Cliente
                            {
                                IdCliente = dr.GetInt32(12),
                                Dni = dr.GetString(13),
                                Nombre = dr.GetString(14),
                                Apellido = dr.GetString(15),
                                Email = dr.GetString(16),
                                Telefono = dr.GetString(17),
                                FechaInscripcion = dr.GetDateTime(18),
                                DVH = dr.GetString(19),
                                Nivel = new Nivel
                                {
                                    IdNivel = dr.GetInt32(20),
                                    Nombre = dr.GetString(21),
                                    PuntosMinimos = dr.GetInt32(22),
                                    Multiplicador = dr.GetDecimal(23)
                                }
                            }
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

        // Cierra el reclamo y, si fue aprobado, crea el lote y actualiza el nivel del cliente. Todo junto.
        public void Resolver(Reclamo r, LotePuntos? l)
        {
            _sqlserver.Open();
            SqlTransaction tx = _sqlserver.BeginTransaction();
            try
            {
                r.DVH = DigitoVerificador.CalcularDVH(r.CadenaDVH());
                using (var cmd = new SqlCommand(@"UPDATE Reclamo
                                                  SET estado = @estado, dniSupervisor = @dniSupervisor,
                                                      motivoResolucion = @motivoRes, fechaResolucion = @fechaRes, DVH = @dvh
                                                  WHERE idReclamo = @id AND estado = 'pendiente'", _sqlserver, tx))
                {
                    cmd.Parameters.AddWithValue("@estado", r.Estado.ToString());
                    cmd.Parameters.AddWithValue("@dniSupervisor", (object?)r.Supervisor?.DNI ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@motivoRes", (object?)r.MotivoResolucion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fechaRes", (object?)r.FechaResolucion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@dvh", r.DVH);
                    cmd.Parameters.AddWithValue("@id", r.IdReclamo);
                    if (cmd.ExecuteNonQuery() == 0)
                        throw new Exception("El reclamo ya fue resuelto por otro usuario.");
                }

                if (l != null)
                {
                    LoteDAL.Insertar(l, _sqlserver, tx);
                    ClienteDAL.ActualizarNivel(r.Cliente, _sqlserver, tx);
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

        // ---- Dígito verificador ----
        public List<Reclamo> ListarParaDV()
        {
            var lista = new List<Reclamo>();
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = @"SELECT idReclamo, idCliente, idVenta, fechaReclamo, puntosReclamados, motivo, estado,
                                                   dniVendedor, dniSupervisor, motivoResolucion, fechaResolucion, DVH
                                            FROM Reclamo ORDER BY idReclamo";
                _sqlserver.Open();
                using (SqlDataReader dr = _sqlcommand.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Reclamo
                        {
                            IdReclamo = dr.GetInt32(0),
                            Cliente = new Cliente { IdCliente = dr.GetInt32(1) },
                            Venta = new Venta { IdVenta = dr.GetInt32(2) },
                            FechaReclamo = dr.GetDateTime(3),
                            PuntosReclamados = dr.GetInt32(4),
                            Motivo = dr.GetString(5),
                            Estado = (EstadoReclamo)Enum.Parse(typeof(EstadoReclamo), dr.GetString(6)),
                            Vendedor = new Usuario { DNI = dr.GetString(7) },
                            Supervisor = dr.IsDBNull(8) ? null : new Usuario { DNI = dr.GetString(8) },
                            MotivoResolucion = dr.IsDBNull(9) ? null : dr.GetString(9),
                            FechaResolucion = dr.IsDBNull(10) ? (DateTime?)null : dr.GetDateTime(10),
                            DVH = dr.GetString(11)
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

        public void ActualizarDVH(int idReclamo, string dvh)
        {
            try
            {
                _sqlserver.Open();
                ActualizarDVH(idReclamo, dvh, _sqlserver, null);
            }
            finally
            {
                _sqlserver.Close();
            }
        }

        private static void ActualizarDVH(int idReclamo, string dvh, SqlConnection cn, SqlTransaction? tx)
        {
            using (var cmd = new SqlCommand("UPDATE Reclamo SET DVH = @dvh WHERE idReclamo = @id", cn, tx))
            {
                cmd.Parameters.AddWithValue("@dvh", dvh);
                cmd.Parameters.AddWithValue("@id", idReclamo);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
