using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siap.API.Models
{
    public class Categoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public int Antiguedad { get; set; }
        public DateTime Created {  get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;

        [Required]
        public int InstitucionId { get; set; }

        [ForeignKey("InstitucionId")]
        public virtual Institucion Institucion { get; set; }

        public virtual ICollection<Grado> Grados { get; set; } = new HashSet<Grado>();
        public virtual ICollection<Escalafon> Escalafones { get; set; }
    }
}
