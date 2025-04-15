using HotelSol.hotelsol.modelo;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelSol.hotelsol.vista
{
    public partial class EmpleadosForm : Form
    {
        private readonly HotelSolDbContext _dbContext;
        private int? empleadoSeleccionadoId = null;

        public EmpleadosForm(HotelSolDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));


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

            // Validar que no se repita el UserName
            bool userNameExiste = _dbContext.Empleados.Any(e => e.UserName == userName);
            if (userNameExiste)
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

            _dbContext.Empleados.Add(nuevoEmpleado);
            _dbContext.SaveChanges();

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
            var empleados = _dbContext.Empleados
                .Select(e => new
                {
                    e.IdEmpleado,
                    e.Nombre,
                    e.Apellido,
                    e.UserName,
                    Categoria = e.Categoria.ToString()
                })
                .ToList();

            dataGridViewEmpleados.DataSource = null;
            dataGridViewEmpleados.DataSource = empleados;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}