using AutoMapper;
using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.Repositorio.Interfase;
using BANCOEMPLEOJAC.Servicio.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Servicio.Implementacion
{
    public class PropuestaServicioServicio :IPropuestaServicioServicio
    {
        private readonly IGenericoRepositorio<PropuestaServicio> _modeloRepositorio;
        private readonly IMapper _mapper;

        public PropuestaServicioServicio(IGenericoRepositorio<PropuestaServicio> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;

        }

        public async Task<PropuestaServicioDTO> Crear(PropuestaServicioDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<PropuestaServicio>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdPropuestaServicio != 0)
                    return _mapper.Map<PropuestaServicioDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se puede crear");
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
                var consulta = _modeloRepositorio.Consultar(p => p.IdPropuestaServicio == modelo.IdPropuestaServicio);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.PropuestaServicioAnteriorId = modelo.PropuestaServicioAnteriorId;
                    fromDbModelo.ServicioId = modelo.ServicioId;
                    fromDbModelo.Orden = modelo.Orden;
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Caracteristicas = modelo.Caracteristicas;
                    fromDbModelo.EmpleadoId = modelo.EmpleadoId;
                    fromDbModelo.EmpleadorId = modelo.EmpleadorId;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Valor = modelo.Valor;
                    fromDbModelo.Ubicacion = modelo.Ubicacion;
                    fromDbModelo.Foto = modelo.Foto;
                    fromDbModelo.FechaHoraRevisaPropuesta = modelo.FechaHoraRevisaPropuesta;
                    fromDbModelo.FechaHoraReRepropone = modelo.FechaHoraReRepropone;
                    fromDbModelo.FechaHoraAcepta = modelo.FechaHoraAcepta;
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
                var consulta = _modeloRepositorio.Consultar(p => p.IdPropuestaServicio == id);
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
                p.Descripcion.ToLower().Contains(buscar.ToLower())
                );

                consulta = consulta.Include(c => c.Servicio);

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
                var consulta = _modeloRepositorio.Consultar(p => p.IdPropuestaServicio == id);
                consulta = consulta.Include(c => c.Servicio);

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

        public async Task<List<PropuestaServicioDTO>> Categoria(int categoria, string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar();
                if (buscar != null)
                    consulta = consulta.Where(c => c.Nombre.Contains(buscar) || c.Caracteristicas.Contains(buscar));
                if (categoria > 0)
                    consulta = consulta.Where(c => c.Servicio.CategoriaId == categoria);

                //var consulta = _modeloRepositorio.Consultar(p =>
                //p.Descripcion.ToLower().Contains(buscar.ToLower()) &&
                //p.Servicio.Nombre.ToLower().Contains(categoria.ToLower())
                //);

                List<PropuestaServicioDTO> lista = _mapper.Map<List<PropuestaServicioDTO>>(await consulta.ToListAsync());
                return lista;
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
                var consulta = _modeloRepositorio.Consultar(p => p.IdPropuestaServicio == modelo.IdPropuestaServicio);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.PropuestaServicioAnteriorId = modelo.PropuestaServicioAnteriorId;
                    fromDbModelo.ServicioId = modelo.ServicioId;
                    fromDbModelo.Orden = modelo.Orden;
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Caracteristicas = modelo.Caracteristicas;
                    fromDbModelo.EmpleadoId = modelo.EmpleadoId;
                    fromDbModelo.EmpleadorId = modelo.EmpleadorId;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Valor = modelo.Valor;
                    fromDbModelo.Ubicacion = modelo.Ubicacion;
                    fromDbModelo.Foto = modelo.Foto;
                    fromDbModelo.FechaHoraRevisaPropuesta = modelo.FechaHoraRevisaPropuesta;
                    fromDbModelo.FechaHoraReRepropone = modelo.FechaHoraReRepropone;
                    fromDbModelo.FechaHoraAcepta = modelo.FechaHoraAcepta;
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



        public async Task<PropuestaServicioDTO> RePropuesta(PropuestaServicioDTO modelo)
        {
            try
            {
                modelo.IdPropuestaServicio = modelo.PropuestaServicioAnteriorId;
                var dbModelo = _mapper.Map<PropuestaServicio>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdPropuestaServicio != 0)
                    return _mapper.Map<PropuestaServicioDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se puede Crear RePropuesta Servicio");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
