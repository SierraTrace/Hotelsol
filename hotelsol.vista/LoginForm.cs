using HotelSol.hotelsol.datos.DAO.interfaz;
using HotelSol.hotelsol.modelo;
using HotelSol.hotelsol.negocio.controlador;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelSol.hotelsol.vista
{
    public partial class LoginForm : Form
    {
        public Empleado? EmpleadoLogueado {  get; private set; }
        private readonly LoginDao loginDao;

        public LoginForm(LoginDao loginDao)
        {
            InitializeComponent();
            this.loginDao = loginDao;
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

            Empleado? empleado = loginDao.VerificarCredenciales(usuario, contraseña);

            if (empleado != null)
            {
                EmpleadoLogueado = empleado;
                DialogResult = DialogResult.OK;
                Close();
            } else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
