using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class AsambleaReuniones
{
    public int Id { get; set; }

    public int? Jacid { get; set; }

    public int? TipoAsamblea { get; set; }

    public DateTime? FechaHoraConvocatoria { get; set; }

    public string? OrdenDelDia { get; set; }

    public string? NombreQuienConvoca { get; set; }

    public string? CalidadQuienConvoca { get; set; }

    public int? NumeroAfiiadosExistente { get; set; }

    public DateTime? FechaHoraFijacionAvisos { get; set; }

    public DateTime? FechaHoraDesFijacionAvisos { get; set; }

    public int? PresidenteId { get; set; }

    public int? SecretarioId { get; set; }

    public int? ActaNumero { get; set; }

    public string? ContenidoActa { get; set; }

    public string? Observaciones { get; set; }

    public virtual Jac? Jac { get; set; }

    public virtual TipoAsamblea? TipoAsambleaNavigation { get; set; }
}
