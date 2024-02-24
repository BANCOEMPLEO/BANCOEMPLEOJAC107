using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class ServicioDTO
    {
        public int Id { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? EmpleadoId { get; set; }

        public int? EmpleadorId { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Precio { get; set; }

        public decimal? PrecioOferta { get; set; }

        public string? Ubicacion { get; set; }

        public string? Foto { get; set; }

        public int? PerfilCargoId { get; set; }

        public string? Observaciones { get; set; }

        public virtual EmpleadoDTO? Empleado { get; set; }

        public virtual EmpleadorDTO? Empleador { get; set; }

        public virtual PerfilCargoDTO? PerfilCargo { get; set; }

        public virtual ICollection<PropuestaServicioDTO> PropuestaServicios { get; set; } = new List<PropuestaServicioDTO>();

    }
}
