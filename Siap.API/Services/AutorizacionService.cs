using Microsoft.IdentityModel.Tokens;
using Siap.API.Context;
using Siap.API.Models;
using Siap.API.Models.Customs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Siap.API.Services
{
    public class AutorizacionService : IAutorizacionService
    {
        private readonly SiapContext _context;
        private readonly IConfiguration _configuration;

        public AutorizacionService(SiapContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;            
        }

        private string GenerarToken(string idUsuario)
        {
            var key = _configuration.GetValue<string>("JwtSettings:key");
            var keyByte = Encoding.ASCII.GetBytes(key);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUsuario));
            var credencialesToken = new SigningCredentials(
                new SymmetricSecurityKey(keyByte),
                SecurityAlgorithms.HmacSha256Signature
                );
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = credencialesToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);
            return tokenCreado;
        }

        private string GenerarRefreshToken()
        {
            var byteArray = new byte[64];
            var refreshToken = "";

            using(var rng= RandomNumberGenerator.Create())
            {
                rng.GetBytes(byteArray);
                refreshToken = Convert.ToBase64String(byteArray);
            }
            return refreshToken;
        }

        private async Task<AutorizacionResponse> GuardarHistorialRefreshToken(int idUsusario, string Token, string refreshToken)
        {
            var historialRefreshToken = new HistorialRefreshTokens
            {
                UserId = idUsusario,
                Token = Token,
                RefreshToken = refreshToken,
                FechaCreacion = DateTime.UtcNow,
                FechaExpiracion = DateTime.UtcNow.AddHours(1) //tiene una duracion de 1 hora

            };

            await _context.HistorialRefreshTokens.AddAsync(historialRefreshToken);
            await _context.SaveChangesAsync();

            return new AutorizacionResponse {Token = Token, RefreshToken = refreshToken, Resultado=true, Mensaje="OK"};
        }

        public async Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion)
        {
            var usuario_encontrado = _context.Users.FirstOrDefault(x=> x.Username == autorizacion.NombreUsuario && x.Password == autorizacion.Password);
            if(usuario_encontrado == null)
            {
                return await Task.FromResult<AutorizacionResponse>(null);
            }

            string tokenCreado = GenerarToken(usuario_encontrado.Id.ToString());
            string refreshTokenCreado = GenerarRefreshToken();
            /*return new AutorizacionResponse()
            {
                Token = tokenCreado,
                Resultado = true,
                Mensaje = "OK"
            };*/
            return await GuardarHistorialRefreshToken(Convert.ToInt32(usuario_encontrado.Id), tokenCreado, refreshTokenCreado);
        }

        public async Task<AutorizacionResponse> DevolverRefreshToken(RefreshTokenRequest refreshTokenRequest, int idUsuario)
        {
            var refreshTokenEncontrado = _context.HistorialRefreshTokens.FirstOrDefault(x => 
            x.Token == refreshTokenRequest.TokenExpirado &&
            x.RefreshToken == refreshTokenRequest.RefreshToken &&
            x.UserId == idUsuario); 

            if(refreshTokenEncontrado == null)
                return new AutorizacionResponse { Resultado = false, Mensaje = "No Existe Token Valido." };

            var refreshTokenCreado = GenerarRefreshToken();
            var tokenCreado = GenerarToken(idUsuario.ToString());

            return await GuardarHistorialRefreshToken(idUsuario, tokenCreado,refreshTokenCreado);
        }
    }
}
