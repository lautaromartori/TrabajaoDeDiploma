using BE.RFN1;

namespace BE.RFN2
{
    public class DetalleCanje
    {
        private int idDetalleCanje;
        private int idCanje;
        private LotePuntos lote = new LotePuntos();
        private int puntosDescontados;
        private string dvh = "";

        public int IdDetalleCanje { get => idDetalleCanje; set => idDetalleCanje = value; }
        public int IdCanje { get => idCanje; set => idCanje = value; }
        public LotePuntos Lote { get => lote; set => lote = value; }
        public int PuntosDescontados { get => puntosDescontados; set => puntosDescontados = value; }
        public string DVH { get => dvh; set => dvh = value; }

        public string CadenaDVH() =>
            FormatoDV.Entero(IdDetalleCanje) + FormatoDV.Entero(IdCanje) +
            FormatoDV.Entero(Lote.IdLote) + FormatoDV.Entero(PuntosDescontados);
    }
}
