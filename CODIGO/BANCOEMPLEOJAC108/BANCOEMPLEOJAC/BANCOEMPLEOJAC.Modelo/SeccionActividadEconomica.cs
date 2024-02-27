using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class SeccionActividadEconomica
{
    public string IdSeccion { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<ActividadEconomica> ActividadEconomicas { get; set; } = new List<ActividadEconomica>();
}
