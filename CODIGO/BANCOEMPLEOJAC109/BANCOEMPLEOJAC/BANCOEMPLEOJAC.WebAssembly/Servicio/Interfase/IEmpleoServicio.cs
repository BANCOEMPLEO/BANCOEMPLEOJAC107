using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IEmpleoServicio
    {
        Task<ResponseDTO<List<EmpleoDTO>>> Lista(int idUsuario,string buscar);
        Task<ResponseDTO<List<EmpleoDTO>>> Catalogo(string categoria,string buscar);
        Task<ResponseDTO<EmpleoDTO>> Obtener(int Id);
        Task<ResponseDTO<EmpleoDTO>> Crear(EmpleoDTO modelo);
        Task<ResponseDTO<bool>> Activar(EmpleoDTO modelo);
        Task<ResponseDTO<bool>> Desactivar(EmpleoDTO modelo);
        Task<ResponseDTO<bool>> Editar(EmpleoDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);

    }
}
