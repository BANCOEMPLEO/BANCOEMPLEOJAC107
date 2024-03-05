using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase;
using System.Net.Http.Json;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Implementacion
{
    public class PropuestaServicioServicio : IPropuestaServicioServicio
    {
        private readonly HttpClient _httpClient;
        public PropuestaServicioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<PropuestaServicioDTO>>> Catalogo(string categoria, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<PropuestaServicioDTO>>>($"PropuestaServicioServicio/Catalogo/{categoria}/{buscar}");
        }

        public async Task<ResponseDTO<PropuestaServicioDTO>> Crear(PropuestaServicioDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("PropuestaServicio/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<PropuestaServicioDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(PropuestaServicioDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("PropuestaServicio/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int Id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"PropuestaServicio/Eliminar/{Id}");
        }

        public async Task<ResponseDTO<List<PropuestaServicioDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<PropuestaServicioDTO>>>($"PropuestaServicio/Lista/{buscar}");
        }

        public async Task<ResponseDTO<PropuestaServicioDTO>> Obtener(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<PropuestaServicioDTO>>($"PropuestaServicio/Obtener/{Id}");
        }
    }
}
