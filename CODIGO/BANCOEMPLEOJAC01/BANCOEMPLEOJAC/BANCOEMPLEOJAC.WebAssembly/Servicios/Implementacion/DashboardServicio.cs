using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace BANCOEMPLEOJAC.WebAssembly.Servicios.Implementacion
{
    public class DashboardServicio : IDashboardServicio
    {
        private readonly HttpClient _httpClient;
        public DashboardServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<DashboardDTO>> Resumen()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashboardDTO>>($"Dashboard/Resumen");
        }
    }
}
