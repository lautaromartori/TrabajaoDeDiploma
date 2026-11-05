using LM830DAL;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LM830BLL
{
    public class LM830PerfilBLL
    {
        private readonly LM830PerfilDAL LM830_dal;
        private readonly LM830BitacoraBLL LM830_bitacoraBLL;
        private readonly LM830DigitoVerificadorBLL LM830_digitoVerificadorBLL = new LM830DigitoVerificadorBLL();
        private const string LM830MODULO_BITACORA = "Perfiles";

        public LM830PerfilBLL()
        {
            LM830_dal = new LM830PerfilDAL();
            LM830_bitacoraBLL = new LM830BitacoraBLL();
        }

        public List<LM830PermisoSimple> LM830ObtenerPermisos() => LM830_dal.LM830ObtenerPermisos();

        public List<LM830Familia> LM830ObtenerFamilias()
        {
            return LM830_dal.LM830ObtenerFamiliasYPerfiles().Where(LM830f => !LM830f.LM830EsRol).ToList();
        }

        public List<LM830Familia> LM830ObtenerPerfiles()
        {
            return LM830_dal.LM830ObtenerFamiliasYPerfiles().Where(LM830f => LM830f.LM830EsRol).ToList();
        }

        public List<LM830PermisoSimple> LM830ObtenerPermisosDisponibles(LM830Familia LM830componentePadre)
        {
            var LM830todosLosPermisos = LM830_dal.LM830ObtenerPermisos();
            if (LM830componentePadre == null) return LM830todosLosPermisos;

            var LM830permisosYaIncluidos = new HashSet<string>();
            var LM830familiasYaIncluidas = new HashSet<string>();

            LM830ObtenerEstructuraPlana(LM830componentePadre, LM830permisosYaIncluidos, LM830familiasYaIncluidas);

            return LM830todosLosPermisos.Where(LM830p => !LM830permisosYaIncluidos.Contains(LM830p.LM830Nombre)).ToList();
        }

        public List<LM830Familia> LM830ObtenerFamiliasDisponibles(string LM830nombrePadre)
        {
            var LM830todasLasFamilias = LM830ObtenerFamilias();
            var LM830todosLosComponentes = LM830_dal.LM830ObtenerFamiliasYPerfiles();
            var LM830padre = LM830todosLosComponentes.FirstOrDefault(LM830f => LM830f.LM830Nombre == LM830nombrePadre);

            if (LM830padre == null) return LM830todasLasFamilias;

            var LM830familiasAsignadas = new HashSet<string>();
            LM830ObtenerEstructuraPlana(LM830padre, new HashSet<string>(), LM830familiasAsignadas);

            return LM830todasLasFamilias.Where(LM830f => LM830f.LM830Nombre != LM830nombrePadre && !LM830familiasAsignadas.Contains(LM830f.LM830Nombre)).ToList();
        }

        public void LM830RecargarPermisosUsuarioEnSesion()
        {
            try
            {
                if (!LM830SessionManager.LM830Instance.LM830Logueado()) return;

                LM830Usuario LM830usuarioActual = LM830SessionManager.LM830Instance.LM830UsuarioActual();
                var LM830perfiles = LM830ObtenerPerfiles();
                var LM830perfilUsuario = LM830perfiles.FirstOrDefault(LM830p => LM830p.LM830Nombre == LM830usuarioActual.LM830Rol);

                if (LM830perfilUsuario != null)
                {
                    LM830usuarioActual.LM830Permisos.Clear();
                    LM830usuarioActual.LM830Permisos.Add(LM830perfilUsuario);
                }
            }
            catch { }
        }

        public void LM830CrearPermiso(string LM830nombre)
        {
            LM830_dal.LM830GuardarPermiso(new LM830PermisoSimple { LM830Nombre = LM830nombre, LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830nombre) });
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_PermisoSimple();
            LM830RegistrarEnBitacora(LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username, $"Crear permiso simple: {LM830nombre}", 1);
        }

        public void LM830EliminarPermiso(string LM830nombre)
        {
            LM830_dal.LM830EliminarPermiso(LM830nombre);
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_PermisoSimple();
            LM830RegistrarEnBitacora(LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username, $"Eliminar permiso simple: {LM830nombre}", 1);
            LM830RecargarPermisosUsuarioEnSesion();
        }

        public void LM830CrearFamilia(string LM830nombre)
        {
            LM830_dal.LM830GuardarFamilia(new LM830Familia { LM830Nombre = LM830nombre, LM830EsRol = false, LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830nombre) });
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_Familia();
            LM830RegistrarEnBitacora(LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username, $"Crear familia: {LM830nombre}", 1);
        }

        public void LM830CrearPerfil(string LM830nombre)
        {
            LM830_dal.LM830GuardarFamilia(new LM830Familia { LM830Nombre = LM830nombre, LM830EsRol = true, LM830DVH = LM830DigitoVerificador.LM830CalcularDVH(LM830nombre) });
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_Perfil();
            LM830RegistrarEnBitacora(LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username, $"Crear perfil: {LM830nombre}", 1);
        }

        public void LM830EliminarFamiliaOPerfil(string LM830nombre)
        {
            var LM830familia = LM830_dal.LM830ObtenerFamiliasYPerfiles().FirstOrDefault(LM830f => LM830f.LM830Nombre == LM830nombre);
            if (LM830familia == null) return;

            if (LM830familia.LM830EsRol)
            {
                var LM830usuariosConEstePerfil = new LM830UsuarioBLL().LM830ListarTodosUsuarios()
                    .Where(LM830u => LM830u.LM830Rol == LM830nombre)
                    .ToList();

                if (LM830usuariosConEstePerfil.Any())
                {
                    string LM830lista = string.Join(", ", LM830usuariosConEstePerfil.Select(LM830u => LM830u.LM830Username));
                    throw new Exception(
                        $"{LM830LanguageManager.LM830Instance.LM830GetTraduction("PerfilBLLmsj1")} '{LM830nombre}' {LM830LanguageManager.LM830Instance.LM830GetTraduction("PerfilBLLmsj2")} {LM830lista}.\n\n" +
                        LM830LanguageManager.LM830Instance.LM830GetTraduction("PerfilBllMsj3"));
                }
            }

            LM830_dal.LM830EliminarFamilia(LM830familia);
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_Familia();
            LM830_digitoVerificadorBLL.LM830RecalcularDVV_Perfil();
            LM830RegistrarEnBitacora(LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username, $"Eliminar contenedor jerárquico: {LM830nombre}", 1);
            LM830RecargarPermisosUsuarioEnSesion();
        }

        public void LM830QuitarHijos(string LM830nombrePadre, List<string> LM830hijos, bool LM830esPermisoSimple)
        {
            var LM830padre = LM830_dal.LM830ObtenerFamiliasYPerfiles().FirstOrDefault(LM830f => LM830f.LM830Nombre == LM830nombrePadre);
            if (LM830padre == null) return;

            foreach (var LM830nombreHijo in LM830hijos)
            {
                var LM830hijoAQuitar = LM830padre.LM830ListaHijos.FirstOrDefault(LM830h => LM830h.LM830Nombre == LM830nombreHijo);
                if (LM830hijoAQuitar != null)
                {
                    LM830padre.LM830QuitarHijo(LM830hijoAQuitar);
                }
            }

            LM830_dal.LM830GuardarRelaciones(LM830padre);

            foreach (var LM830hijo in LM830hijos)
            {
                string LM830tipoNodo = LM830esPermisoSimple ? "Permiso Simple" : "Subfamilia";
                LM830RegistrarEnBitacora(LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username, $"Desvincular {LM830tipoNodo} '{LM830hijo}' del contenedor '{LM830nombrePadre}'", 1);
            }

            LM830RecargarPermisosUsuarioEnSesion();
        }

        public void LM830EliminarPermisoRedundanteDeNodoContenedor(string LM830nombreContenedorRaiz, List<string> LM830permisosComponentes)
        {
            try
            {
                var LM830todosLosComponentes = LM830_dal.LM830ObtenerFamiliasYPerfiles();
                var LM830raiz = LM830todosLosComponentes.FirstOrDefault(LM830f => LM830f.LM830Nombre == LM830nombreContenedorRaiz);
                if (LM830raiz == null) throw new Exception($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("PerfilBllMsj4")} '{LM830nombreContenedorRaiz}'.");

                foreach (var LM830permiso in LM830permisosComponentes)
                {
                    string LM830contenedorDirecto = LM830BuscarContenedorDirectoDelPermiso(LM830raiz, LM830permiso);
                    if (!string.IsNullOrEmpty(LM830contenedorDirecto))
                    {
                        var LM830contenedor = LM830todosLosComponentes.FirstOrDefault(LM830f => LM830f.LM830Nombre == LM830contenedorDirecto);
                        if (LM830contenedor != null)
                        {
                            var LM830permisoAQuitar = LM830contenedor.LM830ListaHijos.FirstOrDefault(LM830h => LM830h.LM830Nombre == LM830permiso && LM830h is LM830PermisoSimple);
                            if (LM830permisoAQuitar != null)
                            {
                                LM830contenedor.LM830QuitarHijo(LM830permisoAQuitar);
                                LM830_dal.LM830GuardarRelaciones(LM830contenedor);
                            }
                        }
                        LM830RegistrarEnBitacora(LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username, $"Mitigación de redundancia: Remoción del permiso '{LM830permiso}' en subnodo '{LM830contenedorDirecto}'", 2);
                    }
                }

                LM830RecargarPermisosUsuarioEnSesion();
            }
            catch (Exception LM830ex)
            {
                LM830RegistrarEnBitacora(LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username, $"ERROR en EliminarPermisoRedundante: {LM830ex.Message}", 1);
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("PerBLLText1") + LM830ex.Message);
            }
        }

        public LM830ResultadoAsignacion LM830AsignarComponentesHijos(string LM830nombrePadre, List<string> LM830nombresHijos, bool LM830esPermisoSimple)
        {
            var LM830resultado = new LM830ResultadoAsignacion { LM830Estado = LM830EstadoAsignacion.LM830Ok };
            if (!LM830nombresHijos.Any()) return LM830resultado;

            var LM830todosLosComponentes = LM830_dal.LM830ObtenerFamiliasYPerfiles();
            var LM830componentePadre = LM830todosLosComponentes.FirstOrDefault(LM830f => LM830f.LM830Nombre == LM830nombrePadre);

            if (LM830componentePadre == null) return LM830resultado;

            foreach (var LM830nombreHijo in LM830nombresHijos)
            {
                if (LM830nombrePadre == LM830nombreHijo)
                {
                    LM830resultado.LM830Estado = LM830EstadoAsignacion.LM830ConflictoPermisos;
                    LM830resultado.LM830PermisosConflictivos.Add(LM830nombreHijo);
                    LM830resultado.LM830OrigenConflicto[LM830nombreHijo] = "Restricción: No es posible asignar un componente jerárquico a sí mismo.";
                    return LM830resultado;
                }

                if (!LM830esPermisoSimple)
                {
                    var LM830componenteHijo = LM830todosLosComponentes.FirstOrDefault(LM830f => LM830f.LM830Nombre == LM830nombreHijo);
                    if (LM830componenteHijo != null && LM830componenteHijo.LM830EsRol && !LM830componentePadre.LM830EsRol)
                    {
                        LM830resultado.LM830Estado = LM830EstadoAsignacion.LM830ConflictoPermisos;
                        LM830resultado.LM830PermisosConflictivos.Add(LM830nombreHijo);
                        LM830resultado.LM830OrigenConflicto[LM830nombreHijo] = $"Incompatibilidad de estructura: El perfil '{LM830nombreHijo}' no puede ser subcomponente de la familia '{LM830nombrePadre}'.";
                        return LM830resultado;
                    }

                    if (LM830ValidarCicloJerarquico(LM830nombreHijo, LM830nombrePadre, LM830todosLosComponentes))
                    {
                        LM830resultado.LM830Estado = LM830EstadoAsignacion.LM830ConflictoPermisos;
                        LM830resultado.LM830PermisosConflictivos.Add(LM830nombreHijo);
                        LM830resultado.LM830OrigenConflicto[LM830nombreHijo] = $"Referencia circular detectada: El componente '{LM830nombreHijo}' ya contiene al componente '{LM830nombrePadre}'.";
                        return LM830resultado;
                    }
                }

                var LM830permisosActualesPadre = new HashSet<string>();
                var LM830familiasActualesPadre = new HashSet<string>();
                LM830ObtenerEstructuraPlana(LM830componentePadre, LM830permisosActualesPadre, LM830familiasActualesPadre);

                foreach (var LM830elemento in LM830componentePadre.LM830ListaHijos.OfType<LM830PermisoSimple>())
                {
                    LM830permisosActualesPadre.Add(LM830elemento.LM830Nombre);
                }

                if (LM830esPermisoSimple)
                {
                    if (LM830permisosActualesPadre.Contains(LM830nombreHijo))
                    {
                        LM830resultado.LM830Estado = LM830EstadoAsignacion.LM830ConflictoPermisos;
                        LM830resultado.LM830PermisosConflictivos.Add(LM830nombreHijo);
                        LM830resultado.LM830OrigenConflicto[LM830nombreHijo] = $"Redundancia detectada: El permiso '{LM830nombreHijo}' ya existe en '{LM830nombrePadre}'.";
                        return LM830resultado;
                    }

                    string LM830mensajeConflictoHorizontal = LM830VerificarConflictoHorizontal(LM830todosLosComponentes, LM830componentePadre, LM830nombreHijo);
                    if (!string.IsNullOrEmpty(LM830mensajeConflictoHorizontal))
                    {
                        LM830resultado.LM830Estado = LM830EstadoAsignacion.LM830ConflictoPermisos;
                        LM830resultado.LM830PermisosConflictivos.Add(LM830nombreHijo);
                        LM830resultado.LM830OrigenConflicto[LM830nombreHijo] = LM830mensajeConflictoHorizontal;
                        return LM830resultado;
                    }
                }
                else
                {
                    var LM830subFamiliaHijo = LM830todosLosComponentes.FirstOrDefault(LM830f => LM830f.LM830Nombre == LM830nombreHijo);
                    if (LM830subFamiliaHijo != null)
                    {
                        var LM830permisosDelHijo = new HashSet<string>();
                        var LM830familiasDelHijo = new HashSet<string>();
                        LM830ObtenerEstructuraPlana(LM830subFamiliaHijo, LM830permisosDelHijo, LM830familiasDelHijo);

                        foreach (var LM830elemento in LM830subFamiliaHijo.LM830ListaHijos.OfType<LM830PermisoSimple>())
                        {
                            LM830permisosDelHijo.Add(LM830elemento.LM830Nombre);
                        }

                        if (LM830familiasActualesPadre.Contains(LM830nombreHijo))
                        {
                            LM830resultado.LM830Estado = LM830EstadoAsignacion.LM830ConflictoPermisos;
                            LM830resultado.LM830PermisosConflictivos.Add(LM830nombreHijo);
                            LM830resultado.LM830OrigenConflicto[LM830nombreHijo] = $"Redundancia estructural: La subfamilia '{LM830nombreHijo}' ya forma parte de '{LM830nombrePadre}'.";
                            return LM830resultado;
                        }

                        var LM830colisionesPermisos = LM830permisosActualesPadre.Intersect(LM830permisosDelHijo).ToList();
                        if (LM830colisionesPermisos.Any())
                        {
                            string LM830permisoEjemplo = LM830colisionesPermisos.First();
                            string LM830nodoResponsable = LM830BuscarContenedorDirectoDelPermiso(LM830componentePadre, LM830permisoEjemplo) ?? LM830componentePadre.LM830Nombre;

                            LM830resultado.LM830Estado = LM830EstadoAsignacion.LM830ConflictoPermisos;
                            LM830resultado.LM830PermisosConflictivos.Add(LM830nombreHijo);
                            LM830resultado.LM830OrigenConflicto[LM830nombreHijo] = $"CONFLICTO_REDUNDANCIA_HEREDADA|{string.Join(",", LM830colisionesPermisos)}|{LM830nombreHijo}|{LM830nodoResponsable}";
                            return LM830resultado;
                        }
                    }
                }
            }

            if (LM830resultado.LM830Estado == LM830EstadoAsignacion.LM830ConflictoPermisos) return LM830resultado;

            foreach (var LM830nombreHijo in LM830nombresHijos)
            {
                if (LM830esPermisoSimple)
                {
                    var LM830permisoHijo = new LM830PermisoSimple { LM830Nombre = LM830nombreHijo };
                    LM830componentePadre.LM830AgregarHijo(LM830permisoHijo);
                }
                else
                {
                    var LM830subFamilia = LM830todosLosComponentes.FirstOrDefault(LM830f => LM830f.LM830Nombre == LM830nombreHijo);
                    if (LM830subFamilia != null)
                    {
                        LM830componentePadre.LM830AgregarHijo(LM830subFamilia);
                    }
                }

                string LM830tipoNodo = LM830esPermisoSimple ? "Permiso Simple" : "Subfamilia";
                LM830RegistrarEnBitacora(LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username, $"Asignación exitosa de {LM830tipoNodo} '{LM830nombreHijo}' a la raíz '{LM830nombrePadre}'", 1);
            }

            LM830_dal.LM830GuardarRelaciones(LM830componentePadre);
            LM830RecargarPermisosUsuarioEnSesion();

            return LM830resultado;
        }

        public void LM830EliminarPermisoDeContenedorEspecifico(string LM830nombreContenedor, string LM830nombrePermiso)
        {
            try
            {
                var LM830todosLosComponentes = LM830_dal.LM830ObtenerFamiliasYPerfiles();
                var LM830contenedor = LM830todosLosComponentes.FirstOrDefault(LM830f => LM830f.LM830Nombre == LM830nombreContenedor);

                if (LM830contenedor != null)
                {
                    var LM830permisoAQuitar = LM830contenedor.LM830ListaHijos.FirstOrDefault(LM830h => LM830h.LM830Nombre == LM830nombrePermiso && LM830h is LM830PermisoSimple);
                    if (LM830permisoAQuitar != null)
                    {
                        LM830contenedor.LM830QuitarHijo(LM830permisoAQuitar);
                        LM830_dal.LM830GuardarRelaciones(LM830contenedor);
                        LM830RegistrarEnBitacora(LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username, $"Desvinculación forzada por redundancia: Permiso '{LM830nombrePermiso}' removido de '{LM830nombreContenedor}'", 2);
                    }
                }
                LM830RecargarPermisosUsuarioEnSesion();
            }
            catch (Exception LM830ex)
            {
                throw new Exception($"{LM830LanguageManager.LM830Instance.LM830GetTraduction("PerBLLText2")} {LM830ex.Message}", LM830ex);
            }
        }
        private string LM830VerificarConflictoHorizontal(List<LM830Familia> LM830todosLosComponentes, LM830Familia LM830nodoDestino, string LM830permisoBuscar)
        {
            var LM830ancestrosRaiz = LM830todosLosComponentes.Where(LM830posiblePadre => LM830ContieneHijoRecursivo(LM830posiblePadre, LM830nodoDestino.LM830Nombre)).ToList();

            foreach (var LM830ancestro in LM830ancestrosRaiz)
            {
                foreach (var LM830hijoFam in LM830ancestro.LM830ListaHijos.OfType<LM830Familia>())
                {
                    if (LM830hijoFam.LM830Nombre == LM830nodoDestino.LM830Nombre) continue;

                    if (LM830TienePermisoHeredado(LM830hijoFam, LM830permisoBuscar))
                    {
                        string LM830contenedorDirecto = LM830BuscarContenedorDirectoDelPermiso(LM830hijoFam, LM830permisoBuscar) ?? LM830hijoFam.LM830Nombre;

                        return $"CONFLICTO_HORIZONTAL_DETALLADO|{LM830permisoBuscar}|{LM830nodoDestino.LM830Nombre}|{LM830ancestro.LM830Nombre}|{LM830hijoFam.LM830Nombre}|{LM830contenedorDirecto}";
                    }
                }

                foreach (var LM830hijoPermiso in LM830ancestro.LM830ListaHijos.OfType<LM830PermisoSimple>())
                {
                    if (LM830hijoPermiso.LM830Nombre == LM830permisoBuscar)
                    {
                        return $"CONFLICTO_HORIZONTAL_DETALLADO|{LM830permisoBuscar}|{LM830nodoDestino.LM830Nombre}|{LM830ancestro.LM830Nombre}|{LM830ancestro.LM830Nombre}|{LM830ancestro.LM830Nombre}";
                    }
                }
            }
            return null;
        }

        private bool LM830ContieneHijoRecursivo(LM830Familia LM830padre, string LM830nombreHijoBuscar)
        {
            if (LM830padre.LM830ListaHijos.OfType<LM830Familia>().Any(LM830f => LM830f.LM830Nombre == LM830nombreHijoBuscar || LM830ContieneHijoRecursivo(LM830f, LM830nombreHijoBuscar)))
                return true;
            if (LM830padre.LM830ListaHijos.OfType<LM830PermisoSimple>().Any(LM830p => LM830p.LM830Nombre == LM830nombreHijoBuscar))
                return true;
            return false;
        }

        private bool LM830TienePermisoHeredado(LM830Familia LM830familia, string LM830permisoBuscar)
        {
            if (LM830familia.LM830Nombre == LM830permisoBuscar) return true;
            if (LM830familia.LM830ListaHijos.OfType<LM830PermisoSimple>().Any(LM830p => LM830p.LM830Nombre == LM830permisoBuscar))
                return true;

            foreach (var LM830subFam in LM830familia.LM830ListaHijos.OfType<LM830Familia>())
            {
                if (LM830TienePermisoHeredado(LM830subFam, LM830permisoBuscar)) return true;
            }
            return false;
        }

        private string LM830BuscarContenedorDirectoDelPermiso(LM830Familia LM830nodoActual, string LM830nombrePermiso)
        {
            if (LM830nodoActual.LM830ListaHijos.OfType<LM830PermisoSimple>().Any(LM830p => LM830p.LM830Nombre == LM830nombrePermiso))
                return LM830nodoActual.LM830Nombre;

            foreach (var LM830subFamilia in LM830nodoActual.LM830ListaHijos.OfType<LM830Familia>())
            {
                string LM830encontrado = LM830BuscarContenedorDirectoDelPermiso(LM830subFamilia, LM830nombrePermiso);
                if (!string.IsNullOrEmpty(LM830encontrado)) return LM830encontrado;
            }

            return null;
        }

        private bool LM830ValidarCicloJerarquico(string LM830actual, string LM830objetivo, List<LM830Familia> LM830componentes)
        {
            var LM830comp = LM830componentes.FirstOrDefault(LM830f => LM830f.LM830Nombre == LM830actual);
            if (LM830comp == null) return false;
            if (LM830comp.LM830ListaHijos.Any(LM830h => LM830h.LM830Nombre == LM830objetivo)) return true;

            foreach (var LM830sub in LM830comp.LM830ListaHijos.OfType<LM830Familia>())
            {
                if (LM830ValidarCicloJerarquico(LM830sub.LM830Nombre, LM830objetivo, LM830componentes)) return true;
            }
            return false;
        }

        private void LM830ObtenerEstructuraPlana(LM830Familia LM830componente, HashSet<string> LM830permisos, HashSet<string> LM830familias)
        {
            foreach (var LM830hijo in LM830componente.LM830ListaHijos)
            {
                if (LM830hijo is LM830PermisoSimple)
                {
                    LM830permisos.Add(LM830hijo.LM830Nombre);
                }
                else if (LM830hijo is LM830Familia LM830fam)
                {
                    LM830familias.Add(LM830fam.LM830Nombre);
                    LM830ObtenerEstructuraPlana(LM830fam, LM830permisos, LM830familias);
                }
            }
        }

        private void LM830RegistrarEnBitacora(string LM830usuario, string LM830evento, int LM830criticidad)
        {
            try
            {
                var LM830registro = new LM830Bitacora
                {
                    LM830Login = !string.IsNullOrEmpty(LM830usuario) ? LM830usuario : "Sistema",
                    LM830Fecha = DateTime.Now,
                    LM830Modulo = LM830MODULO_BITACORA,
                    LM830Evento = LM830evento,
                    LM830Criticidad = LM830criticidad
                };
                LM830_bitacoraBLL.LM830RegistrarEvento(LM830registro);
            }
            catch { }
        }

        public void LM830ArmarArbolEstructural(LM830Familia LM830nodoActual, TreeNodeCollection LM830nodosUI)
        {
            var LM830nuevoNodo = new TreeNode(LM830nodoActual.LM830Nombre)
            {
                Tag = LM830nodoActual,
                ImageIndex = LM830nodoActual.LM830EsRol ? 0 : 1
            };

            LM830nodosUI.Add(LM830nuevoNodo);

            foreach (var LM830hijo in LM830nodoActual.LM830ListaHijos)
            {
                if (LM830hijo is LM830Familia LM830subFamilia)
                {
                    LM830ArmarArbolEstructural(LM830subFamilia, LM830nuevoNodo.Nodes);
                }
                else if (LM830hijo is LM830PermisoSimple LM830permiso)
                {
                    var LM830nodoHoja = new TreeNode(LM830permiso.LM830Nombre)
                    {
                        Tag = LM830permiso,
                        ImageIndex = 2
                    };
                    LM830nuevoNodo.Nodes.Add(LM830nodoHoja);
                }
            }
        }
    }
}
