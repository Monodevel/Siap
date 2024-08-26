using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public interface IInstitucionService
    {
        Task<List<InstitucionDTO>> Lista();
        Task<InstitucionDTO> Buscar(int? id);
        Task<int> Guardar(InstitucionDTO institucionDTO);
        Task<int> Editar(InstitucionDTO institucionDTO);
    }
}
