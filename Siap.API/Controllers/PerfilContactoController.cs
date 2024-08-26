using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Siap.API.Context;
using Siap.Shared;
using Siap.Shared.DTO;

namespace Siap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilContactoController : ControllerBase
    {
        private readonly SiapContext _context;

        public PerfilContactoController(SiapContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult> Lista()
        {
            var responseAPI = new responseAPI<List<PerfilContactoDTO>>();
            var listadoPerfilContacto = new List<PerfilContactoDTO>();
            try
            {
                var listadoDB = await _context.perfilContactos
                    .Include(p => p.Personal)
                    .ToListAsync();
                foreach (var item in listadoDB)
                {
                    listadoPerfilContacto.Add(new PerfilContactoDTO
                    {
                        PersonalId = item.PersonalId,
                        TelefonoFijo = item.TelefonoFijo,
                        TelefonoCelular = item.TelefonoCelular,
                        TelefonoFiscal = item.TelefonoFiscal,
                        AnexoEmco = item.AnexoEmco,
                        CorreoElectronico = item.CorreoElectronico,
                        CorreoEmco = item.CorreoEmco,
                        CorreoSeguro = item.CorreoSeguro,
                        TelefonoEmergencia = item.TelefonoEmergencia,
                        RelacionEmergencia = item.RelacionEmergencia,
                        Domicilio = item.Domicilio
                    });
                }
                responseAPI.EsCorrecto = true;
                responseAPI.Valor = listadoPerfilContacto;
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }
            return Ok(responseAPI);
        }
    }
}
