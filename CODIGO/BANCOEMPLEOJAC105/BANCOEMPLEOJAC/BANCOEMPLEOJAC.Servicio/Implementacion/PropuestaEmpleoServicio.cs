using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Repositorio.Contrato;
using BANCOEMPLEOJAC.Servicio.Contrato;
using AutoMapper;
using BANCOEMPLEOJAC.Utilidades;


namespace BANCOEMPLEOJAC.Servicio.Implementacion
{
    public class PropuestaEmpleoServicio : IPropuestaEmpleoServicio
    {
        private readonly IGenericoRepositorio<PropuestaEmpleoDTO> _modeloRepositorio;
        private readonly IMapper _mapper;

        public PropuestaEmpleoServicio(IGenericoRepositorio<PropuestaEmpleoDTO> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;

        }

        public async Task<PropuestaEmpleoDTO> Crear(PropuestaEmpleoDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<PropuestaEmpleoDTO>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.Id != 0)
                    return _mapper.Map<PropuestaEmpleoDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se puede crear");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<PropuestaEmpleoDTO>> PerfilCargo(string categoria, string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Descripcion.ToLower().Contains(buscar.ToLower()) &&
                string.Concat(p.Empleo.PerfilCargo.Descripcion.ToLower()).Contains(categoria.ToLower())
                );

                List<PropuestaEmpleoDTO> lista = _mapper.Map<List<PropuestaEmpleoDTO>>(await consulta.ToListAsync());
                return lista;
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
                var consulta = _modeloRepositorio.Consultar(p => p.Id == modelo.Id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.PropuestaEmpleoAnteriorId = modelo.PropuestaEmpleoAnteriorId;
                    fromDbModelo.Orden = modelo.Orden;
                    fromDbModelo.EmpleoId = modelo.EmpleoId;
                    fromDbModelo.FechaHoraAceptaEmpleador = modelo.FechaHoraAceptaEmpleador;
                    fromDbModelo.FechaHoraInicio = modelo.FechaHoraInicio;
                    fromDbModelo.FechaHoraFin = modelo.FechaHoraFin;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Valor = modelo.Valor;
                    fromDbModelo.FechaHoraReProponeEmpleador = modelo.FechaHoraReProponeEmpleador;
                    fromDbModelo.FechaHoraAceptaEmpleador = modelo.FechaHoraAceptaEmpleador;
                    fromDbModelo.Aceptada = modelo.Aceptada;
                    fromDbModelo.EmpleadoId = modelo.EmpleadoId;
                    fromDbModelo.Observaciones = modelo.Observaciones;
                    fromDbModelo.RePropone = modelo.RePropone;
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
                var consulta = _modeloRepositorio.Consultar(p => p.Id == id);
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
                string.Concat(p.Descripcion.ToLower(), p.Requisitos.ToLower(), p.Ubicacion.ToLower(), p.Observaciones.ToLower()).Contains(buscar.ToLower())
                );

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
                var consulta = _modeloRepositorio.Consultar(p => p.Id == id);
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

        public async Task<PropuestaEmpleoDTO> RePropuesta(PropuestaEmpleoDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.Id == modelo.Id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.PropuestaEmpleoAnteriorId= modelo.Id;
                    fromDbModelo.Orden = modelo.Orden + 1;
                    fromDbModelo.EmpleoId = modelo.EmpleoId;
                    fromDbModelo.FechaHoraAceptaEmpleador = modelo.FechaHoraAceptaEmpleador;
                    fromDbModelo.FechaHoraInicio = modelo.FechaHoraInicio;
                    fromDbModelo.FechaHoraFin = modelo.FechaHoraFin;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Valor = modelo.Valor;
                    fromDbModelo.FechaHoraReProponeEmpleador = modelo.FechaHoraReProponeEmpleador;
                    fromDbModelo.FechaHoraAceptaEmpleador = modelo.FechaHoraAceptaEmpleador;
                    fromDbModelo.Aceptada = modelo.Aceptada;
                    fromDbModelo.EmpleadoId = modelo.EmpleadoId;
                    fromDbModelo.Observaciones = modelo.Observaciones;
                    fromDbModelo.RePropone = modelo.RePropone;
                    var respuesta = await _modeloRepositorio.Crear(fromDbModelo);

                    if (respuesta.Id != 0)
                        return _mapper.Map<PropuestaEmpleoDTO>(fromDbModelo);
                    else
                        throw new TaskCanceledException("No se puede crear");
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

        public async Task<bool> Aceptada(PropuestaEmpleoDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.Id == modelo.Id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Aceptada = true;
                    fromDbModelo.FechaHoraAceptaEmpleador = DateTime.Now;
                    var respuesta = await _modeloRepositorio.Editar(fromDbModelo);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo Aceptar");
                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados Aceptar");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
