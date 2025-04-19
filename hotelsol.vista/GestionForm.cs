using System;
using System.Windows.Forms;
using HotelSol.hotelsol.datos.DAO.factory;
using HotelSol.hotelsol.datos.DAO.impl;
using HotelSol.hotelsol.datos.DAO.interfaz;
using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;

namespace HotelSol.hotelsol.vista
{
    public partial class GestionForm : Form
    {
        private readonly Empleado _empleado;
        private readonly FactoryDao _factoryDao;

        private readonly EmpleadoDao _empleadoDao;
        private readonly ServicioDao _servicioDao;
        private readonly ClienteDao _clienteDao;
        private readonly HabitacionDao _habitacionDao;
        private readonly ReservaDao _reservaDao;
        private readonly FacturaDao _facturaDao;
     
        public GestionForm(Empleado empleado)
        {
            InitializeComponent();

            _empleado = empleado ?? throw new ArgumentNullException(nameof(empleado));

            _factoryDao = new FactoryDao();
            _empleadoDao = _factoryDao.GetEmpleadoDao();
            _clienteDao = _factoryDao.GetClienteDao();
            _habitacionDao = _factoryDao.GetHabitacionDao();
            _reservaDao = _factoryDao.GetReservaDao();
            _servicioDao = _factoryDao.GetServicioDao();
            _facturaDao = _factoryDao.GetFacturaDao();

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
            var reservasForm = new ReservasForm(_reservaDao, _clienteDao);
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
            clientesItem.Click += (s, e) => AbrirFormularioEnPanel(new ClientesForm(_reservaDao, _clienteDao));
            reservasItem.Click += (s, e) => AbrirFormularioEnPanel(new ReservasForm(_reservaDao, _clienteDao));
            empleadosItem.Click += (s, e) => AbrirFormularioEnPanel(new EmpleadosForm(_empleadoDao));
            habitacionesItem.Click += (s, e) => AbrirFormularioEnPanel(new HabitacionesForm(_habitacionDao));
            serviciosItem.Click += (s, e) => AbrirFormularioEnPanel(new ServiciosForm(_servicioDao));
            facturasItem.Click += (s, e) => AbrirFormularioEnPanel(new FacturasForm(_facturaDao));
            consultasItem.Click += (s, e) => AbrirFormularioEnPanel(new ConsultasForm(_habitacionDao, _reservaDao));
            erpItem.Click += (s, e) => AbrirFormularioEnPanel(new ERPForm(_factoryDao.GetDbContext()));

            salirItem.Click += (s, e) =>
            {
                this.Close();
               // Application.Restart();
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

