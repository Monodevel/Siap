using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Siap.API.Context;
using Siap.API.Models;
using Siap.Shared;
using Siap.Shared.DTO;
using System.Composition;

namespace Siap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionesController : ControllerBase
    {
        private readonly SiapContext _context;

        public DireccionesController(SiapContext context)
        {
            _context = context;
        }

        // GET: api/Direcciones
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult> Lista()
        {
            var responseAPI = new responseAPI<List<DireccionDTO>>();
            var listadoDirecciones = new List<DireccionDTO>();
            var DireccionDB = await _context.Direcciones.ToListAsync();
            try
            {
                foreach (var d in DireccionDB)
                {
                    listadoDirecciones.Add(new DireccionDTO
                    {
                        Id = d.Id,
                        Nombre = d.Nombre,
                        Sigla = d.Sigla,
                    });
                }
                responseAPI.EsCorrecto = true;
                responseAPI.Valor = listadoDirecciones;
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }
            
            return Ok(responseAPI);
        }

        // GET: api/Direcciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Direccion>> GetDireccion(int? id)
        {
            if(id is null)
            {
                return NotFound("Error en la Consulta");
            }
            var direccion = await _context.Direcciones.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }
            var direccionDTO = new DireccionDTO {
                Id = direccion.Id,
                Nombre = direccion.Nombre,
                Sigla = direccion.Sigla,
            };
            return Ok(direccionDTO);
        }

        
        // POST: api/Direcciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DireccionDTO>> Guardar(DireccionDTO direccionDTO)
        {
            var direccionDB = new Direccion
            {
                Nombre = direccionDTO.Nombre,
                Sigla = direccionDTO.Sigla,
            };
            await _context.Direcciones.AddAsync(direccionDB);
            await _context.SaveChangesAsync();
            return Ok("Direccion almacenada con exito");
        }
    }
}
