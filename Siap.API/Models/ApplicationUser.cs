using Microsoft.AspNetCore.Identity;

namespace Siap.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Rut {  get; set; }
        public int PersonalId{ get; set; }

    }
}
