using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase;
using System.Collections.Generic;
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

        public async Task<ResponseDTO<ContratoDTO>> RegistrarEmpleo(ContratoDTO modelo, int UsuarioId)
        {
            var response = await _httpClient.PostAsJsonAsync($"Contrato/RegistrarEmpleo/{UsuarioId}", modelo );
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ContratoDTO>>();
            return result!;
        }
        public async Task<ResponseDTO<ContratoDTO>> RegistrarServicio(ContratoDTO modelo, int UsuarioId)
        {
            var response = await _httpClient.PostAsJsonAsync($"Contrato/RegistraServicio/{UsuarioId}", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ContratoDTO>>();
            return result!;
        }
        public async Task<ResponseDTO<List<ContratoDTO>>> Catalogo(int? UserId, int Categoria, string? buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ContratoDTO>>>($"Contrato/Catalogo/{UserId}/{Categoria}/{buscar}");
        }

        public async Task<ResponseDTO<ContratoDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ContratoDTO>>($"Contrato/Obtener/{id}");
        }
    }
}
