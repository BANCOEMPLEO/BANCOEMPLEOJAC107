using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IContratoServicio
    {
        Task<ResponseDTO<ContratoDTO>> RegistrarEmpleo(ContratoDTO modelo, int UsuarioId);
        Task<ResponseDTO<ContratoDTO>> RegistrarServicio(ContratoDTO modelo, int UsuarioId);
        Task<ResponseDTO<List<ContratoDTO>>> Catalogo(int? UserId, int Categoria, string? buscar);
        Task<ResponseDTO<ContratoDTO>> Obtener(int id);

    }
}
