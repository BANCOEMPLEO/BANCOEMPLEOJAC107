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

                            //propuestaEmpleo_encontrado.Cantidad -= dp.Cantidad;
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
                            // si la  cantidad de empleos ofrecidos menos la cantidad de propuestas aceptadas es mayor o igual a 1, se debe crear una propuesta nueva
                            var CantAceptadas = _dbContext.PropuestaEmpleos.Where(p => p.Aceptada == true && p.EmpleoId == propuestaEmpleo_encontrado.EmpleoId).Count();
                            var Propuesta = _dbContext.PropuestaEmpleos.Where(p => p.EmpleoId == propuestaEmpleo_encontrado.EmpleoId && p.Orden ==1).FirstOrDefault();
                            var CantPropuestas = _dbContext.PropuestaEmpleos.Where(p => p.EmpleoId == propuestaEmpleo_encontrado.EmpleoId).Count();
                            var CantEmpleosOfrecidos = _dbContext.Empleos.Where(e => e.IdEmpleo == propuestaEmpleo_encontrado.EmpleoId).FirstOrDefault().Cantidad;
                            // Se quita uno de Cantidad de Empleo ofrecido a la propuesta orden 1
                            Propuesta.Cantidad -= 1;

                            //if ( (CantEmpleosOfrecidos - CantAceptadas) >= 1)
                            //{
                            //    // Se cra una prouesta nueva con cantidad  = 1
                            //    PropuestaEmpleo propuestaEmpleo = new PropuestaEmpleo();
                            //    propuestaEmpleo.Nombre = Propuesta.Nombre;
                            //    propuestaEmpleo.Descripcion = Propuesta.Descripcion;
                            //    propuestaEmpleo.EmpleoId = Propuesta.EmpleoId;
                            //    propuestaEmpleo.Orden = CantPropuestas + 1;
                            //    propuestaEmpleo.Requisitos = Propuesta.Requisitos;
                            //    propuestaEmpleo.FechaHoraInicio = Propuesta.FechaHoraInicio;
                            //    propuestaEmpleo.FechaHoraFin = Propuesta.FechaHoraFin;
                            //    propuestaEmpleo.Ubicacion = Propuesta.Ubicacion;
                            //    propuestaEmpleo.Cantidad = 1;
                            //    propuestaEmpleo.Valor = Propuesta.Valor;
                            //    propuestaEmpleo.EmpleadorId = Propuesta.EmpleadorId;
                            //    propuestaEmpleo.EmpleadoId = Propuesta.EmpleadoId;
                            //    propuestaEmpleo.Observaciones = Propuesta.Observaciones;
                            //    propuestaEmpleo.Aceptada = false;
                            //    _dbContext.Update(propuestaEmpleo);
                            //    await _dbContext.SaveChangesAsync();
                            //}
                             // o sino se actualiza como activo false el empleo para que no aparezca en publico las propuestasEmpleo

                            var empleo =  _dbContext.Empleos.Where(e => e.IdEmpleo == propuestaEmpleo_encontrado.EmpleoId).FirstOrDefault();
                            //empleo.EmpleadoId = propuestaEmpleo_encontrado.EmpleadoId;
                            //empleo.EmpleadorId = propuestaEmpleo_encontrado.EmpleadorId;
                            if (Propuesta.Cantidad == 0)
                            {
                                empleo.Activo = false;
                                empleo.Observaciones = empleo.Observaciones + "::CANTIDAD PROPUESTAS CONTRATADAS EN FECHA Y HORA QUE SE INACTIVA:: ";
                                empleo.FechaHoraInactiva = DateTime.Now;
                            }
                            else
                            {
                                empleo.Observaciones = empleo.Observaciones + ":: UN EMPLEO CONTRATADO EN :"+ DateTime.Now + "-> FALTA(N) :(" + propuestaEmpleo_encontrado.Cantidad.ToString() + ") POR CONTRATAR::";
                            }
                            _dbContext.Update(empleo);
                            await _dbContext.SaveChangesAsync();

                            // Se graba Propuesta orden 1
                            _dbContext.Update(Propuesta);
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
