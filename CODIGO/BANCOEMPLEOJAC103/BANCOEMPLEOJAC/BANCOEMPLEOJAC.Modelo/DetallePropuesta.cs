using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class DetallePropuesta
{
    public int Id { get; set; }

    public int? DetallePropuestAnteriorId { get; set; }

    public int? PropuestaEmpleoId { get; set; }

    public int? PropuestServicioId { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public virtual DetallePropuesta? DetallePropuestAnterior { get; set; }

    public virtual ICollection<DetallePropuesta> InverseDetallePropuestAnterior { get; set; } = new List<DetallePropuesta>();

    public virtual PropuestaServicio? PropuestServicio { get; set; }

    public virtual PropuestaEmpleo? PropuestaEmpleo { get; set; }
}
