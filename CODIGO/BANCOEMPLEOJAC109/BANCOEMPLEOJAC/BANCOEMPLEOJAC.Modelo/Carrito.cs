using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Modelo
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public PropuestaEmpleo? propuestaEmpleo { get; set; }
        public PropuestaServicio? propuestaServicio { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
    }
}
