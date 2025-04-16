using HotelSol.hotelsol.modelo;
using HotelSol.hotelsol.negocio.controlador;
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
        private readonly FacturaControl facturaControl;
        private Cliente? clienteActual = null;
        private Factura? facturaSeleccionada = null;

        public FacturasForm(HotelSolDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            facturaControl = new FacturaControl(_dbContext);

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
            cmbClientes.DataSource = facturaControl.ObtenerClientesParaCombo();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string dni = txtBuscarDNI.Text.Trim();

            if (string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("Ingrese un DNI.", "Advertencia");
                return;
            }

            var cliente = facturaControl.BuscarClientePorDni(dni);

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
                clienteActual = facturaControl.ObtenerClientePorId(idCliente);

                if (clienteActual != null)
                {
                    CargarReservasDelCliente(clienteActual.IdCliente);
                    CargarServiciosDelCliente(clienteActual.IdCliente);
                }
            }
        }

        private void CargarReservasDelCliente(int clienteId)
        {
            var reservas = facturaControl.ObtenerReservasDisponibles(clienteId);

            chkReservas.DataSource = null;
            chkReservas.DataSource = reservas;
            chkReservas.DisplayMember = nameof(Reserva);
            chkReservas.ValueMember = "IdReserva";
        }

        private void CargarServiciosDelCliente(int clienteId)
        {
            var servicios = facturaControl.ObtenerServiciosDisponibles(clienteId);

            chkServicios.DataSource = null;
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

            var factura = facturaControl.GenerarFactura(clienteActual, reservas, servicios);

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

            var factura = facturaControl.GenerarFactura(clienteActual, reservas, servicios);

            facturaControl.GuardarFactura(factura);

            MessageBox.Show("Factura agregada correctamente.");

            CargarFacturas();
            CargarReservasDelCliente(clienteActual.IdCliente);
            CargarServiciosDelCliente(clienteActual.IdCliente);
        }

        private void CargarFacturas()
        {
            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = facturaControl.ObtenerFacturasParaTabla();
        }

        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idFactura = Convert.ToInt32(dgvFacturas.Rows[e.RowIndex].Cells["IdFactura"].Value);
                facturaSeleccionada = facturaControl.ObtenerFacturaPorId(idFactura);
                
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