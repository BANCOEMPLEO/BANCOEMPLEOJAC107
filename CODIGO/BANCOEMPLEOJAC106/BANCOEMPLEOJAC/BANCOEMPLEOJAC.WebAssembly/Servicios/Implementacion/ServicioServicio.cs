using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace BANCOEMPLEOJAC.WebAssembly.Servicios.Implementacion
{
    public class ServicioServicio : IServicioServicio
    {
        private readonly HttpClient _httpClient;
        public ServicioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<ServicioDTO>>> Catalogo(string categoria, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ServicioDTO>>>($"Servicio/Catalogo/{categoria}/{buscar}");
        }

        public Task<ResponseDTO<ServicioDTO>> Crear(ServicioDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<bool>> Editar(ServicioDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<bool>> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<List<ServicioDTO>>> Lista(string buscar)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<ServicioDTO>> Obtener(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
