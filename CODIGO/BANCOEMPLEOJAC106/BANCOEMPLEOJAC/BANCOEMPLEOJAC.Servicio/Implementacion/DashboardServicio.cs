using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Repositorio.ContratoRepo;
using BANCOEMPLEOJAC.Servicio.Contrato;
using AutoMapper;
using BANCOEMPLEOJAC.Utilidades;



namespace BANCOEMPLEOJAC.Servicio.Implementacion
{
    public class DashboardServicio : IDashboardServicio
    {
        private readonly IContratoRepositorio _contratoRepositorio;
        private readonly IGenericoRepositorio<Usuario> _usuarioRepositorio;
        private readonly IGenericoRepositorio<Empleo> _empleoRepositorio;
        private readonly IGenericoRepositorio<Empleado> _empleadoRepositorio;
        private readonly IGenericoRepositorio<Empleador> _empleadorRepositorio;
        private readonly IGenericoRepositorio<Modelo.Servicio> _servicioRepositorio;
        private readonly IGenericoRepositorio<PropuestaEmpleo> _propuestaEmpleoRepositorio;
        private readonly IGenericoRepositorio<PropuestaServicio> _propuestaServicioRepositorio;

        public DashboardServicio(
            IContratoRepositorio contratoRepositorio,
            IGenericoRepositorio<Usuario> usuarioRepositorio,
            IGenericoRepositorio<Empleo> empleoRepositorio,
            IGenericoRepositorio<Empleado> empleadoRepositorio,
            IGenericoRepositorio<Empleador> empleadorRepositorio,
            IGenericoRepositorio<Modelo.Servicio> servicioRepositorio,
            IGenericoRepositorio<PropuestaEmpleo> propuestaEmpleoRepositorio,
            IGenericoRepositorio<PropuestaServicio> propuestaServicioRepositorio
        )
        {
            _contratoRepositorio = contratoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _empleoRepositorio = empleoRepositorio;
            _empleadoRepositorio = empleadoRepositorio;
            _empleadorRepositorio = empleadorRepositorio;
            _servicioRepositorio = servicioRepositorio;
            _propuestaEmpleoRepositorio = propuestaEmpleoRepositorio;
            _propuestaServicioRepositorio = propuestaServicioRepositorio;
        }

        private string Ingresos()
        {
            var consulta = _contratoRepositorio.Consultar();
            decimal? Ingresos = consulta.Sum(x => x.Total);
            return Convert.ToString(Ingresos);
        }
        private int Contratos()
        {
            var consulta = _contratoRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }
        private int Clientes()
        {
            var consulta = _usuarioRepositorio.Consultar(u => u.Rol == 5);
            int total = consulta.Count();
            return total;
        }

        private int AdministradorLocal()
        {
            var consulta = _usuarioRepositorio.Consultar(u => u.Rol == 4);
            int total = consulta.Count();
            return total;
        }
        private int AdministradorMunicipal()
        {
            var consulta = _usuarioRepositorio.Consultar(u => u.Rol == 3);
            int total = consulta.Count();
            return total;
        }

        private int AdministradorDepartamental()
        {
            var consulta = _usuarioRepositorio.Consultar(u => u.Rol == 2);
            int total = consulta.Count();
            return total;
        }

        private int Empleo()
        {
            var consulta = _empleoRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }
        private int Empleado()
        {
            var consulta = _empleadoRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }
        private int Empleador()
        {
            var consulta = _empleadorRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }
        private int Servicio()
        {
            var consulta = _servicioRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }
        private int PropuestaEmpleo()
        {
            var consulta = _propuestaEmpleoRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }
        private int PropuestaServicio()
        {
            var consulta = _propuestaServicioRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }


        public DashboardDTO Resumen()
        {
            try
            {
                DashboardDTO dto = new DashboardDTO()
                {
                    TotalIngresos = Ingresos(),
                    TotalContratos = Contratos(),
                    TotalEmpleos = Empleo(),
                    TotalServicios = Servicio(),
                    TotalEmpleadores = Empleador(),
                    TotalEmpleados = Empleado(),
                    TotalPropuestasEmpleo = PropuestaEmpleo(),
                    TotalPropuestasServicio = PropuestaServicio(),
                    TotalAdministradorLocal = AdministradorLocal(),
                    TotalAdministradorMunicipal = AdministradorMunicipal(),
                    TotalAdministradorDepartamental = AdministradorDepartamental(),

                };
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
