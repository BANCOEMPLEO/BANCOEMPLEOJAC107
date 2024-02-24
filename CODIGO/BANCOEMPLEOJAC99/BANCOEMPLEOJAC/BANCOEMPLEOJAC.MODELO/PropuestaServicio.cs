using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.MODELO;

public partial class PropuestaServicio
{
    public int Id { get; set; }

    public int? Orden { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? EmpleadoId { get; set; }

    public int? EmpleadorId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Cantidad { get; set; }

    public decimal? ValorUnitario { get; set; }

    public string? Ubicacion { get; set; }

    public string? Foto { get; set; }

    public DateTime? FechaHoraRevisaPropuesta { get; set; }

    public DateTime? FechaHoraReRepropone { get; set; }

    public DateTime? FechaHoraAcepta { get; set; }

    public bool? RePropone { get; set; }

    public bool? Aceptada { get; set; }

    public string? Observaciones { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual Empleador? Empleador { get; set; }
}
