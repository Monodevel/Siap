using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siap.API.Models
{
    public class Grado
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Sigla { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public int InstitucionId { get; set; }
        [ForeignKey("InstitucionId")]
        public virtual Institucion Institucion { get; set; }

        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }
        

    }
}
