using Microsoft.EntityFrameworkCore;

namespace P16_Databases_08_EntityFramework
{
    public class MainDbContext : DbContext
    {
        public const string CONNECTION_STRING =
            @"Server=TRISRV10\SQLEXPRESS;Database=CS2019_Kraus_2;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>().HasIndex(x => x.Value1);
        }

        public DbSet<Model> Models { get; set; }
    }
}
