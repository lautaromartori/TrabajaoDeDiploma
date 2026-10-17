using BE.RFN1;
using BE.RFN2;
using DAL;
using DAL.RFN1;
using DAL.RFN2;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class DigitoVerificadorBLL
    {
        private readonly DigitoVerificadorDAL _controlDVDal = new DigitoVerificadorDAL();
        private readonly PerfilDAL _perfilDal = new PerfilDAL();
        private readonly UsuarioDAL _usuarioDal = new UsuarioDAL();
        private readonly BitacoraDAL _bitacoraDal = new BitacoraDAL();
        private readonly IdiomaDAL _idiomaDal = new IdiomaDAL();
        private readonly ClienteDAL _clienteDal = new ClienteDAL();
        private readonly VentaDAL _ventaDal = new VentaDAL();
        private readonly LoteDAL _loteDal = new LoteDAL();
        private readonly ReclamoDAL _reclamoDal = new ReclamoDAL();
        private readonly CanjeDAL _canjeDal = new CanjeDAL();

        private static readonly string[] TablasDelSistema =
        {
            "Perfil", "Usuario", "Bitacora", "Idioma", "PermisoSimple", "Familia",
            "Cliente", "Venta", "DetalleVenta", "Reclamo", "LotePuntos",
            "Canje", "DetalleCanje"
        };

        private readonly Dictionary<string, ITablaDV> _tablas;

        public DigitoVerificadorBLL()
        {
            _tablas = ArmarTablas().ToDictionary(t => t.Nombre, StringComparer.OrdinalIgnoreCase);
        }

        public static string CadenaDVH_Usuario(Usuario u) =>
            u.DNI + u.Nombre + u.Apellido + u.Username + u.Password + u.Email + u.Bloqueado + u.Activo + u.Rol + u.Intentos;

        public static string CadenaDVH_Bitacora(Bitacora b) =>
            b.Login + b.Fecha.ToString("yyyy-MM-dd HH:mm:ss") + b.Modulo + b.Evento + b.Criticidad;

        public static string CadenaDVH_Idioma(Idioma i) => i.UserName + i.CodigoIdioma;

        private IEnumerable<ITablaDV> ArmarTablas()
        {
            yield return new TablaDV<Familia>("Perfil", "Nombre", _controlDVDal,
                () => _perfilDal.ObtenerPerfiles(), x => x.Nombre, x => x.DVH, x => x.Nombre,
                (x, dvh) => _perfilDal.ActualizarPefilDVH(x.Nombre, dvh),
                Col<Familia>("Nombre", x => x.Nombre));

            yield return new TablaDV<Usuario>("Usuario", "DNI", _controlDVDal,
                () => _usuarioDal.ListarTodosLosUsuariosDVH(), x => x.DNI, x => x.DVH, CadenaDVH_Usuario,
                (x, dvh) => _usuarioDal.ActualizarDVH(x.DNI, dvh),
                Col<Usuario>("DNI", x => x.DNI),
                Col<Usuario>("Nombre", x => x.Nombre),
                Col<Usuario>("Apellido", x => x.Apellido),
                Col<Usuario>("UserName", x => x.Username),
                Col<Usuario>("Password", x => x.Password),
                Col<Usuario>("Email", x => x.Email),
                Col<Usuario>("Bloqueado", x => x.Bloqueado ? "1" : "0"),
                Col<Usuario>("Activo", x => x.Activo ? "1" : "0"),
                Col<Usuario>("Rol", x => x.Rol),
                Col<Usuario>("Intentos", x => x.Intentos.ToString()));

            yield return new TablaDV<Bitacora>("Bitacora", "Id_Evento", _controlDVDal,
                () => _bitacoraDal.listarTodosLosEventos(), x => x.Id_Evento.ToString("D10"), x => x.DVH, CadenaDVH_Bitacora,
                (x, dvh) => _bitacoraDal.ActualizarDVH(x.Id_Evento.ToString(), dvh),
                Col<Bitacora>("Login", x => x.Login),
                Col<Bitacora>("Fecha", x => x.Fecha.ToString("yyyy-MM-dd HH:mm:ss")),
                Col<Bitacora>("Modulo", x => x.Modulo),
                Col<Bitacora>("Evento", x => x.Evento),
                Col<Bitacora>("Criticidad", x => x.Criticidad.ToString()));

            yield return new TablaDV<Idioma>("Idioma", "UserName", _controlDVDal,
                () => _idiomaDal.listarTodosLosIdiomas(), x => x.UserName, x => x.DVH, CadenaDVH_Idioma,
                (x, dvh) => _idiomaDal.ActualizarDVH(x.UserName, dvh),
                Col<Idioma>("UserName", x => x.UserName),
                Col<Idioma>("CodigoIdioma", x => x.CodigoIdioma));

            yield return new TablaDV<PermisoSimple>("PermisoSimple", "Nombre", _controlDVDal,
                () => _perfilDal.ObtenerPermisos(), x => x.Nombre, x => x.DVH, x => x.Nombre,
                (x, dvh) => _perfilDal.ActualizarPermisoSimpleDVH(x.Nombre, dvh),
                Col<PermisoSimple>("Nombre", x => x.Nombre));

            yield return new TablaDV<Familia>("Familia", "Nombre", _controlDVDal,
                () => _perfilDal.ObtenerFamilias(), x => x.Nombre, x => x.DVH, x => x.Nombre,
                (x, dvh) => _perfilDal.ActualizarDVH(x.Nombre, dvh),
                Col<Familia>("Nombre", x => x.Nombre));

            yield return new TablaDV<Cliente>("Cliente", "idCliente", _controlDVDal,
                () => _clienteDal.ListarParaDV(), x => x.IdCliente.ToString("D10"), x => x.DVH, x => x.CadenaDVH(),
                (x, dvh) => _clienteDal.ActualizarDVH(x.IdCliente, dvh),
                Col<Cliente>("idCliente", x => FormatoDV.Entero(x.IdCliente)),
                Col<Cliente>("dni", x => x.Dni),
                Col<Cliente>("nombre", x => x.Nombre),
                Col<Cliente>("apellido", x => x.Apellido),
                Col<Cliente>("email", x => x.Email),
                Col<Cliente>("telefono", x => x.Telefono),
                Col<Cliente>("fechaInscripcion", x => FormatoDV.Fecha(x.FechaInscripcion)),
                Col<Cliente>("idNivel", x => FormatoDV.Entero(x.Nivel.IdNivel)));

            yield return new TablaDV<Venta>("Venta", "idVenta", _controlDVDal,
                () => _ventaDal.ListarParaDV(), x => x.IdVenta.ToString("D10"), x => x.DVH, x => x.CadenaDVH(),
                (x, dvh) => _ventaDal.ActualizarDVH(x.IdVenta, dvh),
                Col<Venta>("idVenta", x => FormatoDV.Entero(x.IdVenta)),
                Col<Venta>("nroComprobante", x => x.NroComprobante),
                Col<Venta>("fecha", x => FormatoDV.FechaHora(x.Fecha)),
                Col<Venta>("idCliente", x => FormatoDV.Entero(x.Cliente?.IdCliente)),
                Col<Venta>("dniVendedor", x => FormatoDV.Texto(x.Vendedor?.DNI)),
                Col<Venta>("total", x => FormatoDV.Importe(x.Total)),
                Col<Venta>("puntosAcreditados", x => FormatoDV.Entero(x.PuntosAcreditados)));

            yield return new TablaDV<DetalleVenta>("DetalleVenta", "idDetalle", _controlDVDal,
                () => _ventaDal.ListarDetalleParaDV(), x => x.IdDetalle.ToString("D10"), x => x.DVH, x => x.CadenaDVH(),
                (x, dvh) => _ventaDal.ActualizarDVHDetalle(x.IdDetalle, dvh),
                Col<DetalleVenta>("idDetalle", x => FormatoDV.Entero(x.IdDetalle)),
                Col<DetalleVenta>("idVenta", x => FormatoDV.Entero(x.IdVenta)),
                Col<DetalleVenta>("idProducto", x => FormatoDV.Entero(x.Producto.IdProducto)),
                Col<DetalleVenta>("cantidad", x => FormatoDV.Entero(x.Cantidad)),
                Col<DetalleVenta>("precioUnitario", x => FormatoDV.Importe(x.PrecioUnitario)),
                Col<DetalleVenta>("subtotal", x => FormatoDV.Importe(x.Subtotal)),
                Col<DetalleVenta>("puntosCalculados", x => FormatoDV.Entero(x.PuntosCalculados)));

            yield return new TablaDV<Reclamo>("Reclamo", "idReclamo", _controlDVDal,
                () => _reclamoDal.ListarParaDV(), x => x.IdReclamo.ToString("D10"), x => x.DVH, x => x.CadenaDVH(),
                (x, dvh) => _reclamoDal.ActualizarDVH(x.IdReclamo, dvh),
                Col<Reclamo>("idReclamo", x => FormatoDV.Entero(x.IdReclamo)),
                Col<Reclamo>("idCliente", x => FormatoDV.Entero(x.Cliente.IdCliente)),
                Col<Reclamo>("idVenta", x => FormatoDV.Entero(x.Venta.IdVenta)),
                Col<Reclamo>("fechaReclamo", x => FormatoDV.FechaHora(x.FechaReclamo)),
                Col<Reclamo>("puntosReclamados", x => FormatoDV.Entero(x.PuntosReclamados)),
                Col<Reclamo>("motivo", x => x.Motivo),
                Col<Reclamo>("estado", x => x.Estado.ToString()),
                Col<Reclamo>("dniVendedor", x => FormatoDV.Texto(x.Vendedor?.DNI)),
                Col<Reclamo>("dniSupervisor", x => FormatoDV.Texto(x.Supervisor?.DNI)),
                Col<Reclamo>("motivoResolucion", x => FormatoDV.Texto(x.MotivoResolucion)),
                Col<Reclamo>("fechaResolucion", x => FormatoDV.FechaHora(x.FechaResolucion)));

            yield return new TablaDV<LotePuntos>("LotePuntos", "idLote", _controlDVDal,
                () => _loteDal.ListarParaDV(), x => x.IdLote.ToString("D10"), x => x.DVH, x => x.CadenaDVH(),
                (x, dvh) => _loteDal.ActualizarDVH(x.IdLote, dvh),
                Col<LotePuntos>("idLote", x => FormatoDV.Entero(x.IdLote)),
                Col<LotePuntos>("idCliente", x => FormatoDV.Entero(x.IdCliente)),
                Col<LotePuntos>("idVenta", x => FormatoDV.Entero(x.IdVenta)),
                Col<LotePuntos>("idReclamo", x => FormatoDV.Entero(x.IdReclamo)),
                Col<LotePuntos>("puntosOriginales", x => FormatoDV.Entero(x.PuntosOriginales)),
                Col<LotePuntos>("puntosDisponibles", x => FormatoDV.Entero(x.PuntosDisponibles)),
                Col<LotePuntos>("fechaAcreditacion", x => FormatoDV.Fecha(x.FechaAcreditacion)),
                Col<LotePuntos>("fechaVencimiento", x => FormatoDV.Fecha(x.FechaVencimiento)),
                Col<LotePuntos>("origen", x => x.Origen.ToString()));

            yield return new TablaDV<Canje>("Canje", "idCanje", _controlDVDal,
                () => _canjeDal.ListarParaDV(), x => x.IdCanje.ToString("D10"), x => x.DVH, x => x.CadenaDVH(),
                (x, dvh) => _canjeDal.ActualizarDVH(x.IdCanje, dvh),
                Col<Canje>("idCanje", x => FormatoDV.Entero(x.IdCanje)),
                Col<Canje>("nroCanje", x => x.NroCanje),
                Col<Canje>("idCliente", x => FormatoDV.Entero(x.Cliente.IdCliente)),
                Col<Canje>("idPremio", x => FormatoDV.Entero(x.Premio.IdPremio)),
                Col<Canje>("puntosRequeridos", x => FormatoDV.Entero(x.PuntosRequeridos)),
                Col<Canje>("valorReferencia", x => FormatoDV.Importe(x.ValorReferencia)),
                Col<Canje>("fechaSolicitud", x => FormatoDV.FechaHora(x.FechaSolicitud)),
                Col<Canje>("estado", x => x.Estado.ToString()),
                Col<Canje>("dniVendedor", x => FormatoDV.Texto(x.Vendedor?.DNI)),
                Col<Canje>("dniSupervisor", x => FormatoDV.Texto(x.Supervisor?.DNI)),
                Col<Canje>("motivoResolucion", x => FormatoDV.Texto(x.MotivoResolucion)),
                Col<Canje>("fechaResolucion", x => FormatoDV.FechaHora(x.FechaResolucion)),
                Col<Canje>("fechaEntrega", x => FormatoDV.FechaHora(x.FechaEntrega)),
                Col<Canje>("dniAnulacion", x => FormatoDV.Texto(x.SupervisorAnulacion?.DNI)),
                Col<Canje>("motivoAnulacion", x => FormatoDV.Texto(x.MotivoAnulacion)),
                Col<Canje>("fechaAnulacion", x => FormatoDV.FechaHora(x.FechaAnulacion)));

            yield return new TablaDV<DetalleCanje>("DetalleCanje", "idDetalleCanje", _controlDVDal,
                () => _canjeDal.ListarDetalleParaDV(), x => x.IdDetalleCanje.ToString("D10"), x => x.DVH, x => x.CadenaDVH(),
                (x, dvh) => _canjeDal.ActualizarDVHDetalle(x.IdDetalleCanje, dvh),
                Col<DetalleCanje>("idDetalleCanje", x => FormatoDV.Entero(x.IdDetalleCanje)),
                Col<DetalleCanje>("idCanje", x => FormatoDV.Entero(x.IdCanje)),
                Col<DetalleCanje>("idLote", x => FormatoDV.Entero(x.Lote.IdLote)),
                Col<DetalleCanje>("puntosDescontados", x => FormatoDV.Entero(x.PuntosDescontados)));
        }

        private static KeyValuePair<string, Func<T, string>> Col<T>(string nombre, Func<T, string> valor)
            => new KeyValuePair<string, Func<T, string>>(nombre, valor);

        public void RecalcularDVH_Usuario(string dni)
        {
            Usuario? u = _usuarioDal.ListarTodosLosUsuariosDVH().FirstOrDefault(x => x.DNI == dni);
            if (u != null)
                _usuarioDal.ActualizarDVH(u.DNI, DigitoVerificador.CalcularDVH(CadenaDVH_Usuario(u)));
        }

        public void RecalcularDVH_Usuario() => _tablas["Usuario"].RecalcularDVH();
        public void RecalcularDVH_Bitacora() => _tablas["Bitacora"].RecalcularDVH();
        public void RecalcularDVH_Idioma() => _tablas["Idioma"].RecalcularDVH();
        public void RecalcularDVH_Perfil() => _tablas["Perfil"].RecalcularDVH();
        public void RecalcularDVH_PermisoSimple() => _tablas["PermisoSimple"].RecalcularDVH();
        public void RecalcularDVH_Familia() => _tablas["Familia"].RecalcularDVH();

        public void RecalcularDVV_Perfil() => RecalcularDVV("Perfil");
        public void RecalcularDVV_Usuario() => RecalcularDVV("Usuario");
        public void RecalcularDVV_Bitacora() => RecalcularDVV("Bitacora");
        public void RecalcularDVV_Idioma() => RecalcularDVV("Idioma");
        public void RecalcularDVV_PermisoSimple() => RecalcularDVV("PermisoSimple");
        public void RecalcularDVV_Familia() => RecalcularDVV("Familia");
        public void RecalcularDVV_Cliente() => RecalcularDVV("Cliente");
        public void RecalcularDVV_Venta() => RecalcularDVV("Venta");
        public void RecalcularDVV_DetalleVenta() => RecalcularDVV("DetalleVenta");
        public void RecalcularDVV_Reclamo() => RecalcularDVV("Reclamo");
        public void RecalcularDVV_LotePuntos() => RecalcularDVV("LotePuntos");
        public void RecalcularDVV_Canje() => RecalcularDVV("Canje");
        public void RecalcularDVV_DetalleCanje() => RecalcularDVV("DetalleCanje");

        private void RecalcularDVV(string tabla)
        {
            _tablas[tabla].RecalcularDVV();
            RecalcularDVVBaseDeDatos();
        }

        private void RecalcularDVVBaseDeDatos()
        {
            var totales = TablasDelSistema.Select(t => _controlDVDal.ObtenerDVV(t, "TOTAL_TABLA") ?? "0").ToList();
            _controlDVDal.ActualizarDVV("SISTEMA", "TOTAL_BASE_DATOS", DigitoVerificador.CalcularDVV(totales));
        }

        public void RecalcularDVV_General()
        {
            try
            {
                foreach (string tabla in TablasDelSistema.Where(t => t != "Bitacora"))
                {
                    _tablas[tabla].RecalcularDVH();
                    _tablas[tabla].RecalcularDVV();
                }

                RegistrarEvento("Recalculo de DVV y DVH realizado correctamente", 1);
                _tablas["Bitacora"].RecalcularDVH();
                _tablas["Bitacora"].RecalcularDVV();

                RecalcularDVVBaseDeDatos();
            }
            catch (Exception ex)
            {
                RegistrarEvento("Error al recalcular DVV y DVH", 3);
                throw new Exception(LanguageManager.Instance.GetTraduction("TextDV13") + ex.Message);
            }
        }

        public List<string> EjecutarAuditoriaDetalladaCompleta()
        {
            var reporte = new List<string>();
            foreach (string tabla in TablasDelSistema)
            {
                _tablas[tabla].Auditar(reporte);
            }
            return reporte;
        }

        private void RegistrarEvento(string descripcion, int criticidad)
        {
            try
            {
                string login = SessionManager.Instance.Logueado() ? SessionManager.Instance.UsuarioActual().Username : "Sistema";
                Bitacora evento = new Bitacora
                {
                    Login = login,
                    Modulo = "DigitoVerificador",
                    Fecha = BitacoraBLL.AhoraSinMilisegundos(),
                    Evento = descripcion,
                    Criticidad = criticidad
                };
                _bitacoraDal.RegistrarEvento(evento, DigitoVerificador.CalcularDVH(CadenaDVH_Bitacora(evento)));
            }
            catch { }
        }

        private interface ITablaDV
        {
            string Nombre { get; }
            void RecalcularDVH();
            void RecalcularDVV();
            void Auditar(List<string> reporte);
        }

        private class TablaDV<T> : ITablaDV where T : class
        {
            public string Nombre { get; }
            private readonly string _columnaPK;
            private readonly DigitoVerificadorDAL _dal;
            private readonly Func<List<T>> _listar;
            private readonly Func<T, string> _clave;
            private readonly Func<T, string> _dvhGuardado;
            private readonly Func<T, string> _cadenaDVH;
            private readonly Action<T, string> _actualizarDVH;
            private readonly KeyValuePair<string, Func<T, string>>[] _columnas;

            public TablaDV(string nombre, string columnaPK, DigitoVerificadorDAL dal, Func<List<T>> listar,
                           Func<T, string> clave, Func<T, string> dvhGuardado, Func<T, string> cadenaDVH,
                           Action<T, string> actualizarDVH, params KeyValuePair<string, Func<T, string>>[] columnas)
            {
                Nombre = nombre;
                _columnaPK = columnaPK;
                _dal = dal;
                _listar = listar;
                _clave = clave;
                _dvhGuardado = dvhGuardado;
                _cadenaDVH = cadenaDVH;
                _actualizarDVH = actualizarDVH;
                _columnas = columnas;
            }

            private List<T> Filas() => _listar().OrderBy(_clave, StringComparer.Ordinal).ToList();

            private string PK(T fila)
            {
                string k = _clave(fila);
                return _clave(fila).Length == 10 && k.All(char.IsDigit) ? int.Parse(k).ToString() : k;
            }

            private string DVHCalculado(T fila) => DigitoVerificador.CalcularDVH(_cadenaDVH(fila));

            private static string DVV(IEnumerable<T> filas, Func<T, string> valor) =>
                DigitoVerificador.CalcularDVV(filas.Select(f => valor(f) ?? "").ToList());

            public void RecalcularDVH()
            {
                foreach (T fila in _listar())
                {
                    string dvh = DVHCalculado(fila);
                    if (dvh != _dvhGuardado(fila)) _actualizarDVH(fila, dvh);
                }
            }

            public void RecalcularDVV()
            {
                List<T> filas = Filas();
                var hashes = new List<string>();
                foreach (var col in _columnas)
                {
                    string dvv = DVV(filas, col.Value);
                    _dal.ActualizarDVV(Nombre, col.Key, dvv);
                    hashes.Add(dvv);
                }
                _dal.ActualizarDVV(Nombre, "TOTAL_TABLA", DigitoVerificador.CalcularDVV(hashes));
            }

            public void Auditar(List<string> reporte)
            {
                List<T> filas = Filas();
                var guardados = _columnas.ToDictionary(c => c.Key, c => _dal.ObtenerDVV(Nombre, c.Key) ?? "");
                var colsErroneas = _columnas.Where(c => DVV(filas, c.Value) != guardados[c.Key]).ToList();
                var filasMal = filas.Where(f => DVHCalculado(f) != _dvhGuardado(f)).ToList();

                bool FilaInsertada(T fila) =>
                    colsErroneas.Count > 0 &&
                    colsErroneas.All(c => DVV(filas.Where(x => !ReferenceEquals(x, fila)), c.Value) == guardados[c.Key]);

                foreach (T fila in filasMal)
                {
                    if (FilaInsertada(fila))
                    {
                        reporte.Add($"[ERROR INSERCIÓN NO AUTORIZADA] Tabla: '{Nombre}' -> Se insertó un NUEVO registro (PK {_columnaPK}: '{PK(fila)}') con DVH inválido.");
                    }
                    else if (colsErroneas.Count > 0)
                    {
                        string columnas = string.Join(", ", colsErroneas.Select(c => c.Key));
                        reporte.Add($"[ERROR MODIFICACIÓN] Tabla: '{Nombre}' -> Registro {_columnaPK}: '{PK(fila)}' tiene datos alterados en la Columna: '{columnas}'.");
                    }
                    else
                    {
                        reporte.Add($"[ERROR MODIFICACIÓN] Tabla: '{Nombre}' -> Registro {_columnaPK}: '{PK(fila)}' tiene el DVH alterado.");
                    }
                }

                if (filasMal.Count == 0 && colsErroneas.Count > 0)
                {
                    string columnas = string.Join(", ", colsErroneas.Select(c => c.Key));
                    T? insertada = filas.FirstOrDefault(FilaInsertada);
                    if (insertada != null)
                    {
                        reporte.Add($"[ERROR INSERCIÓN NO AUTORIZADA] Tabla: '{Nombre}' -> Se detectó un NUEVO registro no autorizado (PK {_columnaPK}: '{PK(insertada)}') en columnas: {columnas}.");
                    }
                    else
                    {
                        reporte.Add($"[ERROR ELIMINACIÓN] Tabla: '{Nombre}' -> Se ha detectado la ELIMINACIÓN o alteración de uno o más registros (Inconsistencia de DVV en columnas: {columnas}).");
                    }
                }
            }
        }
    }
}
