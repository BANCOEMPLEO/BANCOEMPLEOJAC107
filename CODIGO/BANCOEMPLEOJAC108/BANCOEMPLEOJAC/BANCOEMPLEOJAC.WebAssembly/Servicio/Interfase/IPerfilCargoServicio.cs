using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IPerfilCargoServicio
    {
        Task<ResponseDTO<List<PerfilCargoDTO>>> Lista(string buscar);
        Task<ResponseDTO<PerfilCargoDTO>> Obtener(int Id);
        Task<ResponseDTO<PerfilCargoDTO>> Crear(PerfilCargoDTO modelo);
        Task<ResponseDTO<bool>> Editar(PerfilCargoDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);

    }
}
