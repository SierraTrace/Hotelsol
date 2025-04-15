using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelSol.hotelsol.vista
{
    public partial class HabitacionesForm : Form
    {
        private readonly HotelSolDbContext _dbContext;

        public HabitacionesForm(HotelSolDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            this.btnAgregar.Click += new EventHandler(this.btnAgregar_Click);
            this.btnModificar.Click += new EventHandler(this.btnModificar_Click);
            this.dataGridHabitaciones.CellClick += new DataGridViewCellEventHandler(this.dataGridHabitaciones_CellContentClick);

            cmbTipoHabitacion.DataSource = _dbContext.TiposHabitacion.ToList();
            cmbTipoHabitacion.DisplayMember = "Nombre";
            cmbTipoHabitacion.ValueMember = "Id";
            cmbTipoHabitacion.SelectedIndex = -1;

            cmbEstado.DataSource = Enum.GetValues(typeof(EstadoHabitacion));
            cmbEstado.SelectedIndex = -1;
            dataGridHabitaciones.CellClick += dataGridHabitaciones_CellContentClick;

            CargarHabitaciones();
        }

        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero.Text) || !int.TryParse(txtNumero.Text, out int numero))
            {
                MessageBox.Show("Ingrese un número válido para la habitación.");
                return;
            }

            if (cmbTipoHabitacion.SelectedItem is not TipoHabitacion tipoSeleccionado)
            {
                MessageBox.Show("Seleccione un tipo de habitación.");
                return;
            }

            if (cmbEstado.SelectedItem is not EstadoHabitacion estadoSeleccionado)
            {
                MessageBox.Show("Seleccione el estado de la habitación.");
                return;
            }

            decimal precioAlta = numPrecioAlta.Value;
            decimal precioMedia = numPrecioMedia.Value;
            decimal precioBaja = numPrecioBaja.Value;

            if (precioAlta <= 0 || precioMedia <= 0 || precioBaja <= 0)
            {
                MessageBox.Show("Ingrese precios válidos para todas las temporadas.");
                return;
            }

            var habitacion = new Habitacion
            {
                Numero = numero,
                TipoHabitacionId = tipoSeleccionado.Id,
                Estado = estadoSeleccionado
            };

            habitacion.PreciosPorTemporada.Add(new PrecioNoche
            {
                Habitacion = habitacion,
                HabitacionId = habitacion.Numero,
                Temporada = Temporada.Alta,
                Precio = precioAlta
            });
            habitacion.PreciosPorTemporada.Add(new PrecioNoche
            {
                Habitacion = habitacion,
                HabitacionId = habitacion.Numero,
                Temporada = Temporada.Media,
                Precio = precioMedia
            });
            habitacion.PreciosPorTemporada.Add(new PrecioNoche
            {
                Habitacion = habitacion,
                HabitacionId = habitacion.Numero,
                Temporada = Temporada.Baja,
                Precio = precioBaja
            });

            _dbContext.Habitaciones.Add(habitacion);
            _dbContext.SaveChanges();

            MessageBox.Show("Habitación agregada correctamente.");
            LimpiarCampos();
            CargarHabitaciones();
        }

        private void btnModificar_Click(object? sender, EventArgs e)
        {
            if (dataGridHabitaciones.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una habitación para modificar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNumero.Text) || !int.TryParse(txtNumero.Text, out int numero))
            {
                MessageBox.Show("Número inválido.");
                return;
            }

            if (cmbEstado.SelectedItem is not EstadoHabitacion estadoSeleccionado)
            {
                MessageBox.Show("Selecciona un estado válido.", "Advertencia");
                return;
            }

            if (cmbTipoHabitacion.SelectedItem is not TipoHabitacion tipoSeleccionado)
            {
                MessageBox.Show("Selecciona un tipo de habitación.", "Advertencia");
                return;
            }

            var habitacion = _dbContext.Habitaciones
                .Include(h => h.PreciosPorTemporada)
                .FirstOrDefault(h => h.Numero == numero);

            if (habitacion == null)
            {
                MessageBox.Show("Habitación no encontrada.");
                return;
            }

            habitacion.TipoHabitacionId = tipoSeleccionado.Id;
            habitacion.Estado = estadoSeleccionado;

            foreach (var precio in habitacion.PreciosPorTemporada)
            {
                switch (precio.Temporada)
                {
                    case Temporada.Alta:
                        precio.Precio = numPrecioAlta.Value;
                        break;
                    case Temporada.Media:
                        precio.Precio = numPrecioMedia.Value;
                        break;
                    case Temporada.Baja:
                        precio.Precio = numPrecioBaja.Value;
                        break;
                }
            }

            _dbContext.SaveChanges();
            MessageBox.Show("Habitación modificada correctamente.");
            CargarHabitaciones();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNumero.Clear();
            cmbTipoHabitacion.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            numPrecioAlta.Value = numPrecioAlta.Minimum;
            numPrecioMedia.Value = numPrecioMedia.Minimum;
            numPrecioBaja.Value = numPrecioBaja.Minimum;
        }

        private void CargarHabitaciones()
        {
            var habitaciones = _dbContext.Habitaciones
                .Include(h => h.TipoHabitacion)
                .Include(h => h.PreciosPorTemporada)
                .ToList()
                .Select(h => new
                {
                    h.Numero,
                    Tipo = h.TipoHabitacion.Nombre,
                    Estado = h.Estado.ToString(),
                    PrecioAlta = h.PreciosPorTemporada.FirstOrDefault(p => p.Temporada == Temporada.Alta)?.Precio ?? 0,
                    PrecioMedia = h.PreciosPorTemporada.FirstOrDefault(p => p.Temporada == Temporada.Media)?.Precio ?? 0,
                    PrecioBaja = h.PreciosPorTemporada.FirstOrDefault(p => p.Temporada == Temporada.Baja)?.Precio ?? 0
                })
                .ToList();

            dataGridHabitaciones.DataSource = null;
            dataGridHabitaciones.DataSource = habitaciones;
        }

        private void dataGridHabitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridHabitaciones.Rows[e.RowIndex];

                txtNumero.Text = fila.Cells["Numero"].Value?.ToString();

                // Seleccionar el tipo de habitación por texto (DisplayMember)
                string tipoNombre = fila.Cells["Tipo"].Value?.ToString() ?? "";
                var tipo = cmbTipoHabitacion.Items
                    .Cast<TipoHabitacion>()
                    .FirstOrDefault(t => t.Nombre == tipoNombre);
                if (tipo != null)
                    cmbTipoHabitacion.SelectedItem = tipo;

                // Seleccionar estado de habitación
                string estadoNombre = fila.Cells["Estado"].Value?.ToString() ?? "";
                var estado = Enum.TryParse<EstadoHabitacion>(estadoNombre, out var estadoParsed)
                    ? estadoParsed : EstadoHabitacion.Disponible; // Valor por defecto
                cmbEstado.SelectedItem = estado;

                // Precios
                if (decimal.TryParse(fila.Cells["PrecioAlta"].Value?.ToString(), out decimal precioAlta))
                    numPrecioAlta.Value = precioAlta;

                if (decimal.TryParse(fila.Cells["PrecioMedia"].Value?.ToString(), out decimal precioMedia))
                    numPrecioMedia.Value = precioMedia;

                if (decimal.TryParse(fila.Cells["PrecioBaja"].Value?.ToString(), out decimal precioBaja))
                    numPrecioBaja.Value = precioBaja;
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

