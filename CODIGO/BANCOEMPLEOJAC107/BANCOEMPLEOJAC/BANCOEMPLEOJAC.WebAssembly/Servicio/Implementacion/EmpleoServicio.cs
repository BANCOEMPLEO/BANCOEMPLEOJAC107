using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase;
using System.Net.Http.Json;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Implementacion
{
    public class EmpleoServicio : IEmpleoServicio
    {
        private readonly HttpClient _httpClient;
        public EmpleoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<EmpleoDTO>>> Catalogo(string categoria, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<EmpleoDTO>>>($"Empleo/Catalogo/{categoria}/{buscar}");
        }

        public async Task<ResponseDTO<EmpleoDTO>> Crear(EmpleoDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Empleo/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<EmpleoDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(EmpleoDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("Empleo/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }
        public async Task<ResponseDTO<bool>> Activar(EmpleoDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("Empleo/Activar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }
        public async Task<ResponseDTO<bool>> Desactivar(EmpleoDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("Empleo/Desactivar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int Id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Empleo/Eliminar/{Id}");
        }

        public async Task<ResponseDTO<List<EmpleoDTO>>> Lista(string idUsuario, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<EmpleoDTO>>>($"Empleo/Lista/{idUsuario},{buscar}");
        }

        public async Task<ResponseDTO<EmpleoDTO>> Obtener(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<EmpleoDTO>>($"Empleo/Obtener/{Id}");
        }
    }
}
