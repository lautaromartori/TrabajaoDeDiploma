using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BE.RFN1; 

namespace DAL.RFN1
{
    public class ProveedorDAL : AbstractDAL<Proveedor>
    {
        public List<Proveedor> Listar()
        {
            var lista = new List<Proveedor>();
            _sqlcommand.CommandText = "SELECT Id, RazonSocial, Cuit FROM dbo.Proveedor";
            _sqlcommand.Parameters.Clear();

            try
            {
                if (_sqlserver.State != ConnectionState.Open) _sqlserver.Open();
                
                using (SqlDataReader reader = _sqlcommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Proveedor
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            RazonSocial = reader["RazonSocial"].ToString(),
                            Cuit = reader["Cuit"].ToString()
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

        public int Guardar(Proveedor proveedor)
        {
            _sqlcommand.CommandText = @"
                INSERT INTO dbo.Proveedor (RazonSocial, Cuit) 
                VALUES (@RazonSocial, @Cuit); 
                SELECT SCOPE_IDENTITY();";

            _sqlcommand.Parameters.Clear();
            _sqlcommand.Parameters.AddWithValue("@RazonSocial", proveedor.RazonSocial);
            _sqlcommand.Parameters.AddWithValue("@Cuit", proveedor.Cuit);

            try
            {
                if (_sqlserver.State != ConnectionState.Open) _sqlserver.Open();
                proveedor.Id = Convert.ToInt32(_sqlcommand.ExecuteScalar());
                return proveedor.Id;
            }
            finally
            {
                if (_sqlserver.State == ConnectionState.Open) _sqlserver.Close();
            }
        }
    }
}