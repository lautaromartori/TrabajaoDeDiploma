using Microsoft.Data.SqlClient;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Data;

namespace LM830DAL
{
    public class LM830PerfilDAL : LM830AbstractDAL<LM830ComponentePermiso>
    {
        public List<LM830PermisoSimple> LM830ObtenerPermisos()
        {
            var LM830lista = new List<LM830PermisoSimple>();
            try
            {
                if (LM830_sqlserver.State != ConnectionState.Open) LM830_sqlserver.Open();
                LM830_sqlcommand.CommandText = "SELECT Nombre, DVH FROM PermisoSimple";
                using (var LM830reader = LM830_sqlcommand.ExecuteReader())
                {
                    while (LM830reader.Read())
                        LM830lista.Add(new LM830PermisoSimple
                        {
                            LM830Nombre = LM830reader["Nombre"].ToString(),
                            LM830DVH = LM830reader["DVH"].ToString()
                        });
                }
            }
            finally
            {
                if (LM830_sqlserver.State == ConnectionState.Open) LM830_sqlserver.Close();
            }
            return LM830lista;
        }

        public List<LM830Familia> LM830ObtenerFamilias()
        {
            var LM830lista = new List<LM830Familia>();
            try
            {
                if (LM830_sqlserver.State != ConnectionState.Open) LM830_sqlserver.Open();
                using (var LM830cmd = new SqlCommand("SELECT Nombre, DVH FROM Familia", LM830_sqlserver))
                using (var LM830reader = LM830cmd.ExecuteReader())
                {
                    while (LM830reader.Read())
                        LM830lista.Add(new LM830Familia
                        {
                            LM830Nombre = LM830reader["Nombre"].ToString(),
                            LM830EsRol = false,
                            LM830DVH = LM830reader["DVH"].ToString()
                        });
                }
                foreach (var LM830fam in LM830lista)
                    LM830CargarHijosComponente(LM830fam);
            }
            finally
            {
                if (LM830_sqlserver.State == ConnectionState.Open) LM830_sqlserver.Close();
            }
            return LM830lista;
        }

        public List<LM830Familia> LM830ObtenerPerfiles()
        {
            var LM830lista = new List<LM830Familia>();
            try
            {
                if (LM830_sqlserver.State != ConnectionState.Open) LM830_sqlserver.Open();
                using (var LM830cmd = new SqlCommand("SELECT Nombre, DVH FROM Perfil", LM830_sqlserver))
                using (var LM830reader = LM830cmd.ExecuteReader())
                {
                    while (LM830reader.Read())
                        LM830lista.Add(new LM830Familia
                        {
                            LM830Nombre = LM830reader["Nombre"].ToString(),
                            LM830EsRol = true,
                            LM830DVH = LM830reader["DVH"].ToString()
                        });
                }
                foreach (var LM830perfil in LM830lista)
                    LM830CargarHijosComponente(LM830perfil);
            }
            finally
            {
                if (LM830_sqlserver.State == ConnectionState.Open) LM830_sqlserver.Close();
            }
            return LM830lista;
        }

        public List<LM830Familia> LM830ObtenerFamiliasYPerfiles()
        {
            var LM830listaUnificada = new List<LM830Familia>();
            var LM830nombresFamilias = new List<string>();
            var LM830nombresPerfiles = new List<string>();

            try
            {
                if (LM830_sqlserver.State != ConnectionState.Open) LM830_sqlserver.Open();

                using (var LM830cmd = new SqlCommand("SELECT Nombre FROM Familia", LM830_sqlserver))
                using (var LM830reader = LM830cmd.ExecuteReader())
                    while (LM830reader.Read())
                        LM830nombresFamilias.Add(LM830reader["Nombre"].ToString());

                using (var LM830cmd = new SqlCommand("SELECT Nombre FROM Perfil", LM830_sqlserver))
                using (var LM830reader = LM830cmd.ExecuteReader())
                    while (LM830reader.Read())
                        LM830nombresPerfiles.Add(LM830reader["Nombre"].ToString());

                foreach (var LM830nombre in LM830nombresFamilias)
                {
                    var LM830fam = new LM830Familia { LM830Nombre = LM830nombre, LM830EsRol = false };
                    LM830CargarHijosComponente(LM830fam);
                    LM830listaUnificada.Add(LM830fam);
                }
                foreach (var LM830nombre in LM830nombresPerfiles)
                {
                    var LM830perf = new LM830Familia { LM830Nombre = LM830nombre, LM830EsRol = true };
                    LM830CargarHijosComponente(LM830perf);
                    LM830listaUnificada.Add(LM830perf);
                }
            }
            finally
            {
                if (LM830_sqlserver.State == ConnectionState.Open) LM830_sqlserver.Close();
            }
            return LM830listaUnificada;
        }

