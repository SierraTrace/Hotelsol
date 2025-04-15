using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace HotelSol.hotelsol.vista
{
    public partial class HistorialForm : Form
    {
        private readonly HotelSolDbContext _dbContext;

        public HistorialForm(HotelSolDbContext dbContext, Cliente cliente)
        {
            InitializeComponent();
            _dbContext = dbContext;

            CargarHistorial(cliente);
        }

        private void CargarHistorial(Cliente cliente)
        {
            var reservas = _dbContext.Reservas
                .Include(r => r.Habitacion)
                .Where(r => r.ClienteId == cliente.IdCliente)
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
                .ToList();

            dataGridHistorial.DataSource = reservas;
        }
    }
}
