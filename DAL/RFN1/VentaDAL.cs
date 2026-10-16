using BE.RFN1;
using Microsoft.Data.SqlClient;
using Servicios;
using System;
using System.Collections.Generic;

namespace DAL.RFN1
{
    public class VentaDAL : AbstractDAL<Venta>
    {
        // Graba en una sola transacción: la Venta, su DetalleVenta, el LotePuntos (si hay)
        // y el nivel recalculado del cliente. Si algo falla se revierte todo (flujo 10.1).
        public void Guardar(Venta v)
        {
            _sqlserver.Open();
            SqlTransaction tx = _sqlserver.BeginTransaction();
            try
            {
                using (var cmd = new SqlCommand(@"INSERT INTO Venta (nroComprobante, fecha, idCliente, dniVendedor, total, puntosAcreditados, DVH)
                                                  VALUES (@nroTmp, @fecha, @idCliente, @dniVendedor, @total, @puntos, '');
                                                  SELECT CAST(SCOPE_IDENTITY() AS int);", _sqlserver, tx))
                {
                    // nroComprobante es UNIQUE: se inserta uno temporal y se reemplaza con el definitivo, que sale del id.
                    cmd.Parameters.AddWithValue("@nroTmp", "T" + Guid.NewGuid().ToString("N").Substring(0, 19));
                    cmd.Parameters.AddWithValue("@fecha", v.Fecha);
                    cmd.Parameters.AddWithValue("@idCliente", (object?)v.Cliente?.IdCliente ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@dniVendedor", v.Vendedor.DNI);
                    cmd.Parameters.AddWithValue("@total", v.Total);
                    cmd.Parameters.AddWithValue("@puntos", v.PuntosAcreditados);
                    v.IdVenta = (int)cmd.ExecuteScalar();
                }

                v.NroComprobante = "V-" + v.IdVenta.ToString("D8");
                v.DVH = DigitoVerificador.CalcularDVH(v.CadenaDVH());
                using (var cmd = new SqlCommand("UPDATE Venta SET nroComprobante = @nro, DVH = @dvh WHERE idVenta = @id", _sqlserver, tx))
                {
                    cmd.Parameters.AddWithValue("@nro", v.NroComprobante);
                    cmd.Parameters.AddWithValue("@dvh", v.DVH);
                    cmd.Parameters.AddWithValue("@id", v.IdVenta);
                    cmd.ExecuteNonQuery();
                }

                foreach (DetalleVenta d in v.Detalle)
                {
                    d.IdVenta = v.IdVenta;
                    using (var cmd = new SqlCommand(@"INSERT INTO DetalleVenta (idVenta, idProducto, cantidad, precioUnitario, subtotal, puntosCalculados, DVH)
                                                      VALUES (@idVenta, @idProducto, @cantidad, @precio, @subtotal, @puntos, '');
                                                      SELECT CAST(SCOPE_IDENTITY() AS int);", _sqlserver, tx))
                    {
                        cmd.Parameters.AddWithValue("@idVenta", d.IdVenta);
                        cmd.Parameters.AddWithValue("@idProducto", d.Producto.IdProducto);
                        cmd.Parameters.AddWithValue("@cantidad", d.Cantidad);
                        cmd.Parameters.AddWithValue("@precio", d.PrecioUnitario);
                        cmd.Parameters.AddWithValue("@subtotal", d.Subtotal);
                        cmd.Parameters.AddWithValue("@puntos", d.PuntosCalculados);
                        d.IdDetalle = (int)cmd.ExecuteScalar();
                    }

                    d.DVH = DigitoVerificador.CalcularDVH(d.CadenaDVH());
                    using (var cmd = new SqlCommand("UPDATE DetalleVenta SET DVH = @dvh WHERE idDetalle = @id", _sqlserver, tx))
                    {
                        cmd.Parameters.AddWithValue("@dvh", d.DVH);
                        cmd.Parameters.AddWithValue("@id", d.IdDetalle);
                        cmd.ExecuteNonQuery();
                    }
                }

                if (v.Lote != null)
                {
                    v.Lote.IdVenta = v.IdVenta;
                    LoteDAL.Insertar(v.Lote, _sqlserver, tx);
                }

                if (v.Cliente != null)
                {
                    ClienteDAL.ActualizarNivel(v.Cliente, _sqlserver, tx);
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

        public Venta? ObtenerPorNro(string nro)
        {
            Venta? venta = null;
            try
            {
                _sqlserver.Open();
                using (var cmd = new SqlCommand(@"SELECT v.idVenta, v.nroComprobante, v.fecha, v.dniVendedor, v.total, v.puntosAcreditados, v.DVH,
                                                         CASE WHEN EXISTS (SELECT 1 FROM LotePuntos l WHERE l.idVenta = v.idVenta)
                                                                OR EXISTS (SELECT 1 FROM Reclamo r WHERE r.idVenta = v.idVenta AND r.estado = 'aprobado')
                                                              THEN 1 ELSE 0 END AS tieneLote,
                                                         c.idCliente, c.dni, c.nombre, c.apellido, c.email, c.telefono, c.fechaInscripcion, c.DVH,
                                                         n.idNivel, n.nombre, n.puntosMinimos, n.multiplicador
                                                  FROM Venta v
                                                  LEFT JOIN Cliente c ON c.idCliente = v.idCliente
                                                  LEFT JOIN Nivel n ON n.idNivel = c.idNivel
                                                  WHERE v.nroComprobante = @nro", _sqlserver))
                {
                    cmd.Parameters.AddWithValue("@nro", nro);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            venta = new Venta
                            {
                                IdVenta = r.GetInt32(0),
                                NroComprobante = r.GetString(1),
                                Fecha = r.GetDateTime(2),
                                Vendedor = new Usuario { DNI = r.GetString(3) },
                                Total = r.GetDecimal(4),
                                PuntosAcreditados = r.GetInt32(5),
                                DVH = r.GetString(6),
                                TieneLote = r.GetInt32(7) == 1
                            };
                            if (!r.IsDBNull(8))
                            {
                                venta.Cliente = new Cliente
                                {
                                    IdCliente = r.GetInt32(8),
                                    Dni = r.GetString(9),
                                    Nombre = r.GetString(10),
                                    Apellido = r.GetString(11),
                                    Email = r.GetString(12),
                                    Telefono = r.GetString(13),
                                    FechaInscripcion = r.GetDateTime(14),
                                    DVH = r.GetString(15),
                                    Nivel = new Nivel
                                    {
                                        IdNivel = r.GetInt32(16),
                                        Nombre = r.GetString(17),
                                        PuntosMinimos = r.GetInt32(18),
                                        Multiplicador = r.GetDecimal(19)
                                    }
                                };
                            }
                        }
                    }
                }

                if (venta != null)
                {
                    venta.Detalle = ObtenerDetalle(venta.IdVenta);
                }
            }
            finally
            {
                _sqlserver.Close();
            }
            return venta;
        }

        private List<DetalleVenta> ObtenerDetalle(int idVenta)
        {
            var lista = new List<DetalleVenta>();
            using (var cmd = new SqlCommand(@"SELECT d.idDetalle, d.idVenta, d.cantidad, d.precioUnitario, d.subtotal, d.puntosCalculados, d.DVH,
                                                     p.idProducto, p.nombre, p.precio, c.idCategoria, c.nombre, c.multiplicador
                                              FROM DetalleVenta d
                                              INNER JOIN Producto p ON p.idProducto = d.idProducto
                                              INNER JOIN Categoria c ON c.idCategoria = p.idCategoria
                                              WHERE d.idVenta = @id
                                              ORDER BY d.idDetalle", _sqlserver))
            {
                cmd.Parameters.AddWithValue("@id", idVenta);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new DetalleVenta
                        {
                            IdDetalle = r.GetInt32(0),
                            IdVenta = r.GetInt32(1),
                            Cantidad = r.GetInt32(2),
                            PrecioUnitario = r.GetDecimal(3),
                            Subtotal = r.GetDecimal(4),
                            PuntosCalculados = r.GetInt32(5),
                            DVH = r.GetString(6),
                            Producto = new Producto
                            {
                                IdProducto = r.GetInt32(7),
                                Nombre = r.GetString(8),
                                Precio = r.GetDecimal(9),
                                Categoria = new Categoria
                                {
                                    IdCategoria = r.GetInt32(10),
                                    Nombre = r.GetString(11),
                                    Multiplicador = r.GetDecimal(12)
                                }
                            }
                        });
                    }
                }
            }
            return lista;
        }

        // ---- Dígito verificador ----
        public List<Venta> ListarParaDV()
        {
            var lista = new List<Venta>();
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = @"SELECT idVenta, nroComprobante, fecha, idCliente, dniVendedor, total, puntosAcreditados, DVH
                                            FROM Venta ORDER BY idVenta";
                _sqlserver.Open();
                using (SqlDataReader r = _sqlcommand.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new Venta
                        {
                            IdVenta = r.GetInt32(0),
                            NroComprobante = r.GetString(1),
                            Fecha = r.GetDateTime(2),
                            Cliente = r.IsDBNull(3) ? null : new Cliente { IdCliente = r.GetInt32(3) },
                            Vendedor = new Usuario { DNI = r.GetString(4) },
                            Total = r.GetDecimal(5),
                            PuntosAcreditados = r.GetInt32(6),
                            DVH = r.GetString(7)
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

        public List<DetalleVenta> ListarDetalleParaDV()
        {
            var lista = new List<DetalleVenta>();
            try
            {
                _sqlcommand.Parameters.Clear();
                _sqlcommand.CommandText = @"SELECT idDetalle, idVenta, idProducto, cantidad, precioUnitario, subtotal, puntosCalculados, DVH
                                            FROM DetalleVenta ORDER BY idDetalle";
                _sqlserver.Open();
                using (SqlDataReader r = _sqlcommand.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new DetalleVenta
                        {
                            IdDetalle = r.GetInt32(0),
                            IdVenta = r.GetInt32(1),
                            Producto = new Producto { IdProducto = r.GetInt32(2) },
                            Cantidad = r.GetInt32(3),
                            PrecioUnitario = r.GetDecimal(4),
                            Subtotal = r.GetDecimal(5),
                            PuntosCalculados = r.GetInt32(6),
                            DVH = r.GetString(7)
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

        public void ActualizarDVH(int idVenta, string dvh) => EjecutarUpdateDVH("UPDATE Venta SET DVH = @dvh WHERE idVenta = @id", idVenta, dvh);

        public void ActualizarDVHDetalle(int idDetalle, string dvh) => EjecutarUpdateDVH("UPDATE DetalleVenta SET DVH = @dvh WHERE idDetalle = @id", idDetalle, dvh);

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
    }
}
