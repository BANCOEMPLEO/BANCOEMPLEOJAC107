using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase;
using System.Net.Http.Json;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Implementacion
{
    public class ActividadEconomicaServicio : IActividadEconomicaServicio
    {
        private readonly HttpClient _httpClient;
        public ActividadEconomicaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<ActividadEconomicaDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ActividadEconomicaDTO>>>($"ActividadEconomica/Lista/{buscar}");
        }
    }

}
