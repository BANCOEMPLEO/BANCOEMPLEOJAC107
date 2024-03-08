using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase;
using System.Net.Http.Json;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Implementacion
{
    public class PerfilCargoServicio : IPerfilCargoServicio
    {
        private readonly HttpClient _httpClient;
        public PerfilCargoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<PerfilCargoDTO>> Crear(PerfilCargoDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("PerfilCargo/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<PerfilCargoDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(PerfilCargoDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("PerfilCargo/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int Id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"PerfilCargo/Eliminar/{Id}");
        }

        public async Task<ResponseDTO<List<PerfilCargoDTO>>> Lista(int idUsuario, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<PerfilCargoDTO>>>($"PerfilCargo/Lista/{idUsuario}/{buscar}");
        }
        public async Task<ResponseDTO<List<TipoContratoDTO>>> ListaTipoContrato(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<TipoContratoDTO>>>($"PerfilCargo/ListaTipoContrato/{buscar}");
        }

        public async Task<ResponseDTO<PerfilCargoDTO>> Obtener(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<PerfilCargoDTO>>($"PerfilCargo/Obtener/{Id}");
        }
    }
}
