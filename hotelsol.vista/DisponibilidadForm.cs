using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HotelSol.hotelsol.vista;
using Microsoft.EntityFrameworkCore;

namespace HotelSol.hotelsol.vista
{
    public partial class DisponibilidadForm : Form
    {
        private readonly HotelSolDbContext _dbContext;
        private readonly DateTime fechaInicio;
        private readonly DateTime fechaFin;

        public DisponibilidadForm(HotelSolDbContext dbContext, DateTime fechaInicio, DateTime fechaFin)
        {
            InitializeComponent();
            _dbContext = dbContext;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;

            var habitacionesDisponibles = _dbContext.Habitaciones
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

            CargarHabitaciones(habitacionesDisponibles);
        }

        private void CargarHabitaciones(List<Habitacion> habitaciones)
        {
            var lista = habitaciones.Select(h => new
            {
                Numero = h.Numero,
                Tipo = h.TipoHabitacion.Nombre,
                Estado = h.Estado.ToString()
            }).ToList();

            dataGridDisponibilidad.AutoGenerateColumns = true;
            dataGridDisponibilidad.DataSource = lista;
        }
    }
}