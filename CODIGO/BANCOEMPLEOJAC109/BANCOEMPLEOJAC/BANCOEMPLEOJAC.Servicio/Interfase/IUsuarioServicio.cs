using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.Servicio.Interfase
{
    public interface IUsuarioServicio
    {
        Task<List<UsuarioDTO>> Lista(int rol, string buscar, int RolId);
        Task<UsuarioDTO> Obtener(int id);
        Task<SesionDTO> Autorizacion(LoginDTO modelo);
        Task<UsuarioDTO> Crear(UsuarioDTO modelo);
        Task<bool> Editar(UsuarioEditaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
