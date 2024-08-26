namespace Siap.Shared.DTO
{
    public class DepartamentoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public int DireccionId { get; set; }
        public virtual DireccionDTO? Direccion { get; set; }
    }
}
