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
using BANCOEMPLEOJAC.Servicio.Interfase;

namespace BANCOEMPLEOJAC.Servicio.Implementacion
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IGenericoRepositorio<Usuario> _modeloRepositorio;
        private readonly IJacServicio _jacServicio;
        private readonly IMapper _mapper;

        public UsuarioServicio(IGenericoRepositorio<Usuario> modeloRepositorio,
            IJacServicio jacServicio,
            IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _jacServicio = jacServicio;
            _mapper = mapper;
        }

        public async Task<SesionDTO> Autorizacion(LoginDTO modelo)
        {
            try
            {
                modelo.Clave = Encrypt.GetSHA256(modelo.Clave);
                var consulta = _modeloRepositorio.Consultar(p => p.Correo == modelo.Correo && p.Clave == modelo.Clave);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<SesionDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {
            try
            {
                modelo.Clave = Encrypt.GetSHA256(modelo.Clave);
                if (modelo.Rol == null)
                { 
                    modelo.Rol = 6; 
                };
                var dbModelo = _mapper.Map<Usuario>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdUsuario != 0)
                    return _mapper.Map<UsuarioDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se puede crear");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Editar(UsuarioEditaDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdUsuario == modelo.IdUsuario);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Identificacion = modelo.Identificacion;
                    fromDbModelo.Nombres = modelo.Nombres;
                    fromDbModelo.Apellidos = modelo.Apellidos;
                    fromDbModelo.Correo = modelo.Correo;
                    fromDbModelo.Celular = modelo.Celular;
                    fromDbModelo.Redes = modelo.Redes;
                    if (modelo.Clave != "" && modelo.Clave == modelo.ConfirmarClave)
                    {
                        fromDbModelo.Clave = Encrypt.GetSHA256(modelo.Clave);
                    }
                    fromDbModelo.JacId = modelo.JacId;
                    fromDbModelo.Rol = modelo.Rol;
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
                var consulta = _modeloRepositorio.Consultar(p => p.IdUsuario == id);
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

        public async Task<List<UsuarioDTO>> Lista(int rol = 0, string buscar = "NA", int RolId = 0, int JacId = 0)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar();
                if (rol != 0) 
                {
                    // muesta solo los usuarios de un rol
                    if (rol < RolId)
                    {
                        rol = RolId;
                    }
                    // Administrador Municipal :: muestra usuarios de las Jac del Municipio
                    var listaJacs = await _jacServicio.Lista("NA");
                    var zonaverdaId = listaJacs.Where(lj => lj.IdJac == JacId).FirstOrDefault().IdZonaVereda;
                    var listaZonavereda = await _jacServicio.ListaZonaVeredas("");
                    var municipioId = listaZonavereda.Where(lzv => lzv.IdzonaVereda == zonaverdaId).FirstOrDefault().IdMunicipio;
                    var listaZonaVeredaMunicipio = listaZonavereda.Where(lzv => lzv.IdMunicipio == municipioId);
                    // Administrador Departamental :: Muestra usuarios de las Jacs del departamento.
                    var listaMunicipios = await _jacServicio.ListaMunicipios("NA");
                    var regionId = listaMunicipios.Where(m => m.IdMunicipio == municipioId).FirstOrDefault().IdRegion;
                    var listaRegiones = await _jacServicio.ListaRegiones("NA");
                    var departamentoId = listaRegiones.Where(r => r.IdRegion == regionId).FirstOrDefault().IdDepartamento;
                    //var listaJacsDepartamento = listaMunicipios.Where(m => m.IdRegion == )
                    switch (rol)
                    {
                        case 4: case 5:  case 6:
                            // Administrador Local y Usuarios Jac :: muestra los usuarios de esa JAC
                            consulta = consulta.Where(p =>
                            p.Rol == rol &&
                            p.JacId == JacId &&
                            string.Concat(p.Nombres.ToLower(), p.Apellidos.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower()));
                            break;
                        case 3:
                                var listaJacsZonaVeredaMunicipio = listaJacs.Where(lj => listaZonaVeredaMunicipio.Any(lzv => lzv.IdzonaVereda == lj.IdZonaVereda));
                                consulta = consulta.Where(p => listaJacsZonaVeredaMunicipio.Any(lj => lj.IdJac == p.JacId) &&
                                                            p.Rol == RolId &&
                                                               string.Concat(p.Nombres.ToLower(), 
                                                               p.Apellidos.ToLower(), 
                                                               p.Correo.ToLower()).Contains(buscar.ToLower()));
                            break;
                        case 2:
                            // Administrador Departamental :: muestra usuarios de Todo el departamento

                        case 1:
                            // Administrador General del Sistema BANCOEMPLEOJAC :: Muestra solo usuarios administradores

                        default:
                            break;
                    }
                }
                else
                {
                    // muestra los usuarios de roles inferiores o iguales
                    if (rol < RolId)
                    {
                        rol = RolId;
                    }
                    switch (RolId)
                    {
                        case 4: case 5:
                            consulta = consulta.Where(p =>
                            p.Rol >= rol &&
                            p.JacId == JacId && 
                            string.Concat(p.Nombres.ToLower(), p.Apellidos.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower()));
                            break;
                        case 3:


                            break;
                        case 2:


                            break;
                        case 1:


                            break;


                        default:
                            break;
                    }

                };

                List<UsuarioDTO> lista = _mapper.Map<List<UsuarioDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public async Task<UsuarioDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdUsuario == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<UsuarioDTO>(fromDbModelo);
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
