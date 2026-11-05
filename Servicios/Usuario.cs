using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LM830Servicios
{
    public class LM830Usuario
    {
        [System.ComponentModel.DisplayName("DNI")]
        public string LM830DNI { get; set; }
        [System.ComponentModel.DisplayName("Nombre")]
        public string LM830Nombre { get; set; }
        [System.ComponentModel.DisplayName("Apellido")]
        public string LM830Apellido { get; set; }
        [System.ComponentModel.DisplayName("Username")]
        public string LM830Username { get; set; }
        [Browsable(false)]
        [System.ComponentModel.DisplayName("Password")]
        public string LM830Password { get; set; }
        [System.ComponentModel.DisplayName("Email")]
        public string LM830Email { get; set; }
        [Browsable(false)]
        [System.ComponentModel.DisplayName("Bloqueado")]
        public bool LM830Bloqueado { get; set; }
        [Browsable(false)]
        [System.ComponentModel.DisplayName("Activo")]
        public bool LM830Activo { get; set; }
        [System.ComponentModel.DisplayName("Rol")]
        public string LM830Rol { get; set; }
        [System.ComponentModel.DisplayName("Intentos")]
        public int LM830Intentos { get; set; }
        [System.ComponentModel.DisplayName("DVH")]
        public string LM830DVH { get; set; }

        public LM830Usuario() { }

        public LM830Usuario(string LM830dNI, string LM830nombre, string LM830apellido, string LM830nombreUsuario, string LM830password, string LM830email, bool LM830bloqueado, bool LM830activo, string LM830nombre_rol)
        {
            LM830DNI = LM830dNI;
            LM830Nombre = LM830nombre;
            LM830Apellido = LM830apellido;
            LM830Username = LM830nombreUsuario;
            LM830Password = LM830password.Trim();
            LM830Email = LM830email;
            LM830Bloqueado = LM830bloqueado;
            LM830Activo = LM830activo;
            LM830Rol = LM830nombre_rol;
        }
        public LM830Usuario(string LM830dNI, string LM830nombre, string LM830apellido, string LM830nombreUsuario, string LM830password, string LM830email, bool LM830bloqueado, bool LM830activo, string LM830nombre_rol, int LM830intentos)
        {
            LM830DNI = LM830dNI;
            LM830Nombre = LM830nombre;
            LM830Apellido = LM830apellido;
            LM830Username = LM830nombreUsuario;
            LM830Password = LM830password.Trim();
            LM830Email = LM830email;
            LM830Bloqueado = LM830bloqueado;
            LM830Activo = LM830activo;
            LM830Rol = LM830nombre_rol;
            LM830Intentos = LM830intentos;
        }
        public LM830Usuario(string LM830dNI, string LM830nombre, string LM830apellido, string LM830nombreUsuario, string LM830password, string LM830email, bool LM830bloqueado, bool LM830activo, string LM830nombre_rol, int LM830intentos, string LM830dvh)
        {
            LM830DNI = LM830dNI;
            LM830Nombre = LM830nombre;
            LM830Apellido = LM830apellido;
            LM830Username = LM830nombreUsuario;
            LM830Password = LM830password.Trim();
            LM830Email = LM830email;
            LM830Bloqueado = LM830bloqueado;
            LM830Activo = LM830activo;
            LM830Rol = LM830nombre_rol;
            LM830Intentos = LM830intentos;
            LM830DVH = LM830dvh;
        }

        [Browsable(false)]
        [System.ComponentModel.DisplayName("Permisos")]
        public List<LM830ComponentePermiso> LM830Permisos { get; set; } = new List<LM830ComponentePermiso>();
        public bool LM830TienePermiso(string LM830nombrePermiso)
        {
            if (LM830Permisos == null) return false;

            foreach (var LM830componente in LM830Permisos)
            {
                if (LM830componente.LM830TienePermiso(LM830nombrePermiso))
                    return true;
            }
            return false;
        }
    }
}
