using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Modelo;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IJacServicio
    {
        Task<ResponseDTO<List<JacDTO>>> Lista(string buscar);
        Task<ResponseDTO<List<DepartamentoDTO>>> ListaDepartamentos(string buscar);
        Task<ResponseDTO<List<RegionesDTO>>> ListaRegiones(string buscar);
        Task<ResponseDTO<List<MunicipioDTO>>> ListaMunicipios(string buscar);
        Task<ResponseDTO<List<ZonaVeredaDTO>>> ListaZonaVeredas(string buscar);

        Task<ResponseDTO<JacDTO>> Obtener(int Id);
        Task<ResponseDTO<ZonaVeredaDTO>> ObtenerZonaVereda(string IdZonaVereda);
        Task<ResponseDTO<JacDTO>> Crear(JacDTO modelo);
        Task<ResponseDTO<ZonaVeredaDTO>> CrearZonaVereda(ZonaVeredaDTO modelo);
        Task<ResponseDTO<bool>> Editar(JacDTO modelo);
        Task<ResponseDTO<bool>> EditarZonaVereda(ZonaVeredaDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);

    }
}
