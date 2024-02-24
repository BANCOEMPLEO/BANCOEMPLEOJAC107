﻿using System;
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

    public virtual ICollection<Empleador> Empleadors { get; set; } = new List<Empleador>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Jac? Jac { get; set; }

    public virtual Rol? RolNavigation { get; set; }
}