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
        List<TipoHabitacion> ObtenerTiposHabitacion();
        void Agregar(Habitacion habitacion);
        bool ModificarHabitacion(int numero, int tipoId, EstadoHabitacion estado, decimal precioAlta, decimal precioMedia, decimal precioBaja);
        Habitacion? ObtenerHabitacionConPrecios(int numero);
        List<object> ObtenerHabitacionesParaTabla();
        List<Habitacion> ObtenerDisponibles(DateTime fechaInicio, DateTime fechaFin);
    }
}
