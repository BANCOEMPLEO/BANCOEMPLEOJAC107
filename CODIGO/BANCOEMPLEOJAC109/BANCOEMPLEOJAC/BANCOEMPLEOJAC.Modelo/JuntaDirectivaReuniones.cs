using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class JuntaDirectivaReuniones
{
    public int Id { get; set; }

    public int? Jacid { get; set; }

    public int? TipoJunta { get; set; }

    public DateTime? FechaHoraComvocatoria { get; set; }

    public string? OrdenDelDia { get; set; }

    public int? ConvocaId { get; set; }

    public int? PresidenteId { get; set; }

    public int? SecretarioId { get; set; }

    public DateTime? FechaHoraAviso { get; set; }

    public int? ActaNumero { get; set; }

    public string? ContenidoActa { get; set; }

    public string? Observaciones { get; set; }

    public virtual Jac? Jac { get; set; }

    public virtual TipoJuntaDirectiva? TipoJuntaNavigation { get; set; }
}
