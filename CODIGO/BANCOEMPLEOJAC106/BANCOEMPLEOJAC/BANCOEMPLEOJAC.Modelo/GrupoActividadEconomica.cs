using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class GrupoActividadEconomica
{
    public string IdGrupo { get; set; } = null!;

    public string? Descripción { get; set; }

    public virtual ICollection<ActividadEconomica> ActividadEconomicas { get; set; } = new List<ActividadEconomica>();
}
