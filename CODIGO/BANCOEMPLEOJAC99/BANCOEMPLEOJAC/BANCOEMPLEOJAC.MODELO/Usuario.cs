using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.MODELO;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Correo { get; set; }

    public string? Celular { get; set; }

    public string? Clave { get; set; }

    public int? Rol { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? JacId { get; set; }

    public string? Foto { get; set; }

    public virtual ICollection<Administrador> Administradors { get; set; } = new List<Administrador>();

    public virtual ICollection<Empleador> Empleadors { get; set; } = new List<Empleador>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Jac? Jac { get; set; }

    public virtual TipoUsuario? RolNavigation { get; set; }
}
