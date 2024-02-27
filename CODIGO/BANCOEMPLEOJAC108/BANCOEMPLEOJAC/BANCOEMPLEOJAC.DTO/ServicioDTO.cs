using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class ServicioDTO
    {
        public int IdServicio { get; set; }
        public int? CategoriaId { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre Servicio o Producto")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese Descripción Servicio o Producto")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Ingrese Características de Servicio o Producto")]
        public string? Caracteristicas { get; set; }
        public int? EmpleadoId { get; set; }
        public int? EmpleadorId { get; set; }
        [Required(ErrorMessage = "Ingrese Cantidad Servicio o Producto")]
        public int? Cantidad { get; set; }
        [Required(ErrorMessage = "Ingrese Precio Servicio o Producto")]
        public decimal? Precio { get; set; }
        [Required(ErrorMessage = "Ingrese Precio Oferta Servicio o Producto")]
        public decimal? PrecioOferta { get; set; }
        public DateTime FechaHoraCreacion { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Ingrese Ubicacion Servicio o Producto")]
        public string? Ubicacion { get; set; }
        public string? Foto { get; set; }
        public string? Observaciones { get; set; }

        public virtual UsuarioDTO? Usuario { get; set; } = null!;
        public virtual CategoriaDTO? Categoria { get; set; } = null!;

    }
}
