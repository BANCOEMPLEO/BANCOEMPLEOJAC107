using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }
        public int? ActividadEconomicaId { get; set; }
        public int? TipoContratoId { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre Servicio o Producto")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese Descripción Servicio o Producto")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Ingrese Características Servicio o Producto")]
        public string? Caracteristicas { get; set; }
        public decimal? Valor { get; set; }
        [Required(ErrorMessage = "Ingrese Junta de Acción Comunal Local")]
        public int? JacId { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public string? Observaciones { get; set; }

    }
}
