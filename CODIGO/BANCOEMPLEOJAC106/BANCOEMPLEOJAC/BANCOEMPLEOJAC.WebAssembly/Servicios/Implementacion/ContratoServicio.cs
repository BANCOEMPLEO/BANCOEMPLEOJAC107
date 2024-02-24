using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace BANCOEMPLEOJAC.WebAssembly.Servicios.Implementacion
{
    public class ContratoServicio :IContratoServicio
    {
        private readonly HttpClient _httpClient;
        public ContratoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<ContratoDTO>> Registrar(ContratoDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Contrato/Registrar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ContratoDTO>>();
            return result!;
        }
    }
}
