using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage ="Ingrese los Nombres")]
        public string? Nombres { get; set; }
        [Required(ErrorMessage = "Ingrese los Apellidos")]
        public string? Apellidos { get; set; }
        [Required(ErrorMessage = "Ingrese el Correo")]

        public string? Correo { get; set; }
        [Required(ErrorMessage = "Ingrese el número celular")]
        public string? Celular { get; set; }
        [Required(ErrorMessage = "Ingrese contraseña")]
        public string? Clave { get; set; }
        [Required(ErrorMessage = "Ingrese confirmar contraseña")]
        public string? ConfirmarClave { get; set; }

        public int? Rol { get; set; }

        public int? JacId { get; set; }

        public string? Foto { get; set; }


    }
}
