using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class UsuarioEditaDTO
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Ingrese Identificación")]
        [Range(10000,99999999999, ErrorMessage = "La Identificación debe estar entre 10000 y 99.999'999.999")]
        public int? Identificacion { get; set; }
        [Required(ErrorMessage = "Ingrese Nombres")]
        [MinLength(5, ErrorMessage = "Mínimo 5 Caracteres.")]
        [StringLength(50, ErrorMessage = "Maximo 50 Caracteres")]
        public string? Nombres { get; set; }
        [Required(ErrorMessage = "Ingrese Apellidos")]
        [MinLength(5, ErrorMessage = "Mínimo 5 Caracteres.")]
        [StringLength(50, ErrorMessage = "Maximo 50 Caracteres")]
        public string? Apellidos { get; set; }
        [Required(ErrorMessage = "Ingrese Correo")]
        [MinLength(3, ErrorMessage = "Mínimo 3 Caracteres.")]
        [StringLength(50, ErrorMessage = "Maximo 50 Caracteres")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "Ingrese número celular")]
        [Range(2999999999, 3999999999, ErrorMessage = "El número debe estar entre 2999999999 y 399999999")]
        public string? Celular { get; set; }
        [StringLength(100, ErrorMessage = "Maximo 100 Caracteres")]
        public string? Redes { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "Formato de fecha no válido")]
        public DateTime FechaNacimiento { get; set; }
        [MinLength(8, ErrorMessage = "Mínimo 8 Caracteres.")]
        [StringLength(500, ErrorMessage = "Maximo 50 Caracteres")]
        public string? Clave { get; set; }
        [MinLength(8, ErrorMessage = "Mínimo 8 Caracteres.")]
        [StringLength(500, ErrorMessage = "Maximo 50 Caracteres")]
        [Compare("Clave", ErrorMessage = "Las claves deben coincidir")]
        public string? ConfirmarClave { get; set; }
        [StringLength(500, ErrorMessage = "Maximo 500 Caracteres")]
        public string? Observaciones { get; set; }
        public int? Rol { get; set; }
        public int? JacId { get; set; }
        public string? Foto { get; set; }

        public virtual JacDTO? Jac { get; set; }

    }
}
