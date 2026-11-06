using LM830Servicios;
using System;

namespace LM830BE.LM830RFN1
{
    public class LM830LotePuntos
    {
        private int LM830idLote;
        private int LM830idCliente;
        private int? LM830idVenta;
        private LM830Reclamo? LM830reclamo;
        private int LM830puntosOriginales;
        private int LM830puntosDisponibles;
        private DateTime LM830fechaAcreditacion;
        private DateTime LM830fechaVencimiento;
        private LM830OrigenPuntos LM830origen;
        private string LM830dvh = "";

        public int LM830IdLote { get => LM830idLote; set => LM830idLote = value; }
        public int LM830IdCliente { get => LM830idCliente; set => LM830idCliente = value; }
        public int? LM830IdVenta { get => LM830idVenta; set => LM830idVenta = value; }
        public LM830Reclamo? LM830Reclamo { get => LM830reclamo; set => LM830reclamo = value; }
        public int? LM830IdReclamo => LM830Reclamo?.LM830IdReclamo;
        public int LM830PuntosOriginales { get => LM830puntosOriginales; set => LM830puntosOriginales = value; }
        public int LM830PuntosDisponibles { get => LM830puntosDisponibles; set => LM830puntosDisponibles = value; }
        public DateTime LM830FechaAcreditacion { get => LM830fechaAcreditacion; set => LM830fechaAcreditacion = value; }
        public DateTime LM830FechaVencimiento { get => LM830fechaVencimiento; set => LM830fechaVencimiento = value; }
        public LM830OrigenPuntos LM830Origen { get => LM830origen; set => LM830origen = value; }
        public string LM830DVH { get => LM830dvh; set => LM830dvh = value; }

        public string LM830CadenaDVH() =>
            LM830FormatoDV.LM830Entero(LM830IdLote) + LM830FormatoDV.LM830Entero(LM830IdCliente) + LM830FormatoDV.LM830Entero(LM830IdVenta) +
            LM830FormatoDV.LM830Entero(LM830IdReclamo) + LM830FormatoDV.LM830Entero(LM830PuntosOriginales) + LM830FormatoDV.LM830Entero(LM830PuntosDisponibles) +
            LM830FormatoDV.LM830Fecha(LM830FechaAcreditacion) + LM830FormatoDV.LM830Fecha(LM830FechaVencimiento) + LM830Origen.LM830ATexto();
    }
}
