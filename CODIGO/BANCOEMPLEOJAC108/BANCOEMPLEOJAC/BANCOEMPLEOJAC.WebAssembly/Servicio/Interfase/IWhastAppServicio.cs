using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IWhastAppServicio
    {
        Task<ResponseDTO<MensajeWhastAppDTO>> Enviar(MensajeWhastAppDTO modelo);
    }
}
