using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.Repositorio.Contrato;
using BANCOEMPLEOJAC.Repositorio.DBContext;

namespace BANCOEMPLEOJAC.Repositorio.Implementacion
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
                    //foreach (DetallePropuesta dp in modelo.DetallePropuesta)
                    //{
                    //    PropuestaEmpleo propuestEmpleo_encontrado = _dbContext.PropuestaEmpleos.Where(p => p.Id == dp.Id).First();

                    //    propuestEmpleo_encontrado.c
                    //}
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
