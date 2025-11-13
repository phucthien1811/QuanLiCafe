using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace QuanLiCafe.Data
{
    public class CafeContextFactory : IDesignTimeDbContextFactory<CafeContext>
    {
        public CafeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CafeContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CafeDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new CafeContext(optionsBuilder.Options);
        }
    }
}
