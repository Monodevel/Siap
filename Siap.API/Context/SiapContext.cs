using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Siap.API.Models;
using System.Security.Principal;

namespace Siap.API.Context
{
    public class SiapContext: IdentityDbContext<ApplicationUser>
    {
        public SiapContext(DbContextOptions<SiapContext> options): base(options)
        {
                        
        }
        public DbSet<Institucion> Institucions { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Escalafon> Escalafones { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Seccion> Secciones { get; set; }
        public DbSet<PerfilProfesional> PerfilProfesionals { get; set; }
        //public DbSet<Users> Users { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<HistorialRefreshTokens> HistorialRefreshTokens { get; set; }
        public DbSet<PerfilContacto> perfilContactos { get; set; }

    }

}
