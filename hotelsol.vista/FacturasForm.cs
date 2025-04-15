using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HotelSol.hotelsol.vista
{
    public partial class FacturasForm : Form
    {
        private readonly HotelSolDbContext _dbContext;
        private Cliente? clienteActual = null;
        private Factura? facturaSeleccionada = null;

        public FacturasForm(HotelSolDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            btnBuscarCliente.Click += btnBuscarCliente_Click;
            btnCalcular.Click += btnCalcular_Click;
            btnAgregarFactura.Click += btnAgregarFactura_Click;
            dgvFacturas.CellClick += dgvFacturas_CellClick;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;

            CargarClientesEnCombo();
            CargarFacturas();
        }

        private void CargarClientesEnCombo()
        {
            cmbClientes.DisplayMember = "NombreCompleto";
            cmbClientes.ValueMember = "IdCliente";

            cmbClientes.DataSource = _dbContext.Clientes
                .Select(c => new
                {
                    c.IdCliente,
                    NombreCompleto = c.Nombre + " " + c.Apellido,
                    c.Dni
                })
                .ToList();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string dni = txtBuscarDNI.Text.Trim();

            if (string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("Ingrese un DNI.", "Advertencia");
                return;
            }

            var cliente = _dbContext.Clientes
                .Include(c => c.Reservas)
                .FirstOrDefault(c => c.Dni == dni);

            if (cliente == null)
            {
                MessageBox.Show("Cliente no encontrado.");
                return;
            }

            clienteActual = cliente;
            cmbClientes.SelectedValue = cliente.IdCliente;

            CargarReservasDelCliente(cliente.IdCliente);
            CargarServiciosDelCliente(cliente.IdCliente);
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue is int idCliente)
            {
                clienteActual = _dbContext.Clientes.FirstOrDefault(c => c.IdCliente == idCliente);

                if (clienteActual != null)
                {
                    CargarReservasDelCliente(clienteActual.IdCliente);
                    CargarServiciosDelCliente(clienteActual.IdCliente);
                }
            }
        }

        private void CargarReservasDelCliente(int clienteId)
        {
            var reservasUsadas = _dbContext.Facturas
                .SelectMany(f => f.ListaReservas)
                .Select(r => r.IdReserva)
                .ToHashSet();

            var reservas = _dbContext.Reservas
                .Where(r => r.ClienteId == clienteId
                    && !reservasUsadas.Contains(r.IdReserva)
                    && r.Estado != EstadoReserva.Cancelada)
                .ToList();

            chkReservas.DataSource = reservas;
            chkReservas.DisplayMember = nameof(Reserva);
            chkReservas.ValueMember = "IdReserva";
        }

        private void CargarServiciosDelCliente(int clienteId)
        {
            var serviciosUsados = _dbContext.Facturas
                .SelectMany(f => f.ListaServicios)
                .Select(s => s.IdServicio)
                .ToHashSet();

            var servicios = _dbContext.Servicios
                .Where(s => s.ClienteId == clienteId && !serviciosUsados.Contains(s.IdServicio))
                .ToList();

            chkServicios.DataSource = servicios;
            chkServicios.DisplayMember = nameof(Servicio); 
            chkServicios.ValueMember = "IdServicio";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (clienteActual == null)
            {
                MessageBox.Show("Primero selecciona un cliente.");
                return;
            }

            var reservas = chkReservas.CheckedItems.Cast<Reserva>().ToList();
            var servicios = chkServicios.CheckedItems.Cast<Servicio>().ToList();

            var factura = new Factura
            {
                Fecha = DateTime.Now,
                Cliente = clienteActual,
                ClienteId = clienteActual.IdCliente,
                ListaReservas = reservas,
                ListaServicios = servicios
            };

            factura.CalcularPrecioFactura();

            lblTotal.Text = $"Importe: {factura.PrecioTotal:C}";
            lblDescuento.Text = $"Descuento: {factura.Descuento:P}";
            lblPrecioFinal.Text = $"Precio final: {factura.PrecioFactura:C}";
        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            if (clienteActual == null)
            {
                MessageBox.Show("Primero selecciona un cliente.");
                return;
            }

            var reservas = chkReservas.CheckedItems.Cast<Reserva>().ToList();
            var servicios = chkServicios.CheckedItems.Cast<Servicio>().ToList();

            var factura = new Factura
            {
                Fecha = DateTime.Now,
                Cliente = clienteActual,
                ClienteId = clienteActual.IdCliente,
                ListaReservas = reservas,
                ListaServicios = servicios
            };

            factura.CalcularPrecioFactura();

            _dbContext.Facturas.Add(factura);
            _dbContext.SaveChanges();

            MessageBox.Show("Factura agregada correctamente.");

            CargarFacturas();
            CargarReservasDelCliente(clienteActual.IdCliente);
            CargarServiciosDelCliente(clienteActual.IdCliente);
        }

        private void CargarFacturas()
        {
            var facturas = _dbContext.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.ListaReservas)
                .Include(f => f.ListaServicios)
                .ToList();

            dgvFacturas.DataSource = facturas
                .Select(f => new
                {
                    f.IdFactura,
                    Cliente = $"{f.Cliente.Nombre} {f.Cliente.Apellido}",
                    Fecha = f.Fecha.ToString("dd/MM/yyyy"),
                    Total = f.PrecioTotal,
                    Descuento = f.Descuento,
                    PrecioFinal = f.PrecioFactura
                })
                .ToList();
        }

        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idFactura = Convert.ToInt32(dgvFacturas.Rows[e.RowIndex].Cells["IdFactura"].Value);
                facturaSeleccionada = _dbContext.Facturas
                    .Include(f => f.Cliente)
                    .Include(f => f.ListaReservas)
                    .Include(f => f.ListaServicios)
                    .FirstOrDefault(f => f.IdFactura == idFactura);

                if (facturaSeleccionada != null)
                {
                    clienteActual = facturaSeleccionada.Cliente;
                    txtBuscarDNI.Text = clienteActual.Dni;
                    cmbClientes.SelectedValue = clienteActual.IdCliente;

                    CargarReservasDelCliente(clienteActual.IdCliente);
                    CargarServiciosDelCliente(clienteActual.IdCliente);
                }
            }
        }
    }
}