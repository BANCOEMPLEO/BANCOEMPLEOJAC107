using BANCOEMPLEOJAC.DTO;


namespace BANCOEMPLEOJAC.WebAssembly.Servicios.Contrato
{
    public interface IDashboardServicio
    {
        Task<ResponseDTO<DashboardDTO>> Resumen();

    }
}
