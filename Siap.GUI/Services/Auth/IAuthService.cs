using Siap.Shared.DTO;
using System.Security.Claims;

namespace Siap.GUI.Services.Auth
{
    public interface IAuthService
    {
        Task<bool> Login(LoginDTO login);
        Task Logout();

        Task<ClaimsPrincipal> CurrentUser();
    }
}
