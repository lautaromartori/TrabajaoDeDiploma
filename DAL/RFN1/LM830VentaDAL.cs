using LM830BE.LM830RFN1;
using Microsoft.Data.SqlClient;
using LM830Servicios;
using System;
using System.Collections.Generic;

namespace LM830DAL.LM830RFN1
{
    public class LM830VentaDAL : LM830AbstractDAL<LM830Venta>
    {
        public void LM830Guardar(LM830Venta LM830v)
        {
            LM830_sqlserver.Open();
            SqlTransaction LM830tx = LM830_sqlserver.BeginTransaction();
            try
            {
                using (var LM830cmd = new SqlCommand(@"INSERT INTO Venta (nroComprobante, fecha, idCliente, dniVendedor, total, puntosAcreditados, DVH)
                                                  VALUES (@nroTmp, @fecha, @idCliente, @dniVendedor, @total, @puntos, '');
                                                  SELECT CAST(SCOPE_IDENTITY() AS int);", LM830_sqlserver, LM830tx))
                {
                    LM830cmd.Parameters.AddWithValue("@nroTmp", "T" + Guid.NewGuid().ToString("N").Substring(0, 19));
                    LM830cmd.Parameters.AddWithValue("@fecha", LM830v.LM830Fecha);
                    LM830cmd.Parameters.AddWithValue("@idCliente", (object?)LM830v.LM830Cliente?.LM830IdCliente ?? DBNull.Value);
                    LM830cmd.Parameters.AddWithValue("@dniVendedor", LM830v.LM830Vendedor.LM830DNI);
                    LM830cmd.Parameters.AddWithValue("@total", LM830v.LM830Total);
                    LM830cmd.Parameters.AddWithValue("@puntos", LM830v.LM830PuntosAcreditados);
                    LM830v.LM830IdVenta = (int)LM830cmd.ExecuteScalar();
                }

                LM830v.LM830NroComprobante = "V-" + LM830v.LM830IdVenta.ToString("D8");
                LM830v.LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830v.LM830CadenaDVH());
                using (var LM830cmd = new SqlCommand("UPDATE Venta SET nroComprobante = @nro, DVH = @dvh WHERE idVenta = @id", LM830_sqlserver, LM830tx))
                {
                    LM830cmd.Parameters.AddWithValue("@nro", LM830v.LM830NroComprobante);
                    LM830cmd.Parameters.AddWithValue("@dvh", LM830v.LM830DVH);
                    LM830cmd.Parameters.AddWithValue("@id", LM830v.LM830IdVenta);
                    LM830cmd.ExecuteNonQuery();
                }

                foreach (LM830DetalleVenta LM830d in LM830v.LM830Detalle)
                {
                    LM830d.LM830IdVenta = LM830v.LM830IdVenta;
                    using (var LM830cmd = new SqlCommand(@"INSERT INTO DetalleVenta (idVenta, idProducto, cantidad, precioUnitario, subtotal, puntosCalculados, DVH)
                                                      VALUES (@idVenta, @idProducto, @cantidad, @precio, @subtotal, @puntos, '');
                                                      SELECT CAST(SCOPE_IDENTITY() AS int);", LM830_sqlserver, LM830tx))
                    {
                        LM830cmd.Parameters.AddWithValue("@idVenta", LM830d.LM830IdVenta);
                        LM830cmd.Parameters.AddWithValue("@idProducto", LM830d.LM830Producto.LM830IdProducto);
                        LM830cmd.Parameters.AddWithValue("@cantidad", LM830d.LM830Cantidad);
                        LM830cmd.Parameters.AddWithValue("@precio", LM830d.LM830PrecioUnitario);
                        LM830cmd.Parameters.AddWithValue("@subtotal", LM830d.LM830Subtotal);
                        LM830cmd.Parameters.AddWithValue("@puntos", LM830d.LM830PuntosCalculados);
                        LM830d.LM830IdDetalle = (int)LM830cmd.ExecuteScalar();
                    }

                    LM830d.LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830d.LM830CadenaDVH());
                    using (var LM830cmd = new SqlCommand("UPDATE DetalleVenta SET DVH = @dvh WHERE idDetalle = @id", LM830_sqlserver, LM830tx))
                    {
                        LM830cmd.Parameters.AddWithValue("@dvh", LM830d.LM830DVH);
                        LM830cmd.Parameters.AddWithValue("@id", LM830d.LM830IdDetalle);
                        LM830cmd.ExecuteNonQuery();
                    }
                }

                if (LM830v.LM830Lote != null)
                {
                    LM830v.LM830Lote.LM830IdVenta = LM830v.LM830IdVenta;
                    LM830LoteDAL.LM830Insertar(LM830v.LM830Lote, LM830_sqlserver, LM830tx);
                }

                if (LM830v.LM830Cliente != null)
                {
                    LM830ClienteDAL.LM830ActualizarNivel(LM830v.LM830Cliente, LM830_sqlserver, LM830tx);
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

        public LM830Venta? LM830ObtenerPorNro(string LM830nro)
        {
            LM830Venta? LM830venta = null;
            try
            {
                LM830_sqlserver.Open();
                using (var LM830cmd = new SqlCommand(@"SELECT v.idVenta, v.nroComprobante, v.fecha, v.dniVendedor, v.total, v.puntosAcreditados, v.DVH,
                                                         CASE WHEN EXISTS (SELECT 1 FROM LotePuntos l WHERE l.idVenta = v.idVenta)
                                                                OR EXISTS (SELECT 1 FROM Reclamo r WHERE r.idVenta = v.idVenta AND r.estado = 'aprobado')
                                                              THEN 1 ELSE 0 END AS tieneLote,
                                                         c.idCliente, c.dni, c.nombre, c.apellido, c.email, c.telefono, c.fechaInscripcion, c.DVH,
                                                         n.idNivel, n.nombre, n.puntosMinimos, n.multiplicador,
                                                         u.Nombre, u.Apellido, u.UserName
                                                  FROM Venta v
                                                  LEFT JOIN Cliente c ON c.idCliente = v.idCliente
                                                  LEFT JOIN Nivel n ON n.idNivel = c.idNivel
                                                  LEFT JOIN Usuario u ON u.DNI = v.dniVendedor
                                                  WHERE v.nroComprobante = @nro", LM830_sqlserver))
                {
                    LM830cmd.Parameters.AddWithValue("@nro", LM830nro);
                    using (SqlDataReader LM830r = LM830cmd.ExecuteReader())
                    {
                        if (LM830r.Read())
                        {
                            LM830venta = new LM830Venta
                            {
                                LM830IdVenta = LM830r.GetInt32(0),
                                LM830NroComprobante = LM830r.GetString(1),
                                LM830Fecha = LM830r.GetDateTime(2),
                                LM830Vendedor = new LM830Usuario
                                {
                                    LM830DNI = LM830r.GetString(3),
                                    LM830Nombre = LM830r.IsDBNull(20) ? "" : LM830r.GetString(20),
                                    LM830Apellido = LM830r.IsDBNull(21) ? "" : LM830r.GetString(21),
                                    LM830Username = LM830r.IsDBNull(22) ? "" : LM830r.GetString(22)
                                },
                                LM830Total = LM830r.GetDecimal(4),
                                LM830PuntosAcreditados = LM830r.GetInt32(5),
                                LM830DVH = LM830r.GetString(6),
                                LM830TieneLote = LM830r.GetInt32(7) == 1
                            };
                            if (!LM830r.IsDBNull(8))
                            {
                                LM830venta.LM830Cliente = new LM830Cliente
                                {
                                    LM830IdCliente = LM830r.GetInt32(8),
                                    LM830Dni = LM830r.GetString(9),
                                    LM830Nombre = LM830r.GetString(10),
                                    LM830Apellido = LM830r.GetString(11),
                                    LM830Email = LM830r.GetString(12),
                                    LM830Telefono = LM830r.GetString(13),
                                    LM830FechaInscripcion = LM830r.GetDateTime(14),
                                    LM830DVH = LM830r.GetString(15),
                                    LM830Nivel = new LM830Nivel
                                    {
                                        LM830IdNivel = LM830r.GetInt32(16),
                                        LM830Nombre = LM830r.GetString(17),
                                        LM830PuntosMinimos = LM830r.GetInt32(18),
                                        LM830Multiplicador = LM830r.GetDecimal(19)
                                    }
                                };
                            }
                        }
                    }
                }

                if (LM830venta != null)
                {
                    LM830venta.LM830Detalle = LM830ObtenerDetalle(LM830venta.LM830IdVenta);
                }
            }
            finally
            {
                LM830_sqlserver.Close();
            }
            return LM830venta;
        }

        private List<LM830DetalleVenta> LM830ObtenerDetalle(int LM830idVenta)
        {
            var LM830lista = new List<LM830DetalleVenta>();
            using (var LM830cmd = new SqlCommand(@"SELECT d.idDetalle, d.idVenta, d.cantidad, d.precioUnitario, d.subtotal, d.puntosCalculados, d.DVH,
                                                     p.idProducto, p.nombre, p.precio, c.idCategoria, c.nombre, c.multiplicador
                                              FROM DetalleVenta d
                                              INNER JOIN Producto p ON p.idProducto = d.idProducto
                                              INNER JOIN Categoria c ON c.idCategoria = p.idCategoria
                                              WHERE d.idVenta = @id
                                              ORDER BY d.idDetalle", LM830_sqlserver))
            {
                LM830cmd.Parameters.AddWithValue("@id", LM830idVenta);
                using (SqlDataReader LM830r = LM830cmd.ExecuteReader())
                {
                    while (LM830r.Read())
                    {
                        LM830lista.Add(new LM830DetalleVenta
                        {
                            LM830IdDetalle = LM830r.GetInt32(0),
                            LM830IdVenta = LM830r.GetInt32(1),
                            LM830Cantidad = LM830r.GetInt32(2),
                            LM830PrecioUnitario = LM830r.GetDecimal(3),
                            LM830Subtotal = LM830r.GetDecimal(4),
                            LM830PuntosCalculados = LM830r.GetInt32(5),
                            LM830DVH = LM830r.GetString(6),
                            LM830Producto = new LM830Producto
                            {
                                LM830IdProducto = LM830r.GetInt32(7),
                                LM830Nombre = LM830r.GetString(8),
                                LM830Precio = LM830r.GetDecimal(9),
                                LM830Categoria = new LM830Categoria
                                {
                                    LM830IdCategoria = LM830r.GetInt32(10),
                                    LM830Nombre = LM830r.GetString(11),
                                    LM830Multiplicador = LM830r.GetDecimal(12)
                                }
                            }
                        });
                    }
                }
            }
            return LM830lista;
        }

        public List<LM830Venta> LM830ListarParaDV()
        {
            var LM830lista = new List<LM830Venta>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = @"SELECT idVenta, nroComprobante, fecha, idCliente, dniVendedor, total, puntosAcreditados, DVH
                                            FROM Venta ORDER BY idVenta";
                LM830_sqlserver.Open();
                using (SqlDataReader LM830r = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830r.Read())
                    {
                        LM830lista.Add(new LM830Venta
                        {
                            LM830IdVenta = LM830r.GetInt32(0),
                            LM830NroComprobante = LM830r.GetString(1),
                            LM830Fecha = LM830r.GetDateTime(2),
                            LM830Cliente = LM830r.IsDBNull(3) ? null : new LM830Cliente { LM830IdCliente = LM830r.GetInt32(3) },
                            LM830Vendedor = new LM830Usuario { LM830DNI = LM830r.GetString(4) },
                            LM830Total = LM830r.GetDecimal(5),
                            LM830PuntosAcreditados = LM830r.GetInt32(6),
                            LM830DVH = LM830r.GetString(7)
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

        public List<LM830DetalleVenta> LM830ListarDetalleParaDV()
        {
            var LM830lista = new List<LM830DetalleVenta>();
            try
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.CommandText = @"SELECT idDetalle, idVenta, idProducto, cantidad, precioUnitario, subtotal, puntosCalculados, DVH
                                            FROM DetalleVenta ORDER BY idDetalle";
                LM830_sqlserver.Open();
                using (SqlDataReader LM830r = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830r.Read())
                    {
                        LM830lista.Add(new LM830DetalleVenta
                        {
                            LM830IdDetalle = LM830r.GetInt32(0),
                            LM830IdVenta = LM830r.GetInt32(1),
                            LM830Producto = new LM830Producto { LM830IdProducto = LM830r.GetInt32(2) },
                            LM830Cantidad = LM830r.GetInt32(3),
                            LM830PrecioUnitario = LM830r.GetDecimal(4),
                            LM830Subtotal = LM830r.GetDecimal(5),
                            LM830PuntosCalculados = LM830r.GetInt32(6),
                            LM830DVH = LM830r.GetString(7)
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

        public void LM830ActualizarDVH(int LM830idVenta, string LM830dvh) => LM830EjecutarUpdateDVH("UPDATE Venta SET DVH = @dvh WHERE idVenta = @id", LM830idVenta, LM830dvh);

        public void LM830ActualizarDVHDetalle(int LM830idDetalle, string LM830dvh) => LM830EjecutarUpdateDVH("UPDATE DetalleVenta SET DVH = @dvh WHERE idDetalle = @id", LM830idDetalle, LM830dvh);

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
    }
}
