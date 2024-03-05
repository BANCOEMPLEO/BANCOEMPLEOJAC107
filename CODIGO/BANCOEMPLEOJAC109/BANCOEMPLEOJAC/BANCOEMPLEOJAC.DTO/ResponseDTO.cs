using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class ResponseDTO<T>
    {
        public T? Resultado { get; set; }
        public bool EsCorrecto { get; set; } = false;
        public string? Mensaje { get; set; }
    }
}
