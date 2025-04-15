using System;
using System.Linq;

namespace HotelSol.hotelsol.modelo
{
    public static class TemporadaDia
    {
        public static Temporada CalcularTemporadaPorDia(DateTime fecha, HotelSolDbContext db)
        {
            // Validación opcional: evitar fechas falsas
            if (fecha < DateTime.Today.AddYears(-1) || fecha > DateTime.Today.AddYears(2))
                throw new ArgumentOutOfRangeException(nameof(fecha), "La fecha está fuera del rango permitido.");

            int totalHabitaciones = db.Habitaciones.Count();

            if (totalHabitaciones == 0)
                return Temporada.Baja;

            // Contar reservas activas en esa fecha
            int reservasDelDia = db.Reservas
                .Count(r => r.FechaLlegada <= fecha && r.FechaSalida > fecha);

            double porcentajeOcupacion = (double)reservasDelDia / totalHabitaciones * 100;

            if (porcentajeOcupacion < 50)
                return Temporada.Baja;
            else if (porcentajeOcupacion <= 70)
                return Temporada.Media;
            else
                return Temporada.Alta;
        }
    }
}
