using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class ActividadEconomica
{
    public int IdActividad { get; set; }

    public string? IdSeccion { get; set; }

    public string? IdDivision { get; set; }

    public string? IdGrupo { get; set; }

    public string? IdClase { get; set; }

    public string? Descripcion { get; set; }

    public string? Detalle { get; set; }

    public virtual DivisionActividadEconomica? IdDivisionNavigation { get; set; }

    public virtual GrupoActividadEconomica? IdGrupoNavigation { get; set; }

    public virtual SeccionActividadEconomica? IdSeccionNavigation { get; set; }

    public virtual ICollection<PerfilCargo> PerfilCargos { get; set; } = new List<PerfilCargo>();
}
