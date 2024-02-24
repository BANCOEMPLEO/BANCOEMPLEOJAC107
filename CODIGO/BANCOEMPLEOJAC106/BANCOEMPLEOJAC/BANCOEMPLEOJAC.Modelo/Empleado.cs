using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int? UsuarioId { get; set; }

    public bool? Vacante { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<Empleo> Empleos { get; set; } = new List<Empleo>();

    public virtual ICollection<PropuestaEmpleo> PropuestaEmpleos { get; set; } = new List<PropuestaEmpleo>();

    public virtual ICollection<PropuestaServicio> PropuestaServicios { get; set; } = new List<PropuestaServicio>();

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();

    public virtual Usuario? Usuario { get; set; }
}
