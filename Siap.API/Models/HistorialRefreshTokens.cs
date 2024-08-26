using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siap.API.Models
{
    public class HistorialRefreshTokens
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int IdHistorialToken { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
        [Required]
        [MaxLength(500)]
        public string Token { get; set; }

        [MaxLength(500)]
        public string RefreshToken { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaExpiracion { get; set; }

        [NotMapped]
        public bool EsActivo => FechaExpiracion > DateTime.Now;
    }
}
