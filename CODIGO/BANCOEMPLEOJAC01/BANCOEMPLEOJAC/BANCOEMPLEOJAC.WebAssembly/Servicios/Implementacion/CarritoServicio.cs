using Blazored.LocalStorage;
using Blazored.Toast.Services;
using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicios.Contrato;

namespace BANCOEMPLEOJAC.WebAssembly.Servicios.Implementacion
{
    public class CarritoServicio : ICarritoServicio
    {
        private ILocalStorageService _localstorageService;
        private ISyncLocalStorageService _syncstorageService;
        private IToastService _toastService;

        public CarritoServicio(
            ILocalStorageService localstorageService,
            ISyncLocalStorageService syncstorageService,
            IToastService toastService
            )
        {
            _localstorageService = localstorageService;
            _syncstorageService = syncstorageService;
            _toastService = toastService;
        }

        public event Action MostrarItems;

        public async Task AgregarCarrito(CarritoDTO modelo)
        {
            try
            {
                var carrito = await _localstorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if( carrito == null )
                    carrito = new List<CarritoDTO>();

                var encontrado = carrito.FirstOrDefault(c => c.Producto.IdProducto == modelo.Producto.IdProducto);

                if(encontrado != null )
                    carrito.Remove(encontrado);

                carrito.Add(modelo);
                await _localstorageService.SetItemAsync("carrito", carrito);

                if (encontrado != null)
                    _toastService.ShowSuccess("Producto fue actualizado en carrito");
                else
                    _toastService.ShowSuccess("Producto fue agregado al carrito");

                MostrarItems.Invoke();
            }
            catch 
            {
                _toastService.ShowSuccess("No se pudo agregar al carrito");
            }
        }

        public int CantidadProductos()
        {
            var carrito = _syncstorageService.GetItem<List<CarritoDTO>>("carrito");
            return carrito == null ? 0 : carrito.Count();

        }

        public async Task<List<CarritoDTO>> DevolverCarrito()
        {
            var carrito = await _localstorageService.GetItemAsync<List<CarritoDTO>>("carrito");
            if(carrito == null)
                carrito = new List<CarritoDTO>();

            return carrito;
        }

        public async Task EliminarCarrito(int idProducto)
        {
            try
            {
                var carrito = _syncstorageService.GetItem<List<CarritoDTO>>("carrito");
                if(carrito != null)
                {
                    var elemento = carrito.FirstOrDefault(c => c.Producto.IdProducto == idProducto);
                    if(elemento != null)
                    {
                        carrito.Remove(elemento);
                        await _localstorageService.SetItemAsync("carrito", carrito);
                        MostrarItems.Invoke();
                    }

                }
            }
            catch 
            {
                _toastService.ShowSuccess("No se pudo eliminar del carrito");
            }
        }

        public async Task LimpiarCarrito()
        {
            await _localstorageService.RemoveItemAsync("carrito");
            MostrarItems.Invoke();
        }
    }
}
