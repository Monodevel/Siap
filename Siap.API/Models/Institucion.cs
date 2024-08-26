using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siap.API.Models
{
    public class Institucion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0;
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Sigla  { get; set; }
        public DateTime Created {  get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
        public virtual ICollection<Escalafon> Escalafones { get; set; } = new HashSet<Escalafon>();
        public virtual ICollection<Grado> Grados { get; set; } = new HashSet<Grado>();

        public virtual ICollection<PerfilProfesional> PerfilesProfesionales { get; set; } = new HashSet<PerfilProfesional>();

    }
}
