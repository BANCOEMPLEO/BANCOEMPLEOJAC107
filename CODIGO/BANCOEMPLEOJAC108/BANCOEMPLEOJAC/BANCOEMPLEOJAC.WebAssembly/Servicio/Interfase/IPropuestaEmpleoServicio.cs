using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IPropuestaEmpleoServicio
    {
        Task<ResponseDTO<List<PropuestaEmpleoDTO>>> Lista(string buscar);
        Task<ResponseDTO<List<PropuestaEmpleoDTO>>> ListaPorEmpleo(int idEmpleo);
        Task<ResponseDTO<List<PropuestaEmpleoDTO>>> Catalogo(int categoria, string buscar);
        Task<ResponseDTO<PropuestaEmpleoDTO>> Obtener(int Id);
        Task<ResponseDTO<PropuestaEmpleoDTO>> Crear(PropuestaEmpleoDTO modelo);
        Task<ResponseDTO<bool>> Editar(PropuestaEmpleoDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);

    }
}
