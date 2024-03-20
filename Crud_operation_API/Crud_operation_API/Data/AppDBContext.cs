using Microsoft.EntityFrameworkCore;

namespace Crud_operation_API.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
