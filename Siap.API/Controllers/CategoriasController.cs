using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Siap.API.Context;
using Siap.Shared.DTO;
using Siap.API.Models;
using Siap.Shared;

namespace Siap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoriasController : ControllerBase
    {
        private readonly SiapContext _context;

        public CategoriasController(SiapContext context)
        {
            _context = context;
        }

        // GET: api/Categorias/Lista
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult> Lista()
        {
            var responseAPI = new responseAPI<List<CategoriaDTO>>();
            var listaCategorias= new List<CategoriaDTO>();
            try
            {
                var categoriasDB = await _context.Categorias.Include(c => c.Institucion).ToListAsync();
                foreach (var c in categoriasDB)
                {
                    listaCategorias.Add(new CategoriaDTO
                    {
                        Id = c.Id,
                        Nombre = c.Nombre,
                        Sigla = c.Sigla,
                        InstitucionId = c.InstitucionId,
                        Institucion = new InstitucionDTO { Id = c.Institucion.Id, Nombre = c.Institucion.Nombre, Sigla = c.Institucion.Sigla}
                    });
                }
                responseAPI.EsCorrecto = true;
                responseAPI.Valor = listaCategorias;
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto= false;
                responseAPI.Mensaje = ex.Message;
            }  
            return Ok(responseAPI);
        }

        // GET: api/Categorias/5
        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<ActionResult> Buscar(int? id)
        {
            if(id is null)
            {
                return NotFound("Error en la Consulta");
            }
            var responseAPI = new responseAPI<CategoriaDTO>();
            var categoriaDTO = new CategoriaDTO();
            try
            {
                var categoriaDB = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
                if (categoriaDB != null)
                {
                    categoriaDTO.Id = categoriaDB.Id;
                    categoriaDTO.Nombre = categoriaDB.Nombre;
                    categoriaDTO.Sigla = categoriaDB.Sigla;
                    categoriaDTO.InstitucionId = categoriaDB.InstitucionId;

                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = categoriaDTO;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "Error en la busqueda de la Categoria";
                }
            }
            catch(Exception ex)
            {
                responseAPI.EsCorrecto= false;
                responseAPI.Mensaje= ex.Message;
            }
            return Ok(responseAPI);
        }
        // POST: api/Categorias
        
        [HttpPost]
        [Route("Guardar")]
        public async Task<ActionResult> Guardar(CategoriaDTO categoriaDTO)
        {
            var responseAPI = new responseAPI<int>();
            try
            {
                var dbCategoria = new Categoria
                {
                    Nombre = categoriaDTO.Nombre,
                    Sigla = categoriaDTO.Sigla,
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    InstitucionId = categoriaDTO.InstitucionId
                };
                await _context.Categorias.AddAsync(dbCategoria);
                await _context.SaveChangesAsync();

                if(dbCategoria.Id !=0)
                {
                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = dbCategoria.Id;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = " Error al Agregar la Categoria";
                }
            }
            catch(Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;

            }

            return Ok(responseAPI);
        }

        [HttpGet]
        [Route("CategoriaInstitucion/{idInstitucion}")]
        public async Task<ActionResult> CategoriaInstitucion(int idInstitucion)
        {
            var responseAPI = new responseAPI<List<CategoriaDTO>>();
            var listaCategorias = new List<CategoriaDTO>();
            try
            {
                var categoriasDB = await _context.Categorias.Include(c => c.Institucion).Where(c => c.InstitucionId == idInstitucion).ToListAsync();
                foreach (var c in categoriasDB)
                {
                    listaCategorias.Add(new CategoriaDTO
                    {
                        Id = c.Id,
                        Nombre = c.Nombre,
                        Sigla = c.Sigla,
                        InstitucionId = c.InstitucionId,
                        Institucion = new InstitucionDTO { Id = c.Institucion.Id, Nombre = c.Institucion.Nombre, Sigla = c.Institucion.Sigla }
                    });
                }
                responseAPI.EsCorrecto = true;
                responseAPI.Valor = listaCategorias;
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
