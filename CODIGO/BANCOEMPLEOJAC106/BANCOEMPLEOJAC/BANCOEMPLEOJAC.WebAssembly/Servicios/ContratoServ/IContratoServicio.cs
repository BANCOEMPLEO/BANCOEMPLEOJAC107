using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicios.Contrato
{
    public interface IContratoServicio
    {
        Task<ResponseDTO<ContratoDTO>> Registrar(ContratoDTO modelo);

    }
}
