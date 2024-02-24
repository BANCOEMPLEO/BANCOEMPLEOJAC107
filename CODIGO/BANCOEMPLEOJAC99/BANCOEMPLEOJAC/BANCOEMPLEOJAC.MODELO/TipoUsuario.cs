using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.MODELO;

public partial class TipoUsuario
{
    public int IdRol { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
