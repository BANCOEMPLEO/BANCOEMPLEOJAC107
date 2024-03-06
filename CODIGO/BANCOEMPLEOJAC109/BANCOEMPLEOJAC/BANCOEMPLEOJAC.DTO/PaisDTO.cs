using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class PaisDTO
    {
        public string IdPais { get; set; } = null!;

        public string? Nombre { get; set; }

        public string? Descripion { get; set; }

        public string? Region { get; set; }

        public virtual ICollection<DepartamentoDTO> Departamentos { get; set; } = new List<DepartamentoDTO>();
    }
}
