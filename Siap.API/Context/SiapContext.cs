using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Siap.API.Models;
using System.Security.Principal;

namespace Siap.API.Context
{
    public class SiapContext: IdentityDbContext<Users, IdentityRole, string>
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
        public DbSet<Users> Users { get; set; }
        public DbSet<HistorialRefreshTokens> HistorialRefreshTokens { get; set; }
        public DbSet<PerfilContacto> perfilContactos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Relacion uno a uno entre Personal y PerfilProfesional
            modelBuilder.Entity<Personal>()
                .HasOne(p => p.PerfilProfesional)
                .WithOne(pp => pp.Personal)
                .HasForeignKey<PerfilProfesional>(pp => pp.PersonalId);

            modelBuilder.Entity<Personal>()
                .HasOne(p => p.PerfilContacto)
                .WithOne(pc => pc.Personal)
                .HasForeignKey<PerfilContacto>(pc => pc.PersonalId);

            //Relacion muchos a uno entre PeriflPRofesional e institucion
            modelBuilder.Entity<PerfilProfesional>()
                .HasOne(pp => pp.Institucion)
                .WithMany(i => i.PerfilesProfesionales)
                .HasForeignKey(pp => pp.InstitucionId);

            //Semillero
            modelBuilder.Entity<Institucion>().HasData(
                new Institucion { Id = 1, Nombre = "No Informa", Sigla = "N/D", Created = DateTime.Now, Modified = DateTime.Now },
                new Institucion { Id = 2, Nombre = "Ejército de Chile",Sigla ="EJERCITO", Created = DateTime.Now, Modified=DateTime.Now },
                new Institucion { Id = 3, Nombre = "Armada de Chile", Sigla = "ARMADA", Created = DateTime.Now, Modified = DateTime.Now },
                new Institucion { Id = 4, Nombre = "Fuerza Aerea de Chile", Sigla = "FACH", Created = DateTime.Now, Modified = DateTime.Now },
                new Institucion { Id = 5, Nombre = "Carabineros de Chile", Sigla = "Carabineros", Created = DateTime.Now, Modified = DateTime.Now },
                new Institucion { Id = 6, Nombre = "Policia de Investigaciones", Sigla = "PDI", Created = DateTime.Now, Modified = DateTime.Now }
                );
            modelBuilder.Entity<Direccion>().HasData(
                new Direccion { Id = 1, Nombre = "No Informa", Sigla = "NOINFO", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 2, Nombre = "Jefatura del Estado Mayor Conjunto", Sigla = "JEMCO", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 3, Nombre = "Subjefatura del Estado Mayor Conjunto", Sigla = "SUBJEMCO", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 4, Nombre = "Direccion de Inteligencia de la Defensa", Sigla = "DID", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 5, Nombre = "Direccion de Personal y Logistica", Sigla = "DIPERLOG", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 6, Nombre = "Direccion de Finanzas", Sigla = "DIFEMCO", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 7, Nombre = "Direccion de Operaciones y Conduccion Conjunta", Sigla = "DOPCON", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 8, Nombre = "Direccion de Planificacion Conjunta", Sigla = "DIPLANCO", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 9, Nombre = "Direccion de Proyectos y Tecnologias Estrategicas", Sigla = "DIPRO", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 10, Nombre = "Direccion de Educacion, Doctrina y Entrenamiento Conjunto", Sigla = "DIREDENCO", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 11, Nombre = "Direccion de Apoyo General", Sigla = "DAG", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 12, Nombre = "Departamento de Asuntos Internacionales y Especiales", Sigla = "DIPRO", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 13, Nombre = "Comando Conjunto Norte", Sigla = "CCN", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 14, Nombre = "Comando Conjunto Centro", Sigla = "CCC", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 15, Nombre = "Comando Conjunto Austral", Sigla = "CCA", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 16, Nombre = "Centro Conjunto de Operaciones de Paz Chile", Sigla = "CECOPAC", Created = DateTime.Now, Modified = DateTime.Now },
                new Direccion { Id = 17, Nombre = "Fuerza Conjunta Combinada Cruz del Sur", Sigla = "FCCCDZ", Created = DateTime.Now, Modified = DateTime.Now }
                );
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id= 1, Nombre= "No Disponible", Sigla="N/D", DireccionId=1, Created = DateTime.Now, Modified= DateTime.Now }
                );
            modelBuilder.Entity<Seccion>().HasData( 
                new Seccion { Id= 1, DepartamentoId=1, Nombre= "No Disponible", Created=DateTime.Now, Modified=DateTime.Now } 
                );
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id= 1, Nombre= "No Disponible", Sigla="N/D", Antiguedad=99, Created= DateTime.Now, Modified=DateTime.Now, InstitucionId=1 }
                );
            modelBuilder.Entity<Escalafon>().HasData(
                new Escalafon { Id = 1, Nombre = "No Disponible", Antiguedad = 99, Created = DateTime.Now, Modified = DateTime.Now, InstitucionId = 1, CategoriaId = 1 }
                );
            modelBuilder.Entity<Grado>().HasData(
                new Grado { Id = 1, Nombre = "No Disponible", Sigla = "N/D", Created = DateTime.Now, Modified = DateTime.Now, InstitucionId = 1, CategoriaId = 1 }
                );
            //modelBuilder.Entity<Users>().HasData(
            //    new Users { Id=1, Username="Admin", Password="123456", Created=DateTime.Now, Modified= DateTime.Now }
            //    );
            
        }
    }

}
