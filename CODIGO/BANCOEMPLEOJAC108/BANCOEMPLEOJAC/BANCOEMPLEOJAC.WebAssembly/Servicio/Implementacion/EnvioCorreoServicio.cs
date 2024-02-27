using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase;
using System.Net.Http.Json;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Implementacion
{
    public class EnvioCorreoServicio : IEnvioCorreoServicio
    {
        private readonly HttpClient _httpClient;
        public EnvioCorreoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<MensajeCorreoDTO>> Enviar(MensajeCorreoDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("EnvioCorreo/Enviar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<MensajeCorreoDTO>>();
            return result!;

        }
    }
}
