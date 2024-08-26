using Microsoft.AspNetCore.Identity;

namespace Siap.API.Models
{
    public class MyRol : IdentityRole
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
