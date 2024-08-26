using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public interface IDireccionService
    {
        Task<List<DireccionDTO>> Lista();
        Task<DireccionDTO> Buscar(int? id);
        Task<int> Guardar(DireccionDTO direccionDTO);
        Task<int> Editar(DireccionDTO direccionDTO);
    }
}
