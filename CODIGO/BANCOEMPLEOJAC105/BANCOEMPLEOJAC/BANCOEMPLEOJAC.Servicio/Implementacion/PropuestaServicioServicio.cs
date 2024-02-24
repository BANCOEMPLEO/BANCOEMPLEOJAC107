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

namespace BANCOEMPLEOJAC.Servicio.Implementacion
{
    public class PropuestaServicioServicio : IPropuestaServicioServicio
    {
        private readonly IGenericoRepositorio<PropuestaServicioDTO> _modeloRepositorio;
        private readonly IMapper _mapper;

        public PropuestaServicioServicio(IGenericoRepositorio<PropuestaServicioDTO> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;

        }

        public async Task<PropuestaServicioDTO> Crear(PropuestaServicioDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<PropuestaServicioDTO>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.Id != 0)
                    return _mapper.Map<PropuestaServicioDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se puede crear");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<PropuestaServicioDTO>> PerfilCargo(string categoria, string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Descripcion.ToLower().Contains(buscar.ToLower()) &&
                string.Concat(p.Servicio.PerfilCargo.Descripcion.ToLower()).Contains(categoria.ToLower())
                );

                List<PropuestaServicioDTO> lista = _mapper.Map<List<PropuestaServicioDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<bool> Editar(PropuestaServicioDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.Id == modelo.Id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.PropuestaServicioAnteriorId = modelo.PropuestaServicioAnteriorId;
                    fromDbModelo.Orden = modelo.Orden;
                    fromDbModelo.ServicioId = modelo.ServicioId;
                    fromDbModelo.EmpleadorId = modelo.EmpleadorId;
                    fromDbModelo.EmpleadoId = modelo.EmpleadoId;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Aceptada = modelo.Aceptada;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Valor = modelo.Valor;
                    fromDbModelo.FechaHoraAcepta = modelo.FechaHoraAcepta;
                    fromDbModelo.FechaHoraAcepta = modelo.FechaHoraAcepta;
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

        public async Task<List<PropuestaServicioDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                string.Concat(p.Descripcion.ToLower(), p.Nombre.ToLower(), p.Ubicacion.ToLower(), p.Observaciones.ToLower()).Contains(buscar.ToLower())
                );

                List<PropuestaServicioDTO> lista = _mapper.Map<List<PropuestaServicioDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PropuestaServicioDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.Id == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<PropuestaServicioDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PropuestaServicioDTO> RePropuesta(PropuestaServicioDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.Id == modelo.Id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.PropuestaServicioAnteriorId = modelo.Id;
                    fromDbModelo.Orden = modelo.Orden + 1;
                    fromDbModelo.ServicioId = modelo.ServicioId;
                    fromDbModelo.FechaHoraAcepta = modelo.FechaHoraAcepta;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Valor = modelo.Valor;
                    fromDbModelo.FechaHoraReRepropone = modelo.FechaHoraReRepropone;
                    fromDbModelo.FechaHoraRevisaPropuesta = modelo.FechaHoraRevisaPropuesta;
                    fromDbModelo.Aceptada = modelo.Aceptada;
                    fromDbModelo.EmpleadoId = modelo.EmpleadoId;
                    fromDbModelo.Observaciones = modelo.Observaciones;
                    fromDbModelo.RePropone = modelo.RePropone;
                    var respuesta = await _modeloRepositorio.Crear(fromDbModelo);

                    if (respuesta.Id != 0)
                        return _mapper.Map<PropuestaServicioDTO>(fromDbModelo);
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

        public async Task<bool> Aceptada(PropuestaServicioDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.Id == modelo.Id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Aceptada = true;
                    fromDbModelo.FechaHoraAcepta = DateTime.Now;
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
