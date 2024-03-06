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
            CreateMap<ActividadEconomica, ActividadEconomicaDTO>();
            CreateMap<ActividadEconomicaDTO, ActividadEconomica>();

            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Usuario, SesionDTO>();
            //CreateMap<Usuario, SesionDTO>().ForMember(dest => dest.Jac, opt => opt.Ignore());
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<UsuarioEditaDTO, Usuario>();
            CreateMap<UsuarioEditaDTO, UsuarioDTO>();
            CreateMap<UsuarioDTO, UsuarioEditaDTO>();
            CreateMap<Usuario, UsuarioEditaDTO>();

            CreateMap<Rol, RolDTO>();
            CreateMap<RolDTO, Rol>();

            CreateMap<Empleo, EmpleoDTO>();//.ForMember(destino =>
            //    destino.NumeroPropuestas,
            //    opt => opt.Ignore()); 
            CreateMap<EmpleoDTO, Empleo>().ForMember(destino =>
                destino.Empleado,
                opt => opt.Ignore()).ForMember(destino =>
                destino.Empleador,
                opt => opt.Ignore());//.ForMember(destino =>
                //destino.Numero.PropuestaEmpleos,
                //opt => opt.Ignore()); 


            CreateMap<Servicio, ServicioDTO>();
            CreateMap<ServicioDTO, Servicio>();
            //CreateMap<UsuarioDTO, UsuarioEditaDTO>();
            //CreateMap<UsuarioEditaDTO, UsuarioDTO>();


            CreateMap<PerfilCargo, PerfilCargoDTO>();
            CreateMap<PerfilCargoDTO, PerfilCargo>().ForMember(destino =>
                destino.IdActividadEconomicaNavigation,
                opt => opt.Ignore()
                ).ForMember(destino => 
                destino.IdTipoContratoNavigation,
                opt => opt.Ignore());

            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<CategoriaDTO, Categoria>().ForMember(destino =>
                destino.Servicios,
                opt => opt.Ignore()
                ); ;

            //CreateMap<PerfilCargoDTO, PerfilCargo>().ForMember(destino =>
            //    destino.IdActividadEconomicaNavigation,
            //    opt => opt.Ignore()
            //    );

            CreateMap<Jac, JacDTO>();
            CreateMap<JacDTO, Jac>();

            CreateMap<PropuestaEmpleo, PropuestaEmpleoDTO>();
            CreateMap<PropuestaEmpleoDTO, PropuestaEmpleo>();//.ForMember(destino =>
                                                             //destino.Empleo,
                                                             //opt => opt.Ignore());//.ForMember(destino =>
                                                             //destino.Empleado,
                                                             //opt => opt.Ignore());

            CreateMap<PropuestaEmpleo, PropuestaEmpleo2DTO>();
            CreateMap<PropuestaEmpleo2DTO, PropuestaEmpleo>();//.ForMember(destino =>

            //CreateMap<PropuestaEmpleo, PropuestaEmpleoDTO>();
            //CreateMap<PropuestaEmpleoDTO, PropuestaEmpleo>();

            CreateMap<PropuestaServicioDTO, PropuestaServicio>();
            CreateMap<PropuestaServicio, PropuestaServicioDTO>();
            //CreateMap<PropuestaEmpleoDTO, PropuestaEmpleo>().ForMember(destino =>
            //     destino.IdPropuestaEmpleo,
            //     opt => opt.Ignore()
            // );

            CreateMap<DetallePropuesta, DetallePropuestaDTO>();
            CreateMap<DetallePropuestaDTO, DetallePropuesta>();

            CreateMap<Contrato, ContratoDTO>();
            CreateMap<ContratoDTO, Contrato>();


            CreateMap<Pais, PaisDTO>();
            CreateMap<PaisDTO, Pais>();

            CreateMap<Departamento,DepartamentoDTO>();
            CreateMap<DepartamentoDTO, Departamento>();

            CreateMap<Regiones, RegionesDTO>();
            CreateMap<RegionesDTO, Regiones>();


            CreateMap<Municipio, MunicipioDTO>();
            CreateMap<MunicipioDTO, Municipio>();

            CreateMap<ZonaVereda, ZonaVeredaDTO>();
            CreateMap<ZonaVeredaDTO, ZonaVereda>();


        }
        //static string CalcularNuevoCampo(IGenericoRepositorio<Jac> jacModelo, Usuario origen)
        //{
        //    _jacModelo = jacModelo;

        //    // Lógica para calcular el valor del nuevo campo
        //    var nombreJac = _jacModelo.Consultar(u => u.IdJac == origen.JacId).First().Nombre.ToString();
        //    return nombreJac; // Ejemplo arbitrario, debes proporcionar tu propia lógica aquí
        //}

    }
}
