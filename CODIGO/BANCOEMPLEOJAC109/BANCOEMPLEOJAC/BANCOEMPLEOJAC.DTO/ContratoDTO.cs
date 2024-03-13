using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class ContratoDTO
    {
        public int IdContrato { get; set; }

        public int? UsuarioId { get; set; }

        public decimal? Total { get; set; }
        public DateTime? FechaCreacion { get; set; }


        public virtual ICollection<DetallePropuestaDTO> DetallePropuesta { get; set; } = new List<DetallePropuestaDTO>();
    }
}
