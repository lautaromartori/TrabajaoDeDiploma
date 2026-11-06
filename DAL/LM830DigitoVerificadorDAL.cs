using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LM830DAL
{
    public class LM830DigitoVerificadorDAL : LM830AbstractDAL<LM830ControlDVV>
    {
        public string? LM830ObtenerDVV(string LM830nomTabla, string LM830nomColumna)
        {
            try
            {
                LM830_sqlcommand.CommandText = @"SELECT DVV
                                            FROM ControlDVV
                                            WHERE NombreTabla = @NomTabla AND ColumnaNombre = @NomColumna";
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.Parameters.AddWithValue("@NomTabla", LM830nomTabla);
                LM830_sqlcommand.Parameters.AddWithValue("@NomColumna", LM830nomColumna);
                LM830_sqlserver.Open();

                return LM830_sqlcommand.ExecuteScalar()?.ToString();
            }
            catch (Exception LM830ex)
            {
                throw LM830ex;
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
            ;
        }

        public void LM830ActualizarDVV(string LM830nomTabla, string LM830nomColumna, string LM830DVV)
        {
            try
            {
                LM830_sqlcommand.CommandText = @"IF EXISTS (SELECT 1 FROM ControlDVV WHERE NombreTabla = @NomTabla AND ColumnaNombre = @NomColumn)
                                            BEGIN
                                                UPDATE ControlDVV
                                                SET DVV = @dvv
                                                WHERE NombreTabla = @NomTabla AND ColumnaNombre = @NomColumn
                                            END
                                            ELSE
                                            BEGIN
                                                INSERT INTO ControlDVV (NombreTabla, ColumnaNombre, DVV)
                                                VALUES (@NomTabla, @NomColumn, @dvv)
                                            END";
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.Parameters.AddWithValue("@NomTabla", LM830nomTabla);
                LM830_sqlcommand.Parameters.AddWithValue("@NomColumn", LM830nomColumna);
                LM830_sqlcommand.Parameters.AddWithValue("@dvv", LM830DVV);
                LM830_sqlserver.Open();

                LM830_sqlcommand.ExecuteNonQuery();
            }
            catch (Exception LM830ex)
            {
                throw LM830ex;
            }
            finally
            {
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlserver.Close();
            }
        }
    }
}
