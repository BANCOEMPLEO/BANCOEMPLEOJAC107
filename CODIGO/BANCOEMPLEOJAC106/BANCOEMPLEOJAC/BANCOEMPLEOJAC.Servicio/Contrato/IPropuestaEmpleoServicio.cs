using BANCOEMPLEOJAC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Servicio.Contrato
{
    public interface IPropuestaEmpleoServicio
    {
        Task<List<PropuestaEmpleoDTO>> Lista(string buscar);
        Task<List<PropuestaEmpleoDTO>> PerfilCargo(string categoria, string buscar);
        Task<PropuestaEmpleoDTO> Obtener(int id);
        Task<PropuestaEmpleoDTO> Crear(PropuestaEmpleoDTO modelo);
        Task<PropuestaEmpleoDTO> RePropuesta(PropuestaEmpleoDTO modelo);
        Task<bool> Aceptada(PropuestaEmpleoDTO modelo);
        Task<bool> Editar(PropuestaEmpleoDTO modelo);
        Task<bool> Eliminar(int id);

    }
}
