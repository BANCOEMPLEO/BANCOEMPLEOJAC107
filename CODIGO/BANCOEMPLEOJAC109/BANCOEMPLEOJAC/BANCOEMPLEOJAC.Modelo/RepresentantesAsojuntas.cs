using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class RepresentantesAsojuntas
{
    public int Id { get; set; }

    public int? Jacid { get; set; }

    public int? Representante1 { get; set; }

    public int? Representante2 { get; set; }

    public int? Representante3 { get; set; }

    public string? Funciones { get; set; }

    public string? Observaciones { get; set; }

    public virtual Jac? Jac { get; set; }

    public virtual Usuario? Representante1Navigation { get; set; }

    public virtual Usuario? Representante2Navigation { get; set; }

    public virtual Usuario? Representante3Navigation { get; set; }
}
