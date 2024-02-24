using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class CarritoDTO
    {
        public PropuestaEmpleoDTO? PropuestaEmpleo { get; set; }
        public PropuestaServicioDTO? PropuestaServicio { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }

    }
}
