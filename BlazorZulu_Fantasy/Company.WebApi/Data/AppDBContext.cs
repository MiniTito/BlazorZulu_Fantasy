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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
