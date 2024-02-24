using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class Administrador
{
    public int IdAdministrador { get; set; }

    public int? JacId { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Jac? Jac { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
