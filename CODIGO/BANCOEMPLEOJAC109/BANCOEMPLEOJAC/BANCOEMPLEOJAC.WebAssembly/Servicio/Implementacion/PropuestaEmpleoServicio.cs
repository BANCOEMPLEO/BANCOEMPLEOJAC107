using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase;
using System.Net.Http.Json;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Implementacion
{
    public class PropuestaEmpleoServicio : IPropuestaEmpleoServicio
    {
        private readonly HttpClient _httpClient;
        public PropuestaEmpleoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<PropuestaEmpleoDTO>>> Catalogo(int categoria, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<PropuestaEmpleoDTO>>>($"PropuestaEmpleo/Catalogo/{categoria}/{buscar}");
        }

        public async Task<ResponseDTO<PropuestaEmpleoDTO>> Crear(PropuestaEmpleoDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("PropuestaEmpleo/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<PropuestaEmpleoDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(PropuestaEmpleoDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("PropuestaEmpleo/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int Id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"PropuestaEmpleo/Eliminar/{Id}");
        }

        public async Task<ResponseDTO<List<PropuestaEmpleoDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<PropuestaEmpleoDTO>>>($"PropuestaEmpleo/Lista/{buscar}");
        }
        public async Task<ResponseDTO<List<PropuestaEmpleoDTO>>> ListaPorEmpleo(int idEmpleo)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<PropuestaEmpleoDTO>>>($"PropuestaEmpleo/ListaPorEmpleo/{idEmpleo}");
        }

        public async Task<ResponseDTO<PropuestaEmpleoDTO>> Obtener(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<PropuestaEmpleoDTO>>($"PropuestaEmpleo/Obtener/{Id}");
        }
        public async Task<ResponseDTO<int?>> ObtenerAnterior(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<int?>>($"PropuestaEmpleo/ObtenerAnterior/{Id}");
        }
    }
}
