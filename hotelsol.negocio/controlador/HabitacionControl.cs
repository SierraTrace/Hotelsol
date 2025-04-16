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
        private readonly HotelSolDbContext _dbContext;

        public HabitacionControl(HotelSolDbContext context)
        {
            _dbContext = context;
        }

        public List<TipoHabitacion> ObtenerTiposHabitacion()
        {
            return _dbContext.TiposHabitacion.ToList();
        }

        public void AgregarHabitacion(Habitacion habitacion)
        {
            _dbContext.Habitaciones.Add(habitacion);
            _dbContext.SaveChanges();
        }

        public bool ModificarHabitacion(int numero, int tipoId, EstadoHabitacion estado, decimal precioAlta, decimal precioMedia, decimal precioBaja)
        {
            var habitacion = _dbContext.Habitaciones
                .Include(h => h.PreciosPorTemporada)
                .FirstOrDefault(h => h.Numero == numero);

            if (habitacion == null)
                return false;

            habitacion.TipoHabitacionId = tipoId;
            habitacion.Estado = estado;

            foreach (var precio in habitacion.PreciosPorTemporada)
            {
                switch (precio.Temporada)
                {
                    case Temporada.Alta:
                        precio.Precio = precioAlta;
                        break;
                    case Temporada.Media:
                        precio.Precio = precioMedia;
                        break;
                    case Temporada.Baja:
                        precio.Precio = precioBaja;
                        break;
                }
            }

            _dbContext.SaveChanges();
            return true;
        }

        public Habitacion? ObtenerHabitacionConPrecios(int numero)
        {
            return _dbContext.Habitaciones
                .Include(h => h.PreciosPorTemporada)
                .FirstOrDefault(h => h.Numero == numero);
        }

        public List<object> ObtenerHabitacionesParaTabla()
        {
            return _dbContext.Habitaciones
                .Include(h => h.TipoHabitacion)
                .Include(h => h.PreciosPorTemporada)
                .ToList()
                .Select(h => new
                {
                    h.Numero,
                    Tipo = h.TipoHabitacion.Nombre,
                    Estado = h.Estado.ToString(),
                    PrecioAlta = h.PreciosPorTemporada.FirstOrDefault(p => p.Temporada == Temporada.Alta)?.Precio ?? 0,
                    PrecioMedia = h.PreciosPorTemporada.FirstOrDefault(p => p.Temporada == Temporada.Media)?.Precio ?? 0,
                    PrecioBaja = h.PreciosPorTemporada.FirstOrDefault(p => p.Temporada == Temporada.Baja)?.Precio ?? 0
                })
                .Cast<object>()
                .ToList();
        }

        public List<Habitacion> ObtenerDisponibles(DateTime fechaInicio, DateTime fechaFin)
        {
            return _dbContext.Habitaciones
                .Include(h => h.TipoHabitacion)
                .Where(h => !_dbContext.Reservas.Any(r =>
                    r.HabitacionId == h.Numero &&
                    r.Estado != EstadoReserva.Cancelada &&
                    (
                        (fechaInicio >= r.FechaLlegada && fechaInicio < r.FechaSalida) ||
                        (fechaFin > r.FechaLlegada && fechaFin <= r.FechaSalida) ||
                        (fechaInicio <= r.FechaLlegada && fechaFin >= r.FechaSalida)
                    )))
                .ToList();
        }
    }
}
