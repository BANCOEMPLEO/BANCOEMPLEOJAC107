using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class Empleo
{
    public int IdEmpleo { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Requisitos { get; set; }

    public DateTime? FechaHoraInicio { get; set; }

    public DateTime? FechaHoraFin { get; set; }

    public string? Ubicacion { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? PrecioOferta { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaHoraActiva { get; set; }

    public DateTime? FechaHoraInactiva { get; set; }

    public int? EmpleadorId { get; set; }

    public int? EmpleadoId { get; set; }

    public int? PerfilCargoId { get; set; }

    public DateTime? FechaHoraCreacion { get; set; }

    public string? Observaciones { get; set; }

    public virtual Usuario? Empleado { get; set; }

    public virtual Usuario? Empleador { get; set; }

    public virtual PerfilCargo? PerfilCargo { get; set; }

    //public virtual int? NumeroPropuestas { get; set; }
    public virtual ICollection<PropuestaEmpleo> PropuestaEmpleos { get; set; } = new List<PropuestaEmpleo>();
}
