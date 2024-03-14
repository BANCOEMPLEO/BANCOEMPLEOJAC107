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
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly IMapper _mapper;

        public RolServicio(IGenericoRepositorio<Rol> modeloRepositorio,
            IUsuarioServicio usuarioServicio,
            IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _usuarioServicio = usuarioServicio;
            _mapper = mapper;

        }

        public async Task<List<RolDTO>> Lista(int UsuarioId, string buscar)
        {
            try
            {
                var usuario = await _usuarioServicio.Obtener(UsuarioId);


                var consulta = _modeloRepositorio.Consultar(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower())
                );

                consulta = consulta.Where(r => r.IdRol >= usuario.Rol);

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
