using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.Servicio.Contrato
{
    public interface IServicioServicio
    {
        Task<List<ServicioDTO>> Lista(string buscar);
        Task<List<ServicioDTO>> Catalogo(int categoria, string buscar);
        Task<ServicioDTO> Obtener(int id);
        Task<ServicioDTO> Crear(ServicioDTO modelo);
        Task<PropuestaServicioDTO> Propuesta(ServicioDTO modelo);
        Task<bool> Aceptada(ServicioDTO modelo);
        Task<bool> Editar(ServicioDTO modelo);
        Task<bool> Eliminar(int id);

    }
}
