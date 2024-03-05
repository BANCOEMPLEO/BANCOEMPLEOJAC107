using AutoMapper;
using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.Repositorio.Interfase;
using BANCOEMPLEOJAC.Servicio.Interfase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Servicio.Implementacion
{
    public class ActividadEconomicaServicio : IActividadEconomicaServicio
    {
        private readonly IGenericoRepositorio<ActividadEconomica> _modeloRepositorio;
        private readonly IMapper _mapper;

        public ActividadEconomicaServicio(IGenericoRepositorio<ActividadEconomica> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;

        }

        public async Task<List<ActividadEconomicaDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar();
                consulta = consulta.OrderBy(c => c.Descripcion);
                if(buscar.Count() > 0)
                {
                consulta = consulta.Where(p =>
                p.Descripcion.ToLower().Contains(buscar.ToLower()));

                }


                List<ActividadEconomicaDTO> lista = _mapper.Map<List<ActividadEconomicaDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
