using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class EmpleadoDTO
    {
        public int Id { get; set; }

        public int? UsuarioId { get; set; }
        [Required(ErrorMessage = "Ingrese La Identificación")]
        public string Identificacion { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Primer Nombre")]
        public string PrimerNombre { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Segundo Nombre")]
        public string SegundoNombre { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Primer Apellido")]
        public string PrimerApellido { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Segundo Apellido")]
        public string SegundoApellido { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Ingrese Correo Electronico")]
        public string CorreoElectronico { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Movil")]
        public string Movil { get; set; } = null!;

        public string? LinkedIn { get; set; } = null!;

        public bool? Vacante { get; set; }

        public string? Observaciones { get; set; } = null!;

        public virtual ICollection<EmpleoDTO> Empleos { get; set; } = new List<EmpleoDTO>();

        //public virtual ICollection<EmpleoxEmpleado> EmpleoxEmpleados { get; set; } = new List<EmpleoxEmpleado>();

        public virtual ICollection<PropuestaEmpleoDTO> PropuestaEmpleos { get; set; } = new List<PropuestaEmpleoDTO>();

        public virtual ICollection<PropuestaServicioDTO> PropuestaServicios { get; set; } = new List<PropuestaServicioDTO>();

        public virtual ICollection<ServicioDTO> Servicios { get; set; } = new List<ServicioDTO>();

        public virtual UsuarioDTO? Usuario { get; set; }

    }
}
