using Microsoft.AspNetCore.Identity;

namespace Siap.API.Models
{
    public class Users : IdentityUser
    {
        public int PersonalId { get; set; } = 0;

        public DateTime FechaIngreso { get; set; }
    }
}
