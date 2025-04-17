using HotelSol.hotelsol.datos.DAO.impl;
using HotelSol.hotelsol.datos.DAO.interfaz;
using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.datos.DAO.factory
{
    public class FactoryDao
    {
        private readonly HotelSolDbContext _dbContext;

        public FactoryDao()
        {
            var connectionString = "Server=127.0.0.1;Port=4306;Database=persistentminds;Uid=DatarUser;Pwd=7KKdizpDZ81DyI2mn8QC";
            var options = new DbContextOptionsBuilder<HotelSolDbContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;

            _dbContext = new HotelSolDbContext(options);
        }


        public EmpleadoDao GetEmpleadoDao() => new EmpleadoDaoImpl(_dbContext);
        public ClienteDao GetClienteDao() => new ClienteDaoImpl(_dbContext);
        public ReservaDao GetReservaDao() => new ReservaDaoImpl(_dbContext);
        public HabitacionDao GetHabitacionDao() => new HabitacionDaoImpl(_dbContext);
        public ServicioDao GetServicioDao() => new ServicioDaoImpl(_dbContext);
        public FacturaDao GetFacturaDao() => new FacturaDaoImpl(_dbContext);
        public HotelSolDbContext GetDbContext() => _dbContext;
    }
}
