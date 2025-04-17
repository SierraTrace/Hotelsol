using HotelSol.hotelsol.datos.DAO.interfaz;
using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelSol.hotelsol.negocio.controlador
{
    public class HabitacionControl
    {
        private readonly HabitacionDao _habitacionDao;

        public HabitacionControl(HabitacionDao habitacionDao)
        {
            _habitacionDao = habitacionDao;
        }

        public List<TipoHabitacion> ObtenerTiposHabitacion() => _habitacionDao.ObtenerTiposHabitacion();
   
        public void AgregarHabitacion(Habitacion habitacion) => _habitacionDao.Agregar(habitacion);
      
        public bool ModificarHabitacion(int numero, int tipoId, EstadoHabitacion estado, decimal precioAlta, decimal precioMedia, decimal precioBaja) 
            => _habitacionDao.ModificarHabitacion(numero, tipoId, estado, precioAlta, precioMedia, precioBaja);
        public Habitacion? ObtenerHabitacionConPrecios(int numero) => _habitacionDao.ObtenerHabitacionConPrecios(numero);

        public List<object> ObtenerHabitacionesParaTabla() => _habitacionDao.ObtenerHabitacionesParaTabla();
        public List<Habitacion> ObtenerDisponibles(DateTime fechaInicio, DateTime fechaFin) => _habitacionDao.ObtenerDisponibles(fechaInicio, fechaFin);

    }
}
