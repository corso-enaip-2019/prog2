using Microsoft.EntityFrameworkCore;

namespace P19_Web_Dynamic_08_PublishingHouse
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<BookAuthor>()
                .HasKey(ba => new { ba.AuthorId, ba.BookId});
        }
    }
}
