using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siap.API.Models
{
    public class PerfilContacto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int PersonalId { get; set; }
        [ForeignKey("PersonalId")]
        public virtual Personal Personal { get; set; }
        public string TelefonoFijo { get; set; } = string.Empty;
        public string TelefonoCelular { get; set; } = string.Empty;
        public string TelefonoFiscal { get; set; } = string.Empty;
        public string AnexoEmco { get; set; } = string.Empty;
        public string CorreoElectronico { get; set; } = string.Empty;
        public string CorreoEmco { get; set; } = string.Empty;
        public string CorreoSeguro { get; set; } = string.Empty;
        public string TelefonoEmergencia { get; set; } = string.Empty;
        public string RelacionEmergencia { get; set; } = string.Empty;
        public string Domicilio { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}
