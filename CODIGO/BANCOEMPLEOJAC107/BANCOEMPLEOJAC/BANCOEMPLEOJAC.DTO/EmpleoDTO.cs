using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class EmpleoDTO
    {
        public int IdEmpleo { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre del Empleo")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Descripción")]
        public string Descripcion { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Requisitos")]
        public string Requisitos { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Fecha y Hora de Inicio del Empleo")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de fecha no válido")]
        public DateTime FechaHoraInicio { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Ingrese Fecha y Hora de Finalización del Empleo")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de fecha no válido")]
        public DateTime FechaHoraFin { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Ingrese Ubicación de Empleo")]
        public string Ubicacion { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Cantidad de Empleos Ofrecidos")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "Ingrese Precio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Ingrese Precio Oferta")]
        public decimal? PrecioOferta { get; set; }
        public bool Activo { get; set; }
        [Required(ErrorMessage = "Ingrese Fecha y Hora en que se Activa el Empleo")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de fecha no válido")]
        public DateTime FechaHoraActiva { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Ingrese Fecha y Hora en que se Inactiva el Empleo")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de fecha no válido")]
        public DateTime FechaHoraInactiva { get; set; } = DateTime.Now;
        public int? EmpleadorId { get; set; }
        public int? EmpleadoId { get; set; }
        [Required(ErrorMessage = "Ingrese El Perfil o Cargo del Empleo Ofrecido")]
        public int PerfilCargoId { get; set; }
        public DateTime? FechaHoraCreacion { get; set; } = DateTime.Now;

        public string Observaciones { get; set; } = null!;

        public virtual EmpleadoDTO? Empleado { get; set; }

        public virtual EmpleadorDTO? Empleador { get; set; } = null!;

        public virtual PerfilCargoDTO? PerfilCargo { get; set; } = null!;

    }
}
