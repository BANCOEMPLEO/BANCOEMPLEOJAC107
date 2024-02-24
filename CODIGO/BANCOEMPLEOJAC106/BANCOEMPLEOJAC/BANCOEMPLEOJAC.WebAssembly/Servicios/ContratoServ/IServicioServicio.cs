using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicios.Contrato
{
    public interface IServicioServicio
    {
        Task<ResponseDTO<List<ServicioDTO>>> Lista(string buscar);
        Task<ResponseDTO<List<ServicioDTO>>> Catalogo(string categoria, string buscar);
        Task<ResponseDTO<ServicioDTO>> Obtener(int Id);
        Task<ResponseDTO<ServicioDTO>> Crear(ServicioDTO modelo);
        Task<ResponseDTO<bool>> Editar(ServicioDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);

    }
}
