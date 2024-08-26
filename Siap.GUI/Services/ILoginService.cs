using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public interface ILoginService
    {
        Task<LoginDTO> login(LoginDTO loginDTO); 
    }
}