        private void LM830CargarHijosComponente(LM830Familia LM830padre)
        {
            string LM830tablaPermisos = LM830padre.LM830EsRol ? "Perfil_PermisoSimple" : "Familia_PermisoSimple";
            string LM830tablaFamilias = LM830padre.LM830EsRol ? "Perfil_Familia" : "Familia_Familia";
            string LM830colPadre = LM830padre.LM830EsRol ? "NombrePerfil" : "NombreFamilia";
            string LM830colPadreHijo = LM830padre.LM830EsRol ? "NombrePerfil" : "NombrePadre";
            string LM830colHijo = LM830padre.LM830EsRol ? "NombreFamilia" : "NombreHijo";

            using (var LM830cmd = new SqlCommand(
                $"SELECT NombrePermiso FROM {LM830tablaPermisos} WHERE {LM830colPadre} = @Padre", LM830_sqlserver))
            {
                LM830cmd.Parameters.AddWithValue("@Padre", LM830padre.LM830Nombre);
                using (var LM830reader = LM830cmd.ExecuteReader())
                    while (LM830reader.Read())
                        LM830padre.LM830AgregarHijo(new LM830PermisoSimple { LM830Nombre = LM830reader["NombrePermiso"].ToString() });
            }

            var LM830familiasHijas = new List<string>();
            using (var LM830cmd = new SqlCommand(
                $"SELECT {LM830colHijo} FROM {LM830tablaFamilias} WHERE {LM830colPadreHijo} = @Padre", LM830_sqlserver))
            {
                LM830cmd.Parameters.AddWithValue("@Padre", LM830padre.LM830Nombre);
                using (var LM830reader = LM830cmd.ExecuteReader())
                    while (LM830reader.Read())
                        LM830familiasHijas.Add(LM830reader[LM830colHijo].ToString());
            }

            foreach (var LM830nombreHijo in LM830familiasHijas)
            {
                var LM830sub = new LM830Familia { LM830Nombre = LM830nombreHijo, LM830EsRol = false };
                LM830CargarHijosComponente(LM830sub);
                LM830padre.LM830AgregarHijo(LM830sub);
            }
        }

        private bool LM830ExisteNombre(string LM830nombre, string LM830tabla)
        {
            using (var LM830cmd = new SqlCommand(
                $"SELECT COUNT(*) FROM {LM830tabla} WHERE Nombre = @Nombre", LM830_sqlserver))
            {
                LM830cmd.Parameters.AddWithValue("@Nombre", LM830nombre);
                try
                {
                    if (LM830_sqlserver.State != ConnectionState.Open) LM830_sqlserver.Open();
                    return Convert.ToInt32(LM830cmd.ExecuteScalar()) > 0;
                }
                finally
                {
                    if (LM830_sqlserver.State == ConnectionState.Open) LM830_sqlserver.Close();
                }
            }
        }

        public void LM830GuardarPermiso(LM830PermisoSimple LM830permiso)
        {
            if (LM830ExisteNombre(LM830permiso.LM830Nombre, "PermisoSimple"))
                throw new ArgumentException(LM830LanguageManager.LM830Instance.LM830GetTraduction("PerfilDalText2"));

            string LM830dvh = LM830DigitoVerificador.LM830CalcularDVH(LM830permiso.LM830Nombre);

            LM830_sqlcommand.CommandText = "INSERT INTO PermisoSimple (Nombre, DVH) VALUES (@Nombre, @dvh)";
            LM830_sqlcommand.Parameters.Clear();
            LM830_sqlcommand.Parameters.AddWithValue("@Nombre", LM830permiso.LM830Nombre);
            LM830_sqlcommand.Parameters.AddWithValue("@dvh", LM830dvh);
            LM830EjecutarNonQuery();
        }

