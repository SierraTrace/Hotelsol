using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelSol.hotelsol.vista
{
    public partial class ConsultasForm : Form
    {
        private readonly HotelSolDbContext _dbContext;

        public ConsultasForm(HotelSolDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;

            btnDisponibilidad.Click += btnDisponibilidad_Click;
            btnClientesReserva.Click += btnClientesReserva_Click;
        }

        private void btnDisponibilidad_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dateDisponibilidadLlegada.Value.Date;
            DateTime fechaFin = dateDisponibilidadSalida.Value.Date;

            if (fechaFin <= fechaInicio)
            {
                MessageBox.Show("La fecha de salida debe ser posterior a la fecha de llegada.");
                return;
            }

            // Mostrar DisponibilidadForm pasando fechas
            var disponibilidadForm = new DisponibilidadForm(_dbContext, fechaInicio, fechaFin);
            disponibilidadForm.ShowDialog();
        }

        private void btnClientesReserva_Click(object sender, EventArgs e)
        {
            var fechaSeleccionada = dateClientesReserva.Value.Date;
            var form = new ClientesReservaForm(_dbContext, fechaSeleccionada);
            form.ShowDialog();
        }
    }
}


