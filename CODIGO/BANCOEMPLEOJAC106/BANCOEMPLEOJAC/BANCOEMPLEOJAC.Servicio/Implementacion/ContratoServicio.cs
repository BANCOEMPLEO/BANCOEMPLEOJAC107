using AutoMapper;
using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.Repositorio.ContratoRepo;
using BANCOEMPLEOJAC.Servicio.Contrato;
using BANCOEMPLEOJAC.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Servicio.Implementacion
{
    public class ContratoServicio : IContratoServicio
    {
        private readonly IContratoRepositorio _modeloRepositorio;
        private readonly IMapper _mapper;

        public ContratoServicio(IContratoRepositorio modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;

        }

        public async Task<ContratoDTO> Registrar(string tipo, ContratoDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Modelo.Contrato>(modelo);
                var contratoGenerado = await _modeloRepositorio.Registrar(tipo, dbModelo);

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
    }
}
