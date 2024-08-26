using System.ComponentModel.DataAnnotations.Schema;

namespace Siap.API.Models
{
    public class Escalafon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Antiguedad { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;

        public int InstitucionId { get; set; }
        [ForeignKey("InstitucionId")]
        public virtual Institucion Institucion { get; set; }

        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

    }
}
