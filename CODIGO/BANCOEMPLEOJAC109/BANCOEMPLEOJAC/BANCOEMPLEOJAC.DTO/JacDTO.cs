using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class JacDTO
    {
        public int IdJac { get; set; }
        [Required(ErrorMessage = "Ingrese NIT")]
        public int? Nit { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese Zona, Localidad o Vereda")]
        public string? IdZonaVereda { get; set; }
        [Required(ErrorMessage = "Ingrese Delimitación")]
        public string? Delimitacion { get; set; }
        [Required(ErrorMessage = "Ingrese Número Personeria Juridica")]
        public int? NumeroPersoneriaJuridica { get; set; }
        [Required(ErrorMessage = "Ingrese Fecha Registro Personeria Juridica")]
        public DateTime? FechaRegistroPersoneriaJuridica { get; set; }
        public int? IdAdministradorLocal { get; set; }
        public string? NombreAdminLocal { get; set; }
        public string? Foto { get; set; }
        public string? Observaciones { get; set; }
        public virtual ZonaVeredaDTO? IdZonaVeredaNavigation { get; set; }

    }
}
