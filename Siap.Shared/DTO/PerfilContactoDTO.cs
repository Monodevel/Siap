namespace Siap.Shared.DTO
{
    public class PerfilContactoDTO
    {
        public int PersonalId { get; set; }
        public PersonalDTO? Personal { get; set; }
        public string TelefonoFijo { get; set; } = string.Empty;
        public string TelefonoCelular { get; set; } = string.Empty;
        public string TelefonoFiscal { get; set; } = string.Empty;
        public string AnexoEmco { get; set; } = string.Empty;
        public string CorreoElectronico { get; set; } = string.Empty;
        public string CorreoEmco { get; set; } = string.Empty;
        public string CorreoSeguro { get; set; } = string.Empty;
        public string TelefonoEmergencia { get; set; } = string.Empty;
        public string RelacionEmergencia { get; set; } = string.Empty;
        public string Domicilio { get; set; } = string.Empty;
    }
}
