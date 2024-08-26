using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public interface ISeccionService
    {
        Task<List<SeccionDTO>> Lista();
        Task<SeccionDTO> Buscar(int? id);
        Task<int> Guardar(SeccionDTO seccionDTO);
        Task<int> Editar(SeccionDTO seccionDTO);
    }
}
