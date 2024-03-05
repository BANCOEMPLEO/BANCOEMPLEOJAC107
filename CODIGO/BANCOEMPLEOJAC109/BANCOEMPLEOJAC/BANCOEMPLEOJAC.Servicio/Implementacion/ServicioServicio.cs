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
    public class ServicioServicio : IServicioServicio
    {
        private readonly IGenericoRepositorio<Modelo.Servicio> _modeloRepositorio;
        private readonly IMapper _mapper;

        public ServicioServicio(IGenericoRepositorio<Modelo.Servicio> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;

        }

        public async Task<ServicioDTO> Crear(ServicioDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Modelo.Servicio>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdServicio != 0)
                    return _mapper.Map<ServicioDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se puede crear");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Editar(ServicioDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdServicio == modelo.IdServicio);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.CategoriaId = modelo.CategoriaId;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Caracteristicas = modelo.Caracteristicas;
                    fromDbModelo.EmpleadoId = modelo.EmpleadoId;
                    fromDbModelo.EmpleadorId = modelo.EmpleadorId;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Precio = modelo.Precio;
                    fromDbModelo.PrecioOferta = modelo.PrecioOferta;
                    fromDbModelo.Ubicacion = modelo.Ubicacion;
                    fromDbModelo.Foto = modelo.Foto;
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
                var consulta = _modeloRepositorio.Consultar(p => p.IdServicio == id);
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

        public async Task<List<ServicioDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                    p.Nombre.ToLower().Contains(buscar.ToLower()) || 
                    p.Descripcion.ToLower().Contains(buscar.ToLower()) ||
                    p.Caracteristicas.ToLower().Contains(buscar.ToLower()) ||
                    p.Ubicacion.ToLower().Contains(buscar.ToLower()) ||
                    p.Observaciones.ToLower().Contains(buscar.ToLower())
                );

                consulta = consulta.Include(c => c.Categoria);

                List<ServicioDTO> lista = _mapper.Map<List<ServicioDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ServicioDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdServicio == id);
                consulta = consulta.Include(c => c.Categoria);

                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<ServicioDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ServicioDTO>> Catalogo(int categoria, string buscar)
        {
            try
            {
                //var consulta = _modeloRepositorio.Consultar(p =>
                //p.Descripcion.ToLower().Contains(buscar.ToLower()) ||
                //p.Categoria.Descripcion.ToLower().Contains(categoria.ToLower())
                //);
                var consulta = _modeloRepositorio.Consultar();
                if (buscar != null)
                    consulta = consulta.Where(c => c.Nombre.Contains(buscar) || c.Caracteristicas.Contains(buscar));
                if (categoria > 0)
                    consulta = consulta.Where(c => c.CategoriaId == categoria); 

                List<ServicioDTO> lista = _mapper.Map<List<ServicioDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public Task<PropuestaServicioDTO> Propuesta(ServicioDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Aceptada(ServicioDTO modelo)
        {
            throw new NotImplementedException();
        }
    }
}
