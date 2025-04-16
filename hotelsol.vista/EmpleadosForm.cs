using HotelSol.hotelsol.modelo;
using HotelSol.hotelsol.negocio.controlador;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelSol.hotelsol.vista
{
    public partial class EmpleadosForm : Form
    {
        private readonly HotelSolDbContext _dbContext;
        private readonly EmpleadoControl empleadoControl;
        private int? empleadoSeleccionadoId = null;

        public EmpleadosForm(HotelSolDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            empleadoControl = new EmpleadoControl(dbContext);

            this.btnAgregar.Click += new EventHandler(this.btnAgregar_Click);

            cmbCategoria.DataSource = Enum.GetValues(typeof(TipoEmpleado));
            cmbCategoria.SelectedIndex = -1;

            CargarEmpleados();
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string userName = txtUserName.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Completa todos los campos", "Advertencia");
                return;
            }

            if (cmbCategoria.SelectedItem is not TipoEmpleado categoriaSeleccionada)
            {
                MessageBox.Show("Selecciona una categoría de empleado.", "Advertencia");
                return;
            }

            if (empleadoControl.ExisteUserName(userName))
            {
                MessageBox.Show("Ya existe un empleado con ese UserName.", "Error");
                return;
            }

            var nuevoEmpleado = new Empleado
            {
                Nombre = nombre,
                Apellido = apellido,
                UserName = userName,
                Contraseña = contraseña,
                Categoria = categoriaSeleccionada
            };

            empleadoControl.Agregar(nuevoEmpleado);

            MessageBox.Show("Empleado agregado correctamente", "Éxito");

            LimpiarCampos();
            CargarEmpleados();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtUserName.Clear();
            txtContraseña.Clear();
            cmbCategoria.SelectedIndex = -1;
        }

        private void CargarEmpleados()
        {
            dataGridViewEmpleados.DataSource = null;
            dataGridViewEmpleados.DataSource = empleadoControl.ObtenerTodosParaTabla();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}