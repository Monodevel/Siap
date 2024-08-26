using Siap.Shared;
using Siap.Shared.DTO;
using System.Net.Http;

namespace Siap.GUI.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;
        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }
        public async Task<LoginDTO> login(LoginDTO loginDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Usuarios/Autenticar", loginDTO);
            var response = await result.Content.ReadFromJsonAsync<responseAPI<LoginDTO>>();
            if (response!.EsCorrecto)
                return response.Valor;
            else
                throw new Exception(response.Mensaje);
        }
    }
}
