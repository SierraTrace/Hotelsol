using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.datos.DAO.interfaz
{
    public interface ReservaDao
    {
        List<Cliente> ObtenerClientes();
        List<Habitacion> ObtenerHabitaciones();
        bool ExisteConflictoReserva(Habitacion habitacion, DateTime llegada, DateTime salida, int? idReserva = null);
        void AgregarReserva(Reserva reserva);
        void ModificarReserva(Reserva reserva);
        bool ExisteConflictoReservaModificada(int idReservaActual, Habitacion habitacion, DateTime llegada, DateTime salida);
        Temporada CalcularTemporada(DateTime fecha);
        List<object> ObtenerReservasParaTabla();
        List<Reserva> ObtenerTodas();
        Reserva? ObtenerReservaPorId(int id);
        Cliente? BuscarClientePorDni(string dni);
        List<Reserva> ObtenerReservasAtrasadas(DateTime fecha);
        List<Reserva> ObtenerReservasOrdenadas(Func<Reserva, object> keySelector, bool ascendente);
        List<object> ObtenerHistorialReservasPorCliente(int clienteId);
        List<object> ObtenerClientesConReservaEnFecha(DateTime fecha);
        string RealizarCheckIn(int idReserva);
        List<object> ObtenerReservasOrdenadasPorColumna(string columna, bool ascendente);
        bool RealizarCheckOut(int idReserva, out string mensaje);
        List<Reserva> ObtenerNoPresentadosDelDiaAnterior();
        void ActualizarEstadoReserva(Reserva reserva, EstadoReserva nuevoEstado);
        string? CancelarReserva(int idReserva);
        void CompletarDatosDeReserva(Reserva reserva);
    }
}
