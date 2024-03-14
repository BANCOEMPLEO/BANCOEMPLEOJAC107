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
        private readonly IMapper _mapper;

        public UsuarioServicio(IGenericoRepositorio<Usuario> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
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

        public async Task<List<UsuarioDTO>> Lista(int rol, string buscar, int RolId = 0)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar();
                if (rol != 0) {
                    if (rol < RolId)
                    {
                        rol = RolId;
                    }
                    consulta = consulta.Where(p =>
                    p.Rol == rol &&
                    string.Concat(p.Nombres.ToLower(), p.Apellidos.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower()));
                }
                else
                {
                    if (rol < RolId)
                    {
                        rol = RolId;
                    }

                    consulta = consulta.Where(p =>
                    p.Rol >= rol &&
                    string.Concat(p.Nombres.ToLower(), p.Apellidos.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower()));

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
