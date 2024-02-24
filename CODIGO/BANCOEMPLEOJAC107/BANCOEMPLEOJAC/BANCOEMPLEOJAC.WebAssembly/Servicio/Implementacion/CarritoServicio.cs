using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase;
using Blazored.LocalStorage;
using Blazored.Toast.Services;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Implementacion
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
                if (carrito == null)
                    carrito = new List<CarritoDTO>();

                if (modelo != null && modelo.propuestaEmpleo.IdPropuestaEmpleo != null)
                {
                    var encontradoEmpleo = carrito.FirstOrDefault(c => c.propuestaEmpleo.IdPropuestaEmpleo == modelo.propuestaEmpleo.IdPropuestaEmpleo);
                    if (encontradoEmpleo != null)
                        carrito.Remove(encontradoEmpleo);
                }
                if (modelo != null && modelo.propuestaServicio.IdPropuestaServicio != null)
                {
                    var encontradoServicio = carrito.FirstOrDefault(c => c.propuestaServicio.IdPropuestaServicio == modelo.propuestaServicio.IdPropuestaServicio);
                    if (encontradoServicio != null)
                        carrito.Remove(encontradoServicio);
                }

                carrito.Add(modelo);
                await _localstorageService.SetItemAsync("carrito", carrito);

                if (modelo.propuestaEmpleo.IdPropuestaEmpleo != null)
                    _toastService.ShowSuccess("Propuesta Empleo fue actualizada en carrito");
                else
                    _toastService.ShowSuccess("Propuesta Empleo fue agregada al carrito");

                if (modelo.propuestaServicio.IdPropuestaServicio != null)
                    _toastService.ShowSuccess("Propuesta Servicio fue actualizada en carrito");
                else
                    _toastService.ShowSuccess("Propuesta Servicio fue agregada al carrito");

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
            if (carrito == null)
                carrito = new List<CarritoDTO>();

            return carrito;
        }

        public async Task EliminarCarrito(string tipo, int IdProducto)
        {
            try
            {
                var carrito = _syncstorageService.GetItem<List<CarritoDTO>>("carrito");
                if (carrito != null)
                {
                    var elementoEmpleo = carrito.FirstOrDefault(c => c.propuestaEmpleo.IdPropuestaEmpleo == IdProducto);
                    if (elementoEmpleo != null)
                    {
                        carrito.Remove(elementoEmpleo);
                        await _localstorageService.SetItemAsync("carrito", carrito);
                        MostrarItems.Invoke();
                    }
                    var elementoServicio = carrito.FirstOrDefault(c => c.propuestaServicio.IdPropuestaServicio == IdProducto);
                    if (elementoServicio != null)
                    {
                        carrito.Remove(elementoServicio);
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
