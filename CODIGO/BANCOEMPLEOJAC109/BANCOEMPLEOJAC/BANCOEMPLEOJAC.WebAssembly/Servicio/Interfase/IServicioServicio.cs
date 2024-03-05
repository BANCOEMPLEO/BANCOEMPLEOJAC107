using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IServicioServicio
    {
        Task<ResponseDTO<List<ServicioDTO>>> Lista(string buscar);
        Task<ResponseDTO<List<ServicioDTO>>> Catalogo(int categoria, string buscar);
        Task<ResponseDTO<ServicioDTO>> Obtener(int Id);
        Task<ResponseDTO<ServicioDTO>> Crear(ServicioDTO modelo);
        Task<ResponseDTO<bool>> Editar(ServicioDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);

    }
}
