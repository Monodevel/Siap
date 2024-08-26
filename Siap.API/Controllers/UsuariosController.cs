using Microsoft.AspNetCore.Mvc;
using Siap.API.Models.Customs;
using Siap.API.Services;
using Siap.Shared;
using Siap.Shared.DTO;
using System.IdentityModel.Tokens.Jwt;

namespace Siap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IAutorizacionService _autorizacionService;

        public UsuariosController(IAutorizacionService autorizacionService)
        {
            _autorizacionService = autorizacionService;
        }
        [HttpPost]
        [Route("Autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] AutorizacionRequest autorizacion)
        {
            var responseAPI = new responseAPI<AutorizacionResponse>();
            try
            {
                var resultado_autorizacion = await _autorizacionService.DevolverToken(autorizacion);
                if (resultado_autorizacion != null)
                {
                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = resultado_autorizacion;
                }                    
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "Token no se ha obtenido correctamente";
                }

            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }

            return Ok(responseAPI);
        }
        [HttpPost]
        [Route("ObtenerRefreshToken")]
        public async Task<IActionResult> ObtenerRefreshToken([FromBody] RefreshTokenRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenExpirado = tokenHandler.ReadJwtToken(request.TokenExpirado);
            if(tokenExpirado.ValidTo > DateTime.Now)
            {
                return BadRequest(new AutorizacionResponse { Resultado = false, Mensaje = "Token no ha expirado." });
            }
            string idUsuario = tokenExpirado.Claims.First(x => 
            x.Type == JwtRegisteredClaimNames.NameId).Value.ToString();

            var autorizacionResponse = await _autorizacionService.DevolverRefreshToken(request,int.Parse(idUsuario));

            if (autorizacionResponse.Resultado)
                return Ok(autorizacionResponse);
            else
                return BadRequest(autorizacionResponse);
        }
    }
}
