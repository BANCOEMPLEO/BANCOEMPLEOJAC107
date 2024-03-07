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
        private readonly IGenericoRepositorio<Departamento> _departamentoRepositorio;
        private readonly IGenericoRepositorio<Regiones> _regionRepositorio;
        private readonly IGenericoRepositorio<Municipio> _municipioRepositorio;
        private readonly IGenericoRepositorio<ZonaVereda> _zonaveredaRepositorio;
        private readonly IMapper _mapper;

        public JacServicio(IGenericoRepositorio<Jac> modeloRepositorio,
            IGenericoRepositorio<Departamento> departamentoRepositorio,
            IGenericoRepositorio<Regiones> regionRepositorio,
            IGenericoRepositorio<Municipio> municipioRepositorio,
            IGenericoRepositorio<ZonaVereda> zonaveredaRepositorio,
            IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _departamentoRepositorio = departamentoRepositorio;
            _regionRepositorio = regionRepositorio;
            _municipioRepositorio = municipioRepositorio;
            _zonaveredaRepositorio = zonaveredaRepositorio;
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

        public async Task<ZonaVeredaDTO> CrearZonaVereda(ZonaVeredaDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<ZonaVereda>(modelo);
                var rspModelo = await _zonaveredaRepositorio.Crear(dbModelo);

                if (rspModelo.IdzonaVereda != "")
                    return _mapper.Map<ZonaVeredaDTO>(rspModelo);
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
                    fromDbModelo.IdZonaVereda = modelo.IdZonaVereda;
                    fromDbModelo.Nit = modelo.Nit;
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Delimitacion = modelo.Delimitacion;
                    fromDbModelo.NumeroPersoneriaJuridica = modelo.NumeroPersoneriaJuridica;
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

        public async Task<bool> EditarZonaVereda(ZonaVeredaDTO modelo)
        {
            try
            {
                var consulta = _zonaveredaRepositorio.Consultar(p => p.IdzonaVereda == modelo.IdzonaVereda);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Ubicacion = modelo.Ubicacion;
                    fromDbModelo.Latitud = modelo.Latitud;
                    fromDbModelo.Longitud = modelo.Longitud;
                    fromDbModelo.Observaciones = modelo.Observaciones;

                    var respuesta = await _zonaveredaRepositorio.Editar(fromDbModelo);

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

        public async Task<List<ZonaVeredaDTO>> ListaZonaVeredas(string buscar)
        {
            try
            {
                if (buscar == "")
                {
                    var consulta = _zonaveredaRepositorio.Consultar().OrderBy(z => z.Nombre);

                    List<ZonaVeredaDTO> lista = _mapper.Map<List<ZonaVeredaDTO>>(await consulta.ToListAsync());
                    return lista;
                }
                else
                {
                    var consulta = _zonaveredaRepositorio.Consultar(p =>
                    p.IdMunicipio.Equals(buscar)).OrderBy(r => r.Nombre);

                    List<ZonaVeredaDTO> lista = _mapper.Map<List<ZonaVeredaDTO>>(await consulta.ToListAsync());
                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<MunicipioDTO>> ListaMunicipios(string buscar)
        {
            try
            {
                if (buscar == "")
                {
                    var consulta = _municipioRepositorio.Consultar().OrderBy(r => r.Nombre);

                    List<MunicipioDTO> lista = _mapper.Map<List<MunicipioDTO>>(await consulta.ToListAsync());
                    return lista;
                }
                else
                {
                    var consulta = _municipioRepositorio.Consultar(p =>
                        p.IdRegion.Equals(buscar)).OrderBy(r => r.Nombre);

                    List<MunicipioDTO> lista = _mapper.Map<List<MunicipioDTO>>(await consulta.ToListAsync());
                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<RegionesDTO>> ListaRegiones(string buscar)
        {
            try
            {
                if (buscar == "")
                {
                    var consulta = _regionRepositorio.Consultar().OrderBy(r => r.Nombre);

                    List<RegionesDTO> lista = _mapper.Map<List<RegionesDTO>>(await consulta.ToListAsync());
                    return lista;
                }
                else
                {
                    var consulta = _regionRepositorio.Consultar( p =>
                    p.IdDepartamento.Equals(buscar)).OrderBy(r => r.Nombre);

                    List<RegionesDTO> lista = _mapper.Map<List<RegionesDTO>>(await consulta.ToListAsync());
                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<DepartamentoDTO>> ListaDepartamentos(string buscar)
        {
            try
            {
                if (buscar == "")
                {
                    var consulta = _departamentoRepositorio.Consultar().OrderBy(p => p.Nombre);

                    List<DepartamentoDTO> lista = _mapper.Map<List<DepartamentoDTO>>(await consulta.ToListAsync());
                    return lista;

                }
                else
                {
                    var consulta = _departamentoRepositorio.Consultar(p =>
                    p.Nombre.ToLower().Contains(buscar.ToLower()));
                    consulta = consulta.Where(pa => pa.IdPais == "COL").OrderBy(p => p.Nombre);

                    List<DepartamentoDTO> lista = _mapper.Map<List<DepartamentoDTO>>(await consulta.ToListAsync());
                    return lista;

                }
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
        public async Task<ZonaVeredaDTO> ObtenerZonaVereda(string idZonaVereda)
        {
            try
            {
                var consulta = _zonaveredaRepositorio.Consultar(p => p.IdzonaVereda == idZonaVereda);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<ZonaVeredaDTO>(fromDbModelo);
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
