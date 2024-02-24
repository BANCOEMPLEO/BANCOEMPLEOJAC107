using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class PropuestaServicioDTO
    {
        public int Id { get; set; }

        public int? PropuestaServicioAnteriorId { get; set; }

        public int? Orden { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? EmpleadoId { get; set; }

        public int? EmpleadorId { get; set; }

        public int? ServicioId { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Valor { get; set; }

        public string? Ubicacion { get; set; }

        public string? Foto { get; set; }

        public DateTime? FechaHoraRevisaPropuesta { get; set; }

        public DateTime? FechaHoraReRepropone { get; set; }

        public DateTime? FechaHoraAcepta { get; set; }

        public bool? RePropone { get; set; }

        public bool? Aceptada { get; set; }

        public string? Observaciones { get; set; }

        public virtual ICollection<DetallePropuestaDTO> DetallePropuesta { get; set; } = new List<DetallePropuestaDTO>();

        public virtual EmpleadoDTO? Empleado { get; set; }

        public virtual EmpleadorDTO? Empleador { get; set; }

        public virtual ICollection<PropuestaServicioDTO> InversePropuestaServicioAnterior { get; set; } = new List<PropuestaServicioDTO>();

        public virtual PropuestaServicioDTO? PropuestaServicioAnterior { get; set; }

        public virtual ServicioDTO? Servicio { get; set; }

    }
}
