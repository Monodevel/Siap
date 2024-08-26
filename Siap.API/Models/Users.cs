using Microsoft.AspNetCore.Identity;

namespace Siap.API.Models
{
    public class Users : IdentityUser
    {
        public string Rut { get; set; }
        public int PersonalId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public DateTime FechaIngreso { get; set; }
    }
}
