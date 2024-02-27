using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class Region
{
    public string IdRegion { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? IdDepartamento { get; set; }

    public int? Habitantes { get; set; }

    public int? Altitud { get; set; }

    public int? Temperatura { get; set; }

    public int? AreaKm2 { get; set; }

    public string? CodigoPostal { get; set; }

    public int? Aptitud { get; set; }

    public string? Observaciones { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
