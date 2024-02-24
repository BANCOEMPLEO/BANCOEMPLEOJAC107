using BANCOEMPLEOJAC.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Repositorio.ContratoRepo
{
    public interface IContratoRepositorio : IGenericoRepositorio<Contrato>
    {
        Task<Contrato> Registrar(string tipo, Contrato modelo);
    }
}
