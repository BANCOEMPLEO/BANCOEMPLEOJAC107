using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.MODELO;

public partial class Empleado
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public string Identificacion { get; set; } = null!;

    public string PrimerNombre { get; set; } = null!;

    public string SegundoNombre { get; set; } = null!;

    public string PrimerApellido { get; set; } = null!;

    public string SegundoApellido { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public string Movil { get; set; } = null!;

    public string LinkedIn { get; set; } = null!;

    public bool Vacante { get; set; }

    public string Observaciones { get; set; } = null!;

    public virtual ICollection<Empleo> Empleos { get; set; } = new List<Empleo>();

    public virtual ICollection<EmpleoxEmpleado> EmpleoxEmpleados { get; set; } = new List<EmpleoxEmpleado>();

    public virtual ICollection<PropuestaEmpleo> PropuestaEmpleos { get; set; } = new List<PropuestaEmpleo>();

    public virtual ICollection<PropuestaServicio> PropuestaServicios { get; set; } = new List<PropuestaServicio>();

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();

    public virtual Usuario? Usuario { get; set; }
}
