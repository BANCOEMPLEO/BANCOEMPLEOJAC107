using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class DetallePropuestaDTO
    {
        public int IdDetallePropuesta { get; set; }
        public int? ContratoId { get; set; }

        public int? PropuestaEmpleoId { get; set; }

        public int? PropuestaServicioId { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Total { get; set; }
        public string? Observaciones { get; set; }

        public virtual PropuestaEmpleoDTO? PropuestaEmpleo { get; set; }

        public virtual PropuestaServicioDTO? PropuestaServicio { get; set; }

    }
}
