using System.ComponentModel.DataAnnotations.Schema;

namespace Siap.API.Models
{
    public class Seccion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
        public int DepartamentoId { get; set; }
        [ForeignKey("DepartamentoId")]
        public virtual Departamento Departamento { get; set; }

        //dependientes
        public virtual IEnumerable<Personal> PersonalEncuadrado { get; set; }


    }
}
