using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siap.API.Models
{
    public class Departamento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Sigla { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
        public int DireccionId { get; set; }

        [ForeignKey("DireccionId")]
        public virtual Direccion Direccion { get; set; }
        public virtual IEnumerable<Seccion> Secciones { get; set; }
    }
}
