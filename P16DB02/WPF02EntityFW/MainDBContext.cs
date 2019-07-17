using System.Data.Entity;
using WPF02EntityFW.Classes;

namespace WPF02EntityFW
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(string connectionString)
            : base(connectionString)
        { }

        public DbSet<Employee> Employees { get; set; }
    }
}