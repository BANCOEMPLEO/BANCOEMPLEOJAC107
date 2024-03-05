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
    public class RolServicio : IRolServicio
    {
        private readonly IGenericoRepositorio<Rol> _modeloRepositorio;
        private readonly IMapper _mapper;

        public RolServicio(IGenericoRepositorio<Rol> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;

        }

        public async Task<List<RolDTO>> Lista(string buscar)
        {
            try
            {

                var consulta = _modeloRepositorio.Consultar(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower())
                );

                List<RolDTO> lista = _mapper.Map<List<RolDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
