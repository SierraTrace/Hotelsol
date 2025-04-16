using HotelSol.hotelsol.modelo;
using HotelSol.hotelsol.negocio.controlador;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelSol.hotelsol.vista
{
    public partial class ReservasForm : Form
    {
        private readonly HotelSolDbContext _dbContext;
        private readonly ReservaControl reservaControl;
        private readonly ClienteControl clienteControl;

        public ReservasForm(HotelSolDbContext dbContext)
        {
            _dbContext = dbContext;
            reservaControl = new ReservaControl(dbContext);
            clienteControl = new ClienteControl(dbContext);
            InitializeComponent();

            this.Load += (s, e) => VerificarNoPresentadosDeDiasAnteriores();

            dataGridReservas.AutoGenerateColumns = true;

            this.btnCheckOut.Click += btnCheckOut_Click;
            this.btnAgregar.Click += btnAgregar_Click;
            this.btnModificar.Click += btnModificar_Click;
            this.dataGridReservas.CellClick += dataGridReservas_CellClick;
            this.btnBuscarCliente.Click += btnBuscarCliente_Click;
            this.btnCancelar.Click += btnCancelar_Click;
            this.btnCheckIn.Click += btnCheckIn_Click;
            this.dateFechaLlegada.ValueChanged += dateFechaLlegada_ValueChanged;
            this.dataGridReservas.ColumnHeaderMouseClick += dataGridReservas_ColumnHeaderMouseClick;

            CargarCombos();
            CargarReservas();
        }

        private void CargarCombos()
        {
            cmbCliente.DataSource = _dbContext.Clientes.ToList();
            cmbCliente.DisplayMember = "DniYNombre";
            cmbCliente.ValueMember = "IdCliente";

            cmbHabitacion.DataSource = _dbContext.Habitaciones
                .Include(h => h.TipoHabitacion)
                .ToList();
            cmbHabitacion.DisplayMember = "Numero";
            cmbHabitacion.ValueMember = "Numero";

            cmbTipoAlojamiento.DataSource = Enum.GetValues(typeof(TipoAlojamiento));
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out Cliente cliente, out Habitacion habitacion, out DateTime llegada, out DateTime salida, out TipoAlojamiento tipo))
                return;

            if (reservaControl.ExisteConflictoReserva(habitacion, llegada, salida))
            {
                MessageBox.Show("La habitación ya está reservada para una o más fechas seleccionadas.");
                return;
            }

            var reserva = new Reserva
            {
                Cliente = cliente,
                Habitacion = habitacion!,
                FechaLlegada = llegada,
                FechaSalida = salida,
                TipoAlojamiento = tipo,
                Temporada = TemporadaDia.CalcularTemporadaPorDia(llegada, _dbContext),
                Estado = EstadoReserva.Pendiente,
                PreciosNoche = _dbContext.PreciosNoche
                    .Where(p => p.HabitacionId == habitacion.Numero)
                    .ToList(),
                PreciosAlojamiento = _dbContext.PrecioAlojamiento
                     .Where(p => p.TipoHabitacion.Id == habitacion.TipoHabitacion.Id)
                     .ToList()
            };

            reserva.GuardarPrecios(_dbContext);
            reservaControl.AgregarReserva(reserva);

            MessageBox.Show("Reserva agregada correctamente.");
            CargarReservas();
            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva para modificar.");
                return;
            }

            if (dataGridReservas.CurrentRow.Cells["IdReserva"].Value is not int idReserva)
            {
                MessageBox.Show("ID de reserva no válido.");
                return;
            }

            var reserva = reservaControl.ObtenerReservaPorId(idReserva);

            if (reserva == null)
            {
                MessageBox.Show("Reserva no encontrada.");
                return;
            }

            if (!ValidarCampos(out Cliente cliente, out Habitacion habitacion, out DateTime llegada, out DateTime salida, out TipoAlojamiento tipo))
                return;

            if (reservaControl.ExisteConflictoReservaModificada(reserva.IdReserva, habitacion, llegada, salida))
            {
                MessageBox.Show("La habitación ya está reservada para una o más fechas seleccionadas.");
                return;
            }

            reserva.Cliente = cliente;
            reserva.Habitacion = habitacion;
            reserva.FechaLlegada = llegada;
            reserva.FechaSalida = salida;
            reserva.TipoAlojamiento = tipo;
            reserva.Temporada = TemporadaDia.CalcularTemporadaPorDia(llegada, _dbContext);

            if (reserva.Estado == EstadoReserva.No_presentado)
            {
                reserva.Estado = EstadoReserva.Pendiente;
            }

            reserva.PreciosNoche = _dbContext.PreciosNoche
                .Where(p => p.HabitacionId == habitacion.Numero)
                .ToList();

            reserva.PreciosAlojamiento = _dbContext.PrecioAlojamiento
                .Where(p => p.TipoHabitacion.Id == habitacion.TipoHabitacion.Id)
                .ToList();

            reserva.GuardarPrecios(_dbContext);

            reservaControl.ModificarReserva(reserva);

            MessageBox.Show("Reserva modificada correctamente.");
            CargarReservas();
            LimpiarCampos();
        }

        private void dateFechaLlegada_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var temporada = reservaControl.CalcularTemporada(dateFechaLlegada.Value);
                lblTemporadaDetectada.Text = $"Temporada estimada: {temporada}";
            }
            catch
            {
                lblTemporadaDetectada.Text = "Fecha inválida o fuera de rango.";
            }
        }

        private void CargarReservas()
        {
            var reservas = reservaControl.ObtenerReservasParaTabla();

            dataGridReservas.AutoGenerateColumns = true;
            dataGridReservas.DataSource = null;
            dataGridReservas.DataSource = reservas;

            if (dataGridReservas.Rows.Count > 0)
                dataGridReservas.FirstDisplayedScrollingRowIndex = 0;
        }

        private void dataGridReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validamos que sea una fila válida y que no sea una columna fuera de rango
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Validamos que la columna "IdReserva" exista
            if (!dataGridReservas.Columns.Contains("IdReserva"))
                return;

            // Validamos que el valor no sea null ni DBNull
            var cellValue = dataGridReservas.Rows[e.RowIndex].Cells["IdReserva"].Value;
            if (cellValue == null || cellValue == DBNull.Value)
                return;

            // Intentamos hacer el cast
            if (int.TryParse(cellValue.ToString(), out int id))
            {
                var reserva = reservaControl.ObtenerReservaPorId(id);

                if (reserva != null)
                {
                    cmbCliente.SelectedItem = reserva.Cliente!;
                    cmbHabitacion.SelectedItem = reserva.Habitacion!;
                    dateFechaLlegada.Value = reserva.FechaLlegada;
                    dateFechaSalida.Value = reserva.FechaSalida;
                    cmbTipoAlojamiento.SelectedItem = reserva.TipoAlojamiento;
                }
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string dni = txtBuscarDni.Text.Trim();
            var cliente = clienteControl.BuscarPorDni(dni);

            if (cliente != null)
                cmbCliente.SelectedItem = cliente;
            else
                MessageBox.Show("Cliente no encontrado.");

        }

        private bool ValidarCampos(out Cliente cliente, out Habitacion habitacion, out DateTime llegada, out DateTime salida, out TipoAlojamiento tipo)
        {
            cliente = null!;
            habitacion = null!;
            llegada = DateTime.MinValue;
            salida = DateTime.MinValue;
            tipo = default;

            // Validar Cliente
            if (cmbCliente.SelectedItem is not Cliente clienteSeleccionado)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return false;
            }

            // Validar Habitación
            if (cmbHabitacion.SelectedItem is not Habitacion habitacionSeleccionada)
            {
                MessageBox.Show("Debe seleccionar una habitación.");
                return false;
            }

            if (habitacionSeleccionada.Estado == EstadoHabitacion.Ocupada)
            {
                MessageBox.Show("La habitación seleccionada no está disponible.");
                return false;
            }

            // Validar fechas
            llegada = dateFechaLlegada.Value.Date;
            salida = dateFechaSalida.Value.Date;

            if (salida <= llegada)
            {
                MessageBox.Show("La fecha de salida debe ser posterior a la de llegada.");
                return false;
            }

            // Validar Tipo Alojamiento
            if (cmbTipoAlojamiento.SelectedItem is not TipoAlojamiento tipoSeleccionado)
            {
                MessageBox.Show("Debe seleccionar un tipo de alojamiento.");
                return false;
            }

            // Asignar valores si todo es válido
            cliente = clienteSeleccionado;
            habitacion = habitacionSeleccionada;
            tipo = tipoSeleccionado;

            return true;
        }

        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1;
            cmbHabitacion.SelectedIndex = -1;
            cmbTipoAlojamiento.SelectedIndex = -1;

            dateFechaLlegada.Value = DateTime.Today;
            dateFechaSalida.Value = DateTime.Today.AddDays(1);

            txtBuscarDni.Clear();
            lblTemporadaDetectada.Text = "";
            dataGridReservas.ClearSelection();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dataGridReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva para cancelar.");
                return;
            }

            if (dataGridReservas.CurrentRow.Cells["IdReserva"].Value is not int idReserva)
            {
                MessageBox.Show("ID de reserva no válido.");
                return;
            }

            var reserva = _dbContext.Reservas
                .Include(r => r.Habitacion)
                .FirstOrDefault(r => r.IdReserva == idReserva);

            if (reserva == null)
            {
                MessageBox.Show("Reserva no encontrada.");
                return;
            }

            if (reserva.Estado == EstadoReserva.Cancelada)
            {
                MessageBox.Show("La reserva ya está cancelada.");
                return;
            }

            if (reserva.Estado != EstadoReserva.Pendiente && reserva.Estado != EstadoReserva.No_presentado)
            {
                MessageBox.Show("La reserva ya no puedes ser cancelada.");
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Estás seguro de que deseas cancelar esta reserva?",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                reserva.Estado = EstadoReserva.Cancelada;
                reserva.Habitacion.Estado = EstadoHabitacion.Disponible;

                _dbContext.SaveChanges();

                MessageBox.Show("Reserva cancelada correctamente.");
                CargarReservas();
                LimpiarCampos();
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (dataGridReservas.CurrentRow == null ||
                dataGridReservas.CurrentRow.Cells["IdReserva"].Value is not int idReserva)
            {
                MessageBox.Show("Seleccione una reserva para hacer check-in.");
                return;
            }

            string? resultado = reservaControl.RealizarCheckIn(idReserva);

            if (resultado == null)
            {
                MessageBox.Show("Error inesperado durante el check-in.");
                return;
            }

            MessageBox.Show(resultado);
            CargarReservas();
            LimpiarCampos();
        }

        private void dataGridReservas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columna = dataGridReservas.Columns[e.ColumnIndex].DataPropertyName;

            bool ascendente = true;

            if (dataGridReservas.Tag is Tuple<string, bool> ultimaOrden && ultimaOrden.Item1 == columna)
            {
                ascendente = !ultimaOrden.Item2;
            }

            dataGridReservas.DataSource = reservaControl.ObtenerReservasOrdenadasPorColumna(columna, ascendente);
            dataGridReservas.Tag = Tuple.Create(columna, ascendente);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (dataGridReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná una reserva para hacer check-out.");
                return;
            }

            if (dataGridReservas.CurrentRow.Cells["IdReserva"].Value is not int idReserva)
            {
                MessageBox.Show("ID de reserva inválido.");
                return;
            }

            var reserva = reservaControl.ObtenerReservaPorId(idReserva);
              
            if (reserva == null)
            {
                MessageBox.Show("Reserva no encontrada.");
                return;
            }

            var confirmacion = MessageBox.Show(
                $"¿Confirmás la salida de {reserva.Cliente.Nombre} {reserva.Cliente.Apellido}?\n\n" +
                $"Verifica que el cliente ha pagado la factura.",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                if (reservaControl.RealizarCheckOut(idReserva, out string mensaje))
                {
                    MessageBox.Show(mensaje);
                    CargarReservas();
                    LimpiarCampos();
                } else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
           
            }
        }

        private void VerificarNoPresentadosDeDiasAnteriores()
        {
          
            var reservasAtrasadas = reservaControl.ObtenerNoPresentadosDelDiaAnterior();
           
            foreach (var reserva in reservasAtrasadas)
            {
                string mensaje = $"El cliente {reserva.Cliente.DniYNombre} no se presentó ayer ({reserva.FechaLlegada:dd/MM/yyyy}).\n" +
                                 "¿Deseas cancelar la reserva?\n\n" +
                                 "S = Cancelar\nN = Marcar como 'No presentado'";

                var resultado = MessageBox.Show(mensaje, "Cliente no presentado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                var nuevoEstado = (resultado == DialogResult.Yes) ? EstadoReserva.Cancelada : EstadoReserva.No_presentado;
                reservaControl.ActualizarEstadoReserva(reserva, nuevoEstado);

            }

            if (reservasAtrasadas.Any())
            {
                MessageBox.Show("Reservas actualizadas según respuesta del operador.", "Actualización completada");
                CargarReservas();
            }
        }
    }
}
