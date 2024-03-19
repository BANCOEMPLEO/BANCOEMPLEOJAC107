using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Repositorio.Interfase;
using BANCOEMPLEOJAC.Servicio.Contrato;
using AutoMapper;
using BANCOEMPLEOJAC.Utilidades;


namespace BANCOEMPLEOJAC.Servicio.Implementacion
{
    public class PropuestaEmpleoServicio : IPropuestaEmpleoServicio
    {
        private readonly IGenericoRepositorio<PropuestaEmpleo> _modeloRepositorio;
        //private readonly IGenericoRepositorio<Empleo> _empleoRepositorio;
        private readonly IMapper _mapper;

        public PropuestaEmpleoServicio(IGenericoRepositorio<PropuestaEmpleo> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;

        }

        public async Task<PropuestaEmpleoDTO> Crear(PropuestaEmpleoDTO modelo)
        {
            try
            {
                if (modelo.IdPropuestaEmpleo == 0)
                    modelo.IdPropuestaEmpleo = null;
                var dbModelo = _mapper.Map<PropuestaEmpleo>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdPropuestaEmpleo != 0)
                    return _mapper.Map<PropuestaEmpleoDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se puede crear");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Editar(PropuestaEmpleoDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdPropuestaEmpleo == modelo.IdPropuestaEmpleo);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.PropuestaEmpleoAnteriorId = modelo.PropuestaEmpleoAnteriorId;
                    fromDbModelo.EmpleoId = modelo.EmpleoId;
                    fromDbModelo.Orden = modelo.Orden;
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Requisitos = modelo.Requisitos;
                    fromDbModelo.FechaHoraInicio = modelo.FechaHoraInicio;
                    fromDbModelo.FechaHoraFin = modelo.FechaHoraFin;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Observaciones = modelo.Observaciones;
                    fromDbModelo.Valor = modelo.Valor;
                    fromDbModelo.EmpleadoId = modelo.EmpleadoId;
                    fromDbModelo.EmpleadorId = modelo.EmpleadorId;
                    fromDbModelo.FechaHoraRevisaEmpleador = modelo.FechaHoraRevisaEmpleador;
                    fromDbModelo.FechaHoraReProponeEmpleador = modelo.FechaHoraReProponeEmpleador;
                    fromDbModelo.RePropone = modelo.RePropone;
                    fromDbModelo.Aceptada = modelo.Aceptada;
                    fromDbModelo.Observaciones = modelo.Observaciones;
                    var respuesta = await _modeloRepositorio.Editar(fromDbModelo);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo editar");
                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdPropuestaEmpleo == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    var respuesta = await _modeloRepositorio.Eliminar(fromDbModelo);
                    if (!respuesta) throw new TaskCanceledException("No se pudo eliminar");
                    return respuesta;
                }
                else
                    throw new TaskCanceledException("No se encontraron Resultados");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<PropuestaEmpleoDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Descripcion.ToLower().Contains(buscar.ToLower())
                );

                consulta = consulta.Include(c => c.Empleo).Include(p => p.Empleo.PerfilCargo)
                    .Where(p => p.Empleo.Activo == true);

