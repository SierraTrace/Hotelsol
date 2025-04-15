using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelSol.hotelsol.vista
{
    public partial class ReservasForm : Form
    {
        private readonly HotelSolDbContext _dbContext;

        public ReservasForm(HotelSolDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
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

            bool conflicto = _dbContext.Reservas.Any(r =>
                r.HabitacionId == habitacion.Numero &&
                (
                    (llegada >= r.FechaLlegada && llegada < r.FechaSalida) ||
                    (salida > r.FechaLlegada && salida <= r.FechaSalida) ||
                    (llegada <= r.FechaLlegada && salida >= r.FechaSalida)
                )
            );

            if (conflicto)
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
                Estado = EstadoReserva.Pendiente
            };

            reserva.PreciosNoche = _dbContext.PreciosNoche
                .Where(p => p.HabitacionId == habitacion.Numero)
                .ToList();

            reserva.PreciosAlojamiento = _dbContext.PrecioAlojamiento
                .Where(p => p.TipoHabitacion.Id == habitacion.TipoHabitacion.Id)
                .ToList();

            reserva.GuardarPrecios(_dbContext);

            _dbContext.Reservas.Add(reserva);
            _dbContext.SaveChanges();

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

            var reserva = _dbContext.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .FirstOrDefault(r => r.IdReserva == idReserva);

            if (reserva == null)
            {
                MessageBox.Show("Reserva no encontrada.");
                return;
            }

            if (!ValidarCampos(out Cliente cliente, out Habitacion habitacion, out DateTime llegada, out DateTime salida, out TipoAlojamiento tipo))
                return;

            bool conflicto = _dbContext.Reservas.Any(r =>
                r.IdReserva != reserva.IdReserva &&
                r.HabitacionId == habitacion.Numero &&
                (
                    (llegada >= r.FechaLlegada && llegada < r.FechaSalida) ||
                    (salida > r.FechaLlegada && salida <= r.FechaSalida) ||
                    (llegada <= r.FechaLlegada && salida >= r.FechaSalida)
                )
            );

            if (conflicto)
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
            _dbContext.SaveChanges();

            MessageBox.Show("Reserva modificada correctamente.");
            CargarReservas();
            LimpiarCampos();
        }

        private void dateFechaLlegada_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var temporada = TemporadaDia.CalcularTemporadaPorDia(dateFechaLlegada.Value, _dbContext);
                lblTemporadaDetectada.Text = $"Temporada estimada: {temporada}";
            }
            catch
            {
                lblTemporadaDetectada.Text = "Fecha inválida o fuera de rango.";
            }
        }

        private void CargarReservas()
        {
            var reservas = _dbContext.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .OrderByDescending(r => r.IdReserva)
                .ToList()
                .Select(r => new
                {
                    IdReserva = r.IdReserva,
                    Cliente = r.Cliente.DniYNombre,
                    Habitacion = r.Habitacion.Numero,
                    FechaLlegada = r.FechaLlegada.ToString("dd/MM/yyyy"),
                    FechaSalida = r.FechaSalida.ToString("dd/MM/yyyy"),
                    TipoAlojamiento = r.TipoAlojamiento.ToString(),
                    Temporada = r.Temporada.ToString(),
                    Estado = r.Estado.ToString(),
                    Total = r.PrecioReservaGuardado
                })
                .ToList();

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
                var reserva = _dbContext.Reservas
                    .Include(r => r.Cliente)
                    .Include(r => r.Habitacion)
                    .FirstOrDefault(r => r.IdReserva == id);

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
            var cliente = _dbContext.Clientes.FirstOrDefault(c => c.Dni == dni);

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

            if (habitacionSeleccionada.Estado == EstadoHabitacion.Ocupada || habitacionSeleccionada.Estado == EstadoHabitacion.Ocupada)
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
            if (dataGridReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva para hacer check-in.");
                return;
            }

            if (dataGridReservas.CurrentRow.Cells["IdReserva"].Value is not int idReserva)
            {
                MessageBox.Show("ID de reserva no válido.");
                return;
            }

            var reserva = _dbContext.Reservas.FirstOrDefault(r => r.IdReserva == idReserva);

            if (reserva == null)
            {
                MessageBox.Show("Reserva no encontrada.");
                return;
            }

            if (reserva.Estado != EstadoReserva.Pendiente)
            {
                MessageBox.Show("La reserva no está en estado pendiente.");
                return;
            }

            var hoy = DateTime.Today;

            if (reserva.FechaLlegada != hoy)
            {
                MessageBox.Show("Solo puede hacer check-in el día de llegada.");
                return;
            }

            reserva.Estado = EstadoReserva.Confirmada;
            _dbContext.SaveChanges();

            MessageBox.Show($"Check-in realizado correctamente.\n\nSe confirma la entrada de {reserva.Cliente.Nombre} {reserva.Cliente.Apellido}.");
            CargarReservas();
            LimpiarCampos();
        }
        private void dataGridReservas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columna = dataGridReservas.Columns[e.ColumnIndex].DataPropertyName;

            // Alternar entre orden ascendente y descendente
            bool ascendente = true;
            if (dataGridReservas.Tag is Tuple<string, bool> ultimaOrden && ultimaOrden.Item1 == columna)
            {
                ascendente = !ultimaOrden.Item2;
            }

            // Excluir reservas canceladas y pagadas
            var reservas = _dbContext.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .Where(r => r.Estado != EstadoReserva.Cancelada && r.Estado != EstadoReserva.Pagada)
                .ToList();

            var lista = reservas.Select(r => new
            {
                r.IdReserva,
                Cliente = r.Cliente.DniYNombre,
                Habitacion = r.Habitacion.Numero,
                FechaLlegada = r.FechaLlegada.ToString("dd/MM/yyyy"),
                FechaSalida = r.FechaSalida.ToString("dd/MM/yyyy"),
                TipoAlojamiento = r.TipoAlojamiento.ToString(),
                Temporada = r.Temporada.ToString(),
                Estado = r.Estado.ToString(),
                Total = r.PrecioReservaGuardado
            });

            var ordenada = ascendente
                ? lista.OrderBy(x => x.GetType().GetProperty(columna)?.GetValue(x))
                : lista.OrderByDescending(x => x.GetType().GetProperty(columna)?.GetValue(x));

            dataGridReservas.DataSource = ordenada.ToList();

            // Guardar el estado de orden actual
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

            var reserva = _dbContext.Reservas
                .Include(r => r.Cliente)
                .FirstOrDefault(r => r.IdReserva == idReserva);

            if (reserva == null)
            {
                MessageBox.Show("Reserva no encontrada.");
                return;
            }

            if (reserva.Estado != EstadoReserva.Confirmada)
            {
                MessageBox.Show("Solo se puede hacer check-out si la reserva ha sido confirmada anteriormente.");
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
                reserva.Estado = EstadoReserva.Pagada;
                _dbContext.SaveChanges();

                MessageBox.Show("Check-out realizado correctamente.");
                CargarReservas();
                LimpiarCampos();
            }
        }

        private void VerificarNoPresentadosDeDiasAnteriores()
        {
            var hoy = DateTime.Today;
            var ayer = hoy.AddDays(-1);

            var reservasAtrasadas = _dbContext.Reservas
                .Include(r => r.Cliente)
                .Where(r => r.FechaLlegada.Date == ayer && r.Estado == EstadoReserva.Pendiente)
                .ToList();

            foreach (var reserva in reservasAtrasadas)
            {
                string mensaje = $"⚠ El cliente {reserva.Cliente.DniYNombre} no se presentó ayer ({ayer:dd/MM/yyyy}).\n" +
                                 "¿Deseas cancelar la reserva?\n\n" +
                                 "S = Cancelar\nN = Marcar como 'No presentado'";

                var resultado = MessageBox.Show(mensaje, "Cliente no presentado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    reserva.Estado = EstadoReserva.Cancelada;
                }
                else
                {
                    reserva.Estado = EstadoReserva.No_presentado;
                }
            }

            if (reservasAtrasadas.Any())
            {
                _dbContext.SaveChanges();
                MessageBox.Show("Reservas actualizadas según respuesta del operador.", "Actualización completada");
                CargarReservas();
            }
        }
    }
}
