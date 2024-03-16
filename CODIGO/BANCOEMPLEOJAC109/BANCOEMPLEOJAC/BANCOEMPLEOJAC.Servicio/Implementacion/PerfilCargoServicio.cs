﻿using System;
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
using BANCOEMPLEOJAC.Servicio.Interfase;


namespace BANCOEMPLEOJAC.Servicio.Implementacion
{
    public class PerfilCargoServicio : IPerfilCargoServicio
    {
        private readonly IGenericoRepositorio<PerfilCargo> _modeloRepositorio;
        private readonly IGenericoRepositorio<TipoContrato> _tipoContratoRepositorio;
        private readonly IGenericoRepositorio<Empleo> _empleoRepositorio;
        private readonly IGenericoRepositorio<Usuario> _usuarioRepositorio;
        private readonly IMapper _mapper;

        public PerfilCargoServicio(IGenericoRepositorio<PerfilCargo> modeloRepositorio,
            IGenericoRepositorio<TipoContrato> tipoContratoRepositorio,
            IGenericoRepositorio<Empleo> empleoRepositorio,
            IGenericoRepositorio<Usuario> usuarioRepositorio,
            IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _tipoContratoRepositorio = tipoContratoRepositorio;
            _empleoRepositorio = empleoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;

        }

        public async Task<PerfilCargoDTO> Crear(PerfilCargoDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<PerfilCargo>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdPerfilCargo != 0)
                    return _mapper.Map<PerfilCargoDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se puede crear");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<bool> Editar(PerfilCargoDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdPerfilCargo == modelo.IdPerfilCargo);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.IdActividadEconomica = modelo.IdActividadEconomica;
                    fromDbModelo.IdTipoContrato = modelo.IdTipoContrato;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Requisitos = modelo.Requisitos;
                    fromDbModelo.Compensacion = modelo.Compensacion;
                    fromDbModelo.JacId = modelo.JacId;
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
                var consulta = _modeloRepositorio.Consultar(p => p.IdPerfilCargo == id);
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

        public async Task<List<PerfilCargoDTO>> Lista(int idUsuario, string buscar)
        {
            try
            {
                // Se saca la IdJAC del usuario
                var usuario = _usuarioRepositorio.Consultar(u => u.IdUsuario == idUsuario).FirstOrDefault();
                var IdJAC = usuario.JacId;
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Descripcion!.ToLower().Contains(buscar.ToLower())
                ////).Where(p => p.JacId == IdJAC).OrderBy(L => L.Descripcion);
                ////).Where(p => p.IdPerfilCargo in 
                //).OrderBy(L => L.Descripcion);
                //).Where(p => p.JacId == IdJAC).OrderBy(L => L.Descripcion);
                //).Where(p => p.IdPerfilCargo in 
                ).OrderBy(L => L.Descripcion);


                List<PerfilCargoDTO> lista = _mapper.Map<List<PerfilCargoDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        // Es para verificar que no existen empleos con el perfil cargo que se borrará
        public async Task<bool> VerificaPerfilEmpleoBorrar(int idUsuario, int idPerfilCargo)
        {
            try
            {
                // Se saca la IdJAC del usuario
                var usuario = _usuarioRepositorio.Consultar(u => u.IdUsuario == idUsuario).FirstOrDefault();
                var IdJAC = usuario.JacId;
                // se consulta empleo  si tiene perfiles o cargos con el idPerfilCargo para poder borrar el perfilcargo
                var consulta = _empleoRepositorio.Consultar(e => e.PerfilCargoId == idPerfilCargo).Count();
                if (consulta == 0)
                {
                    //  se puede borrar: no hay empleos con éste idPerfilCargo
                    return true;
                }
                // no se puede borrar: hay empleos con éste idPerfilCargo
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PerfilCargo> ConsultarPerfilCargoEnPropuestaEmpleo()
        {
            PerfilCargo perfilCargo = new PerfilCargo();
            //perfilCargo = (PerfilCargo)(from pc in PerfilCargo
            //                            join pe in PropuestaEmpleo
            //                               on pc.IdPerfilCargo equals pe.Empleo.PerfilCargoId
            //                            from pec in _dbContext.PerfilCargos
            //                            select new
            //                            {
            //                                pec.IdPerfilCargo,
            //                                pec.Descripcion
            //                            });
            return perfilCargo;
        }


        public async Task<List<TipoContratoDTO>> ListaTipoContrato(string buscar)
        {
            try
            {
                if (buscar == "")
                {
                    var consulta = _tipoContratoRepositorio.Consultar().OrderBy(tc => tc.Nombre);

                    List<TipoContratoDTO> lista = _mapper.Map<List<TipoContratoDTO>>(await consulta.ToListAsync());
                    return lista;
                }
                else
                {
                    var consulta = _tipoContratoRepositorio.Consultar(p =>
                    p.Nombre.ToLower().Contains(buscar.ToLower())
                    ).OrderBy(tc => tc.Nombre);

                    List<TipoContratoDTO> lista = _mapper.Map<List<TipoContratoDTO>>(await consulta.ToListAsync());
                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<PerfilCargoDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdPerfilCargo == id);
                //consulta = consulta.Include(tc => tc.IdTipoContratoNavigation);

                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<PerfilCargoDTO>(fromDbModelo);
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
