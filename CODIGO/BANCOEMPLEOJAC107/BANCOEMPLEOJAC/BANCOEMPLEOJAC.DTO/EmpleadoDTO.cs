using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class EmpleadoDTO
    {
        public int IdEmpleado { get; set; }
        public int? UsuarioId { get; set; }
        public bool? Vacante { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public string? Observaciones { get; set; }
        public virtual UsuarioDTO? Usuario { get; set; }

    }
}
