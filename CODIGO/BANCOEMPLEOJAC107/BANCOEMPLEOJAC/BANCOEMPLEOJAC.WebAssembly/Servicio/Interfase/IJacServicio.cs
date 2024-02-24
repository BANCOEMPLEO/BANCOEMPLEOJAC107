using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IJacServicio
    {
        Task<ResponseDTO<List<JacDTO>>> Lista(string buscar);
        Task<ResponseDTO<JacDTO>> Obtener(int Id);
        Task<ResponseDTO<JacDTO>> Crear(JacDTO modelo);
        Task<ResponseDTO<bool>> Editar(JacDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);

    }
}
