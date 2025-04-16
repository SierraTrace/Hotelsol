using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.negocio.controlador
{
    public class LoginControl
    {
        private readonly HotelSolDbContext _dbContext;

        public LoginControl(HotelSolDbContext dbContext)
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
