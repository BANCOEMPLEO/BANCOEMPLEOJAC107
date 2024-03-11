using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase;
using System.Net.Http.Json;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Implementacion
{
    public class ContratoServicio :IContratoServicio
    {
        private readonly HttpClient _httpClient;
        public ContratoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<ContratoDTO>> RegistrarEmpleo(ContratoDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Contrato/RegistrarEmpleo", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ContratoDTO>>();
            return result!;
        }
        public async Task<ResponseDTO<ContratoDTO>> RegistrarServicio(ContratoDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Contrato/RegistraServicio", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ContratoDTO>>();
            return result!;
        }
    }
}
