using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Siap.GUI.Authentication
{
    public class CustomAuthStateProvider: AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        public CustomAuthStateProvider(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;            
            _localStorageService = localStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if(_localStorageService == null)
            {
                throw new InvalidOperationException("Servicio de LocalStorage no inicializado.");
            }
            var token = await _localStorageService.GetItemAsync<string>("authToken");

            if (string.IsNullOrWhiteSpace(token))
            {
                return new AuthenticationState(_anonymous);
            }
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var claims = GetClaimsIdentity(token);
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            return new AuthenticationState(user);
        }

        public async Task MarkUserAsAuthenticated(string token)
        {
            await _localStorageService.SetItemAsync("authToken", token);
            var identity = GetClaimsIdentity(token);
            var user = new ClaimsPrincipal(new ClaimsIdentity(identity));
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
        public async Task MarkUserAsLoggedOut()
        {
            await _localStorageService.RemoveItemAsync("authToken");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
        }

        private IEnumerable<Claim> GetClaimsIdentity(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var claims = jwtToken.Claims;
            return claims;
        }
        public ClaimsPrincipal AuthenticationStateUser { get; set; }

    }
}
