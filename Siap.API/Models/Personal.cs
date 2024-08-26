using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siap.API.Models
{
    public class Personal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Rut { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }
        [Required]
        public string ApellidoMaterno { get; set; }
        [Required]
        public DateTime? FechaNacimiento { get; set; } = DateTime.Now;
        [Required]
        public int Sexo { get; set; }
        [Required]
        public bool Disponibilidad { get; set; } = true;

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;

        public virtual PerfilProfesional PerfilProfesional { get; set; }
        public virtual PerfilContacto PerfilContacto { get; set; }
    }
}
