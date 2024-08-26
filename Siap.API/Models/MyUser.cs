using Microsoft.AspNetCore.Identity;

namespace Siap.API.Models
{
    public class MyUser : IdentityUser
    {
        public string Nombre { get; set; }
        public DateTime UltimoAcceso { get; set; }
    }
}
