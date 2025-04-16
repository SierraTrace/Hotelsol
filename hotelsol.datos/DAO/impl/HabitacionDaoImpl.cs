using HotelSol.hotelsol.datos.DAO.interfaz;
using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.datos.DAO.impl
{
    public class HabitacionDaoImpl :HabitacionDao
    {
        private readonly HotelSolDbContext _context;

        public HabitacionDaoImpl(HotelSolDbContext context)
        {
            _context = context;
        }

        public List<Habitacion> ObtenerTodas()
        {
            return _context.Habitaciones
                .Include(h => h.TipoHabitacion)
                .Include(h => h.PreciosPorTemporada)
                .Include(h => h.Reservas)
                .ToList();
        }

        public Habitacion ObtenerPorNumero(int numero)
        {
            return _context.Habitaciones
                .Include(h => h.TipoHabitacion)
                .Include(h => h.PreciosPorTemporada)
                .Include(h => h.Reservas)
                .FirstOrDefault(h => h.Numero == numero);
        }

        public void Agregar(Habitacion habitacion)
        {
            _context.Habitaciones.Add(habitacion);
            _context.SaveChanges();
        }

        public void Modificar(Habitacion habitacion)
        {
            _context.Habitaciones.Update(habitacion);
            _context.SaveChanges();
        }

        public void Eliminar(int numero)
        {
            var habitacion = _context.Habitaciones.Find(numero);
            if (habitacion != null)
            {
                _context.Habitaciones.Remove(habitacion);
                _context.SaveChanges();
            }
        }
    }
}
