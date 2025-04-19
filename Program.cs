using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using HotelSol.hotelsol.modelo;
using HotelSol.hotelsol.vista;
using HotelSol.hotelsol.datos.DAO.impl;
using HotelSol.hotelsol.datos.DAO.interfaz;

namespace HotelSolLimpio.hotelsol
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Cargar appsettings.json
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                // Obtener la cadena de conexión desde appsettings.json
                string connectionString = configuration.GetConnectionString("PersistentMinds")
                    ?? throw new InvalidOperationException("Problemas de conexion con la base de datos. \nPongase en contacto co su proveedor.");

                // Configurar DbContextOptions con Pomelo (MySQL)
                var optionsBuilder = new DbContextOptionsBuilder<HotelSolDbContext>();
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

                // Crear instancia de DbContext
                using var dbContext = new HotelSolDbContext(optionsBuilder.Options);

                LoginDao loginDao = new LoginDaoImpl(dbContext);

                while (true)
                {
                    var loginForm = new LoginForm(loginDao);
                    var resultado = loginForm.ShowDialog();

                    if (resultado == DialogResult.OK && loginForm.EmpleadoLogueado != null)
                    {
                        Application.Run(new GestionForm(loginForm.EmpleadoLogueado));
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(
                    "Ocurrió un error al iniciar la aplicación:\n\n" + ex.Message,
                    "Error crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}