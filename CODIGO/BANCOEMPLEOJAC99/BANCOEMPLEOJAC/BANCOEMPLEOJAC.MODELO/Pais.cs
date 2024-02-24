using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.MODELO;

public partial class Pais
{
    public string Id { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Descripion { get; set; }

    public string? Region { get; set; }

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
