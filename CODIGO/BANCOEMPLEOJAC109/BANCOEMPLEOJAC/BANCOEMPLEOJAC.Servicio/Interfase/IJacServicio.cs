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
        Task<List<DepartamentoDTO>> ListaDepartamentos(string buscar);
        Task<List<RegionesDTO>> ListaRegiones(string buscar);
        Task<List<MunicipioDTO>> ListaMunicipios(string buscar);
        Task<List<ZonaVeredaDTO>> ListaZonaVeredas(string buscar);
        Task<JacDTO> Obtener(int id);
        Task<ZonaVeredaDTO> ObtenerZonaVereda(string idZonaVereda);
        Task<JacDTO> Crear(JacDTO modelo);
        Task<ZonaVeredaDTO> CrearZonaVereda(ZonaVeredaDTO modelo);
        Task<bool> Editar(JacDTO modelo);
        Task<bool> EditarZonaVereda(ZonaVeredaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
