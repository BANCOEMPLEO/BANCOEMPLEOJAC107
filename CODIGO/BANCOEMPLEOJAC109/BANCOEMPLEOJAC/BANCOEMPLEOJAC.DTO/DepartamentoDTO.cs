using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class DepartamentoDTO
    {
        public string IdDepartamento { get; set; } = null!;

        public string? Nombre { get; set; }

        public string? Capital { get; set; }

        public string? IdPais { get; set; }

        public int? Habitantes { get; set; }

        public int? Altitud { get; set; }

        public int? Temperatura { get; set; }

        public int? AreaKm2 { get; set; }

        public string? CodigoPostal { get; set; }

        public int? Aptitud { get; set; }

        public string? Observaciones { get; set; }

        public virtual PaisDTO? IdPaisNavigation { get; set; }

        public virtual ICollection<RegionesDTO> Regiones { get; set; } = new List<RegionesDTO>();
    }
}
