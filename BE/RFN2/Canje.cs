using LM830BE.LM830RFN1;
using LM830Servicios;
using System;
using System.Collections.Generic;

namespace LM830BE.LM830RFN2
{
    public class LM830Canje
    {
        private int LM830idCanje;
        private string LM830nroCanje = "";
        private LM830Cliente LM830cliente = new LM830Cliente();
        private LM830Premio LM830premio = new LM830Premio();
        private int LM830puntosRequeridos;
        private decimal LM830valorReferencia;
        private DateTime LM830fechaSolicitud;
        private LM830EstadoCanje LM830estado;
        private LM830Usuario LM830vendedor = new LM830Usuario();
        private LM830Usuario? LM830supervisor;
        private string? LM830motivoResolucion;
        private DateTime? LM830fechaResolucion;
        private DateTime? LM830fechaEntrega;
        private LM830Usuario? LM830supervisorAnulacion;
        private string? LM830motivoAnulacion;
        private DateTime? LM830fechaAnulacion;
        private List<LM830DetalleCanje> LM830detalle = new List<LM830DetalleCanje>();
        private string LM830dvh = "";

        public int LM830IdCanje { get => LM830idCanje; set => LM830idCanje = value; }
        public string LM830NroCanje { get => LM830nroCanje; set => LM830nroCanje = value; }
        public LM830Cliente LM830Cliente { get => LM830cliente; set => LM830cliente = value; }
        public LM830Premio LM830Premio { get => LM830premio; set => LM830premio = value; }
        public int LM830PuntosRequeridos { get => LM830puntosRequeridos; set => LM830puntosRequeridos = value; }
        public decimal LM830ValorReferencia { get => LM830valorReferencia; set => LM830valorReferencia = value; }
        public DateTime LM830FechaSolicitud { get => LM830fechaSolicitud; set => LM830fechaSolicitud = value; }
        public LM830EstadoCanje LM830Estado { get => LM830estado; set => LM830estado = value; }
        public LM830Usuario LM830Vendedor { get => LM830vendedor; set => LM830vendedor = value; }
        public LM830Usuario? LM830Supervisor { get => LM830supervisor; set => LM830supervisor = value; }
        public string? LM830MotivoResolucion { get => LM830motivoResolucion; set => LM830motivoResolucion = value; }
        public DateTime? LM830FechaResolucion { get => LM830fechaResolucion; set => LM830fechaResolucion = value; }
        public DateTime? LM830FechaEntrega { get => LM830fechaEntrega; set => LM830fechaEntrega = value; }
        public LM830Usuario? LM830SupervisorAnulacion { get => LM830supervisorAnulacion; set => LM830supervisorAnulacion = value; }
        public string? LM830MotivoAnulacion { get => LM830motivoAnulacion; set => LM830motivoAnulacion = value; }
        public DateTime? LM830FechaAnulacion { get => LM830fechaAnulacion; set => LM830fechaAnulacion = value; }
        public List<LM830DetalleCanje> LM830Detalle { get => LM830detalle; set => LM830detalle = value; }
        public string LM830DVH { get => LM830dvh; set => LM830dvh = value; }

        public string LM830CadenaDVH() =>
            LM830FormatoDV.LM830Entero(LM830IdCanje) + LM830NroCanje + LM830FormatoDV.LM830Entero(LM830Cliente.LM830IdCliente) + LM830FormatoDV.LM830Entero(LM830Premio.LM830IdPremio) +
            LM830FormatoDV.LM830Entero(LM830PuntosRequeridos) + LM830FormatoDV.LM830Importe(LM830ValorReferencia) + LM830FormatoDV.LM830FechaHora(LM830FechaSolicitud) +
            LM830Estado.LM830ATexto() + LM830FormatoDV.LM830Texto(LM830Vendedor?.LM830DNI) + LM830FormatoDV.LM830Texto(LM830Supervisor?.LM830DNI) +
            LM830FormatoDV.LM830Texto(LM830MotivoResolucion) + LM830FormatoDV.LM830FechaHora(LM830FechaResolucion) + LM830FormatoDV.LM830FechaHora(LM830FechaEntrega) +
            LM830FormatoDV.LM830Texto(LM830SupervisorAnulacion?.LM830DNI) + LM830FormatoDV.LM830Texto(LM830MotivoAnulacion) + LM830FormatoDV.LM830FechaHora(LM830FechaAnulacion);
    }
}
