using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using HotelSol.hotelsol.negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HotelSol.hotelsol.vista;
using HotelSol.hotelsol.negocio.controlador;

namespace HotelSol.hotelsol.vista
{
    public partial class DisponibilidadForm : Form
    {
        private readonly HotelSolDbContext _dbContext;
        private readonly HabitacionControl habitacionControl;
        private readonly DateTime fechaInicio;
        private readonly DateTime fechaFin;

        public DisponibilidadForm(HotelSolDbContext dbContext, DateTime fechaInicio, DateTime fechaFin)
        {
            InitializeComponent();
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;

            habitacionControl = new HabitacionControl(_dbContext);

            var habitacionesDisponibles = habitacionControl.ObtenerDisponibles(fechaInicio, fechaFin);
        
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