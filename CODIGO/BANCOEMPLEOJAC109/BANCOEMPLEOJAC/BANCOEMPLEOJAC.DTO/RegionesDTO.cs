using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class RegionesDTO
    {
        public string IdRegion { get; set; } = null!;

        public string? Nombre { get; set; }

        public string? IdDepartamento { get; set; }

        public int? Habitantes { get; set; }

        public int? Altitud { get; set; }

        public int? Temperatura { get; set; }

        public int? AreaKm2 { get; set; }

        public string? CodigoPostal { get; set; }

        public int? Aptitud { get; set; }

        public string? Observaciones { get; set; }

        public virtual DepartamentoDTO? IdDepartamentoNavigation { get; set; }

        public virtual ICollection<MunicipioDTO> Municipios { get; set; } = new List<MunicipioDTO>();
    }
}
