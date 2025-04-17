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
    public class ReservaDaoImpl : ReservaDao
    {
        private readonly HotelSolDbContext _dbContext;

        public ReservaDaoImpl(HotelSolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Cliente> ObtenerClientes() => _dbContext.Clientes.ToList();

        public List<Habitacion> ObtenerHabitaciones() => _dbContext.Habitaciones.Include(h => h.TipoHabitacion).ToList();

        public bool ExisteConflictoReserva(Habitacion habitacion, DateTime llegada, DateTime salida, int? idReserva = null) =>
            _dbContext.Reservas.Any(r =>
                (idReserva == null || r.IdReserva != idReserva) &&
                r.HabitacionId == habitacion.Numero &&
                (
                    (llegada >= r.FechaLlegada && llegada < r.FechaSalida) ||
                    (salida > r.FechaLlegada && salida <= r.FechaSalida) ||
                    (llegada <= r.FechaLlegada && salida >= r.FechaSalida)
                )
            );

        public void AgregarReserva(Reserva reserva)
        {
            _dbContext.Reservas.Add(reserva);
            _dbContext.SaveChanges();
        }

        public void ModificarReserva(Reserva reserva) => _dbContext.SaveChanges();

        public bool ExisteConflictoReservaModificada(int idReservaActual, Habitacion habitacion, DateTime llegada, DateTime salida) =>
            _dbContext.Reservas.Any(r =>
                r.IdReserva != idReservaActual &&
                r.HabitacionId == habitacion.Numero &&
                (
                    (llegada >= r.FechaLlegada && llegada < r.FechaSalida) ||
                    (salida > r.FechaLlegada && salida <= r.FechaSalida) ||
                    (llegada <= r.FechaLlegada && salida >= r.FechaSalida)
                )
            );

        public Temporada CalcularTemporada(DateTime fecha) => TemporadaDia.CalcularTemporadaPorDia(fecha, _dbContext);

        public List<object> ObtenerReservasParaTabla() => _dbContext.Reservas
            .Include(r => r.Cliente)
            .Include(r => r.Habitacion)
            .OrderByDescending(r => r.IdReserva)
            .ToList()
            .Select(r => new
            {
                r.IdReserva,
                Cliente = r.Cliente.DniYNombre,
                Habitacion = r.Habitacion.Numero,
                FechaLlegada = r.FechaLlegada.ToString("dd/MM/yyyy"),
                FechaSalida = r.FechaSalida.ToString("dd/MM/yyyy"),
                TipoAlojamiento = r.TipoAlojamiento.ToString(),
                Temporada = r.Temporada.ToString(),
                Estado = r.Estado.ToString(),
                Total = r.PrecioReservaGuardado
            })
            .Cast<object>()
            .ToList();

        public List<Reserva> ObtenerTodas() => _dbContext.Reservas
            .Include(r => r.Cliente)
            .Include(r => r.Habitacion)
            .OrderByDescending(r => r.IdReserva)
            .ToList();

        public Reserva? ObtenerReservaPorId(int id) => _dbContext.Reservas
            .Include(r => r.Cliente)
            .Include(r => r.Habitacion)
            .FirstOrDefault(r => r.IdReserva == id);

        public Cliente? BuscarClientePorDni(string dni) => _dbContext.Clientes.FirstOrDefault(c => c.Dni == dni);

        public List<Reserva> ObtenerReservasAtrasadas(DateTime fecha) => _dbContext.Reservas
            .Include(r => r.Cliente)
            .Where(r => r.FechaLlegada.Date == fecha && r.Estado == EstadoReserva.Pendiente)
            .ToList();

        public List<Reserva> ObtenerReservasOrdenadas(Func<Reserva, object> keySelector, bool ascendente)
        {
            var query = _dbContext.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .Where(r => r.Estado != EstadoReserva.Cancelada && r.Estado != EstadoReserva.Pagada);

            return ascendente ? query.OrderBy(keySelector).ToList() : query.OrderByDescending(keySelector).ToList();
        }

        public List<object> ObtenerHistorialReservasPorCliente(int clienteId) => _dbContext.Reservas
            .Include(r => r.Habitacion)
            .Where(r => r.ClienteId == clienteId)
            .Select(r => new
            {
                r.IdReserva,
                Habitacion = r.Habitacion.Numero,
                r.FechaLlegada,
                r.FechaSalida,
                r.Estado,
                r.TipoAlojamiento,
                r.PrecioReservaGuardado
            })
            .Cast<object>()
            .ToList();

        public List<object> ObtenerClientesConReservaEnFecha(DateTime fecha) => _dbContext.Reservas
            .Include(r => r.Cliente)
            .Where(r => r.FechaLlegada <= fecha && r.FechaSalida > fecha)
            .Select(r => new
            {
                r.Cliente.IdCliente,
                r.Cliente.Dni,
                NombreCompleto = r.Cliente.Nombre + " " + r.Cliente.Apellido,
                r.Cliente.Email,
                r.Cliente.Telefono
            })
            .Distinct()
            .Cast<object>()
            .ToList();

        public string RealizarCheckIn(int idReserva)
        {
            var reserva = _dbContext.Reservas.Include(r => r.Cliente).FirstOrDefault(r => r.IdReserva == idReserva);
            if (reserva == null) return "Reserva no encontrada.";
            if (reserva.Estado != EstadoReserva.Pendiente) return "La reserva no está en estado pendiente.";
            if (reserva.FechaLlegada != DateTime.Today) return "Solo puede hacer check-in el día de llegada.";

            reserva.Estado = EstadoReserva.Confirmada;
            _dbContext.SaveChanges();
            return $"Check-in realizado correctamente.\n\nSe confirma la entrada de {reserva.Cliente.Nombre} {reserva.Cliente.Apellido}.";
        }

        public List<object> ObtenerReservasOrdenadasPorColumna(string columna, bool ascendente)
        {
            var reservas = _dbContext.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .Where(r => r.Estado != EstadoReserva.Cancelada && r.Estado != EstadoReserva.Pagada)
                .ToList();

            var lista = reservas.Select(r => new
            {
                r.IdReserva,
                Cliente = r.Cliente.DniYNombre,
                Habitacion = r.Habitacion.Numero,
                FechaLlegada = r.FechaLlegada.ToString("dd/MM/yyyy"),
                FechaSalida = r.FechaSalida.ToString("dd/MM/yyyy"),
                TipoAlojamiento = r.TipoAlojamiento.ToString(),
                Temporada = r.Temporada.ToString(),
                Estado = r.Estado.ToString(),
                Total = r.PrecioReservaGuardado
            });

            return (ascendente ? lista.OrderBy(x => x.GetType().GetProperty(columna)?.GetValue(x, null))
                                : lista.OrderByDescending(x => x.GetType().GetProperty(columna)?.GetValue(x, null)))
                   .Cast<object>()
                   .ToList();
        }

        public bool RealizarCheckOut(int idReserva, out string mensaje)
        {
            var reserva = _dbContext.Reservas.Include(r => r.Cliente).FirstOrDefault(r => r.IdReserva == idReserva);
            if (reserva == null)
            {
                mensaje = "Reserva no encontrada.";
                return false;
            }
            if (reserva.Estado != EstadoReserva.Confirmada)
            {
                mensaje = "Solo se puede hacer check-out si la reserva ha sido confirmada anteriormente.";
                return false;
            }

            reserva.Estado = EstadoReserva.Pagada;
            _dbContext.SaveChanges();
            mensaje = $"Check-out realizado correctamente para {reserva.Cliente.Nombre} {reserva.Cliente.Apellido}.";
            return true;
        }

        public List<Reserva> ObtenerNoPresentadosDelDiaAnterior()
        {
            var ayer = DateTime.Today.AddDays(-1);
            return _dbContext.Reservas.Include(r => r.Cliente)
                .Where(r => r.FechaLlegada.Date == ayer && r.Estado == EstadoReserva.Pendiente)
                .ToList();
        }

        public void ActualizarEstadoReserva(Reserva reserva, EstadoReserva nuevoEstado)
        {
            reserva.Estado = nuevoEstado;
            _dbContext.SaveChanges();
        }

        public string? CancelarReserva(int idReserva)
        {
            var reserva = _dbContext.Reservas.Include(r => r.Habitacion).FirstOrDefault(r => r.IdReserva == idReserva);
            if (reserva == null) return "Reserva no encontrada.";
            if (reserva.Estado == EstadoReserva.Cancelada) return "La reserva ya está cancelada.";
            if (reserva.Estado != EstadoReserva.Pendiente && reserva.Estado != EstadoReserva.No_presentado) return "La reserva ya no puede ser cancelada.";

            reserva.Estado = EstadoReserva.Cancelada;
            reserva.Habitacion.Estado = EstadoHabitacion.Disponible;
            _dbContext.SaveChanges();
            return null;
        }

        public void CompletarDatosDeReserva(Reserva reserva)
        {
            if (reserva == null || reserva.Habitacion == null || reserva.Habitacion.TipoHabitacion == null)
                throw new ArgumentNullException("La reserva o sus propiedades son nulas.");

            reserva.Temporada = TemporadaDia.CalcularTemporadaPorDia(reserva.FechaLlegada, _dbContext);
            reserva.Estado = EstadoReserva.Pendiente;

            reserva.PreciosNoche = _dbContext.PreciosNoche
                .Where(p => p.HabitacionId == reserva.Habitacion.Numero)
                .ToList();

            reserva.PreciosAlojamiento = _dbContext.PrecioAlojamiento
                .Where(p => p.TipoHabitacion.Id == reserva.Habitacion.TipoHabitacion.Id)
                .ToList();

            reserva.GuardarPrecios(_dbContext);
        }
    }
}
