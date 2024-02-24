using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class EmpleadorDTO
    {
        public int IdEmpleador { get; set; }

        public int? UsuarioId { get; set; }
        [Required(ErrorMessage = "Ingrese La Identificación")]
        public string Identificacion { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Primer Nombre")]
        public string? PrimerNombre { get; set; }
        [Required(ErrorMessage = "Ingrese Segundo Nombre")]
        public string? SegundoNombre { get; set; }
        [Required(ErrorMessage = "Ingrese Primer Apellido")]
        public string? PrimerApellido { get; set; }
        [Required(ErrorMessage = "Ingrese Segundo Apellido")]
        public string? SegundoApellido { get; set; }
        [Required(ErrorMessage = "Ingrese Descripción")]
        public string Descripción { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Correo Electronico")]
        public string CorrerElectronico { get; set; } = null!;

        public string LinkedIn { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Movil")]
        public string Movil { get; set; } = null!;

        public string Observaciones { get; set; } = null!;

        public virtual ICollection<EmpleoDTO> Empleos { get; set; } = new List<EmpleoDTO>();

        public virtual ICollection<PropuestaServicioDTO> PropuestaServicios { get; set; } = new List<PropuestaServicioDTO>();

        public virtual ICollection<ServicioDTO> Servicios { get; set; } = new List<ServicioDTO>();

        public virtual UsuarioDTO? Usuario { get; set; }

    }
}
