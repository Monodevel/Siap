namespace Siap.Shared.DTO
{
    public class PerfilProfesionalDTO
    {
        public int PerfilProfesionalId { get; set; }
        public int PersonalId { get; set; }
        public virtual PersonalDTO? Personal { get; set; }
        public int InstitucionId { get; set; }
        public virtual InstitucionDTO? Institucion { get; set; }
        public int GradoId { get; set; }
        public virtual GradoDTO? GradoDTO { get; set; }
        public int EscalafonId { get; set; }
        public virtual EscalafonDTO? Escalafon { get; set; }
        public int DireccionId { get; set; }
        public virtual DireccionDTO? Direccion { get; set; }
        public int DepartamentoId { get; set; }
        public virtual DepartamentoDTO? Departamento { get; set; }

        public int SeccionId { get; set; }

        public virtual SeccionDTO? Seccion { get; set; }
        public string? Puesto { get; set; } = "No Informado";
        public DateTime FechaPresentacion { get; set; } = DateTime.Now;
        public bool MedallaEmco { get; set; } = false;
        public bool MedallaMDN { get; set; } = false;
        public DateTime FechaDestinacion { get; set; } = DateTime.Now;
    }
}
