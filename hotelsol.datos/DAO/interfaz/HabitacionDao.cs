using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.datos.DAO.interfaz
{
    public interface HabitacionDao
    {
        List<Habitacion> ObtenerTodas();
        Habitacion ObtenerPorNumero(int numero);
        void Agregar(Habitacion habitacion);
        void Modificar(Habitacion habitacion);
        void Eliminar(int numero);
    }
}
