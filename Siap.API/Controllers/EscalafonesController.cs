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
    public class EscalafonesController : ControllerBase
    {
        private readonly SiapContext _context;

        public EscalafonesController(SiapContext context)
        {
            _context = context;
        }

        // GET: api/Escalafones
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult> Lista()
        {
            var responseAPI = new responseAPI<List<EscalafonDTO>>();
            var listadoEscalafones = new List<EscalafonDTO>();
            var listadoDB = await _context.Escalafones.ToListAsync();
            try
            {
                foreach (var e in listadoDB)
                {
                    listadoEscalafones.Add(new EscalafonDTO
                    {
                        Id = e.Id,
                        Nombre = e.Nombre,
                        Antiguedad = e.Antiguedad,
                        InstitucionId = e.InstitucionId,
                        CategoriaId = e.CategoriaId,
                    });
                }
                responseAPI.EsCorrecto = true;
                responseAPI.Valor = listadoEscalafones;
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }
            
            return Ok(responseAPI);
        }

        // GET: api/Escalafones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Escalafon>> GetEscalafon(int id)
        {
            var escalafon = await _context.Escalafones.FindAsync(id);

            if (escalafon == null)
            {
                return NotFound();
            }

            return escalafon;
        }


        // POST: api/Escalafones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EscalafonDTO>> Guardar(EscalafonDTO escalafonDTO)
        {
            var escDTO = new Escalafon
            {
                Nombre = escalafonDTO.Nombre,
                Antiguedad = escalafonDTO.Antiguedad,
                InstitucionId = escalafonDTO.InstitucionId,
                CategoriaId = escalafonDTO.CategoriaId
            };

            await _context.Escalafones.AddAsync(escDTO);
            await _context.SaveChangesAsync();
            return Ok("Escalafon ha sido almacenado con exito");

        }
    }
}
