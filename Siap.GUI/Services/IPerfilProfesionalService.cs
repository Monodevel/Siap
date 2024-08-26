using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public interface IPerfilProfesionalService
    {
        Task<List<PerfilProfesionalDTO>> Lista();
        Task<PerfilProfesionalDTO> BuscarPersonal(int? idPersonal);
        Task<int> Guardar(PerfilProfesionalDTO perfilProfesionalDTO);
    }
}
