using LM830Servicios;
using Microsoft.Data.SqlClient;

namespace LM830DAL.LM830BitacoraCambios
{
    
    public static class LM830ContextoSesion
    {
        public static void LM830AplicarUsuario(SqlConnection LM830conexion, SqlTransaction? LM830transaccion)
        {
            string LM830usuario = LM830SessionManager.LM830Instance.LM830Logueado()
                ? LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username
                : "Sistema";
            LM830Fijar(LM830conexion, LM830transaccion, "usuario", LM830usuario);
        }

        public static void LM830Restaurando(SqlConnection LM830conexion, SqlTransaction? LM830transaccion, bool LM830activo)
        {
            LM830Fijar(LM830conexion, LM830transaccion, "restaurando", LM830activo ? (object)1 : System.DBNull.Value);
        }

        private static void LM830Fijar(SqlConnection LM830conexion, SqlTransaction? LM830transaccion, string LM830clave, object LM830valor)
        {
            using (var LM830cmd = new SqlCommand("EXEC sp_set_session_context @clave, @valor", LM830conexion, LM830transaccion))
            {
                LM830cmd.Parameters.AddWithValue("@clave", LM830clave);
                LM830cmd.Parameters.AddWithValue("@valor", LM830valor);
                LM830cmd.ExecuteNonQuery();
            }
        }
    }
}
