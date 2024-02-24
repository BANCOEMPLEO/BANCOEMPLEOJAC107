﻿using System;
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
    public class PerfilCargoServicio : IPerfilCargoServicio
    {
        private readonly IGenericoRepositorio<PerfilCargoDTO> _modeloRepositorio;
        private readonly IMapper _mapper;

        public PerfilCargoServicio(IGenericoRepositorio<PerfilCargoDTO> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;

        }

        public async Task<PerfilCargoDTO> Crear(PerfilCargoDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<PerfilCargoDTO>(modelo);
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
                    fromDbModelo.IdTipoContrato = modelo.IdTipoContrato;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Requisitos = modelo.Requisitos;
                    fromDbModelo.Compensacion = modelo.Compensacion;
                    fromDbModelo.JacId = modelo.JacId;
                    fromDbModelo.Notas = modelo.Notas;
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

        public async Task<List<PerfilCargoDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                string.Concat(p.Descripcion.ToLower(), p.Requisitos.ToLower()).Contains(buscar.ToLower())
                );

                List<PerfilCargoDTO> lista = _mapper.Map<List<PerfilCargoDTO>>(await consulta.ToListAsync());
                return lista;
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