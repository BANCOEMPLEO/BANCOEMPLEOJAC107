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

                consulta = consulta.Include(c => c.Empleo);

                List<PropuestaEmpleoDTO> lista = _mapper.Map<List<PropuestaEmpleoDTO>>(await consulta.ToListAsync());
                return lista;
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
                var consulta = _modeloRepositorio.Consultar(p => p.IdPropuestaEmpleo == id);
                consulta = consulta.Include(c => c.Empleo);

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

        public async Task<List<PropuestaEmpleoDTO>> Catalogo(int categoria, string buscar)
        {
            try
            {

                var consulta = _modeloRepositorio.Consultar();
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
                var consulta = _modeloRepositorio.Consultar();
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
