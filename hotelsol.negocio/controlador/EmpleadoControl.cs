using HotelSol.hotelsol.datos.DAO.interfaz;
using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.negocio.controlador
{
    public class EmpleadoControl
    {
        private readonly EmpleadoDao _empleadoDao;

        public EmpleadoControl(EmpleadoDao empleadoDao)
        {
            _empleadoDao = empleadoDao;
        }

        public bool ExisteUserName(string userName) => _empleadoDao.ExisteUserName(userName);
        public void Agregar(Empleado empleado) => _empleadoDao.Agregar(empleado);
        public List<object> ObtenerTodosParaTabla() => _empleadoDao.ObtenerTodosParaTabla();
    }
}
