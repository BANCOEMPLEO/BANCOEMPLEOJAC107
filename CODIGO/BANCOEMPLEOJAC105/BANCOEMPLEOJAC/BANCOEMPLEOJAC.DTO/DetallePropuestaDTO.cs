using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class DetallePropuestaDTO
    {
        public int Id { get; set; }

        public int? DetallePropuestAnteriorId { get; set; }

        public int? PropuestaEmpleoId { get; set; }

        public int? PropuestServicioId { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Total { get; set; }


    }
}
