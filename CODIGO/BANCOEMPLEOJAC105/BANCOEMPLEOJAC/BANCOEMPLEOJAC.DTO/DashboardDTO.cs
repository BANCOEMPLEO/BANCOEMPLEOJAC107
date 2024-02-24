using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class DashboardDTO
    {
        public string? TotalIngresos { get; set; }
        public int TotalPropuestasEmpleo { get; set; }
        public int TotalPropuestasServicio { get; set; } 
        public int TotalEmpleadores { get; set; }
        public int TotalEmpleados { get; set; }
        public int TotalServicios { get; set; }

    }
}
