using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class MunicipioDTO
    {
        public string IdMunicipio { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Nombres")]
        [MinLength(5, ErrorMessage = "Mínimo 5 Caracteres.")]
        [StringLength(50, ErrorMessage = "Maximo 50 Caracteres")]
        public string? Nombre { get; set; }
        public string? IdRegion { get; set; }
        public int? Habitantes { get; set; }
        public short? Altitud { get; set; }
        public short? Temperatura { get; set; }
        public short? AreaKm2 { get; set; }
        public string? CodigoPostal { get; set; }
        public int? Aptitud { get; set; }
        public string? Observaciones { get; set; }

    }
}
