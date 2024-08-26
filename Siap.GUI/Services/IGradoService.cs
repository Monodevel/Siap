using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public interface IGradoService
    {
        Task<List<GradoDTO>> Lista();
        Task<GradoDTO> Buscar(int? id);
        Task<int> Guardar(GradoDTO gradoDTO);
        Task<int> Editar(GradoDTO gradoDTO);
    }
}
