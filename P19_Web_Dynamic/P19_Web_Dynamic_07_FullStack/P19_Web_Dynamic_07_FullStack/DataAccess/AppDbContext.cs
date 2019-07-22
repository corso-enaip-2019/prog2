using Microsoft.EntityFrameworkCore;
using P19_Web_Dynamic_07_FullStack.Models;

namespace P19_Web_Dynamic_07_FullStack.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villain>()
                .HasOne(i => i.Nemesis)
                .WithMany(c => c.Enemies)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<Superhero> Superheroes { get; set; }
        public DbSet<Villain> Villains { get; set; }
    }
}
