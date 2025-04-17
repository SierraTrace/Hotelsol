using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using HotelSol.hotelsol.negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HotelSol.hotelsol.vista;
using HotelSol.hotelsol.negocio.controlador;
using HotelSol.hotelsol.datos.DAO.interfaz;

namespace HotelSol.hotelsol.vista
{
    public partial class DisponibilidadForm : Form
    {
        private readonly HabitacionControl habitacionControl;
        private readonly DateTime fechaInicio;
        private readonly DateTime fechaFin;

        public DisponibilidadForm(HabitacionDao habitacionDao, DateTime fechaInicio, DateTime fechaFin)
        {
            InitializeComponent();
    
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;

            habitacionControl = new HabitacionControl(habitacionDao);

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