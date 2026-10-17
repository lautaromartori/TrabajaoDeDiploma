using BE.RFN1;
using Servicios;
using System;
using System.Collections.Generic;

namespace BE.RFN2
{
    public class Canje
    {
        private int idCanje;
        private string nroCanje = "";
        private Cliente cliente = new Cliente();
        private Premio premio = new Premio();
        private int puntosRequeridos;
        private decimal valorReferencia;
        private DateTime fechaSolicitud;
        private EstadoCanje estado;
        private Usuario vendedor = new Usuario();
        private Usuario? supervisor;
        private string? motivoResolucion;
        private DateTime? fechaResolucion;
        private DateTime? fechaEntrega;
        private Usuario? supervisorAnulacion;
        private string? motivoAnulacion;
        private DateTime? fechaAnulacion;
        private List<DetalleCanje> detalle = new List<DetalleCanje>();
        private string dvh = "";

        public int IdCanje { get => idCanje; set => idCanje = value; }
        public string NroCanje { get => nroCanje; set => nroCanje = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Premio Premio { get => premio; set => premio = value; }
        public int PuntosRequeridos { get => puntosRequeridos; set => puntosRequeridos = value; }
        public decimal ValorReferencia { get => valorReferencia; set => valorReferencia = value; }
        public DateTime FechaSolicitud { get => fechaSolicitud; set => fechaSolicitud = value; }
        public EstadoCanje Estado { get => estado; set => estado = value; }
        public Usuario Vendedor { get => vendedor; set => vendedor = value; }
        public Usuario? Supervisor { get => supervisor; set => supervisor = value; }
        public string? MotivoResolucion { get => motivoResolucion; set => motivoResolucion = value; }
        public DateTime? FechaResolucion { get => fechaResolucion; set => fechaResolucion = value; }
        public DateTime? FechaEntrega { get => fechaEntrega; set => fechaEntrega = value; }
        public Usuario? SupervisorAnulacion { get => supervisorAnulacion; set => supervisorAnulacion = value; }
        public string? MotivoAnulacion { get => motivoAnulacion; set => motivoAnulacion = value; }
        public DateTime? FechaAnulacion { get => fechaAnulacion; set => fechaAnulacion = value; }
        public List<DetalleCanje> Detalle { get => detalle; set => detalle = value; }
        public string DVH { get => dvh; set => dvh = value; }

        public string CadenaDVH() =>
            FormatoDV.Entero(IdCanje) + NroCanje + FormatoDV.Entero(Cliente.IdCliente) + FormatoDV.Entero(Premio.IdPremio) +
            FormatoDV.Entero(PuntosRequeridos) + FormatoDV.Importe(ValorReferencia) + FormatoDV.FechaHora(FechaSolicitud) +
            Estado.ToString() + FormatoDV.Texto(Vendedor?.DNI) + FormatoDV.Texto(Supervisor?.DNI) +
            FormatoDV.Texto(MotivoResolucion) + FormatoDV.FechaHora(FechaResolucion) + FormatoDV.FechaHora(FechaEntrega) +
            FormatoDV.Texto(SupervisorAnulacion?.DNI) + FormatoDV.Texto(MotivoAnulacion) + FormatoDV.FechaHora(FechaAnulacion);
    }
}
