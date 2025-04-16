using HotelSol.hotelsol.modelo;
using HotelSol.hotelsol.negocio.controlador;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelSol.hotelsol.vista
{
    public partial class ClientesReservaForm : Form
    {
        private readonly HotelSolDbContext _dbContext;
        private readonly ReservaControl reservaControl;

        public ClientesReservaForm(HotelSolDbContext dbContext, DateTime fechaSeleccionada)
        {
            InitializeComponent();
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            reservaControl = new ReservaControl(_dbContext);

            CargarClientesConReserva(fechaSeleccionada);
        }

        private void CargarClientesConReserva(DateTime fecha)
        {
            var clientes = reservaControl.ObtenerClientesConReservaEnFecha(fecha);
               
            dataGridClientesreserva.DataSource = null;
            dataGridClientesreserva.DataSource = clientes;
        }

        private void ClientesReservaForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridClientesreserva_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
