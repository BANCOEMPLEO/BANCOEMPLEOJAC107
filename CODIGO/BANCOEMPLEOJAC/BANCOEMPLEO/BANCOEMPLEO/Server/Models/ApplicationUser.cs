using Microsoft.AspNetCore.Identity;

namespace BANCOEMPLEO.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        float latitud { get; set; }
        float longitud { get; set; }
        int id_vereda { get; set; }
    }
}