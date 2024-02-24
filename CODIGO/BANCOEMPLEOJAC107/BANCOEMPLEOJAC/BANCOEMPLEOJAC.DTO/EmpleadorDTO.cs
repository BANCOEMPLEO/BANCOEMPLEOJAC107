using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class EmpleadorDTO
    {
        public int IdEmpleador { get; set; }

        public int? UsuarioId { get; set; }

        public bool? Contratando { get; set; }

        public DateTime? FechaHoraCreacion { get; set; }

        public string? Observaciones { get; set; }

    }
}
