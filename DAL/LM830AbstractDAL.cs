using Microsoft.Data.SqlClient;
using LM830Servicios;
using System;

namespace LM830DAL
{
    public abstract class LM830AbstractDAL<LM830T> where LM830T : class
    {
        protected SqlConnection LM830_sqlserver;
        protected SqlCommand LM830_sqlcommand;

        protected LM830AbstractDAL()
        {
            string LM830cadenaConexion = LM830ConexionConfig.LM830ObtenerCadenaConexion();

            LM830_sqlserver = new SqlConnection(LM830cadenaConexion);
            LM830_sqlcommand = new SqlCommand();
            LM830_sqlcommand.Connection = LM830_sqlserver;
            LM830_sqlcommand.CommandType = System.Data.CommandType.Text;
        }
    }
}
