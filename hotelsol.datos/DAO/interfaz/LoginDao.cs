using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.datos.DAO.interfaz
{
    public interface LoginDao
    {
        Empleado? VerificarCredenciales(string usuario, string contraseña);
    }
}
