using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANCOEMPLEOJAC.MODELO;
using BANCOEMPLEOJAC.Repositorio.Implementacion;
using BANCOEMPLEOJAC.REPOSITORIO.Contrato;
using BANCOEMPLEOJAC.REPOSITORIO.DBContext;

namespace BANCOEMPLEOJAC.REPOSITORIO.Implementacion
{
    public class PropuestaEmpleoRepositorio : GenericoRepositorio<PropuestaEmpleo>, IPropuestaEmpleoRepositorio
    {
        private readonly Bancoempleojac99Context _dbContext;

        public PropuestaEmpleoRepositorio(Bancoempleojac99Context dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
                
        }

        public async Task<PropuestaEmpleo> Registrar(PropuestaEmpleo modelo)
        {
            PropuestaEmpleo propuestaEmpleo = new PropuestaEmpleo();

            using(var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _dbContext.PropuestaEmpleos.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();
                    propuestaEmpleo = modelo;
                    transaction.Commit();
                }
                catch 
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return propuestaEmpleo;
        }
    }
}
