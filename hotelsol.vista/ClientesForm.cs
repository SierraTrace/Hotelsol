using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelSol.hotelsol.vista
{
    public partial class ClientesForm : Form
    {
        private readonly HotelSolDbContext _dbContext;

        public ClientesForm(HotelSolDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.dataGridViewClientes.CellClick += dataGridViewClientes_CellClick;
            this.btnModificar.Click += btnModificar_Click;

            // Inicializa combo y carga datos
            cmbTipoCliente.DataSource = Enum.GetValues(typeof(TipoCliente));
            cmbTipoCliente.SelectedIndex = -1;
            CargarClientes();
        }

        private int? clienteSeleccionadoId = null;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string dni = txtDNI.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            if (cmbTipoCliente.SelectedItem is not TipoCliente tipoClienteSeleccionado)
            {
                MessageBox.Show("Selecciona un tipo de cliente.", "Advertencia");
                return;
            }

            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(dni) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("Completa todos los campos", "Advertencia");
                return;
            }

            // Verifica que no exista un cliente con el mismo DNI
            bool clienteExistente = _dbContext.Clientes.Any(c => c.Dni == dni);
            if (clienteExistente)
            {
                MessageBox.Show("Ya existe un cliente con ese DNI.", "Error");
                return;
            }

            var nuevoCliente = new Cliente
            {
                Nombre = nombre,
                Apellido = apellido,
                Dni = dni,
                Email = email,
                Telefono = telefono,
                TipoCliente = tipoClienteSeleccionado
            };

            _dbContext.Clientes.Add(nuevoCliente);
            _dbContext.SaveChanges();

            MessageBox.Show("Cliente agregado correctamente", "Éxito");

            LimpiarCampos();
            CargarClientes();
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {

            cmbTipoCliente.DataSource = Enum.GetValues(typeof(TipoCliente));
            cmbTipoCliente.SelectedIndex = 0;
            CargarClientes();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            cmbTipoCliente.SelectedIndex = -1;

            clienteSeleccionadoId = null;

            txtNombre.Enabled = true;
            txtDNI.Enabled = true;

            dataGridViewClientes.ClearSelection();
        }

        private void CargarClientes()
        {
            var clientes = _dbContext.Clientes
                .Select(c => new
                {
                    c.IdCliente,
                    c.Nombre,
                    c.Apellido,
                    c.Dni,
                    c.Email,
                    c.Telefono,
                    Tipo = c.TipoCliente.ToString()
                })
                .ToList();

            dataGridViewClientes.DataSource = null;
            dataGridViewClientes.DataSource = clientes;
        }

        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dataGridViewClientes.Rows[e.RowIndex];

                clienteSeleccionadoId = Convert.ToInt32(fila.Cells["IdCliente"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value?.ToString();
                txtDNI.Text = fila.Cells["Dni"].Value?.ToString();
                txtEmail.Text = fila.Cells["Email"].Value?.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value?.ToString();

                string tipoTexto = fila.Cells["Tipo"].Value?.ToString();
                if (Enum.TryParse<TipoCliente>(tipoTexto, out var tipo))
                {
                    cmbTipoCliente.SelectedItem = tipo;
                }

                
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtDNI.Enabled = false;
            }

        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId == null)
            {
                MessageBox.Show("Selecciona un cliente de la lista para modificar.");
                return;
            }

            var cliente = _dbContext.Clientes.FirstOrDefault(c => c.IdCliente == clienteSeleccionadoId.Value);
            if (cliente == null)
            {
                MessageBox.Show("Cliente no encontrado.");
                return;
            }

            // Campos permitidos
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            if (cmbTipoCliente.SelectedItem is not TipoCliente tipoClienteSeleccionado)
            {
                MessageBox.Show("Selecciona un tipo de cliente.");
                return;
            }

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("Email y teléfono no pueden estar vacíos.");
                return;
            }

            cliente.Email = email;
            cliente.Telefono = telefono;
            cliente.TipoCliente = tipoClienteSeleccionado;

            _dbContext.SaveChanges();

            MessageBox.Show("Cliente modificado correctamente.");
            LimpiarCampos();
            CargarClientes();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId == null)
            {
                MessageBox.Show("Selecciona un cliente primero.");
                return;
            }

            var cliente = _dbContext.Clientes.FirstOrDefault(c => c.IdCliente == clienteSeleccionadoId.Value);
            if (cliente == null)
            {
                MessageBox.Show("Cliente no encontrado.");
                return;
            }

            var historialForm = new HistorialForm(_dbContext, cliente);
            historialForm.ShowDialog(); // o .Show() si preferís sin bloqueo
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
