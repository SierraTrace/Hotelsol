using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using HotelSol.hotelsol.modelo;
using HotelSol.hotelsol.vista;

namespace HotelSolLimpio.hotelsol
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Cargar appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Obtener la cadena de conexión desde appsettings.json
            string connectionString = configuration.GetConnectionString("PersistentMinds")
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión en appsettings.json");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Error: La cadena de conexión no está definida en appsettings.json.");
            }

            // Configurar DbContextOptions con Pomelo (MySQL)
            var optionsBuilder = new DbContextOptionsBuilder<HotelSolDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            // Crear instancia de DbContext
            using var dbContext = new HotelSolDbContext(optionsBuilder.Options);

            // Iniciar la aplicación con FormLogin
            Application.Run(new LoginForm(dbContext));
        }
    }
}