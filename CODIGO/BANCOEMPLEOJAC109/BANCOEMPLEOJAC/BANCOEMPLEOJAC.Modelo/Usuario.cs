using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int? Identificacion { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Correo { get; set; }

    public string? Celular { get; set; }

    public string? Redes { get; set; }

    public string? Clave { get; set; }

    public int? Rol { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public int? JacId { get; set; }

    public string? Foto { get; set; }

    public DateTime? FechaHoraCreacion { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<Administrador> Administradors { get; set; } = new List<Administrador>();

    public virtual ICollection<ComisionesTrabajo> ComisionesTrabajoCoordinadors { get; set; } = new List<ComisionesTrabajo>();

    public virtual ICollection<ComisionesTrabajo> ComisionesTrabajoSuplentes { get; set; } = new List<ComisionesTrabajo>();

    public virtual ICollection<CoordinadorComisionEmpresarial> CoordinadorComisionEmpresarialCoordinadors { get; set; } = new List<CoordinadorComisionEmpresarial>();

    public virtual ICollection<CoordinadorComisionEmpresarial> CoordinadorComisionEmpresarialSuplentes { get; set; } = new List<CoordinadorComisionEmpresarial>();

    public virtual ICollection<Dignatario> DignatarioPresidentes { get; set; } = new List<Dignatario>();

    public virtual ICollection<Dignatario> DignatarioSecretarios { get; set; } = new List<Dignatario>();

    public virtual ICollection<Dignatario> DignatarioTesosreros { get; set; } = new List<Dignatario>();

    public virtual ICollection<Dignatario> DignatarioVicepresidentes { get; set; } = new List<Dignatario>();

    public virtual ICollection<Empleo> EmpleoEmpleadors { get; set; } = new List<Empleo>();

    public virtual ICollection<Empleo> EmpleoEmpleados { get; set; } = new List<Empleo>();

    public virtual ICollection<Fiscal> FiscalFiscalNavigations { get; set; } = new List<Fiscal>();

    public virtual ICollection<Fiscal> FiscalSuplentes { get; set; } = new List<Fiscal>();

    public virtual Jac? Jac { get; set; }

    public virtual ICollection<PropuestaEmpleo> PropuestaEmpleoEmpleadors { get; set; } = new List<PropuestaEmpleo>();

    public virtual ICollection<PropuestaEmpleo> PropuestaEmpleoEmpleados { get; set; } = new List<PropuestaEmpleo>();

    public virtual ICollection<PropuestaServicio> PropuestaServicioEmpleadors { get; set; } = new List<PropuestaServicio>();

    public virtual ICollection<PropuestaServicio> PropuestaServicioEmpleados { get; set; } = new List<PropuestaServicio>();

    public virtual ICollection<RepresentantesAsojuntas> RepresentantesAsojuntaRepresentante1Navigations { get; set; } = new List<RepresentantesAsojuntas>();

    public virtual ICollection<RepresentantesAsojuntas> RepresentantesAsojuntaRepresentante2Navigations { get; set; } = new List<RepresentantesAsojuntas>();

    public virtual ICollection<RepresentantesAsojuntas> RepresentantesAsojuntaRepresentante3Navigations { get; set; } = new List<RepresentantesAsojuntas>();

    public virtual Rol? RolNavigation { get; set; }

    public virtual ICollection<Servicio> ServicioEmpleadors { get; set; } = new List<Servicio>();

    public virtual ICollection<Servicio> ServicioEmpleados { get; set; } = new List<Servicio>();
}
