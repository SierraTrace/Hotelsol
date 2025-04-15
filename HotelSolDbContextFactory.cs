using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HotelSol.hotelsol.modelo
{
    public class HotelSolDbContextFactory : IDesignTimeDbContextFactory<HotelSolDbContext>
    {
        public HotelSolDbContext CreateDbContext(string[] args)
        {
            // Cargar configuración desde appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("PersistentMinds");

            var optionsBuilder = new DbContextOptionsBuilder<HotelSolDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new HotelSolDbContext(optionsBuilder.Options);
        }
    }
}