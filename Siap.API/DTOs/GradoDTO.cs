namespace Siap.API.DTOs
{
    public class GradoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public int InstitucionId { get; set; }
        public int CategoriaId { get; set; }

    }
}
