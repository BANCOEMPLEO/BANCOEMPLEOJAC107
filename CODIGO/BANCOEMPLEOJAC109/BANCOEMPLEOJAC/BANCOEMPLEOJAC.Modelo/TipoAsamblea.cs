using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class TipoAsamblea
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<AsambleaReuniones> AsambleaReuniones { get; set; } = new List<AsambleaReuniones>();
}
