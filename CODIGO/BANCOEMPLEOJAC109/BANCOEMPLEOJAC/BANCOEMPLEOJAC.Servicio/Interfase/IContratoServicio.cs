using BANCOEMPLEOJAC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Servicio.Contrato
{
    public interface IContratoServicio
    {
        Task<ContratoDTO> Registrar(string tipo, ContratoDTO modelo, int UsuarioId);
        Task<List<ContratoDTO>> PerfilCargo(int UserId, int? categoria, string? buscar);
        Task<ContratoDTO> Obtener(int id);

    }
}
