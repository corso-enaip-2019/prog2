using System.Data.Entity;
using System.Diagnostics;

namespace P16_Databases_07_EntityFramework
{
    class MainDbContext : DbContext
    {
        public const string CONNECTION_STRING = @"Server=TRISRV10\SQLEXPRESS;Database=CS2019_Kraus_1;Trusted_Connection=True;";

        public MainDbContext()
            : base(CONNECTION_STRING)
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
