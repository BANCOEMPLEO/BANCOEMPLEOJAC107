using BANCOEMPLEOJAC.DTO;
namespace BANCOEMPLEOJAC.WebAssembly.Servicios.Contrato
{
    public interface IUsuarioServicio
    {
        Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar);
        Task<ResponseDTO<UsuarioDTO>> Obtener(int id);
        Task<ResponseDTO<SessionDTO>> Autorizacion(LoginDTO modelo);
        Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo);
        Task<ResponseDTO<bool>> Editar(UsuarioDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
