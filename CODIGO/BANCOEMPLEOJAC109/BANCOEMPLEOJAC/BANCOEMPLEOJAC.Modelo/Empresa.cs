using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class Empresa
{
    public int Id { get; set; }

    public int? Nit { get; set; }

    public string? RozonSocial { get; set; }

    public bool? Social { get; set; }

    public string? RegistroMercantil { get; set; }

    public string? CamaraComercio { get; set; }

    public string? GerenteGeneral { get; set; }

    public string? Direccion { get; set; }

    public string? Barrio { get; set; }

    public int? Jacid { get; set; }

    public string? Observaciones { get; set; }

    public virtual Jac? Jac { get; set; }
}
