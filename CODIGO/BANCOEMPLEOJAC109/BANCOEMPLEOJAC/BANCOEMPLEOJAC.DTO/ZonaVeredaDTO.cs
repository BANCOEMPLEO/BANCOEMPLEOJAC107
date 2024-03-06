using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class ZonaVeredaDTO
    {
        public string IdzonaVereda { get; set; } = null!;

        public string? IdMunicipio { get; set; }
        [Required(ErrorMessage = "Ingrese Nombres")]
        [MinLength(5, ErrorMessage = "Mínimo 5 Caracteres.")]
        [StringLength(50, ErrorMessage = "Maximo 50 Caracteres")]
        public string? Nombre { get; set; }

        public string? Observaciones { get; set; }
        [Required(ErrorMessage = "Ingrese Ubicación")]
        [MinLength(5, ErrorMessage = "Mínimo 5 Caracteres.")]
        [StringLength(2000, ErrorMessage = "Maximo 2000 Caracteres")]
        public string? Ubicacion { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }

        public int? ImagenId { get; set; }
        public virtual MunicipioDTO? IdMunicipioNavigation { get; set; }

        public virtual ICollection<JacDTO> Jacs { get; set; } = new List<JacDTO>();
    }
}
