using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public interface IDepartamentoService
    {
        Task<List<DepartamentoDTO>> Lista();
        Task<DepartamentoDTO> Buscar(int? id);
        Task<int> Guardar(DepartamentoDTO departamentoDTO);
        Task<int> Editar(DepartamentoDTO departamentoDTO);
    }
}
