using System;
using System.Collections.Generic;

namespace BANCOEMPLEOJAC.Modelo;

public partial class EmpleoxEmpleado
{
    public int Id { get; set; }

    public DateTime FechaHoraInicio { get; set; }

    public DateTime FechaHoraFin { get; set; }

    public string Notas { get; set; } = null!;

    public int EmpleoId { get; set; }

    public int EmpleadoId { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Empleo Empleo { get; set; } = null!;
}
