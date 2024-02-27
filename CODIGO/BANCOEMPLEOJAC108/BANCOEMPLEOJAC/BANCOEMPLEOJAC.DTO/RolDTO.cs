using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class RolDTO
    {
        public int IdRol { get; set; }
        [Required(ErrorMessage = "Ingrese Nombres")]
        [MinLength(5, ErrorMessage = "Mínimo 5 Caracteres.")]
        [StringLength(50, ErrorMessage = "Maximo 50 Caracteres")]
        public string? Nombre { get; set; }
    }
}
