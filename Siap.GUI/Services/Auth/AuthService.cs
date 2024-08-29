using Microsoft.AspNetCore.Components.Authorization;
using Siap.GUI.Authentication;
using Siap.Shared.DTO;
using Siap.Shared.Responses;
using System.Security.Claims;

namespace Siap.GUI.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;            
        }

        public async Task<ClaimsPrincipal> CurrentUser()
        {
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            return state.User;
        }

        public async Task<bool> Login(LoginDTO login)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/Login",login);
            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                await ((CustomAuthStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginResponse.Token);

                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", loginResponse.Token);
                return true;
            }
            return false;
        }

        public async Task Logout()
        {
            await ((CustomAuthStateProvider) _authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        
    }
}
