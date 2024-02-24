using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicios.Contrato
{
    public interface IEmpleoServicio
    {
        Task<ResponseDTO<List<EmpleoDTO>>> Lista(string buscar);
        Task<ResponseDTO<List<EmpleoDTO>>> Catalogo(string categoria,string buscar);
        Task<ResponseDTO<EmpleoDTO>> Obtener(int Id);
        Task<ResponseDTO<EmpleoDTO>> Crear(EmpleoDTO modelo);
        Task<ResponseDTO<bool>> Editar(EmpleoDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);

    }
}
