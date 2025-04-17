using HotelSol.hotelsol.datos.DAO.interfaz;
using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelSol.hotelsol.negocio.controlador
{
    public class ReservaControl
    {
        private readonly ReservaDao _reservaDao;

        public ReservaControl(ReservaDao reservaDao)
        {
            _reservaDao = reservaDao;
        }

        public List<Cliente> ObtenerClientes() => _reservaDao.ObtenerClientes();

        public List<Habitacion> ObtenerHabitaciones() => _reservaDao.ObtenerHabitaciones();

        public bool ExisteConflictoReserva(Habitacion habitacion, DateTime llegada, DateTime salida, int? idReserva = null)
            => _reservaDao.ExisteConflictoReserva(habitacion, llegada, salida, idReserva);

        public void AgregarReserva(Reserva reserva) => _reservaDao.AgregarReserva(reserva);

        public void ModificarReserva(Reserva reserva) => _reservaDao.ModificarReserva(reserva);

        public bool ExisteConflictoReservaModificada(int idReservaActual, Habitacion habitacion, DateTime llegada, DateTime salida)
             => _reservaDao.ExisteConflictoReservaModificada(idReservaActual, habitacion, llegada, salida);

        public Temporada CalcularTemporada(DateTime fecha) => _reservaDao.CalcularTemporada(fecha);

        public List<object> ObtenerReservasParaTabla() => _reservaDao.ObtenerReservasParaTabla();

        public List<Reserva> ObtenerTodas() => _reservaDao.ObtenerTodas();

        public Reserva? ObtenerReservaPorId(int id) => _reservaDao.ObtenerReservaPorId(id);

        public Cliente? BuscarClientePorDni(string dni) => _reservaDao.BuscarClientePorDni(dni);

        public List<Reserva> ObtenerReservasAtrasadas(DateTime fecha) => _reservaDao.ObtenerReservasAtrasadas(fecha);

        public List<Reserva> ObtenerReservasOrdenadas(Func<Reserva, object> keySelector, bool ascendente)
             => _reservaDao.ObtenerReservasOrdenadas(keySelector, ascendente);

        public List<object> ObtenerHistorialReservasPorCliente(int clienteId)
            => _reservaDao.ObtenerHistorialReservasPorCliente(clienteId);


        public List<object> ObtenerClientesConReservaEnFecha(DateTime fecha)
            => _reservaDao.ObtenerClientesConReservaEnFecha(fecha);

        public string RealizarCheckIn(int idReserva)
            => _reservaDao.RealizarCheckIn(idReserva);

        public List<object> ObtenerReservasOrdenadasPorColumna(string columna, bool ascendente)
              => _reservaDao.ObtenerReservasOrdenadasPorColumna(columna, ascendente);

        public bool RealizarCheckOut(int idReserva, out string mensaje)
            => _reservaDao.RealizarCheckOut(idReserva, out mensaje);


        public List<Reserva> ObtenerNoPresentadosDelDiaAnterior() => _reservaDao.ObtenerNoPresentadosDelDiaAnterior();


        public void ActualizarEstadoReserva(Reserva reserva, EstadoReserva nuevoEstado)
             => _reservaDao.ActualizarEstadoReserva(reserva, nuevoEstado);


        public string? CancelarReserva(int idReserva) => _reservaDao.CancelarReserva(idReserva);

        public void CompletarDatosDeReserva(Reserva reserva)
            => _reservaDao.CompletarDatosDeReserva(reserva);

    }
}
