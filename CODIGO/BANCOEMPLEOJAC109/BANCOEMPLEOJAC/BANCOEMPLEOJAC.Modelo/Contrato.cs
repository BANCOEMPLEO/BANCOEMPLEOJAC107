using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class Contrato
{
    public int IdContrato { get; set; }

    public int? UsuarioId { get; set; }

    public decimal? Total { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<DetallePropuesta> DetallePropuesta { get; set; } = new List<DetallePropuesta>();
}
