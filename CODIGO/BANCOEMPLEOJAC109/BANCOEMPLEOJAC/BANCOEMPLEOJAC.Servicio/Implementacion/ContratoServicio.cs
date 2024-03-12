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
    public class ContratoServicio : IContratoServicio
    {
        private readonly IContratoRepositorio _contratoRepositorio;
        private readonly IGenericoRepositorio<PropuestaEmpleo> _propuestaEServicio;
        private readonly IMapper _mapper;

        public ContratoServicio(IContratoRepositorio modeloRepositorio,
            IGenericoRepositorio<PropuestaEmpleo> propuestaEServicio,
            IMapper mapper)
        {
            _contratoRepositorio = modeloRepositorio;
            _propuestaEServicio = propuestaEServicio;
            _mapper = mapper;

        }

        public async Task<ContratoDTO> Registrar(string tipo, ContratoDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Modelo.Contrato>(modelo);
                var contratoGenerado = await _contratoRepositorio.Registrar(tipo, dbModelo);

                if (contratoGenerado.IdContrato != 0)
                    return _mapper.Map<ContratoDTO>(contratoGenerado);
                else
                    throw new TaskCanceledException("No se pudo Registrar");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        // VOY : Haciendo lista de contratos por uuario : 11/MAR/2024 3:50AM
        //public async Task<List<ContratoDTO>> Listar(int? tipo, string buscar)
        //{
        //    try
        //    {
        //        var consulta = _modeloRepositorio.Consultar();
        //        if (tipo.HasValue)
        //        {
        //            consulta = consulta.Where(p =>
        //            p.UsuarioId == tipo.Value);
        //        }
        //        if (!string.IsNullOrEmpty(buscar))
        //        {
        //            consulta = consulta.Where(p =>
        //            p.DetallePropuesta.Any(b => b.Observaciones.ToLower().Contains(buscar.ToLower())));
        //        }

        //        List<ContratoDTO> lista = _mapper.Map<List<ContratoDTO>>(await consulta.ToListAsync());
        //        return lista;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public async Task<List<ContratoDTO>> PerfilCargo(int? UserId, int? categoria, string? buscar)
        {
            try
            {
                var consultacontrato = _contratoRepositorio.Consultar(c => c.UsuarioId == UserId)
                    .Include(c => c.DetallePropuesta);
                    //.ThenInclude(pe => pe.PropuestaEmpleo);
                    //.ThenInclude(e => e.Empleo)
                    //.ThenInclude(pc => pc.PerfilCargo);



                List<ContratoDTO> lista = _mapper.Map<List<ContratoDTO>>(await consultacontrato.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
