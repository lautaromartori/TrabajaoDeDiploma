using LM830BE.LM830RFN1;
using Microsoft.Data.SqlClient;
using LM830Servicios;
using System;
using System.Collections.Generic;

namespace LM830DAL.LM830RFN1
{
    public class LM830ReclamoDAL : LM830AbstractDAL<LM830Reclamo>
    {
        public bool LM830ExistePendiente(LM830Venta LM830v)
        {
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = "SELECT COUNT(1) FROM Reclamo WHERE idVenta = @idVenta AND estado = 'pendiente'";
                LM830_sqlcommand.Parameters.AddWithValue("@idVenta", LM830v.LM830IdVenta);
                LM830_sqlserver.Open();
                return Convert.ToInt32(LM830_sqlcommand.ExecuteScalar()) > 0;
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }

        public void LM830Insertar(LM830Reclamo LM830r)
        {
            LM830_sqlserver.Open();
            SqlTransaction LM830tx = LM830_sqlserver.BeginTransaction();
            try
            {
                using (var LM830cmd = new SqlCommand(@"INSERT INTO Reclamo (idCliente, idVenta, fechaReclamo, puntosReclamados, motivo, estado, dniVendedor, DVH)
                                                  VALUES (@idCliente, @idVenta, @fecha, @puntos, @motivo, @estado, @dniVendedor, '');
                                                  SELECT CAST(SCOPE_IDENTITY() AS int);", LM830_sqlserver, LM830tx))
                {
                    LM830cmd.Parameters.AddWithValue("@idCliente", LM830r.LM830Cliente.LM830IdCliente);
                    LM830cmd.Parameters.AddWithValue("@idVenta", LM830r.LM830Venta.LM830IdVenta);
                    LM830cmd.Parameters.AddWithValue("@fecha", LM830r.LM830FechaReclamo);
                    LM830cmd.Parameters.AddWithValue("@puntos", LM830r.LM830PuntosReclamados);
                    LM830cmd.Parameters.AddWithValue("@motivo", LM830r.LM830Motivo);
                    LM830cmd.Parameters.AddWithValue("@estado", LM830r.LM830Estado.LM830ATexto());
                    LM830cmd.Parameters.AddWithValue("@dniVendedor", LM830r.LM830Vendedor.LM830DNI);
                    LM830r.LM830IdReclamo = (int)LM830cmd.ExecuteScalar();
                }

                LM830r.LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830r.LM830CadenaDVH());
                LM830ActualizarDVH(LM830r.LM830IdReclamo, LM830r.LM830DVH, LM830_sqlserver, LM830tx);

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

        public List<LM830Reclamo> LM830ListarPendientes()
        {
            var LM830lista = new List<LM830Reclamo>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = @"SELECT r.idReclamo, r.fechaReclamo, r.puntosReclamados, r.motivo, r.estado, r.dniVendedor, r.DVH,
                                                   v.idVenta, v.nroComprobante, v.fecha, v.total, v.puntosAcreditados,
                                                   c.idCliente, c.dni, c.nombre, c.apellido, c.email, c.telefono, c.fechaInscripcion, c.DVH,
                                                   n.idNivel, n.nombre, n.puntosMinimos, n.multiplicador
                                            FROM Reclamo r
                                            INNER JOIN Venta v ON v.idVenta = r.idVenta
                                            INNER JOIN Cliente c ON c.idCliente = r.idCliente
                                            INNER JOIN Nivel n ON n.idNivel = c.idNivel
                                            WHERE r.estado = 'pendiente'
                                            ORDER BY r.fechaReclamo";
                LM830_sqlserver.Open();
                using (SqlDataReader LM830dr = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830dr.Read())
                    {
                        LM830lista.Add(new LM830Reclamo
                        {
                            LM830IdReclamo = LM830dr.GetInt32(0),
                            LM830FechaReclamo = LM830dr.GetDateTime(1),
                            LM830PuntosReclamados = LM830dr.GetInt32(2),
                            LM830Motivo = LM830dr.GetString(3),
                            LM830Estado = LM830EnumTexto.LM830DesdeTexto<LM830EstadoReclamo>(LM830dr.GetString(4)),
                            LM830Vendedor = new LM830Usuario { LM830DNI = LM830dr.GetString(5) },
                            LM830DVH = LM830dr.GetString(6),
                            LM830Venta = new LM830Venta
                            {
                                LM830IdVenta = LM830dr.GetInt32(7),
                                LM830NroComprobante = LM830dr.GetString(8),
                                LM830Fecha = LM830dr.GetDateTime(9),
                                LM830Total = LM830dr.GetDecimal(10),
                                LM830PuntosAcreditados = LM830dr.GetInt32(11)
                            },
                            LM830Cliente = new LM830Cliente
                            {
                                LM830IdCliente = LM830dr.GetInt32(12),
                                LM830Dni = LM830dr.GetString(13),
                                LM830Nombre = LM830dr.GetString(14),
                                LM830Apellido = LM830dr.GetString(15),
                                LM830Email = LM830dr.GetString(16),
                                LM830Telefono = LM830dr.GetString(17),
                                LM830FechaInscripcion = LM830dr.GetDateTime(18),
                                LM830DVH = LM830dr.GetString(19),
                                LM830Nivel = new LM830Nivel
                                {
                                    LM830IdNivel = LM830dr.GetInt32(20),
                                    LM830Nombre = LM830dr.GetString(21),
                                    LM830PuntosMinimos = LM830dr.GetInt32(22),
                                    LM830Multiplicador = LM830dr.GetDecimal(23)
                                }
                            }
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

        public void LM830Resolver(LM830Reclamo LM830r, LM830LotePuntos? LM830l)
        {
            LM830_sqlserver.Open();
            SqlTransaction LM830tx = LM830_sqlserver.BeginTransaction();
            try
            {
                LM830r.LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830r.LM830CadenaDVH());
                using (var LM830cmd = new SqlCommand(@"UPDATE Reclamo
                                                  SET estado = @estado, dniSupervisor = @dniSupervisor,
                                                      motivoResolucion = @motivoRes, fechaResolucion = @fechaRes, DVH = @dvh
                                                  WHERE idReclamo = @id AND estado = 'pendiente'", LM830_sqlserver, LM830tx))
                {
                    LM830cmd.Parameters.AddWithValue("@estado", LM830r.LM830Estado.LM830ATexto());
                    LM830cmd.Parameters.AddWithValue("@dniSupervisor", (object?)LM830r.LM830Supervisor?.LM830DNI ?? DBNull.Value);
                    LM830cmd.Parameters.AddWithValue("@motivoRes", (object?)LM830r.LM830MotivoResolucion ?? DBNull.Value);
                    LM830cmd.Parameters.AddWithValue("@fechaRes", (object?)LM830r.LM830FechaResolucion ?? DBNull.Value);
                    LM830cmd.Parameters.AddWithValue("@dvh", LM830r.LM830DVH);
                    LM830cmd.Parameters.AddWithValue("@id", LM830r.LM830IdReclamo);
                    if (LM830cmd.ExecuteNonQuery() == 0)
                        throw new Exception("El reclamo ya fue resuelto por otro usuario.");
                }

                if (LM830l != null)
                {
                    LM830LoteDAL.LM830Insertar(LM830l, LM830_sqlserver, LM830tx);
                    LM830ClienteDAL.LM830ActualizarNivel(LM830r.LM830Cliente, LM830_sqlserver, LM830tx);
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

        public List<LM830Reclamo> LM830ListarParaDV()
        {
            var LM830lista = new List<LM830Reclamo>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = @"SELECT idReclamo, idCliente, idVenta, fechaReclamo, puntosReclamados, motivo, estado,
                                                   dniVendedor, dniSupervisor, motivoResolucion, fechaResolucion, DVH
                                            FROM Reclamo ORDER BY idReclamo";
                LM830_sqlserver.Open();
                using (SqlDataReader LM830dr = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830dr.Read())
                    {
                        LM830lista.Add(new LM830Reclamo
                        {
                            LM830IdReclamo = LM830dr.GetInt32(0),
                            LM830Cliente = new LM830Cliente { LM830IdCliente = LM830dr.GetInt32(1) },
                            LM830Venta = new LM830Venta { LM830IdVenta = LM830dr.GetInt32(2) },
                            LM830FechaReclamo = LM830dr.GetDateTime(3),
                            LM830PuntosReclamados = LM830dr.GetInt32(4),
                            LM830Motivo = LM830dr.GetString(5),
                            LM830Estado = LM830EnumTexto.LM830DesdeTexto<LM830EstadoReclamo>(LM830dr.GetString(6)),
                            LM830Vendedor = new LM830Usuario { LM830DNI = LM830dr.GetString(7) },
                            LM830Supervisor = LM830dr.IsDBNull(8) ? null : new LM830Usuario { LM830DNI = LM830dr.GetString(8) },
                            LM830MotivoResolucion = LM830dr.IsDBNull(9) ? null : LM830dr.GetString(9),
                            LM830FechaResolucion = LM830dr.IsDBNull(10) ? (DateTime?)null : LM830dr.GetDateTime(10),
                            LM830DVH = LM830dr.GetString(11)
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

        public void LM830ActualizarDVH(int LM830idReclamo, string LM830dvh)
        {
            try
            {
                LM830_sqlserver.Open();
                LM830ActualizarDVH(LM830idReclamo, LM830dvh, LM830_sqlserver, null);
            }
            finally
            {
                LM830_sqlserver.Close();
            }
        }

        private static void LM830ActualizarDVH(int LM830idReclamo, string LM830dvh, SqlConnection LM830cn, SqlTransaction? LM830tx)
        {
            using (var LM830cmd = new SqlCommand("UPDATE Reclamo SET DVH = @dvh WHERE idReclamo = @id", LM830cn, LM830tx))
            {
                LM830cmd.Parameters.AddWithValue("@dvh", LM830dvh);
                LM830cmd.Parameters.AddWithValue("@id", LM830idReclamo);
                LM830cmd.ExecuteNonQuery();
            }
        }
    }
}
