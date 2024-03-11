using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IContratoServicio
    {
        Task<ResponseDTO<ContratoDTO>> RegistrarEmpleo(ContratoDTO modelo);
        Task<ResponseDTO<ContratoDTO>> RegistrarServicio(ContratoDTO modelo);

    }
}
