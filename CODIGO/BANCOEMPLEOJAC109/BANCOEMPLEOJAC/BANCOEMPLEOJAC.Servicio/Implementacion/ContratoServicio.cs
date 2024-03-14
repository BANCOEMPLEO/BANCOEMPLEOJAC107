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
        // HECHO : Haciendo lista de contratos por uuario : 11/MAR/2024 3:50AM : FIN : 13/MAR/2024 6:51PM 
        public async Task<List<ContratoDTO>> PerfilCargo(int UserId, int? categoria, string? buscar)
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

        public async Task<ContratoDTO> Obtener(int id)
        {
            try
            {
                var consulta = _contratoRepositorio.Consultar(p => p.IdContrato == id);
                consulta = consulta.Include(c => c.DetallePropuesta);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<ContratoDTO>(fromDbModelo);
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
