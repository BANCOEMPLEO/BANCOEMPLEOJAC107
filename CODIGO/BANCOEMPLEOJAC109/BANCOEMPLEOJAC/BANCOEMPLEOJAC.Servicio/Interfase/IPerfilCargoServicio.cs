using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Modelo;

namespace BANCOEMPLEOJAC.Servicio.Interfase
{
    public interface IPerfilCargoServicio
    {
        Task<List<PerfilCargoDTO>> Lista(int idUsuario, string buscar);
        Task<bool> VerificaPerfilEmpleoBorrar(int idUsuario, int idPerfilCargo);
        Task<List<TipoContratoDTO>> ListaTipoContrato(string buscar);
        Task<PerfilCargo> ConsultarPerfilCargoEnPropuestaEmpleo();

        Task<PerfilCargoDTO> Obtener(int id);
        Task<PerfilCargoDTO> Crear(PerfilCargoDTO modelo);
        Task<bool> Editar(PerfilCargoDTO modelo);
        Task<bool> Eliminar(int id);

    }
}
