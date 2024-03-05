using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class Jac
{
    public int IdJac { get; set; }

    public int? Nit { get; set; }

    public string? Nombre { get; set; }

    public string? IdZonaVereda { get; set; }

    public string? Delimitacion { get; set; }

    public int? NumeroPersoneriaJuridica { get; set; }

    public DateTime? FechaRegistroPersoneriaJuridica { get; set; }

    public int? IdAdministradorLocal { get; set; }

    public string? NombreAdminLocal { get; set; }

    public DateTime? FechaHoraCreacion { get; set; }

    public string? Foto { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<Administrador> Administradors { get; set; } = new List<Administrador>();

    public virtual ICollection<AsambleaReuniones> AsambleaReuniones { get; set; } = new List<AsambleaReuniones>();

    public virtual ICollection<CoordinadorComisionEmpresarial> CoordinadorComisionEmpresarials { get; set; } = new List<CoordinadorComisionEmpresarial>();

    public virtual ICollection<Dignatario> Dignatarios { get; set; } = new List<Dignatario>();

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();

    public virtual ICollection<Fiscal> Fiscals { get; set; } = new List<Fiscal>();

    public virtual ZonaVereda? IdZonaVeredaNavigation { get; set; }

    public virtual ICollection<JuntaDirectivaReuniones> JuntaDirectivaReuniones { get; set; } = new List<JuntaDirectivaReuniones>();

    public virtual ICollection<PerfilCargo> PerfilCargos { get; set; } = new List<PerfilCargo>();

    public virtual ICollection<RepresentantesAsojuntas> RepresentantesAsojunta { get; set; } = new List<RepresentantesAsojuntas>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public virtual ICollection<ComisionesTrabajo> ComisionTrabajos { get; set; } = new List<ComisionesTrabajo>();
}
