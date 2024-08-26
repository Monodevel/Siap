using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDTO>> Lista();
        Task<CategoriaDTO> Buscar(int? id);
        Task<int> Guardar(CategoriaDTO categoriaDTO);

        Task<List<CategoriaDTO>> CategoriaInstitucion(int? idInstitucion);
    }
}
