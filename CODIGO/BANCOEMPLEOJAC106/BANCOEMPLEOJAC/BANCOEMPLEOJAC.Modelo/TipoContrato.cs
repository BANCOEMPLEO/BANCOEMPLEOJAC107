using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class TipoContrato
{
    public int IdTipoContrato { get; set; }

    public string? Nombre { get; set; }

    public string? Descripción { get; set; }

    public virtual ICollection<PerfilCargo> PerfilCargos { get; set; } = new List<PerfilCargo>();
}
