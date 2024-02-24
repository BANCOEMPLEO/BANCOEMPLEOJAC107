using BANCOEMPLEOJAC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Servicio.Contrato
{
    public interface IJacServicio
    {
        Task<List<JacDTO>> Lista(string buscar);
        Task<JacDTO> Obtener(int id);
        Task<JacDTO> Crear(JacDTO modelo);
        Task<bool> Editar(JacDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
