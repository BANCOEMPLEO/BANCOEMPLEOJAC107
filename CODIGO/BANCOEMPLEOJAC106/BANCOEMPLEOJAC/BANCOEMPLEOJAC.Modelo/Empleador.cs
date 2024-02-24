using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class Empleador
{
    public int IdEmpleador { get; set; }

    public int? UsuarioId { get; set; }

    public bool? Contratando { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<Empleo> Empleos { get; set; } = new List<Empleo>();

    public virtual ICollection<PropuestaServicio> PropuestaServicios { get; set; } = new List<PropuestaServicio>();

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();

    public virtual Usuario? Usuario { get; set; }
}