        public void LM830EliminarPermiso(string LM830nombre)
        {
            try
            {
                if (LM830_sqlserver.State != ConnectionState.Open) LM830_sqlserver.Open();

                using (var LM830cmd1 = new SqlCommand(
                    "DELETE FROM Familia_PermisoSimple WHERE NombrePermiso = @Nombre", LM830_sqlserver))
                {
                    LM830cmd1.Parameters.AddWithValue("@Nombre", LM830nombre);
                    LM830cmd1.ExecuteNonQuery();
                }
                using (var LM830cmd2 = new SqlCommand(
                    "DELETE FROM Perfil_PermisoSimple WHERE NombrePermiso = @Nombre", LM830_sqlserver))
                {
                    LM830cmd2.Parameters.AddWithValue("@Nombre", LM830nombre);
                    LM830cmd2.ExecuteNonQuery();
                }

                LM830_sqlcommand.CommandText = "DELETE FROM PermisoSimple WHERE Nombre = @Nombre";
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.Parameters.AddWithValue("@Nombre", LM830nombre);
                LM830_sqlcommand.ExecuteNonQuery();
            }
            finally
            {
                if (LM830_sqlserver.State == ConnectionState.Open) LM830_sqlserver.Close();
                LM830_sqlcommand.Parameters.Clear();
            }
        }

        public void LM830GuardarFamilia(LM830Familia LM830familia)
        {
            string LM830tabla = LM830familia.LM830EsRol ? "Perfil" : "Familia";

            if (LM830ExisteNombre(LM830familia.LM830Nombre, LM830tabla))
            {
                string LM830tipo = LM830familia.LM830EsRol ? "perfil" : "familia";
                throw new ArgumentException(
                    $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("PerfilDalText2")} {LM830tipo} {LM830LanguageManager.LM830Instance.LM830GetTraduction("PerfilDalText3")}");
            }

            string LM830dvh = LM830DigitoVerificador.LM830CalcularDVH(LM830familia.LM830Nombre);

            LM830_sqlcommand.CommandText = $"INSERT INTO {LM830tabla} (Nombre, DVH) VALUES (@Nombre, @dvh)";
            LM830_sqlcommand.Parameters.Clear();
            LM830_sqlcommand.Parameters.AddWithValue("@Nombre", LM830familia.LM830Nombre);
            LM830_sqlcommand.Parameters.AddWithValue("@dvh", LM830dvh);
            LM830EjecutarNonQuery();
        }

        public void LM830EliminarFamilia(LM830Familia LM830familia)
        {
            string LM830tabla = LM830familia.LM830EsRol ? "Perfil" : "Familia";
            try
            {
                if (LM830_sqlserver.State != ConnectionState.Open) LM830_sqlserver.Open();

                LM830LimpiarRelacionesComponente(LM830familia.LM830Nombre, LM830familia.LM830EsRol);

                if (!LM830familia.LM830EsRol)
                {
                    using (var LM830cmd1 = new SqlCommand(
                        "DELETE FROM Familia_Familia WHERE NombreHijo = @Nombre", LM830_sqlserver))
                    {
                        LM830cmd1.Parameters.AddWithValue("@Nombre", LM830familia.LM830Nombre);
                        LM830cmd1.ExecuteNonQuery();
                    }
                    using (var LM830cmd2 = new SqlCommand(
                        "DELETE FROM Perfil_Familia WHERE NombreFamilia = @Nombre", LM830_sqlserver))
                    {
                        LM830cmd2.Parameters.AddWithValue("@Nombre", LM830familia.LM830Nombre);
                        LM830cmd2.ExecuteNonQuery();
                    }
                }

                LM830_sqlcommand.CommandText = $"DELETE FROM {LM830tabla} WHERE Nombre = @Nombre";
                LM830_sqlcommand.Parameters.Clear();
                LM830_sqlcommand.Parameters.AddWithValue("@Nombre", LM830familia.LM830Nombre);
                LM830_sqlcommand.ExecuteNonQuery();
            }
            finally
            {
                if (LM830_sqlserver.State == ConnectionState.Open) LM830_sqlserver.Close();
                LM830_sqlcommand.Parameters.Clear();
            }
        }

