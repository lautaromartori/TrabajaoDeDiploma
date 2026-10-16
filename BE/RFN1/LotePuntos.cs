using System;

namespace BE.RFN1
{
    public class LotePuntos
    {
        private int idLote;
        private int idCliente;
        private int? idVenta;
        private Reclamo? reclamo;
        private int puntosOriginales;
        private int puntosDisponibles;
        private DateTime fechaAcreditacion;
        private DateTime fechaVencimiento;
        private OrigenPuntos origen;
        private string dvh = "";

        public int IdLote { get => idLote; set => idLote = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int? IdVenta { get => idVenta; set => idVenta = value; }
        public Reclamo? Reclamo { get => reclamo; set => reclamo = value; }
        public int? IdReclamo => Reclamo?.IdReclamo;
        public int PuntosOriginales { get => puntosOriginales; set => puntosOriginales = value; }
        public int PuntosDisponibles { get => puntosDisponibles; set => puntosDisponibles = value; }
        public DateTime FechaAcreditacion { get => fechaAcreditacion; set => fechaAcreditacion = value; }
        public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public OrigenPuntos Origen { get => origen; set => origen = value; }
        public string DVH { get => dvh; set => dvh = value; }

        public string CadenaDVH() =>
            FormatoDV.Entero(IdLote) + FormatoDV.Entero(IdCliente) + FormatoDV.Entero(IdVenta) +
            FormatoDV.Entero(IdReclamo) + FormatoDV.Entero(PuntosOriginales) + FormatoDV.Entero(PuntosDisponibles) +
            FormatoDV.Fecha(FechaAcreditacion) + FormatoDV.Fecha(FechaVencimiento) + Origen.ToString();
    }
}
