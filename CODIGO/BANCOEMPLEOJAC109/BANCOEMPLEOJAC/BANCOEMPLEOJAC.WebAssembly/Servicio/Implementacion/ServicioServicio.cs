using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase;
using System.Net.Http.Json;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Implementacion
{
    public class ServicioServicio : IServicioServicio
    {
        private readonly HttpClient _httpClient;
        public ServicioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<ServicioDTO>>> Catalogo(int categoria, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ServicioDTO>>>($"Servicio/Catalogo/{categoria}/{buscar}");
        }

        public async Task<ResponseDTO<ServicioDTO>> Crear(ServicioDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Servicio/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ServicioDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(ServicioDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("Servicio/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int Id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Servicio/Eliminar/{Id}");
        }

        public async Task<ResponseDTO<List<ServicioDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ServicioDTO>>>($"Servicio/Lista/{buscar}");
        }

        public async Task<ResponseDTO<ServicioDTO>> Obtener(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ServicioDTO>>($"Servicio/Obtener/{Id}");
        }
    }
}
