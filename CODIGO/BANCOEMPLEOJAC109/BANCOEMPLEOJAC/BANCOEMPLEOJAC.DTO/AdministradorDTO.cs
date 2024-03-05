using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.DTO
{
    public class AdministradorDTO
    {
        public int IdAdministrador { get; set; }

        public int? JacId { get; set; }

        public int? UsuarioId { get; set; }

        public virtual JacDTO? Jac { get; set; }

        public virtual UsuarioDTO? Usuario { get; set; }
    }
}
