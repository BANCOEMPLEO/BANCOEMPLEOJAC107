using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class DistanciaDTO
    {
        public double? latitudPunto1 { get; set; }
        public double? longitudPunto1 { get; set; }
        public double? latitudPunto2 { get; set; }
        public double? longitudPunto2 { get; set; }

    }
}
