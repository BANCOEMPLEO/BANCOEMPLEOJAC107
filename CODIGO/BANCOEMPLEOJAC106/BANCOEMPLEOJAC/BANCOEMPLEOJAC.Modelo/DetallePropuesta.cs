using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class DetallePropuesta
{
    public int IdDetallePropuesta { get; set; }

    public int? ContratoId { get; set; }

    public int? DetallePropuestaAnteriorId { get; set; }

    public int? PropuestaEmpleoId { get; set; }

    public int? PropuestaServicioId { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public virtual Contrato? Contrato { get; set; }

    public virtual DetallePropuesta? DetallePropuestaAnterior { get; set; }

    public virtual ICollection<DetallePropuesta> InverseDetallePropuestaAnterior { get; set; } = new List<DetallePropuesta>();

    public virtual PropuestaEmpleo? PropuestaEmpleo { get; set; }

    public virtual PropuestaServicio? PropuestaServicio { get; set; }
}
