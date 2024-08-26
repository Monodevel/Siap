using System.ComponentModel.DataAnnotations.Schema;

namespace Siap.API.Models
{
    public class Direccion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0;
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
        public virtual IEnumerable<Departamento> Departamento { get; set; }
    }
}
