﻿using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class TipoJuntaDirectiva
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<JuntaDirectivaReuniones> JuntaDirectivaReuniones { get; set; } = new List<JuntaDirectivaReuniones>();
}
