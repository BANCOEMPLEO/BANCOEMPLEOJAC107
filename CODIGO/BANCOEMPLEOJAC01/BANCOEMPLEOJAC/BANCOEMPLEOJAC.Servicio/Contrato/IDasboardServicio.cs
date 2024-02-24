using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.Servicio.Contrato
{
    public interface IDasboardServicio
    {
        DashboardDTO Resumen();
    }

}
