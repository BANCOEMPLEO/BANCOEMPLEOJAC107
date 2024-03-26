using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class FormaPagoDTO
    {
        public int IdFormaPago { get; set; } 
        public DateTime FechaHoraTransaccion { get; set; }  = DateTime.Now;
        public string? EmpleadorIdOrigen { get; set; }
        [Required(ErrorMessage ="Se requiere Entidad Origen y Destino")]
        public string? EntidadOrigen { get; set; }
        [Required(ErrorMessage = "Se requiere Cuenta o Número Origen")]
        public string? CuentaOrigen { get; set; }
        [Required(ErrorMessage = "Se requiere Código Transacción")]
        public string? CodigoTransacción { get; set; }
        [Required(ErrorMessage = "Se requiere Empleado Destino")]
        public string? EmpleadoIdDestino { get; set; }
        public string? EntidadDestino { get; set; }
        [Required(ErrorMessage = "Se requiere Cuenta o Número Destino")]
        public string? CuentaDestino { get; set; }
        public string? Foto { get; set; }
    }
}
