using BE;
using BE.RFN1;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL.RFN1
{
    public class ProductoDAL : AbstractDAL<Producto>
    {
        public List<Producto> Listar()
        {
            var lista = new List<Producto>();
            _sqlcommand.CommandText = "SELECT Id, Nombre, PrecioCosto, ImpuestoPorcentaje FROM dbo.Producto";
            _sqlcommand.Parameters.Clear();

            try
            {
                if (_sqlserver.State != ConnectionState.Open) _sqlserver.Open();

                using (SqlDataReader reader = _sqlcommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Producto
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            PrecioCosto = Convert.ToDecimal(reader["PrecioCosto"]),
                            ImpuestoPorcentaje = Convert.ToDecimal(reader["ImpuestoPorcentaje"])
                        });
                    }
                }
            }
            finally
            {
                if (_sqlserver.State == ConnectionState.Open) _sqlserver.Close();
            }

            return lista;
        }

        public int Guardar(Producto producto)
        {
            _sqlcommand.CommandText = @"
                INSERT INTO dbo.Producto (Nombre, PrecioCosto, ImpuestoPorcentaje) 
                VALUES (@Nombre, @PrecioCosto, @ImpuestoPorcentaje); 
                SELECT SCOPE_IDENTITY();";

            _sqlcommand.Parameters.Clear();
            _sqlcommand.Parameters.AddWithValue("@Nombre", producto.Nombre);
            _sqlcommand.Parameters.AddWithValue("@PrecioCosto", producto.PrecioCosto);
            _sqlcommand.Parameters.AddWithValue("@ImpuestoPorcentaje", producto.ImpuestoPorcentaje);

            try
            {
                if (_sqlserver.State != ConnectionState.Open) _sqlserver.Open();
                producto.Id = Convert.ToInt32(_sqlcommand.ExecuteScalar());
                return producto.Id;
            }
            finally
            {
                if (_sqlserver.State == ConnectionState.Open) _sqlserver.Close();
            }
        }
    }
}