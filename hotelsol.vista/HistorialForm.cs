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
using HotelSol.hotelsol.negocio.controlador;

namespace HotelSol.hotelsol.vista
{
    public partial class HistorialForm : Form
    {
        private readonly HotelSolDbContext _dbContext;
        private readonly ReservaControl reservaControl;

        public HistorialForm(HotelSolDbContext dbContext, Cliente cliente)
        {
            InitializeComponent();
            _dbContext = dbContext;

            CargarHistorial(cliente);
        }

        private void CargarHistorial(Cliente cliente)
        {
            dataGridHistorial.DataSource = null;
            dataGridHistorial.DataSource = reservaControl.ObtenerHistorialReservasPorCliente(cliente.IdCliente);
        }
    }
}
