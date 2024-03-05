using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class DivisionActividadEconomica
{
    public string IdDivision { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<ActividadEconomica> ActividadEconomicas { get; set; } = new List<ActividadEconomica>();
}
