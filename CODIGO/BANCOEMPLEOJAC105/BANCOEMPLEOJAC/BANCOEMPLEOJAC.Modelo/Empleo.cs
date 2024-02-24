using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class Empleo
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Requisitos { get; set; } = null!;

    public DateTime FechaHoraInicio { get; set; }

    public DateTime FechaHoraFin { get; set; }

    public string Ubicacion { get; set; } = null!;

    public int? Cantidad { get; set; }

    public decimal Precio { get; set; }

    public string? PrecioOferta { get; set; }

    public bool Diario { get; set; }

    public bool Jornal { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaHoraActiva { get; set; }

    public DateTime FechaHoraInactiva { get; set; }

    public int EmpleadorId { get; set; }

    public int? EmpleadoId { get; set; }

    public int PerfilCargoId { get; set; }

    public DateTime? FechaHoraCreacion { get; set; }

    public string Observaciones { get; set; } = null!;

    public virtual Empleado? Empleado { get; set; }

    public virtual Empleador Empleador { get; set; } = null!;

    public virtual ICollection<EmpleoxEmpleado> EmpleoxEmpleados { get; set; } = new List<EmpleoxEmpleado>();

    public virtual PerfilCargo PerfilCargo { get; set; } = null!;

    public virtual ICollection<PropuestaEmpleo> PropuestaEmpleos { get; set; } = new List<PropuestaEmpleo>();
}
