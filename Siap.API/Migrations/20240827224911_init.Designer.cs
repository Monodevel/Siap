﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Siap.API.Context;

#nullable disable

namespace Siap.API.Migrations
{
    [DbContext(typeof(SiapContext))]
    [Migration("20240827224911_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.6.24327.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Siap.API.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Rut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Siap.API.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Antiguedad")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstitucionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstitucionId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Siap.API.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("DireccionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DireccionId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Siap.API.Models.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("Siap.API.Models.Escalafon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Antiguedad")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstitucionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("InstitucionId");

                    b.ToTable("Escalafones");
                });

            modelBuilder.Entity("Siap.API.Models.Grado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstitucionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("InstitucionId");

                    b.ToTable("Grados");
                });

            modelBuilder.Entity("Siap.API.Models.HistorialRefreshTokens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaExpiracion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdHistorialToken")
                        .HasColumnType("int");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HistorialRefreshTokens");
                });

            modelBuilder.Entity("Siap.API.Models.Institucion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Institucions");
                });

            modelBuilder.Entity("Siap.API.Models.PerfilContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnexoEmco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoEmco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoSeguro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Domicilio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonalId")
                        .HasColumnType("int");

                    b.Property<string>("RelacionEmergencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoCelular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoEmergencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoFijo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoFiscal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonalId")
                        .IsUnique();

                    b.ToTable("perfilContactos");
                });

            modelBuilder.Entity("Siap.API.Models.PerfilProfesional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("DireccionId")
                        .HasColumnType("int");

                    b.Property<int>("EscalafonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaDestinacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPresentacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("GradoId")
                        .HasColumnType("int");

                    b.Property<int>("InstitucionId")
                        .HasColumnType("int");

                    b.Property<bool>("MedallaEMCO")
                        .HasColumnType("bit");

                    b.Property<bool>("MedallaMDN")
                        .HasColumnType("bit");

                    b.Property<int>("PersonalId")
                        .HasColumnType("int");

                    b.Property<string>("Puesto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeccionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("DireccionId");

                    b.HasIndex("EscalafonId");

                    b.HasIndex("GradoId");

                    b.HasIndex("InstitucionId");

                    b.HasIndex("PersonalId")
                        .IsUnique();

                    b.HasIndex("SeccionId");

                    b.ToTable("PerfilProfesionals");
                });

            modelBuilder.Entity("Siap.API.Models.Personal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disponibilidad")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SeccionId")
                        .HasColumnType("int");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeccionId");

                    b.ToTable("Personal");
                });

            modelBuilder.Entity("Siap.API.Models.Seccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Secciones");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Siap.API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Siap.API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Siap.API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Siap.API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Siap.API.Models.Categoria", b =>
                {
                    b.HasOne("Siap.API.Models.Institucion", "Institucion")
                        .WithMany()
                        .HasForeignKey("InstitucionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucion");
                });

            modelBuilder.Entity("Siap.API.Models.Departamento", b =>
                {
                    b.HasOne("Siap.API.Models.Direccion", "Direccion")
                        .WithMany("Departamento")
                        .HasForeignKey("DireccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("Siap.API.Models.Escalafon", b =>
                {
                    b.HasOne("Siap.API.Models.Categoria", "Categoria")
                        .WithMany("Escalafones")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Siap.API.Models.Institucion", "Institucion")
                        .WithMany("Escalafones")
                        .HasForeignKey("InstitucionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Institucion");
                });

            modelBuilder.Entity("Siap.API.Models.Grado", b =>
                {
                    b.HasOne("Siap.API.Models.Categoria", "Categoria")
                        .WithMany("Grados")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Siap.API.Models.Institucion", "Institucion")
                        .WithMany("Grados")
                        .HasForeignKey("InstitucionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Institucion");
                });

            modelBuilder.Entity("Siap.API.Models.PerfilContacto", b =>
                {
                    b.HasOne("Siap.API.Models.Personal", "Personal")
                        .WithOne("PerfilContacto")
                        .HasForeignKey("Siap.API.Models.PerfilContacto", "PersonalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personal");
                });

            modelBuilder.Entity("Siap.API.Models.PerfilProfesional", b =>
                {
                    b.HasOne("Siap.API.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Siap.API.Models.Direccion", "Direccion")
                        .WithMany()
                        .HasForeignKey("DireccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Siap.API.Models.Escalafon", "Escalafon")
                        .WithMany()
                        .HasForeignKey("EscalafonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Siap.API.Models.Grado", "Grado")
                        .WithMany()
                        .HasForeignKey("GradoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Siap.API.Models.Institucion", "Institucion")
                        .WithMany("PerfilesProfesionales")
                        .HasForeignKey("InstitucionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Siap.API.Models.Personal", "Personal")
                        .WithOne("PerfilProfesional")
                        .HasForeignKey("Siap.API.Models.PerfilProfesional", "PersonalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Siap.API.Models.Seccion", "Seccion")
                        .WithMany()
                        .HasForeignKey("SeccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Direccion");

                    b.Navigation("Escalafon");

                    b.Navigation("Grado");

                    b.Navigation("Institucion");

                    b.Navigation("Personal");

                    b.Navigation("Seccion");
                });

            modelBuilder.Entity("Siap.API.Models.Personal", b =>
                {
                    b.HasOne("Siap.API.Models.Seccion", null)
                        .WithMany("PersonalEncuadrado")
                        .HasForeignKey("SeccionId");
                });

            modelBuilder.Entity("Siap.API.Models.Seccion", b =>
                {
                    b.HasOne("Siap.API.Models.Departamento", "Departamento")
                        .WithMany("Secciones")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Siap.API.Models.Categoria", b =>
                {
                    b.Navigation("Escalafones");

                    b.Navigation("Grados");
                });

            modelBuilder.Entity("Siap.API.Models.Departamento", b =>
                {
                    b.Navigation("Secciones");
                });

            modelBuilder.Entity("Siap.API.Models.Direccion", b =>
                {
                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Siap.API.Models.Institucion", b =>
                {
                    b.Navigation("Escalafones");

                    b.Navigation("Grados");

                    b.Navigation("PerfilesProfesionales");
                });

            modelBuilder.Entity("Siap.API.Models.Personal", b =>
                {
                    b.Navigation("PerfilContacto");

                    b.Navigation("PerfilProfesional");
                });

            modelBuilder.Entity("Siap.API.Models.Seccion", b =>
                {
                    b.Navigation("PersonalEncuadrado");
                });
#pragma warning restore 612, 618
        }
    }
}
