using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Servicio.Implementacion
{
    public class CarritoServicio : ICarritoServicio
    {
        //private readonly 
        //public CarritoServicio()
        //{
                
        //}

        public event Action MostrarItems;

        public Task AgregarCarrito(CarritoDTO modelo)
        {
            throw new NotImplementedException();
        }

        public int CantidadProductos()
        {
            throw new NotImplementedException();
        }

        public Task<List<CarritoDTO>> DevolverCarrito()
        {
            throw new NotImplementedException();
        }

        public Task EliminarCarrito(string tipo, int IdProducto)
        {
            throw new NotImplementedException();
        }

        public Task LimpiarCarrito()
        {
            throw new NotImplementedException();
        }
    }
}
