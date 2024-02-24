using BANCOEMPLEOJAC.DTO;


namespace BANCOEMPLEOJAC.WebAssembly.Servicios.Contrato
{
    public interface IVentaServicio
    {
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);

    }
}
