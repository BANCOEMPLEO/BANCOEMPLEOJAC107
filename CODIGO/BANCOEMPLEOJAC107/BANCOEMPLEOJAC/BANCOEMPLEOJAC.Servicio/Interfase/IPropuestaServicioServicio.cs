using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.Servicio.Contrato
{
    public interface IPropuestaServicioServicio
    {
        Task<List<PropuestaServicioDTO>> Lista(string buscar);
        Task<List<PropuestaServicioDTO>> Categoria(int categoria, string buscar);
        Task<PropuestaServicioDTO> Obtener(int id);
        Task<PropuestaServicioDTO> Crear(PropuestaServicioDTO modelo);
        Task<PropuestaServicioDTO> RePropuesta(PropuestaServicioDTO modelo);
        Task<bool> Aceptada(PropuestaServicioDTO modelo);
        Task<bool> Editar(PropuestaServicioDTO modelo);
        Task<bool> Eliminar(int id);

    }
}
