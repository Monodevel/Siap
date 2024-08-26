using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public interface IPersonalService
    {
        Task<List<PersonalDTO>> Lista();
        Task<PersonalDTO> Buscar(int? id);
        Task<PersonalDTO> DetallePersonal(int id);
        Task<int> Guardar(PersonalDTO personalDTO);
        Task<int> Editar(PersonalDTO personalDTO);
    }
}
