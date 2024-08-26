namespace Siap.API.DTOs
{
    public class PersonalDTO
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public char Sexo { get; set; }
        public bool Disponbilidad { get; set; }
    }
}
