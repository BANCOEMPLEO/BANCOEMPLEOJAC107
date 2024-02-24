using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class PropuestaEmpleoDTO
    {
        public int Id { get; set; }

        public int? PropuestaEmpleoAnteriorId { get; set; }

        public int? Orden { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public int? EmpleoId { get; set; }

        public int? EmpleadoId { get; set; }
        [Required(ErrorMessage = "Ingrese la Descripción")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Ingrese la Cantidad")]
        public int? Cantidad { get; set; }
        [Required(ErrorMessage = "Ingrese Requiitos")]
        public string? Requisitos { get; set; }
        [Required(ErrorMessage = "Ingrese Fecha y Hora Inicio")]
        public DateTime? FechaHoraInicio { get; set; }
        [Required(ErrorMessage = "Ingrese Fecha y Hora Fin")]
        public DateTime? FechaHoraFin { get; set; }
        [Required(ErrorMessage = "Ingrese Ubicación")]
        public string? Ubicacion { get; set; }
        [Required(ErrorMessage = "Ingrese Valor")]
        public decimal? Valor { get; set; }

        public DateTime? FechaHoraRevisaEmpleador { get; set; }

        public DateTime? FechaHoraReProponeEmpleador { get; set; }

        public DateTime? FechaHoraAceptaEmpleador { get; set; }

        public bool? RePropone { get; set; }

        public bool? Aceptada { get; set; }

        public string? Observaciones { get; set; }

        public virtual EmpleoDTO? Empleo { get; set; }


    }
}
