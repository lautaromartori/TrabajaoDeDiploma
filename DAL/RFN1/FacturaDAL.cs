using BE;
using BE.RFN1;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL.RFN1
{
    public class FacturaDAL : AbstractDAL<Factura>
    {
        public bool RegistrarFacturaConDetalles(Factura factura)
        {
            try
            {
                if (_sqlserver.State != ConnectionState.Open) _sqlserver.Open();

                using (SqlTransaction transaction = _sqlserver.BeginTransaction())
                {
                    _sqlcommand.Transaction = transaction;

                    try
                    {
                  
                        _sqlcommand.CommandText = @"
                            INSERT INTO dbo.Factura (IdProveedor, NumeroFactura, Fecha, TipoComprobante, Impuestos, Total)
                            VALUES (@IdProveedor, @NumeroFactura, @Fecha, @TipoComprobante, @Impuestos, @Total);
                            SELECT SCOPE_IDENTITY();";

                        _sqlcommand.Parameters.Clear();
                        _sqlcommand.Parameters.AddWithValue("@IdProveedor", factura.Proveedor.Id);
                        _sqlcommand.Parameters.AddWithValue("@NumeroFactura", factura.NumeroFactura);
                        _sqlcommand.Parameters.AddWithValue("@Fecha", factura.Fecha);
                        _sqlcommand.Parameters.AddWithValue("@TipoComprobante", factura.TipoComprobante);
                        _sqlcommand.Parameters.AddWithValue("@Impuestos", factura.Impuestos);
                        _sqlcommand.Parameters.AddWithValue("@Total", factura.Total);

                        factura.Id = Convert.ToInt32(_sqlcommand.ExecuteScalar());

                      
                        foreach (var detalle in factura.Detalles)
                        {
                            _sqlcommand.CommandText = @"
                                INSERT INTO dbo.DetalleFactura (IdFactura, IdProducto, Cantidad, PrecioUnitario, Impuestos, Subtotal)
                                VALUES (@IdFactura, @IdProducto, @Cantidad, @PrecioUnitario, @ImpuestosDetalle, @Subtotal);";

                            _sqlcommand.Parameters.Clear();
                            _sqlcommand.Parameters.AddWithValue("@IdFactura", factura.Id);
                            _sqlcommand.Parameters.AddWithValue("@IdProducto", detalle.Producto.Id);
                            _sqlcommand.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                            _sqlcommand.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                            _sqlcommand.Parameters.AddWithValue("@ImpuestosDetalle", detalle.Impuestos);
                            _sqlcommand.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);

                            _sqlcommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            finally
            {
                if (_sqlserver.State == ConnectionState.Open) _sqlserver.Close();
            }
        }
    }
}