using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.Repositorio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Repositorio.Contrato
{
    public interface IPropuestaEmpleoRepositorio : IGenericoRepositorio<PropuestaEmpleo>
    {
        Task<PropuestaEmpleo> Registrar(PropuestaEmpleo modelo);
    }
}
