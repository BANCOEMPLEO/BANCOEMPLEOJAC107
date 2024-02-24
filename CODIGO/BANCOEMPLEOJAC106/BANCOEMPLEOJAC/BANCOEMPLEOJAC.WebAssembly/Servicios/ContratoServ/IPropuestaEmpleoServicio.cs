using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicios.Contrato
{
    public interface IPropuestaEmpleoServicio
    {
        Task<ResponseDTO<List<PropuestaEmpleoDTO>>> Lista(string buscar);
        Task<ResponseDTO<List<PropuestaEmpleoDTO>>> Catalogo(string categoria, string buscar);
        Task<ResponseDTO<PropuestaEmpleoDTO>> Obtener(int Id);
        Task<ResponseDTO<PropuestaEmpleoDTO>> Crear(PropuestaEmpleoDTO modelo);
        Task<ResponseDTO<bool>> Editar(PropuestaEmpleoDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);

    }
}
