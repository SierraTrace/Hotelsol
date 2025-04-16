using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelSol.hotelsol.vista
{
    public partial class LoginForm : Form
    {
        private readonly HotelSolDbContext _dbContext;

        public LoginForm(HotelSolDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = userNameTxt.Text.Trim();
            string contraseña = contraseñaTxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Por favor, introduce usuario y contraseña.", "Advertencia");
                return;
            }

            try
            {
                var empleado = _dbContext.Empleados
                    .FirstOrDefault(e => e.UserName == usuario && e.Contraseña == contraseña);

                if (empleado != null)
                {
                    MessageBox.Show($"Bienvenido, {empleado.Nombre} ({empleado.Categoria})", "Acceso concedido");

                    this.Hide();

                    // Abrimos siempre el mismo formulario y pasamos al empleado
                    GestionForm gestionForm = new GestionForm(empleado);
                    gestionForm.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    contraseñaTxt.Clear();
                    contraseñaTxt.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al acceder a la base de datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
