using LM830BE.LM830RFN1;
using LM830BE.LM830RFN2;
using LM830DAL;
using LM830DAL.LM830RFN1;
using LM830DAL.LM830RFN2;
using LM830Servicios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LM830BLL
{
    public class LM830DigitoVerificadorBLL
    {
        private readonly LM830DigitoVerificadorDAL LM830_controlDVDal = new LM830DigitoVerificadorDAL();
        private readonly LM830PerfilDAL LM830_perfilDal = new LM830PerfilDAL();
        private readonly LM830UsuarioDAL LM830_usuarioDal = new LM830UsuarioDAL();
        private readonly LM830BitacoraDAL LM830_bitacoraDal = new LM830BitacoraDAL();
        private readonly LM830IdiomaDAL LM830_idiomaDal = new LM830IdiomaDAL();
        private readonly LM830ClienteDAL LM830_clienteDal = new LM830ClienteDAL();
        private readonly LM830VentaDAL LM830_ventaDal = new LM830VentaDAL();
        private readonly LM830LoteDAL LM830_loteDal = new LM830LoteDAL();
        private readonly LM830ReclamoDAL LM830_reclamoDal = new LM830ReclamoDAL();
        private readonly LM830CanjeDAL LM830_canjeDal = new LM830CanjeDAL();

        private static readonly string[] LM830TablasDelSistema =
        {
            "Perfil", "Usuario", "Bitacora", "Idioma", "PermisoSimple", "Familia",
            "Cliente", "Venta", "DetalleVenta", "Reclamo", "LotePuntos",
            "Canje", "DetalleCanje"
        };

        private readonly Dictionary<string, LM830ITablaDV> LM830_tablas;

        public LM830DigitoVerificadorBLL()
        {
            LM830_tablas = LM830ArmarTablas().ToDictionary(LM830t => LM830t.LM830Nombre, StringComparer.OrdinalIgnoreCase);
        }

        public static string LM830CadenaDVH_Usuario(LM830Usuario LM830u) =>
            LM830u.LM830DNI + LM830u.LM830Nombre + LM830u.LM830Apellido + LM830u.LM830Username + LM830u.LM830Password + LM830u.LM830Email + LM830u.LM830Bloqueado + LM830u.LM830Activo + LM830u.LM830Rol + LM830u.LM830Intentos;

        public static string LM830CadenaDVH_Bitacora(LM830Bitacora LM830b) =>
            LM830b.LM830Login + LM830b.LM830Fecha.ToString("yyyy-MM-dd HH:mm:ss") + LM830b.LM830Modulo + LM830b.LM830Evento + LM830b.LM830Criticidad;

        public static string LM830CadenaDVH_Idioma(LM830Idioma LM830i) => LM830i.LM830UserName + LM830i.LM830CodigoIdioma;

        private IEnumerable<LM830ITablaDV> LM830ArmarTablas()
        {
            yield return new LM830TablaDV<LM830Familia>("Perfil", "Nombre", LM830_controlDVDal,
                () => LM830_perfilDal.LM830ObtenerPerfiles(), LM830x => LM830x.LM830Nombre, LM830x => LM830x.LM830DVH, LM830x => LM830x.LM830Nombre,
                (LM830x, LM830dvh) => LM830_perfilDal.LM830ActualizarPefilDVH(LM830x.LM830Nombre, LM830dvh),
                LM830Col<LM830Familia>("Nombre", LM830x => LM830x.LM830Nombre));

            yield return new LM830TablaDV<LM830Usuario>("Usuario", "DNI", LM830_controlDVDal,
                () => LM830_usuarioDal.LM830ListarTodosLosUsuariosDVH(), LM830x => LM830x.LM830DNI, LM830x => LM830x.LM830DVH, LM830CadenaDVH_Usuario,
                (LM830x, LM830dvh) => LM830_usuarioDal.LM830ActualizarDVH(LM830x.LM830DNI, LM830dvh),
                LM830Col<LM830Usuario>("DNI", LM830x => LM830x.LM830DNI),
                LM830Col<LM830Usuario>("Nombre", LM830x => LM830x.LM830Nombre),
                LM830Col<LM830Usuario>("Apellido", LM830x => LM830x.LM830Apellido),
                LM830Col<LM830Usuario>("UserName", LM830x => LM830x.LM830Username),
                LM830Col<LM830Usuario>("Password", LM830x => LM830x.LM830Password),
                LM830Col<LM830Usuario>("Email", LM830x => LM830x.LM830Email),
                LM830Col<LM830Usuario>("Bloqueado", LM830x => LM830x.LM830Bloqueado ? "1" : "0"),
                LM830Col<LM830Usuario>("Activo", LM830x => LM830x.LM830Activo ? "1" : "0"),
                LM830Col<LM830Usuario>("Rol", LM830x => LM830x.LM830Rol),
                LM830Col<LM830Usuario>("Intentos", LM830x => LM830x.LM830Intentos.ToString()));

            yield return new LM830TablaDV<LM830Bitacora>("Bitacora", "Id_Evento", LM830_controlDVDal,
                () => LM830_bitacoraDal.LM830listarTodosLosEventos(), LM830x => LM830x.LM830Id_Evento.ToString("D10"), LM830x => LM830x.LM830DVH, LM830CadenaDVH_Bitacora,
                (LM830x, LM830dvh) => LM830_bitacoraDal.LM830ActualizarDVH(LM830x.LM830Id_Evento.ToString(), LM830dvh),
                LM830Col<LM830Bitacora>("Login", LM830x => LM830x.LM830Login),
                LM830Col<LM830Bitacora>("Fecha", LM830x => LM830x.LM830Fecha.ToString("yyyy-MM-dd HH:mm:ss")),
                LM830Col<LM830Bitacora>("Modulo", LM830x => LM830x.LM830Modulo),
                LM830Col<LM830Bitacora>("Evento", LM830x => LM830x.LM830Evento),
                LM830Col<LM830Bitacora>("Criticidad", LM830x => LM830x.LM830Criticidad.ToString()));

            yield return new LM830TablaDV<LM830Idioma>("Idioma", "UserName", LM830_controlDVDal,
                () => LM830_idiomaDal.LM830listarTodosLosIdiomas(), LM830x => LM830x.LM830UserName, LM830x => LM830x.LM830DVH, LM830CadenaDVH_Idioma,
                (LM830x, LM830dvh) => LM830_idiomaDal.LM830ActualizarDVH(LM830x.LM830UserName, LM830dvh),
                LM830Col<LM830Idioma>("UserName", LM830x => LM830x.LM830UserName),
                LM830Col<LM830Idioma>("CodigoIdioma", LM830x => LM830x.LM830CodigoIdioma));

            yield return new LM830TablaDV<LM830PermisoSimple>("PermisoSimple", "Nombre", LM830_controlDVDal,
                () => LM830_perfilDal.LM830ObtenerPermisos(), LM830x => LM830x.LM830Nombre, LM830x => LM830x.LM830DVH, LM830x => LM830x.LM830Nombre,
                (LM830x, LM830dvh) => LM830_perfilDal.LM830ActualizarPermisoSimpleDVH(LM830x.LM830Nombre, LM830dvh),
                LM830Col<LM830PermisoSimple>("Nombre", LM830x => LM830x.LM830Nombre));

            yield return new LM830TablaDV<LM830Familia>("Familia", "Nombre", LM830_controlDVDal,
                () => LM830_perfilDal.LM830ObtenerFamilias(), LM830x => LM830x.LM830Nombre, LM830x => LM830x.LM830DVH, LM830x => LM830x.LM830Nombre,
                (LM830x, LM830dvh) => LM830_perfilDal.LM830ActualizarDVH(LM830x.LM830Nombre, LM830dvh),
                LM830Col<LM830Familia>("Nombre", LM830x => LM830x.LM830Nombre));

            yield return new LM830TablaDV<LM830Cliente>("Cliente", "idCliente", LM830_controlDVDal,
                () => LM830_clienteDal.LM830ListarParaDV(), LM830x => LM830x.LM830IdCliente.ToString("D10"), LM830x => LM830x.LM830DVH, LM830x => LM830x.LM830CadenaDVH(),
                (LM830x, LM830dvh) => LM830_clienteDal.LM830ActualizarDVH(LM830x.LM830IdCliente, LM830dvh),
                LM830Col<LM830Cliente>("idCliente", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830IdCliente)),
                LM830Col<LM830Cliente>("dni", LM830x => LM830x.LM830Dni),
                LM830Col<LM830Cliente>("nombre", LM830x => LM830x.LM830Nombre),
                LM830Col<LM830Cliente>("apellido", LM830x => LM830x.LM830Apellido),
                LM830Col<LM830Cliente>("email", LM830x => LM830x.LM830Email),
                LM830Col<LM830Cliente>("telefono", LM830x => LM830x.LM830Telefono),
                LM830Col<LM830Cliente>("fechaInscripcion", LM830x => LM830FormatoDV.LM830Fecha(LM830x.LM830FechaInscripcion)),
                LM830Col<LM830Cliente>("idNivel", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830Nivel.LM830IdNivel)));

            yield return new LM830TablaDV<LM830Venta>("Venta", "idVenta", LM830_controlDVDal,
                () => LM830_ventaDal.LM830ListarParaDV(), LM830x => LM830x.LM830IdVenta.ToString("D10"), LM830x => LM830x.LM830DVH, LM830x => LM830x.LM830CadenaDVH(),
                (LM830x, LM830dvh) => LM830_ventaDal.LM830ActualizarDVH(LM830x.LM830IdVenta, LM830dvh),
                LM830Col<LM830Venta>("idVenta", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830IdVenta)),
                LM830Col<LM830Venta>("nroComprobante", LM830x => LM830x.LM830NroComprobante),
                LM830Col<LM830Venta>("fecha", LM830x => LM830FormatoDV.LM830FechaHora(LM830x.LM830Fecha)),
                LM830Col<LM830Venta>("idCliente", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830Cliente?.LM830IdCliente)),
                LM830Col<LM830Venta>("dniVendedor", LM830x => LM830FormatoDV.LM830Texto(LM830x.LM830Vendedor?.LM830DNI)),
                LM830Col<LM830Venta>("total", LM830x => LM830FormatoDV.LM830Importe(LM830x.LM830Total)),
                LM830Col<LM830Venta>("puntosAcreditados", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830PuntosAcreditados)));

            yield return new LM830TablaDV<LM830DetalleVenta>("DetalleVenta", "idDetalle", LM830_controlDVDal,
                () => LM830_ventaDal.LM830ListarDetalleParaDV(), LM830x => LM830x.LM830IdDetalle.ToString("D10"), LM830x => LM830x.LM830DVH, LM830x => LM830x.LM830CadenaDVH(),
                (LM830x, LM830dvh) => LM830_ventaDal.LM830ActualizarDVHDetalle(LM830x.LM830IdDetalle, LM830dvh),
                LM830Col<LM830DetalleVenta>("idDetalle", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830IdDetalle)),
                LM830Col<LM830DetalleVenta>("idVenta", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830IdVenta)),
                LM830Col<LM830DetalleVenta>("idProducto", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830Producto.LM830IdProducto)),
                LM830Col<LM830DetalleVenta>("cantidad", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830Cantidad)),
                LM830Col<LM830DetalleVenta>("precioUnitario", LM830x => LM830FormatoDV.LM830Importe(LM830x.LM830PrecioUnitario)),
                LM830Col<LM830DetalleVenta>("subtotal", LM830x => LM830FormatoDV.LM830Importe(LM830x.LM830Subtotal)),
                LM830Col<LM830DetalleVenta>("puntosCalculados", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830PuntosCalculados)));

            yield return new LM830TablaDV<LM830Reclamo>("Reclamo", "idReclamo", LM830_controlDVDal,
                () => LM830_reclamoDal.LM830ListarParaDV(), LM830x => LM830x.LM830IdReclamo.ToString("D10"), LM830x => LM830x.LM830DVH, LM830x => LM830x.LM830CadenaDVH(),
                (LM830x, LM830dvh) => LM830_reclamoDal.LM830ActualizarDVH(LM830x.LM830IdReclamo, LM830dvh),
                LM830Col<LM830Reclamo>("idReclamo", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830IdReclamo)),
                LM830Col<LM830Reclamo>("idCliente", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830Cliente.LM830IdCliente)),
                LM830Col<LM830Reclamo>("idVenta", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830Venta.LM830IdVenta)),
                LM830Col<LM830Reclamo>("fechaReclamo", LM830x => LM830FormatoDV.LM830FechaHora(LM830x.LM830FechaReclamo)),
                LM830Col<LM830Reclamo>("puntosReclamados", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830PuntosReclamados)),
                LM830Col<LM830Reclamo>("motivo", LM830x => LM830x.LM830Motivo),
                LM830Col<LM830Reclamo>("estado", LM830x => LM830x.LM830Estado.LM830ATexto()),
                LM830Col<LM830Reclamo>("dniVendedor", LM830x => LM830FormatoDV.LM830Texto(LM830x.LM830Vendedor?.LM830DNI)),
                LM830Col<LM830Reclamo>("dniSupervisor", LM830x => LM830FormatoDV.LM830Texto(LM830x.LM830Supervisor?.LM830DNI)),
                LM830Col<LM830Reclamo>("motivoResolucion", LM830x => LM830FormatoDV.LM830Texto(LM830x.LM830MotivoResolucion)),
                LM830Col<LM830Reclamo>("fechaResolucion", LM830x => LM830FormatoDV.LM830FechaHora(LM830x.LM830FechaResolucion)));

            yield return new LM830TablaDV<LM830LotePuntos>("LotePuntos", "idLote", LM830_controlDVDal,
                () => LM830_loteDal.LM830ListarParaDV(), LM830x => LM830x.LM830IdLote.ToString("D10"), LM830x => LM830x.LM830DVH, LM830x => LM830x.LM830CadenaDVH(),
                (LM830x, LM830dvh) => LM830_loteDal.LM830ActualizarDVH(LM830x.LM830IdLote, LM830dvh),
                LM830Col<LM830LotePuntos>("idLote", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830IdLote)),
                LM830Col<LM830LotePuntos>("idCliente", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830IdCliente)),
                LM830Col<LM830LotePuntos>("idVenta", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830IdVenta)),
                LM830Col<LM830LotePuntos>("idReclamo", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830IdReclamo)),
                LM830Col<LM830LotePuntos>("puntosOriginales", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830PuntosOriginales)),
                LM830Col<LM830LotePuntos>("puntosDisponibles", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830PuntosDisponibles)),
                LM830Col<LM830LotePuntos>("fechaAcreditacion", LM830x => LM830FormatoDV.LM830Fecha(LM830x.LM830FechaAcreditacion)),
                LM830Col<LM830LotePuntos>("fechaVencimiento", LM830x => LM830FormatoDV.LM830Fecha(LM830x.LM830FechaVencimiento)),
                LM830Col<LM830LotePuntos>("origen", LM830x => LM830x.LM830Origen.LM830ATexto()));

            yield return new LM830TablaDV<LM830Canje>("Canje", "idCanje", LM830_controlDVDal,
                () => LM830_canjeDal.LM830ListarParaDV(), LM830x => LM830x.LM830IdCanje.ToString("D10"), LM830x => LM830x.LM830DVH, LM830x => LM830x.LM830CadenaDVH(),
                (LM830x, LM830dvh) => LM830_canjeDal.LM830ActualizarDVH(LM830x.LM830IdCanje, LM830dvh),
                LM830Col<LM830Canje>("idCanje", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830IdCanje)),
                LM830Col<LM830Canje>("nroCanje", LM830x => LM830x.LM830NroCanje),
                LM830Col<LM830Canje>("idCliente", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830Cliente.LM830IdCliente)),
                LM830Col<LM830Canje>("idPremio", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830Premio.LM830IdPremio)),
                LM830Col<LM830Canje>("puntosRequeridos", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830PuntosRequeridos)),
                LM830Col<LM830Canje>("valorReferencia", LM830x => LM830FormatoDV.LM830Importe(LM830x.LM830ValorReferencia)),
                LM830Col<LM830Canje>("fechaSolicitud", LM830x => LM830FormatoDV.LM830FechaHora(LM830x.LM830FechaSolicitud)),
                LM830Col<LM830Canje>("estado", LM830x => LM830x.LM830Estado.LM830ATexto()),
                LM830Col<LM830Canje>("dniVendedor", LM830x => LM830FormatoDV.LM830Texto(LM830x.LM830Vendedor?.LM830DNI)),
                LM830Col<LM830Canje>("dniSupervisor", LM830x => LM830FormatoDV.LM830Texto(LM830x.LM830Supervisor?.LM830DNI)),
                LM830Col<LM830Canje>("motivoResolucion", LM830x => LM830FormatoDV.LM830Texto(LM830x.LM830MotivoResolucion)),
                LM830Col<LM830Canje>("fechaResolucion", LM830x => LM830FormatoDV.LM830FechaHora(LM830x.LM830FechaResolucion)),
                LM830Col<LM830Canje>("fechaEntrega", LM830x => LM830FormatoDV.LM830FechaHora(LM830x.LM830FechaEntrega)),
                LM830Col<LM830Canje>("dniAnulacion", LM830x => LM830FormatoDV.LM830Texto(LM830x.LM830SupervisorAnulacion?.LM830DNI)),
                LM830Col<LM830Canje>("motivoAnulacion", LM830x => LM830FormatoDV.LM830Texto(LM830x.LM830MotivoAnulacion)),
                LM830Col<LM830Canje>("fechaAnulacion", LM830x => LM830FormatoDV.LM830FechaHora(LM830x.LM830FechaAnulacion)));

            yield return new LM830TablaDV<LM830DetalleCanje>("DetalleCanje", "idDetalleCanje", LM830_controlDVDal,
                () => LM830_canjeDal.LM830ListarDetalleParaDV(), LM830x => LM830x.LM830IdDetalleCanje.ToString("D10"), LM830x => LM830x.LM830DVH, LM830x => LM830x.LM830CadenaDVH(),
                (LM830x, LM830dvh) => LM830_canjeDal.LM830ActualizarDVHDetalle(LM830x.LM830IdDetalleCanje, LM830dvh),
                LM830Col<LM830DetalleCanje>("idDetalleCanje", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830IdDetalleCanje)),
                LM830Col<LM830DetalleCanje>("idCanje", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830IdCanje)),
                LM830Col<LM830DetalleCanje>("idLote", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830Lote.LM830IdLote)),
                LM830Col<LM830DetalleCanje>("puntosDescontados", LM830x => LM830FormatoDV.LM830Entero(LM830x.LM830PuntosDescontados)));
        }

        private static KeyValuePair<string, Func<LM830T, string>> LM830Col<LM830T>(string LM830nombre, Func<LM830T, string> LM830valor)
            => new KeyValuePair<string, Func<LM830T, string>>(LM830nombre, LM830valor);

        public void LM830RecalcularDVH_Usuario(string LM830dni)
        {
            LM830Usuario? LM830u = LM830_usuarioDal.LM830ListarTodosLosUsuariosDVH().FirstOrDefault(LM830x => LM830x.LM830DNI == LM830dni);
            if (LM830u != null)
                LM830_usuarioDal.LM830ActualizarDVH(LM830u.LM830DNI, LM830DigitoVerificador.LM830CalcularDVH(LM830CadenaDVH_Usuario(LM830u)));
        }

        public void LM830RecalcularDVH_Usuario() => LM830_tablas["Usuario"].LM830RecalcularDVH();
        public void LM830RecalcularDVH_Bitacora() => LM830_tablas["Bitacora"].LM830RecalcularDVH();
        public void LM830RecalcularDVH_Idioma() => LM830_tablas["Idioma"].LM830RecalcularDVH();
        public void LM830RecalcularDVH_Perfil() => LM830_tablas["Perfil"].LM830RecalcularDVH();
        public void LM830RecalcularDVH_PermisoSimple() => LM830_tablas["PermisoSimple"].LM830RecalcularDVH();
        public void LM830RecalcularDVH_Familia() => LM830_tablas["Familia"].LM830RecalcularDVH();

        public void LM830RecalcularDVV_Perfil() => LM830RecalcularDVV("Perfil");
        public void LM830RecalcularDVV_Usuario() => LM830RecalcularDVV("Usuario");
        public void LM830RecalcularDVV_Bitacora() => LM830RecalcularDVV("Bitacora");
        public void LM830RecalcularDVV_Idioma() => LM830RecalcularDVV("Idioma");
        public void LM830RecalcularDVV_PermisoSimple() => LM830RecalcularDVV("PermisoSimple");
        public void LM830RecalcularDVV_Familia() => LM830RecalcularDVV("Familia");
        public void LM830RecalcularDVV_Cliente() => LM830RecalcularDVV("Cliente");
        public void LM830RecalcularDVV_Venta() => LM830RecalcularDVV("Venta");
        public void LM830RecalcularDVV_DetalleVenta() => LM830RecalcularDVV("DetalleVenta");
        public void LM830RecalcularDVV_Reclamo() => LM830RecalcularDVV("Reclamo");
        public void LM830RecalcularDVV_LotePuntos() => LM830RecalcularDVV("LotePuntos");
        public void LM830RecalcularDVV_Canje() => LM830RecalcularDVV("Canje");
        public void LM830RecalcularDVV_DetalleCanje() => LM830RecalcularDVV("DetalleCanje");

        private void LM830RecalcularDVV(string LM830tabla)
        {
            LM830_tablas[LM830tabla].LM830RecalcularDVV();
            LM830RecalcularDVVBaseDeDatos();
        }

        private void LM830RecalcularDVVBaseDeDatos()
        {
            var LM830totales = LM830TablasDelSistema.Select(LM830t => LM830_controlDVDal.LM830ObtenerDVV(LM830t, "TOTAL_TABLA") ?? "0").ToList();
            LM830_controlDVDal.LM830ActualizarDVV("SISTEMA", "TOTAL_BASE_DATOS", LM830DigitoVerificador.LM830CalcularDVV(LM830totales));
        }

        public void LM830RecalcularDVV_General()
        {
            try
            {
                foreach (string LM830tabla in LM830TablasDelSistema.Where(LM830t => LM830t != "Bitacora"))
                {
                    LM830_tablas[LM830tabla].LM830RecalcularDVH();
                    LM830_tablas[LM830tabla].LM830RecalcularDVV();
                }

                LM830RegistrarEvento("Recalculo de DVV y DVH realizado correctamente", 1);
                LM830_tablas["Bitacora"].LM830RecalcularDVH();
                LM830_tablas["Bitacora"].LM830RecalcularDVV();

                LM830RecalcularDVVBaseDeDatos();
            }
            catch (Exception LM830ex)
            {
                LM830RegistrarEvento("Error al recalcular DVV y DVH", 3);
                throw new Exception(LM830LanguageManager.LM830Instance.LM830GetTraduction("TextDV13") + LM830ex.Message);
            }
        }

        public List<string> LM830EjecutarAuditoriaDetalladaCompleta()
        {
            var LM830reporte = new List<string>();
            foreach (string LM830tabla in LM830TablasDelSistema)
            {
                LM830_tablas[LM830tabla].LM830Auditar(LM830reporte);
            }
            return LM830reporte;
        }

        private void LM830RegistrarEvento(string LM830descripcion, int LM830criticidad)
        {
            try
            {
                string LM830login = LM830SessionManager.LM830Instance.LM830Logueado() ? LM830SessionManager.LM830Instance.LM830UsuarioActual().LM830Username : "Sistema";
                LM830Bitacora LM830evento = new LM830Bitacora
                {
                    LM830Login = LM830login,
                    LM830Modulo = "DigitoVerificador",
                    LM830Fecha = LM830BitacoraBLL.LM830AhoraSinMilisegundos(),
                    LM830Evento = LM830descripcion,
                    LM830Criticidad = LM830criticidad
                };
                LM830_bitacoraDal.LM830RegistrarEvento(LM830evento, LM830DigitoVerificador.LM830CalcularDVH(LM830CadenaDVH_Bitacora(LM830evento)));
            }
            catch { }
        }

        private interface LM830ITablaDV
        {
            string LM830Nombre { get; }
            void LM830RecalcularDVH();
            void LM830RecalcularDVV();
            void LM830Auditar(List<string> LM830reporte);
        }

        private class LM830TablaDV<LM830T> : LM830ITablaDV where LM830T : class
        {
            public string LM830Nombre { get; }
            private readonly string LM830_columnaPK;
            private readonly LM830DigitoVerificadorDAL LM830_dal;
            private readonly Func<List<LM830T>> LM830_listar;
            private readonly Func<LM830T, string> LM830_clave;
            private readonly Func<LM830T, string> LM830_dvhGuardado;
            private readonly Func<LM830T, string> LM830_cadenaDVH;
            private readonly Action<LM830T, string> LM830_actualizarDVH;
            private readonly KeyValuePair<string, Func<LM830T, string>>[] LM830_columnas;

            public LM830TablaDV(string LM830nombre, string LM830columnaPK, LM830DigitoVerificadorDAL LM830dal, Func<List<LM830T>> LM830listar,
                           Func<LM830T, string> LM830clave, Func<LM830T, string> LM830dvhGuardado, Func<LM830T, string> LM830cadenaDVH,
                           Action<LM830T, string> LM830actualizarDVH, params KeyValuePair<string, Func<LM830T, string>>[] LM830columnas)
            {
                LM830Nombre = LM830nombre;
                LM830_columnaPK = LM830columnaPK;
                LM830_dal = LM830dal;
                LM830_listar = LM830listar;
                LM830_clave = LM830clave;
                LM830_dvhGuardado = LM830dvhGuardado;
                LM830_cadenaDVH = LM830cadenaDVH;
                LM830_actualizarDVH = LM830actualizarDVH;
                LM830_columnas = LM830columnas;
            }

            private List<LM830T> LM830Filas() => LM830_listar().OrderBy(LM830_clave, StringComparer.Ordinal).ToList();

            private string LM830PK(LM830T LM830fila)
            {
                string LM830k = LM830_clave(LM830fila);
                return LM830_clave(LM830fila).Length == 10 && LM830k.All(char.IsDigit) ? int.Parse(LM830k).ToString() : LM830k;
            }

            private string LM830DVHCalculado(LM830T LM830fila) => LM830DigitoVerificador.LM830CalcularDVH(LM830_cadenaDVH(LM830fila));

            private static string LM830DVV(IEnumerable<LM830T> LM830filas, Func<LM830T, string> LM830valor) =>
                LM830DigitoVerificador.LM830CalcularDVV(LM830filas.Select(LM830f => LM830valor(LM830f) ?? "").ToList());

            public void LM830RecalcularDVH()
            {
                foreach (LM830T LM830fila in LM830_listar())
                {
                    string LM830dvh = LM830DVHCalculado(LM830fila);
                    if (LM830dvh != LM830_dvhGuardado(LM830fila)) LM830_actualizarDVH(LM830fila, LM830dvh);
                }
            }

            public void LM830RecalcularDVV()
            {
                List<LM830T> LM830filas = LM830Filas();
                var LM830hashes = new List<string>();
                foreach (var LM830col in LM830_columnas)
                {
                    string LM830dvv = LM830DVV(LM830filas, LM830col.Value);
                    LM830_dal.LM830ActualizarDVV(LM830Nombre, LM830col.Key, LM830dvv);
                    LM830hashes.Add(LM830dvv);
                }
                LM830_dal.LM830ActualizarDVV(LM830Nombre, "TOTAL_TABLA", LM830DigitoVerificador.LM830CalcularDVV(LM830hashes));
            }

            public void LM830Auditar(List<string> LM830reporte)
            {
                List<LM830T> LM830filas = LM830Filas();
                var LM830guardados = LM830_columnas.ToDictionary(LM830c => LM830c.Key, LM830c => LM830_dal.LM830ObtenerDVV(LM830Nombre, LM830c.Key) ?? "");
                var LM830colsErroneas = LM830_columnas.Where(LM830c => LM830DVV(LM830filas, LM830c.Value) != LM830guardados[LM830c.Key]).ToList();
                var LM830filasMal = LM830filas.Where(LM830f => LM830DVHCalculado(LM830f) != LM830_dvhGuardado(LM830f)).ToList();

                bool LM830FilaInsertada(LM830T LM830fila) =>
                    LM830colsErroneas.Count > 0 &&
                    LM830colsErroneas.All(LM830c => LM830DVV(LM830filas.Where(LM830x => !ReferenceEquals(LM830x, LM830fila)), LM830c.Value) == LM830guardados[LM830c.Key]);

                foreach (LM830T LM830fila in LM830filasMal)
                {
                    if (LM830FilaInsertada(LM830fila))
                    {
                        LM830reporte.Add($"[ERROR INSERCIÓN NO AUTORIZADA] Tabla: '{LM830Nombre}' -> Se insertó un NUEVO registro (PK {LM830_columnaPK}: '{LM830PK(LM830fila)}') con DVH inválido.");
                    }
                    else if (LM830colsErroneas.Count > 0)
                    {
                        string LM830columnas = string.Join(", ", LM830colsErroneas.Select(LM830c => LM830c.Key));
                        LM830reporte.Add($"[ERROR MODIFICACIÓN] Tabla: '{LM830Nombre}' -> Registro {LM830_columnaPK}: '{LM830PK(LM830fila)}' tiene datos alterados en la Columna: '{LM830columnas}'.");
                    }
                    else
                    {
                        LM830reporte.Add($"[ERROR MODIFICACIÓN] Tabla: '{LM830Nombre}' -> Registro {LM830_columnaPK}: '{LM830PK(LM830fila)}' tiene el DVH alterado.");
                    }
                }

                if (LM830filasMal.Count == 0 && LM830colsErroneas.Count > 0)
                {
                    string LM830columnas = string.Join(", ", LM830colsErroneas.Select(LM830c => LM830c.Key));
                    LM830T? LM830insertada = LM830filas.FirstOrDefault(LM830FilaInsertada);
                    if (LM830insertada != null)
                    {
                        LM830reporte.Add($"[ERROR INSERCIÓN NO AUTORIZADA] Tabla: '{LM830Nombre}' -> Se detectó un NUEVO registro no autorizado (PK {LM830_columnaPK}: '{LM830PK(LM830insertada)}') en columnas: {LM830columnas}.");
                    }
                    else
                    {
                        LM830reporte.Add($"[ERROR ELIMINACIÓN] Tabla: '{LM830Nombre}' -> Se ha detectado la ELIMINACIÓN o alteración de uno o más registros (Inconsistencia de DVV en columnas: {LM830columnas}).");
                    }
                }
            }
        }
    }
}
