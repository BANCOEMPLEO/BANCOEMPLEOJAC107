using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.Repositorio.DBContext;
using BANCOEMPLEOJAC.Repositorio.Interfase;
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
        // POR HACER : QUE TRAIGA EL USUARIO PARA PONER EN PROPUESTAEMPLEO FECHA:16/MAR/2024 11:02AM
        public async Task<Contrato> Registrar(string tipo, Contrato modelo, int UsuarioId)
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
                            // Quita de propuestaEmpleo la cantidad contratada
                            PropuestaEmpleo propuestaEmpleo_encontrado = _dbContext.PropuestaEmpleos.Where(p => p.IdPropuestaEmpleo == dp.PropuestaEmpleoId).FirstOrDefault();

                            propuestaEmpleo_encontrado.Cantidad = propuestaEmpleo_encontrado.Cantidad - dp.Cantidad;
                            propuestaEmpleo_encontrado.Aceptada = true;
                            if (propuestaEmpleo_encontrado.EmpleadoId == null)
                            {
                                propuestaEmpleo_encontrado.EmpleadoId = UsuarioId;
                            }
                            if (propuestaEmpleo_encontrado.EmpleadorId == null)
                            {
                                propuestaEmpleo_encontrado.EmpleadorId = UsuarioId;
                            }
                            propuestaEmpleo_encontrado.FechaHoraAceptaEmpleador = DateTime.Now;
                            _dbContext.Update(propuestaEmpleo_encontrado);
                            await _dbContext.SaveChangesAsync();

                            // POR HACER : ACTUALIZAR EMPLEO CON EL IDEMPLEADOR Y IDEMPLEADO Y DESACTIVARLO FECHA: 13/MAR/2024 2:02PM
                            var empleo =  _dbContext.Empleos.Where(e => e.IdEmpleo == propuestaEmpleo_encontrado.EmpleoId).FirstOrDefault();
                            empleo.EmpleadoId = propuestaEmpleo_encontrado.EmpleadoId;
                            empleo.EmpleadorId = propuestaEmpleo_encontrado.EmpleadorId;
                            if (propuestaEmpleo_encontrado.Cantidad == 0)
                            {
                                empleo.Activo = false;
                                empleo.Observaciones = empleo.Observaciones + "::EMPLEO CONTRATADO EN FECHA Y HORA QUE SE INACTIVA:: ";
                            }
                            else
                            {
                                empleo.Observaciones = empleo.Observaciones + ":: UN EMPLEO CONTRATADO EN :"+ DateTime.Now + "-> FALTA(N) :(" + propuestaEmpleo_encontrado.Cantidad.ToString() + ") POR CONTRATAR::";
                            }
                            empleo.FechaHoraInactiva = DateTime.Now;
                            _dbContext.Update(empleo);
                            await _dbContext.SaveChangesAsync();

                        }
                        //if(tipo == "Servicio")
                        //{
                        //    PropuestaServicio propuestaServicio_encontrado = _dbContext.PropuestaServicios.Where(p => p.IdPropuestaServicio == dp.PropuestaServicioId).First();

                        //    propuestaServicio_encontrado.Cantidad = propuestaServicio_encontrado.Cantidad - dp.Cantidad;
                        //    _dbContext.Update(propuestaServicio_encontrado);

                        //}
                    }


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
