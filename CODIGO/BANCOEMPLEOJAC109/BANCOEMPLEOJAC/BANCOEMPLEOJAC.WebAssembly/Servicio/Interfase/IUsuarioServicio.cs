using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.WebAssembly.Servicio.Interfase
{
    public interface IUsuarioServicio
    {
        Task<ResponseDTO<List<UsuarioDTO>>> Lista(int rol, string buscar);
        Task<ResponseDTO<UsuarioEditaDTO>> Obtener(int Id);
        Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo);
        Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo);
        Task<ResponseDTO<bool>> Editar(UsuarioEditaDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int Id);


    }
}
