using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Siap.API.Context;
using Siap.Shared.DTO;
using Siap.Shared;
using Siap.API.Models;
using Microsoft.AspNetCore.Authorization;


namespace Siap.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucionesController : ControllerBase
    {
        private readonly SiapContext _context;

        public InstitucionesController(SiapContext context)
        {
            _context = context;
        }

        // GET: api/Instituciones/Lista
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult> Lista()
        {
            var responseAPI = new responseAPI<List<InstitucionDTO>>();
            var listaInstitucionDTO = new List<InstitucionDTO>();
            try
            {
                var listadoDB = await _context.Institucions.ToListAsync();
                foreach (var item in listadoDB)
                {
                    listaInstitucionDTO.Add(new InstitucionDTO
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Sigla = item.Sigla,
                    });
                }
                responseAPI.EsCorrecto = true;
                responseAPI.Valor = listaInstitucionDTO;
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }

            return Ok(responseAPI);
        }

        // GET: api/Instituciones/Lista/5
        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<ActionResult> Buscar(int? id)
        {
            if (id is null)
            {
                return NotFound("Error en la Consulta");
            }
            var responseAPI = new responseAPI<InstitucionDTO>();
            var institucionDTO = new InstitucionDTO();
            try
            {
                var institucionDB = await _context.Institucions.FirstOrDefaultAsync(i => i.Id == id);
                if (institucionDB != null)
                {
                    institucionDTO.Id = institucionDB.Id;
                    institucionDTO.Nombre = institucionDB.Nombre;
                    institucionDTO.Sigla = institucionDB.Sigla;
                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = institucionDTO;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "Institucion no ha sido encontrada";
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
        public async Task<ActionResult> Guardar(InstitucionDTO institucionDTO)
        {
            var responseAPI = new responseAPI<int>();
            try
            {
                var dbInstitucion = new Institucion
                {
                    Nombre = institucionDTO.Nombre,
                    Sigla = institucionDTO.Sigla,
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                };
                await _context.Institucions.AddAsync(dbInstitucion);
                await _context.SaveChangesAsync();

                if (dbInstitucion.Id != 0)
                {
                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = dbInstitucion.Id;
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

        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<ActionResult> Editar(InstitucionDTO institucionDTO, int id)
        {
            var responseAPI = new responseAPI<int>();
            try
            {
                var dbInstitucion = await _context.Institucions.FirstOrDefaultAsync(x => x.Id == id);
                if (dbInstitucion != null)
                {
                    dbInstitucion.Nombre = institucionDTO.Nombre;
                    dbInstitucion.Sigla = institucionDTO.Sigla;

                    _context.Institucions.Update(dbInstitucion);
                    await _context.SaveChangesAsync();

                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = institucionDTO.Id;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "La modificacion no ha podido ser realizada";
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
