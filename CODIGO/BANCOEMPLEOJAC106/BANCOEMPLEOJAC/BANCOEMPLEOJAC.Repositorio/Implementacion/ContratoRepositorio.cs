using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.Repositorio.ContratoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Repositorio.Implementacion
{
    public class ContratoRepositorio : GenericoRepositorio<Contrato>, IContratoRepositorio
    {
        private readonly Bancoempleojac99Context _dbContext;

        public ContratoRepositorio(Bancoempleojac99Context dbContetxt) : base(dbContetxt)
        {
            _dbContext = dbContetxt;
        }

        public async Task<Contrato> Registrar(string tipo, Contrato modelo)
        {
            Contrato ContratoGenerado = new Contrato();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetallePropuesta dp in modelo.DetallePropuesta)
                    {
                        if(tipo == "Empleo")
                        {
                            PropuestaEmpleo propuestaEmpleo_encontrado = _dbContext.PropuestaEmpleos.Where(p => p.IdPropuestaEmpleo == dp.PropuestaEmpleoId).First();

                            propuestaEmpleo_encontrado.Cantidad = propuestaEmpleo_encontrado.Cantidad - dp.Cantidad;
                            _dbContext.Update(propuestaEmpleo_encontrado);
                        }
                        if(tipo == "Servicio")
                        {
                            PropuestaServicio propuestaServicio_encontrado = _dbContext.PropuestaServicios.Where(p => p.IdPropuestaServicio == dp.PropuestaServicioId).First();

                            propuestaServicio_encontrado.Cantidad = propuestaServicio_encontrado.Cantidad - dp.Cantidad;
                            _dbContext.Update(propuestaServicio_encontrado);

                        }
                    }
                    await _dbContext.SaveChangesAsync();


                    await _dbContext.Contratos.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();
                    ContratoGenerado = modelo;
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return ContratoGenerado;
        }
    }
}
