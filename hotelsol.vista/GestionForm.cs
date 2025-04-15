using System;
using System.Windows.Forms;
using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;

namespace HotelSol.hotelsol.vista
{
    public partial class GestionForm : Form
    {
        private readonly Empleado _empleado;
        private readonly HotelSolDbContext _dbContext;

        public GestionForm(Empleado empleado)
        {
            InitializeComponent();

            _empleado = empleado ?? throw new ArgumentNullException(nameof(empleado));

            // Configuración del DbContext con cadena de conexión
            var connectionString = "Server=192.168.1.45;Port=4306;Database=persistentminds;User=DatarUser;Password=7KKdizpDZ81DyI2mn8QC;";
            var optionsBuilder = new DbContextOptionsBuilder<HotelSolDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            _dbContext = new HotelSolDbContext(optionsBuilder.Options);

            // Título de la ventana
            this.Text = $"HotelSol {_empleado.Nombre} ({_empleado.Categoria})";

            // NO usamos MDI si trabajamos con panelContenedor
            this.IsMdiContainer = false;

            // Crear y añadir el menú
            var menuStrip = CrearMenuSegunRol();
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
            this.Controls.SetChildIndex(menuStrip, 0); // Menú va arriba

            // Cargar formulario inicial en el panel
            var reservasForm = new ReservasForm(_dbContext);
            AbrirFormularioEnPanel(reservasForm);
        }

        private void AbrirFormularioEnPanel(Form formulario)
        {
            panelContenedor.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formulario);
            panelContenedor.Tag = formulario;

            formulario.Show();
        }

        private MenuStrip CrearMenuSegunRol()
        {
            var menuStrip = new MenuStrip();

            var clientesItem = new ToolStripMenuItem("Clientes");
            var reservasItem = new ToolStripMenuItem("Reservas");
            var empleadosItem = new ToolStripMenuItem("Empleados");
            var habitacionesItem = new ToolStripMenuItem("Habitaciones");
            var serviciosItem = new ToolStripMenuItem("Servicios");
            var facturasItem = new ToolStripMenuItem("Facturas");
            var consultasItem = new ToolStripMenuItem("Consultas");
            var erpItem = new ToolStripMenuItem("Integración ERP");
            var salirItem = new ToolStripMenuItem("Cerrar sesión");

            // Usamos el método AbrirFormularioEnPanel en lugar de MdiParent
            clientesItem.Click += (s, e) => AbrirFormularioEnPanel(new ClientesForm(_dbContext));
            reservasItem.Click += (s, e) => AbrirFormularioEnPanel(new ReservasForm(_dbContext));
            empleadosItem.Click += (s, e) => AbrirFormularioEnPanel(new EmpleadosForm(_dbContext));
            habitacionesItem.Click += (s, e) => AbrirFormularioEnPanel(new HabitacionesForm(_dbContext));
            serviciosItem.Click += (s, e) => AbrirFormularioEnPanel(new ServiciosForm(_dbContext));
            facturasItem.Click += (s, e) => AbrirFormularioEnPanel(new FacturasForm(_dbContext));
            consultasItem.Click += (s, e) => AbrirFormularioEnPanel(new ConsultasForm(_dbContext));
            erpItem.Click += (s, e) => AbrirFormularioEnPanel(new ERPForm(_dbContext));

            salirItem.Click += (s, e) =>
            {
                this.Close();
                Application.Restart();
            };

            // Añadir según rol
            menuStrip.Items.Add(clientesItem);
            menuStrip.Items.Add(reservasItem);
            menuStrip.Items.Add(serviciosItem);
            menuStrip.Items.Add(facturasItem);
            menuStrip.Items.Add(consultasItem);

            if (_empleado.Categoria == TipoEmpleado.Administrador)
            {
                menuStrip.Items.Add(empleadosItem);
                menuStrip.Items.Add(habitacionesItem);
                menuStrip.Items.Add(erpItem);
            }

            menuStrip.Items.Add(salirItem);

            return menuStrip;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


