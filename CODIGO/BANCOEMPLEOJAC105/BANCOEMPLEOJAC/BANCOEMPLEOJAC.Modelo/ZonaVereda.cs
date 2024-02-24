using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class ZonaVereda
{
    public string Id { get; set; } = null!;

    public string? IdMunicipio { get; set; }

    public string? Nombre { get; set; }

    public string? Observaciones { get; set; }

    public string? Ubicacion { get; set; }

    public string? Latitud { get; set; }

    public string? Longitud { get; set; }

    public int? ImagenId { get; set; }

    public virtual Municipio? IdMunicipioNavigation { get; set; }

    public virtual ICollection<Jac> Jacs { get; set; } = new List<Jac>();
}
