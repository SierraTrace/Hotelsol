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
using HotelSol.hotelsol.datos.DAO.interfaz;

namespace HotelSol.hotelsol.vista
{
    public partial class HistorialForm : Form
    {
        private readonly ReservaControl reservaControl;

        public HistorialForm(ReservaDao reservaDao, Cliente cliente)
        {
            InitializeComponent();
            this.reservaControl = new ReservaControl(reservaDao);

            CargarHistorial(cliente);
        }

        private void CargarHistorial(Cliente cliente)
        {
            dataGridHistorial.DataSource = null;
            dataGridHistorial.DataSource = reservaControl.ObtenerHistorialReservasPorCliente(cliente.IdCliente);
        }
    }
}
