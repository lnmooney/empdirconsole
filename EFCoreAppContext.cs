using Microsoft.EntityFrameworkCore;

namespace EFCoreApp
{
    public class EFCoreAppContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=empdir.database.windows.net;Database=empdir;User Id=sqladmin;Password=password1!;Trusted_Connection=False;MultipleActiveResultSets=true");
        }
    }
}