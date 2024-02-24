using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.MODELO;

public partial class Municipio
{
    public string Id { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? IdRegion { get; set; }

    public int? Habitantes { get; set; }

    public short? Altitud { get; set; }

    public short? Temperatura { get; set; }

    public short? AreaKm2 { get; set; }

    public string? CodigoPostal { get; set; }

    public int? Aptitud { get; set; }

    public string? Observaciones { get; set; }

    public virtual Region? IdRegionNavigation { get; set; }

    public virtual ICollection<ZonaVereda> ZonaVereda { get; set; } = new List<ZonaVereda>();
}
