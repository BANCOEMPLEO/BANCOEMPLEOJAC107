using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class PropuestaServicio
{
    public int IdPropuestaServicio { get; set; }

    public int? PropuestaServicioAnteriorId { get; set; }

    public int? ServicioId { get; set; }

    public int? Orden { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Caracteristicas { get; set; }

    public int? EmpleadoId { get; set; }

    public int? EmpleadorId { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Valor { get; set; }

    public string? Ubicacion { get; set; }

    public string? Foto { get; set; }

    public DateTime? FechaHoraRevisaPropuesta { get; set; }

    public DateTime? FechaHoraReRepropone { get; set; }

    public DateTime? FechaHoraAcepta { get; set; }

    public bool? RePropone { get; set; }

    public bool? Aceptada { get; set; }

    public DateTime? FechaHoraCreacion { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<DetallePropuesta> DetallePropuesta { get; set; } = new List<DetallePropuesta>();

    public virtual Empleado? Empleado { get; set; }

    public virtual Empleador? Empleador { get; set; }

    public virtual ICollection<PropuestaServicio> InversePropuestaServicioAnterior { get; set; } = new List<PropuestaServicio>();

    public virtual PropuestaServicio? PropuestaServicioAnterior { get; set; }

    public virtual Servicio? Servicio { get; set; }
}
