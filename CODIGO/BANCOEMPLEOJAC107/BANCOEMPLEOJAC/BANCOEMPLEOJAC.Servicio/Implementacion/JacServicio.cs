using AutoMapper;
using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.Repositorio.Interfase;
using BANCOEMPLEOJAC.Servicio.Contrato;
using BANCOEMPLEOJAC.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Servicio.Implementacion
{
    public class JacServicio : IJacServicio
    {
        private readonly IGenericoRepositorio<Jac> _modeloRepositorio;
        private readonly IMapper _mapper;

        public JacServicio(IGenericoRepositorio<Jac> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;

        }

        public async Task<JacDTO> Crear(JacDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Jac>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdJac != 0)
                    return _mapper.Map<JacDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se puede crear");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Editar(JacDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdJac == modelo.IdJac);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nit = modelo.Nit;
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.NombrePresidente = modelo.NombrePresidente;
                    fromDbModelo.Delimitacion = modelo.Delimitacion;
                    fromDbModelo.FechaRegistroPersoneriaJuridica = modelo.FechaRegistroPersoneriaJuridica;
                    fromDbModelo.IdAdministradorLocal = modelo.IdAdministradorLocal;
                    fromDbModelo.NombreAdminLocal = modelo.NombreAdminLocal;
                    fromDbModelo.Foto = modelo.Foto;

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
                var consulta = _modeloRepositorio.Consultar(p => p.IdJac == id);
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

        public async Task<List<JacDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower()));
                

                List<JacDTO> lista = _mapper.Map<List<JacDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<JacDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdJac == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<JacDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
