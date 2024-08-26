namespace Siap.Shared.DTO
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public int InstitucionId { get; set; }

        public virtual InstitucionDTO? Institucion { get; set; }
    }
}
