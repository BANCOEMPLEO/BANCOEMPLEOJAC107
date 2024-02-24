using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IRolServicio
    {
        Task<ResponseDTO<List<RolDTO>>> Lista(string buscar);

    }
}
