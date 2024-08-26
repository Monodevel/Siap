using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Siap.API.Context;
using Siap.API.Models;
using Siap.Shared;
using Siap.Shared.DTO;

namespace Siap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeccionesController : ControllerBase
    {
        private readonly SiapContext _context;

        public SeccionesController(SiapContext context)
        {
            _context = context;
        }

        // GET: api/Secciones
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult> Lista()
        {
            var responseAPI = new responseAPI<List<SeccionDTO>>();
            var listadoSecciones = new List<SeccionDTO>();
            var listadoDB = await _context.Secciones.ToListAsync();
            try
            {
                foreach (var s in listadoDB)
                {
                    listadoSecciones.Add(new SeccionDTO
                    {
                        Id = s.Id,
                        Nombre = s.Nombre,
                        DepartamentoId = s.DepartamentoId,
                    });
                }
                responseAPI.EsCorrecto = true;
                responseAPI.Valor = listadoSecciones;
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }
            return Ok(responseAPI);
        }

        // GET: api/Secciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seccion>> GetSeccion(int id)
        {
            var seccion = await _context.Secciones.FindAsync(id);
            if (seccion == null)
            {
                return NotFound();
            }
            var seccionDto = new SeccionDTO
            {
                Id = seccion.Id,
                Nombre = seccion.Nombre,
                DepartamentoId = seccion.DepartamentoId,
            };
            return Ok(seccionDto);
        }
        [HttpPost]
        public async Task<ActionResult<SeccionDTO>> Guardar(SeccionDTO seccionDTO)
        {
            var cateDTO = new Seccion
            {
                Nombre = seccionDTO.Nombre,
                DepartamentoId = seccionDTO.DepartamentoId,
            };
            await _context.Secciones.AddAsync(cateDTO);
            await _context.SaveChangesAsync();
            return Ok(cateDTO);
        }

        // DELETE: api/Secciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeccion(int id)
        {
            var seccionDto = new SeccionDTO();
            var seccion = await _context.Secciones.FindAsync(id);
            if (seccion == null)
            {
                return NotFound();
            }

            _context.Secciones.Remove(seccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
