using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANCOEMPLEOJAC.Utilidades;

namespace BANCOEMPLEOJAC.Servicio.Implementacion
{
    public class DistanciaServicio : IDistanciaServicio
    {

        public async Task<double>  CalcularDistancia(DistanciaDTO modelo)
        {
            var dist = DistanciaLatLon.CalculateDistance(
                (double)modelo.latitudPunto1, 
                (double)modelo.longitudPunto1,
                (double)modelo.latitudPunto2, 
                (double)modelo.longitudPunto2);
            return dist;

        }
    }
}
