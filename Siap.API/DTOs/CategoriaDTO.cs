namespace Siap.API.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public int Antiguedad { get; set; }
        public string InstitucionNombre { get; set; }
        public int InstitucionId { get; set; }
    }
}
