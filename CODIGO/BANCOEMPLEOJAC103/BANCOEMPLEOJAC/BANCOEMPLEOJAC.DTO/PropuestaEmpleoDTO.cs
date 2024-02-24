using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class PropuestaEmpleoDTO
    {
        public int Id { get; set; }

        public int? Orden { get; set; }

        public int? EmpleoId { get; set; }

        public int? EmpleadoId { get; set; }

        public string? Descripcion { get; set; }

        public string? Requisitos { get; set; }

        public DateTime? FechaHoraInicio { get; set; }

        public DateTime? FechaHoraFin { get; set; }

        public string? Ubicacion { get; set; }

        public decimal? Compensacion { get; set; }

        public DateTime? FechaHoraRevisaEmpleador { get; set; }

        public DateTime? FechaHoraReProponeEmpleador { get; set; }

        public DateTime? FechaHoraAceptaEmpleador { get; set; }

        public bool? RePropone { get; set; }

        public bool? Aceptada { get; set; }

        public string? Observaciones { get; set; }

    }
}
