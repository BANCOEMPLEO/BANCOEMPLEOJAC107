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
        [Required(ErrorMessage = "Ingrese Actividad Económica")]
        public int? IdActividadEconomica { get; set; }
        [Required(ErrorMessage = "Ingrese Tipo Contrato")]
        public int? IdTipoContrato { get; set; }
        [Required(ErrorMessage = "Ingrese Descripción")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Ingrese Requisitos")]
        public string? Requisitos { get; set; }
        [Required(ErrorMessage = "Ingrese Valor Compensación")]
        public decimal? Compensacion { get; set; }
        [Required(ErrorMessage = "Ingrese Junta de Acción Comunal")]
        public int? JacId { get; set; }
        public string? Observaciones { get; set; }



    }
}
