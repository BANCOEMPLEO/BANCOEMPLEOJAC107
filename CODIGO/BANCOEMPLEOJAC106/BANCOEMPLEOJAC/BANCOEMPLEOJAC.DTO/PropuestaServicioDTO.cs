using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class PropuestaServicioDTO
    {
        public int IdPropuestaServicio { get; set; }

        public int? EmpleadoId { get; set; }

        public int? EmpleadorId { get; set; }

        public int? ServicioId { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre Servicio o Producto")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese Descripción Servicio o Producto")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Ingrese Cantidad Servicio o Producto")]
        public int? Cantidad { get; set; }
        [Required(ErrorMessage = "Ingrese Valor Servicio o Producto")]
        public decimal? Valor { get; set; }
        [Required(ErrorMessage = "Ingrese Ubicación Servicio o Producto")]
        public string? Ubicacion { get; set; }
        [Required(ErrorMessage = "Ingrese Foto Servicio o Producto")]
        public string? Foto { get; set; }

        public DateTime? FechaHoraRevisaPropuesta { get; set; }

        public DateTime? FechaHoraReRepropone { get; set; }

        public DateTime? FechaHoraAcepta { get; set; }

        public bool? RePropone { get; set; }

        public bool? Aceptada { get; set; }

        public string? Observaciones { get; set; }

        public virtual ICollection<DetallePropuestaDTO> DetallePropuesta { get; set; } = new List<DetallePropuestaDTO>();
    }
}
