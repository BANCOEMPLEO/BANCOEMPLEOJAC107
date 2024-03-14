using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase;
using System.Net.Http.Json;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Implementacion
{
    public class RolServicio : IRolServicio
    {
        private readonly HttpClient _httpClient;
        public RolServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<RolDTO>>> Lista(int UsuarioId, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<RolDTO>>>($"Rol/Lista/{UsuarioId}/{buscar}");
        }
    }
}
