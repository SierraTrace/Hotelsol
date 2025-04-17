using HotelSol.hotelsol.modelo;
using HotelSol.hotelsol.datos.DAO.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.datos.DAO.impl
{
    internal class LoginDaoImpl : LoginDao
    {
        private readonly HotelSolDbContext _dbContext;

        public LoginDaoImpl(HotelSolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Empleado? VerificarCredenciales(string usuario, string contraseña)
        {
            return _dbContext.Empleados
                .FirstOrDefault(e => e.UserName == usuario && e.Contraseña == contraseña);
        }
    }
}
