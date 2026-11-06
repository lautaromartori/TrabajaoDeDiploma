using LM830BE.LM830RFN1;

namespace LM830BE.LM830RFN2
{
    public class LM830DetalleCanje
    {
        private int LM830idDetalleCanje;
        private int LM830idCanje;
        private LM830LotePuntos LM830lote = new LM830LotePuntos();
        private int LM830puntosDescontados;
        private string LM830dvh = "";

        public int LM830IdDetalleCanje { get => LM830idDetalleCanje; set => LM830idDetalleCanje = value; }
        public int LM830IdCanje { get => LM830idCanje; set => LM830idCanje = value; }
        public LM830LotePuntos LM830Lote { get => LM830lote; set => LM830lote = value; }
        public int LM830PuntosDescontados { get => LM830puntosDescontados; set => LM830puntosDescontados = value; }
        public string LM830DVH { get => LM830dvh; set => LM830dvh = value; }

        public string LM830CadenaDVH() =>
            LM830FormatoDV.LM830Entero(LM830IdDetalleCanje) + LM830FormatoDV.LM830Entero(LM830IdCanje) +
            LM830FormatoDV.LM830Entero(LM830Lote.LM830IdLote) + LM830FormatoDV.LM830Entero(LM830PuntosDescontados);
    }
}
