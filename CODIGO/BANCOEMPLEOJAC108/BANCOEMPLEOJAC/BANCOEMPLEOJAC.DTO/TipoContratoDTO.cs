using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class TipoContratoDTO
    {
        public int IdTipoContrato { get; set; }
        [Required(ErrorMessage = "Ingrese Nombres")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese Descripción")]
        public string? Descripción { get; set; }

    }
}
