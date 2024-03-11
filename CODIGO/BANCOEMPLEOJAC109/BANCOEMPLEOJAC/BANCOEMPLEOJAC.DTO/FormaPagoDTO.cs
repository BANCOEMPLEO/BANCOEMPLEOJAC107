using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class FormaPagoDTO
    {
        public int IdFormaPago {  get; set; } 
        public DateTime FechaHoraTransaccion { get; set; }  
        public string? EmpleadorIdOrigen { get; set; }
        public string? EntidadOrigen { get; set; }
        public string? CuentaOrigen { get; set; }
        public string? CodigoTransacción { get; set; }
        public string? EmpleadoIdDestino { get; set; }
        public string? EntidadDestino { get; set; }
        public string? CuentaDestino { get; set; }
        public string? Foto { get; set; }
    }
}
