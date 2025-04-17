using System;
using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;
using HotelSol.hotelsol.negocio.controlador;
using HotelSol.hotelsol.datos.DAO.interfaz;

namespace HotelSol.hotelsol.vista
{
    public partial class ServiciosForm : Form
    {
        private readonly ServicioControl servicioControl;
        private readonly Cliente? _clienteActual;

        public ServiciosForm(ServicioDao servicioDao)
        {
            InitializeComponent();
           
            servicioControl = new ServicioControl(servicioDao);
           
            btnAgregar.Click += btnAgregar_Click;
            btnModificar.Click += btnModificar_Click;
            dataGridServicios.CellClick += dataGridServicios_CellClick;
            btnBuscarCliente.Click += btnBuscarCliente_Click;

            CargarClientes();
            CargarServicios();
        }

        public ServiciosForm(ServicioDao servicioDao, Cliente cliente) : this(servicioDao)
        {
            _clienteActual = cliente;
            cmbClientes.SelectedItem = cliente;
            cmbClientes.Enabled = false;

            btnAgregar.Visible = false;
            btnModificar.Visible = false;

            var btnCargar = new Button
            {
                Text = "Cargar",
                Width = 100,
                Height = 30,
                Top = btnAgregar.Top,
                Left = btnAgregar.Left
            };

            btnCargar.Click += btnCargarServicio_Click;
            this.Controls.Add(btnCargar);
        }

        private void CargarClientes()
        {
            cmbClientes.DataSource = servicioControl.ObtenerClientes();
            cmbClientes.DisplayMember = "DniYNombre"; 
            cmbClientes.ValueMember = "IdCliente";
        }

        private void CargarServicios()
        {
            dataGridServicios.DataSource = null;
            dataGridServicios.DataSource = servicioControl.ObtenerServiciosParaTabla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out string concepto, out decimal precio, out Cliente cliente))
                return;

            var servicio = new Servicio
            {
                Concepto = concepto,
                Precio = precio,
                Cliente = cliente
            };

            servicioControl.AgregarServicio(servicio);

            MessageBox.Show("Servicio agregado correctamente.");
            LimpiarCampos();
            CargarServicios();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridServicios.CurrentRow == null || dataGridServicios.CurrentRow.Cells["IdServicio"].Value is not int id)
            {
                MessageBox.Show("Seleccione un servicio válido.");
                return;
            }

            var servicio = servicioControl.ObtenerServicioPorId(id);
            if (servicio == null)
            {
                MessageBox.Show("Servicio no encontrado.");
                return;
            }

            if (!ValidarCampos(out string concepto, out decimal precio, out Cliente cliente))
                return;

            servicio.Concepto = concepto;
            servicio.Precio = precio;
            servicio.Cliente = cliente;

            servicioControl.ModificarServicio(servicio);

            MessageBox.Show("Servicio modificado correctamente.");
            LimpiarCampos();
            CargarServicios();
        }

        private void btnCargarServicio_Click(object sender, EventArgs e)
        {
            if (_clienteActual == null)
                return;

            if (!ValidarCampos(out string concepto, out decimal precio, out _))
                return;

            var servicio = new Servicio
            {
                Concepto = concepto,
                Precio = precio,
                Cliente = _clienteActual
            };

            servicioControl.AgregarServicio(servicio);

            MessageBox.Show("Servicio agregado correctamente.");
            this.Close();
        }

        private void btnBuscarCliente_Click(object? sender, EventArgs e)
        {
            string dni = txtBuscarDni.Text.Trim();
            var cliente = servicioControl.BuscarClientePorDni(dni);

            if (cliente != null)
                cmbClientes.SelectedItem = cliente;
            else
                MessageBox.Show("Cliente no encontrado.");
        }

        private void dataGridServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (!dataGridServicios.Columns.Contains("IdServicio"))
                return;

            var idValue = dataGridServicios.Rows[e.RowIndex].Cells["IdServicio"].Value;
            if (idValue == null || idValue == DBNull.Value)
                return;

            if (int.TryParse(idValue.ToString(), out int id))
            {
                var servicio = servicioControl.ObtenerServicioPorId(id);
                if (servicio != null)
                {
                    txtConcepto.Text = servicio.Concepto;
                    numPrecio.Value = servicio.Precio;
                    cmbClientes.SelectedItem = servicio.Cliente;
                }
            }
        }

        private bool ValidarCampos(out string concepto, out decimal precio, out Cliente cliente)
        {
            concepto = txtConcepto.Text.Trim();
            precio = numPrecio.Value;
            cliente = null!;

            if (string.IsNullOrWhiteSpace(concepto))
            {
                MessageBox.Show("Debe ingresar un concepto.");
                return false;
            }

            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a cero.");
                return false;
            }

            if (cmbClientes.SelectedItem is not Cliente clienteSeleccionado)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return false;
            }

            cliente = clienteSeleccionado;
            return true;
        }

        private void LimpiarCampos()
        {
            txtConcepto.Clear();
            numPrecio.Value = numPrecio.Minimum;
            cmbClientes.SelectedIndex = -1;
            txtBuscarDni.Clear();
            dataGridServicios.ClearSelection();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}