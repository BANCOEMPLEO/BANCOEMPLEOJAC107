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
    public class EmpleoServicio : IEmpleoServicio
    {
        private readonly IGenericoRepositorio<Empleo> _modeloRepositorio;
        private readonly IGenericoRepositorio<PropuestaEmpleo> _propuestaEmpleoRepositorio;
        private readonly IMapper _mapper;

        public EmpleoServicio(IGenericoRepositorio<Empleo> modeloRepositorio,
            IGenericoRepositorio<PropuestaEmpleo> propuestaEmpleoRepositorio,
            IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _propuestaEmpleoRepositorio = propuestaEmpleoRepositorio;
            _mapper = mapper;

        }

        public async Task<EmpleoDTO> Crear(EmpleoDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Empleo>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdEmpleo != 0)
                    return _mapper.Map<EmpleoDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se puede crear");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Editar(EmpleoDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdEmpleo == modelo.IdEmpleo);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Requisitos = modelo.Requisitos;
                    fromDbModelo.FechaHoraInicio = modelo.FechaHoraInicio;
                    fromDbModelo.FechaHoraFin = modelo.FechaHoraFin;
                    fromDbModelo.Ubicacion = modelo.Ubicacion;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Precio = modelo.Precio;
                    fromDbModelo.PrecioOferta = modelo.PrecioOferta;
                    fromDbModelo.Activo = modelo.Activo;
                    fromDbModelo.FechaHoraActiva = modelo.FechaHoraActiva;
                    fromDbModelo.FechaHoraInactiva = modelo.FechaHoraInactiva;
                    fromDbModelo.EmpleadorId = modelo.EmpleadorId;
                    fromDbModelo.EmpleadoId = modelo.EmpleadoId;
                    fromDbModelo.PerfilCargoId = modelo.PerfilCargoId;
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

        public async Task<bool> Activar(EmpleoDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdEmpleo == modelo.IdEmpleo);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Activo = true;
                    fromDbModelo.FechaHoraActiva = DateTime.Now;
                    fromDbModelo.EmpleadorId = modelo.EmpleadorId;
                    fromDbModelo.EmpleadoId = modelo.EmpleadoId;
                    fromDbModelo.Observaciones = modelo.Observaciones + " " + "Activado en : " + DateTime.Now.ToString();

                    // Solo si no encuentra PropuestaEmpleo con este IdEmpleo se crea propuestaEmpleo
                    if (_propuestaEmpleoRepositorio.Consultar(c => c.EmpleoId == modelo.IdEmpleo).Count() == 0)
                    {
                        // Crea la PropuestaEmpleo
                        PropuestaEmpleo propuestaEmpleo = new PropuestaEmpleo();
                        propuestaEmpleo.EmpleoId = modelo.IdEmpleo;
                        propuestaEmpleo.Nombre = modelo.Nombre;
                        propuestaEmpleo.Descripcion = modelo.Descripcion;
                        propuestaEmpleo.Requisitos = modelo.Requisitos;
                        propuestaEmpleo.FechaHoraInicio = modelo.FechaHoraInicio;
                        propuestaEmpleo.FechaHoraFin = modelo.FechaHoraFin; 
                        propuestaEmpleo.Ubicacion = modelo.Ubicacion;
                        propuestaEmpleo.Cantidad = modelo.Cantidad;
                        propuestaEmpleo.Valor = modelo.Precio;
                        propuestaEmpleo.EmpleadoId = modelo.EmpleadoId;
                        var propuestacreada = await _propuestaEmpleoRepositorio.Crear(propuestaEmpleo);
                        if (propuestacreada == null)
                        {
                            throw new TaskCanceledException("No se pudo crear la Propuesta Empleo");
                        }

                    }
                    var respuesta = await _modeloRepositorio.Editar(fromDbModelo);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo Activar");
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

        public async Task<bool> Desactivar(EmpleoDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdEmpleo == modelo.IdEmpleo);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Activo = false;
                    fromDbModelo.FechaHoraInactiva = DateTime.Now;
                    fromDbModelo.EmpleadorId = modelo.EmpleadorId;
                    fromDbModelo.EmpleadoId = modelo.EmpleadoId;
                    fromDbModelo.Observaciones = modelo.Observaciones + " " + "Desctivado en : " + DateTime.Now.ToString();
                    var respuesta = await _modeloRepositorio.Editar(fromDbModelo);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo Desactivar");
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
                var consulta = _modeloRepositorio.Consultar(p => p.IdEmpleo == id);
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

        public async Task<List<EmpleoDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Descripcion.ToLower().Contains(buscar.ToLower())
                );

                consulta = consulta.Include(c => c.PerfilCargo);

                List<EmpleoDTO> lista = _mapper.Map<List<EmpleoDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmpleoDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdEmpleo == id);
                consulta = consulta.Include(c => c.PerfilCargo);

                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<EmpleoDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<EmpleoDTO>> Catalogo(string categoria, string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Descripcion.ToLower().Contains(buscar.ToLower()) &&
                p.PerfilCargo.Descripcion.ToLower().Contains(categoria.ToLower())
                );

                List<EmpleoDTO> lista = _mapper.Map<List<EmpleoDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<PropuestaEmpleoDTO> Propuesta(EmpleoDTO modelo)
        {
            throw new NotImplementedException();
        }
    }
}
