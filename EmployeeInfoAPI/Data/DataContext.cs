using Microsoft.EntityFrameworkCore;

namespace EmployeeInfoAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<EmployeeInfo> Employees { get; set; }
    }
}
