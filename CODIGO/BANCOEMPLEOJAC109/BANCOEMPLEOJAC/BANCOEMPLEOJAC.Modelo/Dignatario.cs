using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class Dignatario
{
    public int Id { get; set; }

    public int? Jacid { get; set; }

    public int? PresidenteId { get; set; }

    public string? FuncionesPresidente { get; set; }

    public int? VicepresidenteId { get; set; }

    public string? FuncionesVicepresidente { get; set; }

    public int? TesosreroId { get; set; }

    public string? FuncionesTesorero { get; set; }

    public int? SecretarioId { get; set; }

    public string? FuncionesSecretario { get; set; }

    public string? Observaciones { get; set; }

    public virtual Jac? Jac { get; set; }

    public virtual Usuario? Presidente { get; set; }

    public virtual Usuario? Secretario { get; set; }

    public virtual Usuario? Tesosrero { get; set; }

    public virtual Usuario? Vicepresidente { get; set; }
}
