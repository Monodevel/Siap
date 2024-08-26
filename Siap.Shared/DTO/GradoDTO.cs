namespace Siap.Shared.DTO
{
    public class GradoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public int InstitucionId { get; set; }

        public InstitucionDTO? Institucion { get; set; }
        public int CategoriaId { get; set; }

        public CategoriaDTO? Categoria { get; set; }

    }
}
