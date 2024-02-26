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
        public int IdPropuestaEmpleo { get; set; }

        public int? PropuestaEmpleoAnteriorId { get; set; }
        public int? EmpleoId { get; set; }

        public int? Orden { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre de Empleo Propuesto")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese Descripción de Empleo Propuesta")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Ingrese Requisitos de Empleo Propuestos")]
        public string? Requisitos { get; set; }
        [Required(ErrorMessage = "Ingrese Fecha y Hora de Inicio del Empleo")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de fecha no válido")]
        public DateTime? FechaHoraInicio { get; set; }
        [Required(ErrorMessage = "Ingrese Fecha y Hora de Finalización del Empleo")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de fecha no válido")]
        public DateTime? FechaHoraFin { get; set; }
        [Required(ErrorMessage = "Ingrese Propuesta de Ubicación")]
        public string? Ubicacion { get; set; }
        [Required(ErrorMessage = "Ingrese Cantidad Propuesta de Empleo(s)")]
        public int? Cantidad { get; set; }
        [Required(ErrorMessage = "Ingrese Valor Propuesta de Empleo")]
        public decimal? Valor { get; set; }
        public int? EmpleadoId { get; set; }
        [Required(ErrorMessage = "Ingrese Fecha y Hora Revisá Empleador")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de fecha no válido")]
        public DateTime? FechaHoraRevisaEmpleador { get; set; }
        [Required(ErrorMessage = "Ingrese Fecha y Hora en que RePropone Empleador")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de fecha no válido")]
        public DateTime? FechaHoraReProponeEmpleador { get; set; }
        [Required(ErrorMessage = "Ingrese Fecha y Hora en que Acepta Prouesta Empleador")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de fecha no válido")]
        public DateTime? FechaHoraAceptaEmpleador { get; set; }

        public bool? RePropone { get; set; }

        public bool? Aceptada { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public string? Observaciones { get; set; }

        public virtual ICollection<DetallePropuestaDTO> DetallePropuesta { get; set; } = new List<DetallePropuestaDTO>();

        public virtual ICollection<PropuestaEmpleoDTO> InversePropuestaEmpleoAnterior { get; set; } = new List<PropuestaEmpleoDTO>();
        public virtual EmpleoDTO? Empleo { get; set; }
        public virtual EmpleadoDTO? Emplado { get; set; }

        public virtual PropuestaEmpleoDTO? PropuestaEmpleoAnterior { get; set; }

    }
}
