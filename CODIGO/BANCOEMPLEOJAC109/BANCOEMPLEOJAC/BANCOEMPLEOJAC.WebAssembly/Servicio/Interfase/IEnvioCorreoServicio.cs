using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IEnvioCorreoServicio
    {
        Task<ResponseDTO<MensajeCorreoDTO>> Enviar(MensajeCorreoDTO modelo);

    }
}
