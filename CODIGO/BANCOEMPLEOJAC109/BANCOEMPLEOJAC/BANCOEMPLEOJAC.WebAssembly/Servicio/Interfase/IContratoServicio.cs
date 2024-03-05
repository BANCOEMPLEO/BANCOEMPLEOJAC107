using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IContratoServicio
    {
        Task<ResponseDTO<ContratoDTO>> Registrar(ContratoDTO modelo);

    }
}
