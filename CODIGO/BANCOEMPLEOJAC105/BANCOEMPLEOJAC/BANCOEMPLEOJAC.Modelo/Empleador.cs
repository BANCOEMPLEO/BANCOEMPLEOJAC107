using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class Empleador
{
    public int IdEmpleador { get; set; }

    public int? UsuarioId { get; set; }

    public string Identificacion { get; set; } = null!;

    public string? PrimerNombre { get; set; }

    public string? SegundoNombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string Descripción { get; set; } = null!;

    public string CorrerElectronico { get; set; } = null!;

    public string LinkedIn { get; set; } = null!;

    public string Movil { get; set; } = null!;

    public string Observaciones { get; set; } = null!;

    public virtual ICollection<Empleo> Empleos { get; set; } = new List<Empleo>();

    public virtual ICollection<PropuestaServicio> PropuestaServicios { get; set; } = new List<PropuestaServicio>();

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();

    public virtual Usuario? Usuario { get; set; }
}
