using System.Data.Entity;

namespace P16_Databases_06_EntityFramework
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(string connectionString)
            : base(connectionString)
        { }

        public DbSet<Employee> Employees { get; set; }
    }
}
