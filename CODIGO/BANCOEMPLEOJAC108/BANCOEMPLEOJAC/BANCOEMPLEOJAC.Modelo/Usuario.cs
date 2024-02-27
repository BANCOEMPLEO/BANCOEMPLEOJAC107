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

    public virtual ICollection<Empleo> EmpleoEmpleadors { get; set; } = new List<Empleo>();

    public virtual ICollection<Empleo> EmpleoEmpleados { get; set; } = new List<Empleo>();

    public virtual Jac? Jac { get; set; }

    public virtual ICollection<PropuestaEmpleo> PropuestaEmpleoEmpleadors { get; set; } = new List<PropuestaEmpleo>();

    public virtual ICollection<PropuestaEmpleo> PropuestaEmpleoEmpleados { get; set; } = new List<PropuestaEmpleo>();

    public virtual ICollection<PropuestaServicio> PropuestaServicioEmpleadors { get; set; } = new List<PropuestaServicio>();

    public virtual ICollection<PropuestaServicio> PropuestaServicioEmpleados { get; set; } = new List<PropuestaServicio>();

    public virtual Rol? RolNavigation { get; set; }

    public virtual ICollection<Servicio> ServicioEmpleadors { get; set; } = new List<Servicio>();

    public virtual ICollection<Servicio> ServicioEmpleados { get; set; } = new List<Servicio>();
}
