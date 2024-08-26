using System.ComponentModel.DataAnnotations;

namespace Siap.API.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public int Password { get; set; }
    }
}
