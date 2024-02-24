using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class Categoria
{
    public int IdCategoria { get; set; }
    public int? ActividadEconomicaId { get; set; }
    public int? TipoContratoId { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? Caracteristicas { get; set; }
    public decimal? Valor { get; set; }
    public int? JacId { get; set; }
    public DateTime? FechaHoraCreacion { get; set; }
    public string? Observaciones { get; set; }

    public virtual ActividadEconomica? ActividadEconomica { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();

    public virtual TipoContrato? TipoContrato { get; set; }
}
