using HotelSol.hotelsol.datos.DAO.interfaz;
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
        private readonly LoginDao _loginDao;

        public LoginControl(LoginDao loginDao)
        {
            _loginDao = loginDao;
        }

        public Empleado? VerificarCredenciales(string usuario, string contraseña)
        {
            return _loginDao.VerificarCredenciales(usuario, contraseña);

        }
    }
}
