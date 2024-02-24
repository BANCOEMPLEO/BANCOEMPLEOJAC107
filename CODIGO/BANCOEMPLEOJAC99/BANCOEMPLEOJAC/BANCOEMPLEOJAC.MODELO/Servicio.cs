using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.MODELO;

public partial class Servicio
{
    public int Id { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? EmpleadoId { get; set; }

    public int? EmpleadorId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Cantidad { get; set; }

    public decimal? ValorUnitario { get; set; }

    public string? Ubicacion { get; set; }

    public string? Foto { get; set; }

    public int? PerfilCargoId { get; set; }

    public string? Observaciones { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual Empleador? Empleador { get; set; }

    public virtual PerfilCargo? PerfilCargo { get; set; }
}
