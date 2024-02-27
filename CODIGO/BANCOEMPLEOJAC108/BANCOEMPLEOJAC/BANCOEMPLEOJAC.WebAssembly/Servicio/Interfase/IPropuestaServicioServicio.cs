using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IPropuestaServicioServicio
    {
        Task<ResponseDTO<List<PropuestaServicioDTO>>> Lista(string buscar);
        Task<ResponseDTO<List<PropuestaServicioDTO>>> Catalogo(string categoria, string buscar);
        Task<ResponseDTO<PropuestaServicioDTO>> Obtener(int Id);
        Task<ResponseDTO<PropuestaServicioDTO>> Crear(PropuestaServicioDTO modelo);
        Task<ResponseDTO<bool>> Editar(PropuestaServicioDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);

    }
}
