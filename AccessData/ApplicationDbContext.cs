using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AccessData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }

            modelBuilder.Entity<Rol>().HasData(new Rol() { Id = 1, Nombre = "Administrador" });
            modelBuilder.Entity<Rol>().HasData(new Rol() { Id = 2, Nombre = "Veterinario" });
            modelBuilder.Entity<Rol>().HasData(new Rol() { Id = 3, Nombre = "Cliente" });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                Nombres = "nombreAdmin",
                Apellidos = "apellidoAdmin",
                DNI = "42132132",
                Email = "admin@gmail.com",
                Password = "admin",
                RolId = 1,
                Sexo = "M",
                Telefono = "42573232"
            }, new Usuario
            {
                Id = 2,
                Nombres = "nombreVeterinario",
                Apellidos = "apellidoVeterinario",
                DNI = "42142796",
                Email = "veterinario@gmail.com",
                Password = "veterinario",
                RolId = 2,
                Sexo = "F",
                Telefono = "42546354"
            }, new Usuario
            {
                Id = 3,
                Nombres = "nombreCliente",
                Apellidos = "apellidoCliente",
                DNI = "36235638",
                Email = "cliente@gmail.com",
                Password = "cliente",
                RolId = 3,
                Sexo = "M",
                Telefono = "42543532"
            }
            );
        }
    }
}