using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase;
using System.Net.Http.Json;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Implementacion
{
    public class DistanciaLatLonServicio : IDistanciaLatLonServicio
    {
        private readonly HttpClient _httpClient;

        public DistanciaLatLonServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<double> CalcularDistancia(DistanciaDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("CalcularDistancia/Consultar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<double>>();
            return result.Resultado!;
        }
    }
}
