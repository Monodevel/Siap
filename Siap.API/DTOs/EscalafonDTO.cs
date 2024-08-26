namespace Siap.API.DTOs
{
    public class EscalafonDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Antiguedad { get; set; }
        public int InstitucionId { get; set; }
        public int CategoriaId { get; set; }
    }
}
