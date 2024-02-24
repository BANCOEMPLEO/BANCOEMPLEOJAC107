using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class PropuestaEmpleo
{
    public int IdPropuestaEmpleo { get; set; }

    public int? PropuestaEmpleoAnteriorId { get; set; }

    public int? EmpleoId { get; set; }

    public int? Orden { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Requisitos { get; set; }

    public DateTime? FechaHoraInicio { get; set; }

    public DateTime? FechaHoraFin { get; set; }

    public string? Ubicacion { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Valor { get; set; }

    public int? EmpleadoId { get; set; }

    public DateTime? FechaHoraRevisaEmpleador { get; set; }

    public DateTime? FechaHoraReProponeEmpleador { get; set; }

    public DateTime? FechaHoraAceptaEmpleador { get; set; }

    public bool? RePropone { get; set; }

    public bool? Aceptada { get; set; }

    public DateTime? FechaHoraCreacion { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<DetallePropuesta> DetallePropuesta { get; set; } = new List<DetallePropuesta>();

    public virtual Empleado? Empleado { get; set; }

    public virtual Empleo? Empleo { get; set; }

    public virtual ICollection<PropuestaEmpleo> InversePropuestaEmpleoAnterior { get; set; } = new List<PropuestaEmpleo>();

    public virtual PropuestaEmpleo? PropuestaEmpleoAnterior { get; set; }
}
