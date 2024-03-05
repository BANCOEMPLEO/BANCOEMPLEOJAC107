using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public int? CategoriaId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Caracteristicas { get; set; }

    public int? EmpleadoId { get; set; }

    public int? EmpleadorId { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? PrecioOferta { get; set; }

    public string? Ubicacion { get; set; }

    public DateTime? FechaHoraCreacion { get; set; }

    public string? Foto { get; set; }

    public string? Observaciones { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual Usuario? Empleado { get; set; }

    public virtual Usuario? Empleador { get; set; }

    public virtual ICollection<PropuestaServicio> PropuestaServicios { get; set; } = new List<PropuestaServicio>();
}
