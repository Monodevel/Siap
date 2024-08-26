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
    public class GradosController : ControllerBase
    {
        private readonly SiapContext _context;

        public GradosController(SiapContext context)
        {
            _context = context;
        }

        // GET: api/Grados
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult> Lista()
        {
            var responseAPI = new responseAPI<List<GradoDTO>>();
            var listadoGrados = new List<GradoDTO>();
            var listadoDB = await _context.Grados
                .Include(g=> g.Institucion)
                .Include(g=> g.Categoria)
                .ToListAsync();
            try
            {
                foreach (var g in listadoDB)
                {
                    listadoGrados.Add(new GradoDTO
                    {
                        Id = g.Id,
                        Nombre = g.Nombre,
                        Sigla = g.Sigla,
                        InstitucionId = g.InstitucionId,
                        Institucion = new InstitucionDTO { Id = g.Institucion.Id, Nombre = g.Institucion.Nombre, Sigla = g.Institucion.Sigla },
                        CategoriaId = g.CategoriaId,
                        Categoria = new CategoriaDTO { Id = g.Categoria.Id, Nombre = g.Categoria.Nombre, Sigla = g.Categoria.Sigla, InstitucionId = g.Categoria.InstitucionId},

                    });
                }
                responseAPI.EsCorrecto = true;
                responseAPI.Valor = listadoGrados;
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }
            return Ok(responseAPI);
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<ActionResult> Buscar(int? id)
        {
            if (id is null)
            {
                return NotFound("Error en la Consulta");
            }
            var responseAPI = new responseAPI<GradoDTO>();
            var gradoDTO = new GradoDTO();
            try
            {
                var gradoDB = await _context.Grados.FirstOrDefaultAsync(g => g.Id == id);
                if (gradoDB != null)
                {
                    gradoDTO.Id = gradoDB.Id;
                    gradoDTO.Nombre = gradoDB.Nombre;
                    gradoDTO.Sigla = gradoDB.Sigla;
                    gradoDTO.CategoriaId = gradoDB.CategoriaId;
                    gradoDTO.InstitucionId = gradoDB.InstitucionId;
                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = gradoDTO;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "El Grado no ha sido encontrado";
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
        [Route("Guardar")]
        public async Task<ActionResult> Guardar(GradoDTO gradoDTO)
        {
            var responseAPI = new responseAPI<int>();
            try
            {
                var dbGrado = new Grado
                {
                    Nombre = gradoDTO.Nombre,
                    Sigla = gradoDTO.Sigla,
                    CategoriaId = gradoDTO.CategoriaId,
                    InstitucionId = gradoDTO.InstitucionId,
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                };
                await _context.Grados.AddAsync(dbGrado);
                await _context.SaveChangesAsync();

                if (dbGrado.Id != 0)
                {
                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = dbGrado.Id;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "No guardado";
                }

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
