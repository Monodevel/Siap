namespace Siap.API.DTOs
{
    public class PerfilProfesionalDTO
    {
        public int PerfilProfesionalId { get; set; }
        public int PersonalId { get; set; }
        public int InstitucionId { get; set; }
        public int GradoId { get; set; }
        public int EscalafonId { get; set; }
        public int DireccionId { get; set; }
        public int DepartamentoId { get; set; }
        public int SeccionId { get; set; }
        public string? Puesto { get; set; } = "No Informado";
        public DateTime FechaPresentacion { get; set; } = DateTime.Now;
        public bool MedallaEmco { get; set; }
        public bool MedallaMDN { get; set; }
        public DateTime FechaDestinacion { get; set; } = DateTime.Now;
    }
}
