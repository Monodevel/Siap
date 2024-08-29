using Microsoft.AspNetCore.Identity;
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
    public class PersonalController : ControllerBase
    {
        private readonly SiapContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public PersonalController(SiapContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Personal
        [HttpGet]
        //[Authorize] cuando se implemente JWT de buena forma.
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseAPI = new responseAPI<List<PersonalDTO>>();
            var listadoPersonal = new List<PersonalDTO>();
            var listadoDB = await _context.Personal
                .Include(p => p.PerfilProfesional).ToListAsync();
            try
            {
                foreach (var p in listadoDB)
                {
                    listadoPersonal.Add(new PersonalDTO
                    {
                        Id = p.Id,
                        Rut = p.Rut,
                        Nombres = p.Nombres,
                        ApellidoPaterno = p.ApellidoPaterno,
                        ApellidoMaterno = p.ApellidoMaterno,
                        FechaNacimiento = p.FechaNacimiento,
                        Sexo = p.Sexo,
                        Disponbilidad = p.Disponibilidad,
                        InstitucionId = p.PerfilProfesional.InstitucionId,
                        GradoId = p.PerfilProfesional.GradoId,
                        EscalafonId = p.PerfilProfesional.EscalafonId,
                        DireccionId = p.PerfilProfesional.DireccionId,
                        DepartamentoId = p.PerfilProfesional.DepartamentoId,
                        SeccionId = p.PerfilProfesional.SeccionId,
                        Puesto = p.PerfilProfesional.Puesto,
                        MedallaEMCO = p.PerfilProfesional.MedallaEMCO,
                        MedallaMDN = p.PerfilProfesional.MedallaMDN

                    });
                }
                responseAPI.EsCorrecto = true;
                responseAPI.Valor = listadoPersonal;
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }
            return Ok(responseAPI);
        }

        // GET: api/Personal/5
        [HttpGet]
        [Route("Buscar/{id}")]

        public async Task<ActionResult<PersonalDTO>> Buscar(int? id)
        {
            if (id is null)
            {
                return NotFound("Error en la Consulta");
            }
            var responseAPI = new responseAPI<PersonalDTO>();
            var personalDTO = new PersonalDTO();
            try
            {
                var personalDB = await _context.Personal.FirstOrDefaultAsync(p => p.Id == id);
                if (personalDB != null)
                {
                    personalDTO.Rut = personalDB.Rut;
                    personalDTO.Nombres = personalDB.Nombres;
                    personalDTO.ApellidoPaterno = personalDB.ApellidoPaterno;
                    personalDTO.ApellidoMaterno = personalDB.ApellidoMaterno;
                    personalDTO.FechaNacimiento = personalDB.FechaNacimiento;
                    personalDTO.Sexo = personalDB.Sexo;
                    personalDTO.Disponbilidad = personalDB.Disponibilidad;
                    personalDTO.PerfilProfesional = null;

                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = personalDTO;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "Personal no ha sido encontrado";
                }
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }
            return Ok(responseAPI);

        }
        // POST: api/Personal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Guardar")]
        public async Task<ActionResult> Guardar(PersonalDTO personalDTO)
        {
            var responseAPI = new responseAPI<int>();
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    /*var user = new ApplicationUser { UserName = model.Rut, Email = model.Email, PersonalId = 0 };
                        var result = await _userManager.CreateAsync(user, model.Password);*/

                    /*-- Agrega el Usuario --*/
                    var dbPersonal = new Personal
                    {
                        Rut = personalDTO.Rut,
                        Nombres = personalDTO.Nombres,
                        ApellidoPaterno = personalDTO.ApellidoPaterno,
                        ApellidoMaterno = personalDTO.ApellidoMaterno,
                        FechaNacimiento = personalDTO.FechaNacimiento,
                        Sexo = personalDTO.Sexo,
                        Disponibilidad = personalDTO.Disponbilidad,
                        Created = DateTime.Now,
                        Modified = DateTime.Now
                    };
                    await _context.Personal.AddAsync(dbPersonal);
                    await _context.SaveChangesAsync();

                    /*-- Perfil Profesional --*/
                    var perfilDB = new PerfilProfesional
                    {
                        PersonalId = dbPersonal.Id,
                        GradoId = personalDTO.GradoId,
                        InstitucionId = personalDTO.InstitucionId,
                        EscalafonId = personalDTO.EscalafonId,
                        DireccionId = personalDTO.DireccionId,
                        DepartamentoId = personalDTO.DepartamentoId,
                        SeccionId = personalDTO.SeccionId,
                        Puesto = personalDTO.Puesto,
                        FechaPresentacion = DateTime.Now,
                        FechaDestinacion = DateTime.Now,
                        MedallaEMCO = personalDTO.MedallaEMCO,
                        MedallaMDN = personalDTO.MedallaMDN
                    };
                    await _context.PerfilProfesionals.AddAsync(perfilDB);
                    await _context.SaveChangesAsync();

                    /*-- Perfil de Contacto --*/
                    var perfilContactoDB = new PerfilContacto
                    {
                        PersonalId = dbPersonal.Id,
                        TelefonoFijo = " ",
                        TelefonoCelular = " ",
                        TelefonoFiscal = " ",
                        AnexoEmco = " ",
                        CorreoElectronico = " ",
                        CorreoEmco = " ",
                        CorreoSeguro = " ",
                        TelefonoEmergencia = " ",
                        RelacionEmergencia = " ",
                        Domicilio = " ",
                        Created = DateTime.Now,
                        Modified = DateTime.Now
                    };


                    await _context.perfilContactos.AddAsync(perfilContactoDB);
                    /*-- Agrega Datos de Ingreso --*/
                    var user = new ApplicationUser { UserName = personalDTO.Rut, Email=personalDTO.ApellidoPaterno+"."+personalDTO.ApellidoMaterno+"@emco.mil.cl", PersonalId = personalDTO.Id };
                    var result = await _userManager.CreateAsync(user, "Qwerty1234*");

                    await _context.SaveChangesAsync();

                    /* Una vez validados los cambios se ejecuta el commit */

                    await transaction.CommitAsync();

                    if (dbPersonal.Id != 0)
                    {
                        responseAPI.EsCorrecto = true;
                        responseAPI.Valor = dbPersonal.Id;
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        responseAPI.EsCorrecto = false;
                        responseAPI.Mensaje = "No Guardado";
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = ex.Message;
                }

            }

            return Ok(responseAPI);

        }

        [HttpGet]
        [Route("DetallePersonal/{id}")]
        public async Task<ActionResult> DetallePersonal(int? id)
        {
            var responseAPI = new responseAPI<PersonalDTO>();
            try
            {
                var personal = await _context.Personal
                    .Include(p => p.PerfilProfesional)
                        .ThenInclude(pp => pp.Grado)
                    .Include(p => p.PerfilProfesional.Escalafon)
                    .Include(p => p.PerfilProfesional.Direccion)
                    .Include(p => p.PerfilProfesional.Departamento)
                    .Include(p => p.PerfilProfesional.Seccion)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (personal != null)
                {
                    var personalDTO = new PersonalDTO
                    {
                        Id = personal.Id,
                        Rut = personal.Rut,
                        Nombres = personal.Nombres,
                        ApellidoPaterno = personal.ApellidoPaterno,
                        ApellidoMaterno = personal.ApellidoMaterno,
                        FechaNacimiento = personal.FechaNacimiento,
                        Sexo = personal.Sexo,
                        Disponbilidad = personal.Disponibilidad,
                        // Mapeo de PerfilProfesional
                        PerfilProfesional = new PerfilProfesionalDTO
                        {
                            InstitucionId = personal.PerfilProfesional.InstitucionId,
                            Institucion = new InstitucionDTO
                            {
                                Id = personal.PerfilProfesional.Institucion.Id,
                                Nombre = personal.PerfilProfesional.Institucion.Nombre,
                                Sigla = personal.PerfilProfesional.Institucion.Sigla
                            },
                            GradoId = personal.PerfilProfesional.GradoId,
                            GradoDTO = new GradoDTO
                            {
                                Id = personal.PerfilProfesional.Grado.Id,
                                Nombre = personal.PerfilProfesional.Grado.Nombre,
                                Sigla = personal.PerfilProfesional.Grado.Sigla
                            },
                            EscalafonId = personal.PerfilProfesional.EscalafonId,
                            Escalafon = new EscalafonDTO
                            {
                                Id = personal.PerfilProfesional.Escalafon.Id,
                                Nombre = personal.PerfilProfesional.Escalafon.Nombre
                            },
                            DireccionId = personal.PerfilProfesional.DireccionId,
                            Direccion = new DireccionDTO
                            {
                                Id = personal.PerfilProfesional.Direccion.Id,
                                Nombre = personal.PerfilProfesional.Direccion.Nombre,
                                Sigla = personal.PerfilProfesional.Direccion.Sigla
                            },
                            DepartamentoId = personal.PerfilProfesional.DepartamentoId,
                            Departamento = new DepartamentoDTO
                            {
                                Id = personal.PerfilProfesional.Departamento.Id,
                                Nombre = personal.PerfilProfesional.Departamento.Nombre,
                                Sigla = personal.PerfilProfesional.Departamento.Sigla
                            },
                            SeccionId = personal.PerfilProfesional.SeccionId,
                            Seccion = new SeccionDTO
                            {
                                Id = personal.PerfilProfesional.Seccion.Id,
                                Nombre = personal.PerfilProfesional.Seccion.Nombre
                            }
                        }
                    };

                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = personalDTO;
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
