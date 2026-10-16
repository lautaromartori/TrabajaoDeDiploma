namespace BE.RFN1
{
    // Los valores se guardan en la BD tal cual (en minúscula), como en el modelo conceptual.
    public enum OrigenPuntos
    {
        venta,
        reclamo
    }

    public enum EstadoReclamo
    {
        pendiente,
        aprobado,
        rechazado
    }
}
