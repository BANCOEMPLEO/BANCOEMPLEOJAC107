using BANCOEMPLEOJAC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Servicio.Contrato
{
    public interface IEmpleoServicio
    {
        Task<List<EmpleoDTO>> Lista(string buscar);
        Task<List<EmpleoDTO>> Catalogo(string categoria, string buscar);
        Task<EmpleoDTO> Obtener(int id);
        Task<EmpleoDTO> Crear(EmpleoDTO modelo);
        Task<PropuestaEmpleoDTO> Propuesta(EmpleoDTO modelo);
        Task<bool> Editar(EmpleoDTO modelo);
        Task<bool> Activar(EmpleoDTO modelo);
        Task<bool> Desactivar(EmpleoDTO modelo);
        Task<bool> Eliminar(int id);

    }
}
