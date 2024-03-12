using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IContratoServicio
    {
        Task<ResponseDTO<ContratoDTO>> RegistrarEmpleo(ContratoDTO modelo);
        Task<ResponseDTO<ContratoDTO>> RegistrarServicio(ContratoDTO modelo);
        Task<ResponseDTO<List<ContratoDTO>>> Catalogo(int? UserId, int Categoria, string? buscar);

    }
}
