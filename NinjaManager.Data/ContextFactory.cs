using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NinjaManager.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("../NinjaManager.Web/appsettings.json")
            .Build();

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"));

            return new ApplicationDbContext(builder.Options);
        }
    }
}