using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class MensajeWhastAppDTO
    {
        //public int Id { get; set; }
        [Required(ErrorMessage = "Es necesario Desde el número que se envía")]
        public string DeNumero { get; set; }
        [Required(ErrorMessage ="Es necesario Para el número")]
        public string ParaNumero { get; set; }
        [Required(ErrorMessage = "Es necesario el Mensaje a enviar")]
        public string Mensaje { get; set; }

    }
}