        public void LM830GuardarRelaciones(LM830Familia LM830padre)
        {
            try
            {
                if (LM830_sqlserver.State != ConnectionState.Open) LM830_sqlserver.Open();

                LM830LimpiarRelacionesComponente(LM830padre.LM830Nombre, LM830padre.LM830EsRol);

                foreach (var LM830hijo in LM830padre.LM830ObtenerHijos())
                {
                    if (LM830hijo is LM830PermisoSimple LM830permiso)
                    {
                        string LM830tabla = LM830padre.LM830EsRol ? "Perfil_PermisoSimple" : "Familia_PermisoSimple";
                        string LM830col1 = LM830padre.LM830EsRol ? "NombrePerfil" : "NombreFamilia";
                        using (var LM830cmd = new SqlCommand(
                            $"INSERT INTO {LM830tabla} ({LM830col1}, NombrePermiso) VALUES (@Padre, @Hijo)", LM830_sqlserver))
                        {
                            LM830cmd.Parameters.AddWithValue("@Padre", LM830padre.LM830Nombre);
                            LM830cmd.Parameters.AddWithValue("@Hijo", LM830permiso.LM830Nombre);
                            LM830cmd.ExecuteNonQuery();
                        }
                    }
                    else if (LM830hijo is LM830Familia LM830subFamilia)
                    {
                        string LM830tabla = LM830padre.LM830EsRol ? "Perfil_Familia" : "Familia_Familia";
                        string LM830col1 = LM830padre.LM830EsRol ? "NombrePerfil" : "NombrePadre";
                        string LM830col2 = LM830padre.LM830EsRol ? "NombreFamilia" : "NombreHijo";
                        using (var LM830cmd = new SqlCommand(
                            $"INSERT INTO {LM830tabla} ({LM830col1}, {LM830col2}) VALUES (@Padre, @Hijo)", LM830_sqlserver))
                        {
                            LM830cmd.Parameters.AddWithValue("@Padre", LM830padre.LM830Nombre);
                            LM830cmd.Parameters.AddWithValue("@Hijo", LM830subFamilia.LM830Nombre);
                            LM830cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            finally
            {
                if (LM830_sqlserver.State == ConnectionState.Open) LM830_sqlserver.Close();
            }
        }

        private void LM830LimpiarRelacionesComponente(string LM830nombrePadre, bool LM830esRol)
        {
            string LM830q1 = LM830esRol
                ? "DELETE FROM Perfil_PermisoSimple WHERE NombrePerfil = @Padre"
                : "DELETE FROM Familia_PermisoSimple WHERE NombreFamilia = @Padre";
            string LM830q2 = LM830esRol
                ? "DELETE FROM Perfil_Familia WHERE NombrePerfil = @Padre"
                : "DELETE FROM Familia_Familia WHERE NombrePadre = @Padre";

            using (var LM830cmd1 = new SqlCommand(LM830q1, LM830_sqlserver))
            {
                LM830cmd1.Parameters.AddWithValue("@Padre", LM830nombrePadre);
                LM830cmd1.ExecuteNonQuery();
            }
            using (var LM830cmd2 = new SqlCommand(LM830q2, LM830_sqlserver))
            {
                LM830cmd2.Parameters.AddWithValue("@Padre", LM830nombrePadre);
                LM830cmd2.ExecuteNonQuery();
            }
        }

        private void LM830EjecutarNonQuery()
        {
            try
            {
                if (LM830_sqlserver.State != ConnectionState.Open) LM830_sqlserver.Open();
                LM830_sqlcommand.ExecuteNonQuery();
            }
            finally
            {
                if (LM830_sqlserver.State == ConnectionState.Open) LM830_sqlserver.Close();
                LM830_sqlcommand.Parameters.Clear();
            }
        }

        public void LM830ActualizarPefilDVH(string LM830nombre, string LM830dvhCalculado)
        {
            LM830_sqlcommand.CommandText = "UPDATE Perfil SET DVH = @dvh WHERE Nombre = @nom";
            LM830_sqlcommand.Parameters.Clear();
            LM830_sqlcommand.Parameters.AddWithValue("@dvh", LM830dvhCalculado);
            LM830_sqlcommand.Parameters.AddWithValue("@nom", LM830nombre);
            LM830EjecutarNonQuery();
        }

        public void LM830ActualizarPermisoSimpleDVH(string LM830nombre, string LM830dvhCalculado)
        {
            LM830_sqlcommand.CommandText = "UPDATE PermisoSimple SET DVH = @dvh WHERE Nombre = @nom";
            LM830_sqlcommand.Parameters.Clear();
            LM830_sqlcommand.Parameters.AddWithValue("@dvh", LM830dvhCalculado);
            LM830_sqlcommand.Parameters.AddWithValue("@nom", LM830nombre);
            LM830EjecutarNonQuery();
        }

        public void LM830ActualizarDVH(string LM830nombre, string LM830dvhCalculado)
        {
            LM830_sqlcommand.CommandText = "UPDATE Familia SET DVH = @dvh WHERE Nombre = @nom";
            LM830_sqlcommand.Parameters.Clear();
            LM830_sqlcommand.Parameters.AddWithValue("@dvh", LM830dvhCalculado);
            LM830_sqlcommand.Parameters.AddWithValue("@nom", LM830nombre);
            LM830EjecutarNonQuery();
        }
    }
}
