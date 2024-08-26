namespace Siap.Shared.DTO
{
    public class PersonalDTO
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Sexo { get; set; } //1-Masculino; 2-Femenino; 3 - No indica
        public bool Disponbilidad { get; set; }

        /* Para crear el Perfil */
        public int InstitucionId { get; set; }
        public int GradoId { get; set; }
        public int EscalafonId { get; set; }
        public int DireccionId { get; set; }
        public int DepartamentoId { get; set; }
        public int SeccionId { get; set; }
        public string Puesto { get; set; }
        public bool MedallaEMCO { get; set; }
        public bool MedallaMDN { get; set; }

        public virtual PerfilProfesionalDTO? PerfilProfesional { get; set; }
    }
}
