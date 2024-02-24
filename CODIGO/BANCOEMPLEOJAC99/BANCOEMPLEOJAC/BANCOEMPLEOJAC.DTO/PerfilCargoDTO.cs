using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class PerfilCargoDTO
    {
        public int IdPerfilCargo { get; set; }

        public int? IdTipoContrato { get; set; }
        [Required(ErrorMessage = "Ingrese la Descripción")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Ingrese los Requisitos")]
        public string? Requisitos { get; set; }
        [Required(ErrorMessage = "Ingrese la Compesación o Valor")]
        public decimal? Compensacion { get; set; }

        public int? JacId { get; set; }

        public string? Notas { get; set; }


    }
}
