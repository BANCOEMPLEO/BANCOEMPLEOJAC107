using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IActividadEconomicaServicio
    {
        Task<ResponseDTO<List<ActividadEconomicaDTO>>> Lista( string buscar);
    }
}
