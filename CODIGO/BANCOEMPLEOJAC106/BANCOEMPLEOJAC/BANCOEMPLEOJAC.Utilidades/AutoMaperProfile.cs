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

            CreateMap<Usuario, UsuarioEditaDTO>();
            CreateMap<UsuarioEditaDTO, Usuario>();
            CreateMap<UsuarioDTO, UsuarioEditaDTO>();
            CreateMap<UsuarioEditaDTO, UsuarioDTO>();


            CreateMap<PerfilCargo, PerfilCargoDTO>();
            CreateMap<PerfilCargoDTO, PerfilCargo>();

            //CreateMap<PerfilCargoDTO, PerfilCargo>().ForMember(destino =>
            //    destino.IdActividadEconomicaNavigation,
            //    opt => opt.Ignore()
            //    );

            CreateMap<Jac, JacDTO>();
            CreateMap<JacDTO, Jac>();

            CreateMap<PropuestaEmpleo, PropuestaEmpleoDTO>();
            CreateMap<PropuestaEmpleoDTO, PropuestaEmpleo>();

            CreateMap<PropuestaEmpleo, PropuestaEmpleoDTO>();
            CreateMap<PropuestaEmpleoDTO, PropuestaEmpleo>();

            //CreateMap<PropuestaServicioDTO, PropuestaServicio>().ForMember(destino =>
            //     destino.IdPropuestaServicio,
            //     opt => opt.Ignore()
            // );
            //CreateMap<PropuestaEmpleoDTO, PropuestaEmpleo>().ForMember(destino =>
            //     destino.IdPropuestaEmpleo,
            //     opt => opt.Ignore()
            // );

            CreateMap<DetallePropuesta, DetallePropuestaDTO>();
            CreateMap<DetallePropuestaDTO, DetallePropuesta>();

            CreateMap<Contrato, ContratoDTO>();
            CreateMap<ContratoDTO, Contrato>();


        }

    }
}
