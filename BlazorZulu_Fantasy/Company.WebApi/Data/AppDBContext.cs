using Company.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.WebApi.Data
{
    public class AppDBContext : DbContext
    {
        //CONSTRUCTOR
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
            //indice compuesto. equipos repetidos de diferentes paises
            modelBuilder.Entity<Team>().HasIndex(x => new { x.CountryId, x.Name }).IsUnique();
            //evita borrar en cascada. el pais se elimina cuando no tengas hijos
            DisableCascadingDelete(modelBuilder);

        }

        //Deshabilita el Borrado en Cascada
        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var item in relationships)
            {
                item.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
