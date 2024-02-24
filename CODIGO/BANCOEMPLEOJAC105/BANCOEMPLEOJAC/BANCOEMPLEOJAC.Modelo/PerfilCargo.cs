using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class PerfilCargo
{
    public int IdPerfilCargo { get; set; }

    public int? IdTipoContrato { get; set; }

    public string? Descripcion { get; set; }

    public string? Requisitos { get; set; }

    public decimal? Compensacion { get; set; }

    public int? JacId { get; set; }

    public string? Notas { get; set; }

    public virtual ICollection<Empleo> Empleos { get; set; } = new List<Empleo>();

    public virtual TipoContrato? IdTipoContratoNavigation { get; set; }

    public virtual Jac? Jac { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
