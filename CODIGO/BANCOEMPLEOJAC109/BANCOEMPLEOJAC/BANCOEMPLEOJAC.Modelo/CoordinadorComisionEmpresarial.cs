using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class CoordinadorComisionEmpresarial
{
    public int Id { get; set; }

    public int? Jacid { get; set; }

    public int? CoordinadorId { get; set; }

    public int? SuplenteId { get; set; }

    public string? Funciones { get; set; }

    public string? Observaciones { get; set; }

    public virtual Usuario? Coordinador { get; set; }

    public virtual Jac? Jac { get; set; }

    public virtual Usuario? Suplente { get; set; }
}