                List<PropuestaEmpleoDTO> lista = _mapper.Map<List<PropuestaEmpleoDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmpleoEstadoDTO> EstadoPorEmpleo(int idEmpleo)
        {
            try
            {
                EmpleoEstadoDTO estado = new EmpleoEstadoDTO();
                estado.Propuestas = _modeloRepositorio.Consultar(p => p.EmpleoId == idEmpleo).Count();
                estado.Contratado = _modeloRepositorio.Consultar(p => p.EmpleoId == idEmpleo).Where(c => c.Aceptada == true).Count();
                estado.Vacante = 0; // _modeloRepositorio.Consultar(p => p.EmpleoId == idEmpleo).Where(c => c.Aceptada != true).Count();
                estado.EnVerificacion = _modeloRepositorio.Consultar(p => p.EmpleoId == idEmpleo).Where(c => c.Aceptada != true).
                    Where(e => e.EmpleadorId != null && e.EmpleadoId != null).Count();
                //                consulta = consulta.Include(c => c.Empleo);
                //estado.EnVerificacion = 0;
                
                return estado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PropuestaEmpleoDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdPropuestaEmpleo == id)
                    .Include(c => c.Empleo).ThenInclude(p => p.PerfilCargo).ThenInclude(j => j.Jac);


                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<PropuestaEmpleoDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int?> ObtenerAnterior(int Orden, int id)
        {
            try
            {
                if (Orden > 1)
                {
                    Orden -= 1;
                }
                else return null;
                var consulta = _modeloRepositorio.Consultar(p => p.EmpleoId == id && p.Orden == Orden);
                if (consulta.Count() > 0)
                {
                    var fromDbModelo = await consulta.FirstOrDefaultAsync();
                    if (fromDbModelo != null)
                    {
                        var idAnterior = fromDbModelo.IdPropuestaEmpleo;
                        return idAnterior;
                    }
                    else
                        return null;

                }
                else
                {
                    return null;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<int?> ObtenerSiguiente(int Orden, int id)
        {
            try
            {
                if (Orden >= 1)
                {
                    Orden += 1;
                }
                var consulta = _modeloRepositorio.Consultar(p => p.EmpleoId == id && p.Orden == Orden);
                if (consulta.Count() > 0)
                {
                    var fromDbModelo = await consulta.FirstOrDefaultAsync();
                    if (fromDbModelo != null)
                    {
                        var idSiguiente = fromDbModelo.IdPropuestaEmpleo;
                        return idSiguiente;
                    }
                    else
                        return null;

                }
                else
                {
                    return null;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<PropuestaEmpleoDTO>> Catalogo(int categoria, string buscar)
        {
            try
            {

                var consulta = _modeloRepositorio.Consultar(r => r.RePropone != true && r.Cantidad > 0);
                consulta = consulta.Include(e => e.Empleo).ThenInclude(e => e.PerfilCargo)
                    .ThenInclude(j => j.Jac).ThenInclude(z => z.IdZonaVeredaNavigation);
                //consulta = consulta.Include("PerfilCargo");
                // consulta.
                //if (buscar != null)
                //    consulta = consulta.Where(c => c.Nombre.Contains(buscar) || c.Requisitos.Contains(buscar));
                //if (categoria > 0)
                //    consulta = consulta.Where(c => c.Empleo.PerfilCargoId == categoria);

                //var consulta = _modeloRepositorio.Consultar(p =>
                //p.Descripcion.ToLower().Contains(buscar.ToLower()) &&
                //p.Empleo.Descripcion.ToLower().Contains(categoria.ToLower())
                //);

                List<PropuestaEmpleoDTO> lista = _mapper.Map<List<PropuestaEmpleoDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<PropuestaEmpleoDTO>> PerfilCargo(int categoria, string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar().
                    Include(e => e.Empleo).
                    ThenInclude(pc => pc.PerfilCargo).
                    Where(pe => pe.Empleo.Activo == true && pe.RePropone != true && pe.Cantidad > 0);
                if (buscar != null)
                    consulta = consulta.Where(c => c.Nombre.Contains(buscar) || c.Requisitos.Contains(buscar));
                if (categoria > 0)
                    consulta = consulta.Where(c => c.Empleo.PerfilCargoId == categoria);

                //var consulta = _modeloRepositorio.Consultar(p =>
                //p.Descripcion.ToLower().Contains(buscar.ToLower()) &&
                //p.Empleo.Descripcion.ToLower().Contains(categoria.ToLower())
                //);

                List<PropuestaEmpleoDTO> lista = _mapper.Map<List<PropuestaEmpleoDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PropuestaEmpleoDTO> RePropuesta(PropuestaEmpleoDTO modelo)
        {
            try
            {
                modelo.PropuestaEmpleoAnteriorId = modelo.IdPropuestaEmpleo;
                var dbModelo = _mapper.Map<PropuestaEmpleo>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdPropuestaEmpleo != 0)
                    return _mapper.Map<PropuestaEmpleoDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se puede crear RePropuesta Empleo");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Aceptada(PropuestaEmpleoDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdPropuestaEmpleo == modelo.IdPropuestaEmpleo);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.PropuestaEmpleoAnteriorId = modelo.PropuestaEmpleoAnteriorId;
                    fromDbModelo.EmpleoId = modelo.EmpleoId;
                    fromDbModelo.Orden = modelo.Orden;
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Requisitos = modelo.Requisitos;
                    fromDbModelo.FechaHoraInicio = modelo.FechaHoraInicio;
                    fromDbModelo.FechaHoraFin = modelo.FechaHoraFin;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Observaciones = modelo.Observaciones;
                    fromDbModelo.Valor = modelo.Valor;
                    fromDbModelo.EmpleadoId = modelo.EmpleadoId;
                    fromDbModelo.EmpleadorId = modelo.EmpleadorId;
                    fromDbModelo.FechaHoraRevisaEmpleador = modelo.FechaHoraRevisaEmpleador;
                    fromDbModelo.FechaHoraReProponeEmpleador = modelo.FechaHoraReProponeEmpleador;
                    fromDbModelo.RePropone = modelo.RePropone;
                    fromDbModelo.Aceptada = true;
                    fromDbModelo.Observaciones = modelo.Observaciones;
                    var respuesta = await _modeloRepositorio.Editar(fromDbModelo);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo editar");
                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
