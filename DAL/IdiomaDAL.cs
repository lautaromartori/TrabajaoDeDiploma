using Microsoft.Data.SqlClient;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LM830DAL
{
    public class LM830IdiomaDAL : LM830AbstractDAL<LM830IdiomaDAL>
    {
        public string LM830ObtenerIdioma(string LM830userName)
        {
            try
            {
                LM830_sqlcommand.Parameters.Clear();

                LM830_sqlcommand.CommandText = @"
                    SELECT CodigoIdioma
                    FROM Idioma
                    WHERE UserName = @UserName";

                LM830_sqlcommand.Parameters.AddWithValue(
                    "@UserName",
                    LM830userName);

                LM830_sqlserver.Open();

                object LM830resultado =
                    LM830_sqlcommand.ExecuteScalar();

                if (LM830resultado == null)
                    return "es";

                return LM830resultado.ToString();
            }
            finally
            {
                if (LM830_sqlserver.State ==
                    System.Data.ConnectionState.Open)
                {
                    LM830_sqlserver.Close();
                }

                LM830_sqlcommand.Parameters.Clear();
            }
        }
        public List<LM830Idioma> LM830listarTodosLosIdiomas()
        {
            List<LM830Idioma> LM830lista = new List<LM830Idioma>();
            try
            {
                LM830_sqlcommand.CommandText = @"SELECT UserName, CodigoIdioma, DVH FROM Idioma";
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Open();
                using (SqlDataReader LM830reader = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830reader.Read())
                    {
                        LM830Idioma LM830idioma = new LM830Idioma
                        {
                            LM830UserName = LM830reader["UserName"].ToString(),
                            LM830CodigoIdioma = LM830reader["CodigoIdioma"].ToString(),
                            LM830DVH = LM830reader["DVH"].ToString()
                        };
                        LM830lista.Add(LM830idioma);
                    }
                }
            }
            finally
            {
                if (LM830_sqlserver.State == System.Data.ConnectionState.Open)
                {
                    LM830_sqlserver.Close();
                }
                LM830_sqlcommand.Parameters.Clear();
            }
            return LM830lista;
        }

        public void LM830GuardarIdioma(
            string LM830userName,
            string LM830codigoIdioma,
            string LM830DVH)
        {
            try
            {
                LM830_sqlcommand.Parameters.Clear();

                LM830_sqlcommand.CommandText = @"
                IF EXISTS
                (
                    SELECT 1
                    FROM Idioma
                    WHERE UserName = @UserName
                )
                BEGIN
                    UPDATE Idioma
                    SET
                        CodigoIdioma = @CodigoIdioma,
                        DVH = @dvh
                    WHERE UserName = @UserName
                END
                ELSE
                BEGIN
                    INSERT INTO Idioma
                    (
                        UserName,
                        CodigoIdioma,
                        DVH
                    )
                    VALUES
                    (
                        @UserName,
                        @CodigoIdioma,
                        @dvh
                    )
                END";

                LM830_sqlcommand.Parameters.AddWithValue(
                    "@UserName",
                    LM830userName);

                LM830_sqlcommand.Parameters.AddWithValue(
                    "@CodigoIdioma",
                    LM830codigoIdioma);

                LM830_sqlcommand.Parameters.AddWithValue(
                    "@dvh",
                    LM830DVH);

                LM830_sqlserver.Open();

                LM830_sqlcommand.ExecuteNonQuery();
            }
            finally
            {
                if (LM830_sqlserver.State ==
                    System.Data.ConnectionState.Open)
                {
                    LM830_sqlserver.Close();
                }

                LM830_sqlcommand.Parameters.Clear();
            }
        }

        public void LM830ActualizarDVH(string LM830userName, string LM830dvhCalculado)
        {
            try
            {
                LM830_sqlcommand.CommandText = @"UPDATE Idioma SET DVH = @DVH WHERE UserName = @UserName";
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.Parameters.AddWithValue("@DVH", LM830dvhCalculado);
                LM830_sqlcommand.Parameters.AddWithValue("@UserName", LM830userName);
                LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (Exception LM830ex)
            {
                throw;
            }
            finally
            {
                if (LM830_sqlserver.State == System.Data.ConnectionState.Open)
                {
                    LM830_sqlserver.Close();
                }
                LM830_sqlcommand.Parameters.Clear();
            }
        }
    }
}
