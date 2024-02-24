using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Repositorio.ContratoRepo;
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
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.EmpleadoId = modelo.EmpleadoId;
                    fromDbModelo.EmpleadorId = modelo.EmpleadorId;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.PerfilCargoId = modelo.PerfilCargoId;
                    fromDbModelo.Observaciones = modelo.Observaciones;
                    fromDbModelo.Precio = modelo.Precio;
                    fromDbModelo.PrecioOferta = modelo.PrecioOferta;
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
                p.Descripcion.ToLower().Contains(buscar.ToLower())
                );

                consulta = consulta.Include(c => c.PerfilCargo);

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
                consulta = consulta.Include(c => c.PerfilCargo);

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

        public async Task<List<ServicioDTO>> Catalogo(string categoria, string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Descripcion.ToLower().Contains(buscar.ToLower()) &&
                p.PerfilCargo.Descripcion.ToLower().Contains(categoria.ToLower())
                );

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
