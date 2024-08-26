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
    public class DepartamentosController : ControllerBase
    {
        private readonly SiapContext _context;

        public DepartamentosController(SiapContext context)
        {
            _context = context;
        }

        // GET: api/Departamentos
        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult> Lista()
        {
            var responseAPI = new responseAPI<List<DepartamentoDTO>>();
            var listadoDepartamentos = new List<DepartamentoDTO>();
            var listadoDB = await _context.Departamentos
                .Include(d => d.Direccion)
                .ToListAsync();
            try
            {
                foreach (var item in listadoDB)
                {
                    listadoDepartamentos.Add(new DepartamentoDTO
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Sigla = item.Sigla,
                        DireccionId = item.DireccionId,
                        Direccion = new DireccionDTO { Id = item.Direccion.Id, Nombre = item.Direccion.Nombre, Sigla = item.Direccion.Sigla}
                    });
                }
                responseAPI.EsCorrecto = true;
                responseAPI.Valor = listadoDepartamentos;
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
            var responseAPI = new responseAPI<DepartamentoDTO>();
            var departamentoDTO = new DepartamentoDTO();
            try
            {
                var departamentoDB = await _context.Departamentos.FirstOrDefaultAsync(i => i.Id == id);
                if (departamentoDB != null)
                {
                    departamentoDTO.Id = departamentoDB.Id;
                    departamentoDTO.Nombre = departamentoDB.Nombre;
                    departamentoDTO.Sigla = departamentoDB.Sigla;
                    departamentoDTO.DireccionId = departamentoDB.DireccionId;
                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = departamentoDTO;
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
        // POST: api/Departamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        
        [HttpPost]
        [Route("Guardar")]
        public async Task<ActionResult<Departamento>> Guardar(DepartamentoDTO departamentoDTO)
        {
            var responseAPI = new responseAPI<int>();
            try
            {
                var dbDepartamento = new Departamento
                {
                    Nombre = departamentoDTO.Nombre,
                    Sigla = departamentoDTO.Sigla,
                    DireccionId = departamentoDTO.DireccionId,
                };
                await _context.Departamentos.AddAsync(dbDepartamento);
                await _context.SaveChangesAsync();

                if (dbDepartamento.Id != 0)
                {
                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = dbDepartamento.Id;
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
        public async Task<ActionResult> Editar(DepartamentoDTO departamentoDTO, int id)
        {
            var responseAPI = new responseAPI<int>();
            try
            {
                var dbDepartamento = await _context.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
                if (dbDepartamento != null)
                {
                    dbDepartamento.Nombre = departamentoDTO.Nombre;
                    dbDepartamento.Sigla = departamentoDTO.Sigla;
                    dbDepartamento.DireccionId = departamentoDTO.DireccionId;

                    _context.Departamentos.Update(dbDepartamento);
                    await _context.SaveChangesAsync();

                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = departamentoDTO.Id;
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
