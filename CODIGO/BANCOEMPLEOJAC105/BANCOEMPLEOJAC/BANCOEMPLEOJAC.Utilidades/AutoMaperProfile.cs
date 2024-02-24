using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BANCOEMPLEOJAC.Utilidades;
using BANCOEMPLEOJAC.Modelo;
using AutoMapper;
using BANCOEMPLEOJAC.DTO;

namespace BANCOEMPLEOJAC.Utilidades
{
    public class AutoMaperProfile : Profile
    {
        public AutoMaperProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Usuario, SesionDTO>();
            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<PerfilCargo, PerfilCargoDTO>();
            CreateMap<PerfilCargoDTO, PerfilCargo>();

            CreateMap<PropuestaEmpleo, PropuestaEmpleoDTO>();
            CreateMap<PropuestaEmpleoDTO, PropuestaEmpleo>();

            CreateMap<PropuestaServicio, PropuestaServicioDTO>();
            CreateMap<PropuestaServicioDTO, PropuestaServicio>();

           //CreateMap<PropuestaEmpleoDTO, PropuestaEmpleo>().ForMember(destino =>
            //    destino.Id,
            //    opt => opt.Ignore()
            //);

            CreateMap<DetallePropuesta, DetallePropuestaDTO>();
            CreateMap<DetallePropuestaDTO, DetallePropuesta>();



        }

    }
}
