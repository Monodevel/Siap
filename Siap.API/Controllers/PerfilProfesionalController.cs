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
    public class PerfilProfesionalController : ControllerBase
    {
        private readonly SiapContext _context;
        public PerfilProfesionalController(SiapContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult> Lista()
        {
            var responseAPI = new responseAPI<List<PerfilProfesionalDTO>>();
            var listadoPerfilesProfesional = new List<PerfilProfesionalDTO>();
            try
            {
                var listadoDB = await _context.PerfilProfesionals
                    .Include(p => p.Personal)
                    .Include(p => p.Institucion)
                    .Include(p => p.Grado)
                    .Include(p => p.Escalafon)
                    .Include(p => p.Direccion)
                    .Include(p => p.Departamento)
                    .Include(p => p.Seccion)
                    .ToListAsync();
                foreach (var item in listadoDB)
                {
                    listadoPerfilesProfesional.Add(new PerfilProfesionalDTO
                    {
                        PersonalId = item.PersonalId,
                        Personal = new PersonalDTO { Id = item.Personal.Id, Nombres = item.Personal.Nombres, Rut = item.Personal.Rut, ApellidoPaterno = item.Personal.ApellidoPaterno, ApellidoMaterno = item.Personal.ApellidoMaterno },
                        InstitucionId = item.InstitucionId,
                        Institucion = new InstitucionDTO { Id = item.Institucion.Id, Nombre = item.Institucion.Nombre, Sigla = item.Institucion.Sigla },
                        GradoId = item.GradoId,
                        GradoDTO = new GradoDTO { Id = item.Grado.Id, InstitucionId = item.Grado.InstitucionId, CategoriaId = item.Grado.CategoriaId, Nombre = item.Grado.Nombre, Sigla = item.Grado.Sigla },
                        EscalafonId = item.EscalafonId,
                        Escalafon = new EscalafonDTO { Id = item.Escalafon.Id, Nombre = item.Escalafon.Nombre, CategoriaId = item.Escalafon.CategoriaId, InstitucionId = item.Escalafon.InstitucionId },
                        DireccionId = item.DireccionId,
                        Direccion = new DireccionDTO { Id = item.Direccion.Id, Nombre = item.Direccion.Nombre, Sigla = item.Direccion.Sigla },
                        DepartamentoId = item.DepartamentoId,
                        Departamento = new DepartamentoDTO { Id = item.Departamento.Id, Nombre = item.Departamento.Nombre, Sigla = item.Departamento.Sigla },
                        SeccionId = item.SeccionId,
                        Seccion = new SeccionDTO { Id = item.Seccion.Id, Nombre = item.Seccion.Nombre },
                        Puesto = item.Puesto,
                        FechaPresentacion = item.FechaPresentacion,
                        MedallaEmco = item.MedallaEMCO,
                        MedallaMDN = item.MedallaMDN,
                        FechaDestinacion = item.FechaDestinacion
                    });
                }
                responseAPI.EsCorrecto = true;
                responseAPI.Valor = listadoPerfilesProfesional;
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
        public async Task<ActionResult> Guardar(PerfilProfesionalDTO perfilProfesionalDTO)
        {
            var responseAPI = new responseAPI<int>();
            try
            {
                var dbPerfilPersonal = new PerfilProfesional
                {
                    PersonalId = perfilProfesionalDTO.PersonalId,
                    InstitucionId = perfilProfesionalDTO.InstitucionId,
                    GradoId = perfilProfesionalDTO.GradoId,
                    EscalafonId = perfilProfesionalDTO.EscalafonId,
                    DireccionId = perfilProfesionalDTO.EscalafonId,
                    DepartamentoId = perfilProfesionalDTO.DepartamentoId,
                    SeccionId = perfilProfesionalDTO.SeccionId,
                    Puesto = perfilProfesionalDTO.Puesto,
                    FechaPresentacion = perfilProfesionalDTO.FechaPresentacion,
                    MedallaEMCO = perfilProfesionalDTO.MedallaEmco,
                    MedallaMDN = perfilProfesionalDTO.MedallaMDN
                };
                await _context.PerfilProfesionals.AddAsync(dbPerfilPersonal);
                await _context.SaveChangesAsync();

                if (dbPerfilPersonal.Id != 0)
                {
                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = dbPerfilPersonal.Id;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "No Guardado";
                }
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }
            return Ok(responseAPI);
        }

        [HttpGet]
        [Route("BuscarPersonal/{idPersonal}")]
        public async Task<ActionResult> BuscarPersonal(int? idPersonal)
        {
            var responseAPI = new responseAPI<PerfilProfesionalDTO>();
            try
            {
                var perfilProfesional = await _context.PerfilProfesionals
                    .Include(p => p.Escalafon)
                    .Include(p => p.Grado)
                    .Include(p => p.Direccion)
                    .Include(p => p.Departamento)
                    .Include(p => p.Institucion)
                    .Include(p => p.Seccion).FirstOrDefaultAsync(p => p.PersonalId == idPersonal);

                if (perfilProfesional != null)
                {
                    var PerfilDTO = new PerfilProfesionalDTO
                    {
                        InstitucionId = perfilProfesional.InstitucionId,
                        Institucion = new InstitucionDTO
                        {
                            Id = perfilProfesional.Institucion.Id,
                            Nombre = perfilProfesional.Institucion.Nombre,
                            Sigla = perfilProfesional.Institucion.Sigla
                        },
                        GradoId = perfilProfesional.GradoId,
                        GradoDTO = new GradoDTO
                        {
                            Id = perfilProfesional.Grado.Id,
                            Nombre = perfilProfesional.Grado.Nombre,
                            Sigla = perfilProfesional.Grado.Sigla
                        },
                        EscalafonId = perfilProfesional.EscalafonId,
                        Escalafon = new EscalafonDTO
                        {
                            Id = perfilProfesional.Escalafon.Id,
                            Nombre = perfilProfesional.Escalafon.Nombre
                        },
                        DireccionId = perfilProfesional.DireccionId,
                        Direccion = new DireccionDTO
                        {
                            Id = perfilProfesional.Direccion.Id,
                            Nombre = perfilProfesional.Direccion.Nombre,
                            Sigla = perfilProfesional.Direccion.Sigla
                        },
                        DepartamentoId = perfilProfesional.DepartamentoId,
                        Departamento = new DepartamentoDTO
                        {
                            Id = perfilProfesional.Departamento.Id,
                            Nombre = perfilProfesional.Departamento.Nombre,
                            Sigla = perfilProfesional.Departamento.Sigla
                        },
                        SeccionId = perfilProfesional.SeccionId,
                        Seccion = new SeccionDTO
                        {
                            Id = perfilProfesional.Seccion.Id,
                            Nombre = perfilProfesional.Seccion.Nombre
                        }
                    };

                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = PerfilDTO;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "La informacion no ha podido ser encontrada.";
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
