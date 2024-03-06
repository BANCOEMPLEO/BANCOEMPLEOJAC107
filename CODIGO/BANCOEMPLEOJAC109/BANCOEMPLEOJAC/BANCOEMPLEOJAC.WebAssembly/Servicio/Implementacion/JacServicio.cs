using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase;
using System.Net.Http.Json;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Implementacion
{
    public class JacServicio : IJacServicio 
    {
        private readonly HttpClient _httpClient;
        public JacServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<JacDTO>> Crear(JacDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Jac/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<JacDTO>>();
            return result!;
        }
        public async Task<ResponseDTO<ZonaVeredaDTO>> CrearZonaVereda(ZonaVeredaDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Jac/CrearZonaVereda", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ZonaVeredaDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(JacDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("Jac/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int Id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Jac/Eliminar/{Id}");
        }

        public async Task<ResponseDTO<List<JacDTO>>> Lista(string buscar)
        {
            var response = await _httpClient.GetFromJsonAsync<ResponseDTO<List<JacDTO>>>($"Jac/Lista/{buscar}");
            return response;
        }

        public async Task<ResponseDTO<List<DepartamentoDTO>>> ListaDepartamentos(string buscar)
        {
            var response = await _httpClient.GetFromJsonAsync<ResponseDTO<List<DepartamentoDTO>>>($"Jac/ListaDepartamentos/{buscar}");
            return response;
        }

        public async Task<ResponseDTO<List<RegionesDTO>>> ListaRegiones(string buscar)
        {
            var response = await _httpClient.GetFromJsonAsync<ResponseDTO<List<RegionesDTO>>>($"Jac/ListaRegiones/{buscar}");
            return response;
        }

        public async Task<ResponseDTO<List<MunicipioDTO>>> ListaMunicipios(string buscar)
        {
            var response = await _httpClient.GetFromJsonAsync<ResponseDTO<List<MunicipioDTO>>>($"Jac/ListaMunicipios/{buscar}");
            return response;
        }

        public async Task<ResponseDTO<List<ZonaVeredaDTO>>> ListaZonaVeredas(string buscar)
        {
            var response = await _httpClient.GetFromJsonAsync<ResponseDTO<List<ZonaVeredaDTO>>>($"Jac/ListaZonaVeredas/{buscar}");
            return response;
        }

        public async Task<ResponseDTO<JacDTO>> Obtener(int Id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<JacDTO>>($"Jac/Obtener/{Id}");
        }
    }
}
