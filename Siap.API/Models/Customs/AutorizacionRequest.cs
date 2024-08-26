using System.ComponentModel.DataAnnotations;

namespace Siap.API.Models.Customs
{
    public class AutorizacionRequest
    {
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
