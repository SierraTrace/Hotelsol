using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelSol.hotelsol.vista
{
    public partial class ClientesReservaForm : Form
    {
        private readonly HotelSolDbContext _dbContext;

        public ClientesReservaForm(HotelSolDbContext dbContext, DateTime fechaSeleccionada)
        {
            InitializeComponent();
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            CargarClientesConReserva(fechaSeleccionada);
        }

        private void CargarClientesConReserva(DateTime fecha)
        {
            var clientes = _dbContext.Reservas
                .Include(r => r.Cliente)
                .Where(r => r.FechaLlegada <= fecha && r.FechaSalida > fecha)
                .Select(r => new
                {
                    r.Cliente.IdCliente,
                    r.Cliente.Dni,
                    NombreCompleto = r.Cliente.Nombre + " " + r.Cliente.Apellido,
                    r.Cliente.Email,
                    r.Cliente.Telefono
                })
                .Distinct()
                .ToList();

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
