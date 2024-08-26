using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siap.API.Models
{
    public class PerfilProfesional
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int PersonalId { get; set; }
        [ForeignKey("PersonalId")]
        public virtual Personal Personal { get; set; }
        [Required]
        public int InstitucionId { get; set; }
        [ForeignKey("InstitucionId")]
        public virtual Institucion Institucion { get; set; }
        [Required]
        public int GradoId { get; set; }
        [ForeignKey("GradoId")]
        public virtual Grado Grado { get; set; }
        [Required]
        public int EscalafonId { get; set; }
        [ForeignKey("EscalafonId")]
        public virtual Escalafon Escalafon { get; set; }
        [Required]
        public int DireccionId { get; set; }
        [ForeignKey("DireccionId")]
        public virtual Direccion Direccion { get; set; }
        [Required]
        public int DepartamentoId { get; set; }
        [ForeignKey("DepartamentoId")]
        public virtual Departamento Departamento { get; set; }
        [Required]
        public int SeccionId { get; set; }
        [ForeignKey("SeccionId")]
        public virtual Seccion Seccion { get; set; }
        [Required]
        public string Puesto { get; set; } = string.Empty;
        [Required]
        public DateTime FechaPresentacion { get; set; } = DateTime.Now;
        public bool MedallaEMCO { get; set; } = false;
        public bool MedallaMDN { get; set; } = false;
        public DateTime FechaDestinacion { get; set; } = DateTime.Now;
    }
}
