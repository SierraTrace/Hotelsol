using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.datos.DAO.interfaz
{
    public interface EmpleadoDao
    {
        List<Empleado> ObtenerTodos();
        Empleado ObtenerPorId(int id);
        Empleado BuscarPorUserName(string userName);
        void Agregar(Empleado empleado);
        void Modificar(Empleado empleado);
        void Eliminar(int id);
    }
}
