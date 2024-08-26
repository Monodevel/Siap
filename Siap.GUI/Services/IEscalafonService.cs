using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public interface IEscalafonService
    {
        Task<List<EscalafonDTO>> Lista();
        Task<EscalafonDTO> Buscar(int? id);
        Task<int> Guardar(EscalafonDTO escalafonDTO);
        Task<int> Editar(EscalafonDTO escalafonDTO);
    }
}
