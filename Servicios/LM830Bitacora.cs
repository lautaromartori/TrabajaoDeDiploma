namespace LM830Servicios
{
    public class LM830Bitacora
    {
        [System.ComponentModel.DisplayName("Id_Evento")]
        public int LM830Id_Evento { get; set; }
        [System.ComponentModel.DisplayName("Login")]
        public string LM830Login { get; set; }
        [System.ComponentModel.DisplayName("Fecha")]
        public DateTime LM830Fecha { get; set; }
        [System.ComponentModel.DisplayName("Modulo")]
        public string LM830Modulo { get; set; }
        [System.ComponentModel.DisplayName("Evento")]
        public string LM830Evento { get; set; }
        [System.ComponentModel.DisplayName("Criticidad")]
        public int LM830Criticidad { get; set; }
        [System.ComponentModel.DisplayName("DVH")]
        public string LM830DVH { get; set; }


        [System.ComponentModel.DisplayName("FechaSolo")]
        public string LM830FechaSolo => LM830Fecha.ToString("dd/MM/yyyy");
        [System.ComponentModel.DisplayName("HoraSolo")]
        public string LM830HoraSolo => LM830Fecha.ToString("HH:mm");

        public LM830Bitacora()
        {
        }
        public LM830Bitacora(int LM830idEvento, string LM830login, DateTime LM830fecha, string LM830modulo, string LM830evento, int LM830criticidad, string LM830dvh)
        {
            this.LM830Id_Evento = LM830idEvento;
            this.LM830Login = LM830login;
            this.LM830Fecha = LM830fecha;
            this.LM830Modulo = LM830modulo;
            this.LM830Evento = LM830evento;
            this.LM830Criticidad = LM830criticidad;
            this.LM830DVH = LM830dvh;
        }
    }
}
