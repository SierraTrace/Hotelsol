using HotelSol.hotelsol.datos.DAO.interfaz;
using HotelSol.hotelsol.modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.negocio.controlador
{
    public class ServicioControl
    {
        private readonly ServicioDao _servicioDao;

        public ServicioControl(ServicioDao servicioDao)
        {
            _servicioDao = servicioDao;
        }

        public List<Cliente> ObtenerClientes() => _servicioDao.ObtenerClientes();
        public Cliente? BuscarClientePorDni(string dni) => _servicioDao.BuscarClientePorDni(dni);
        public List<object> ObtenerServiciosParaTabla() => _servicioDao.ObtenerServiciosParaTabla();
        public Servicio? ObtenerServicioPorId(int id) => _servicioDao.ObtenerServicioPorId(id);
        public void AgregarServicio(Servicio servicio) => _servicioDao.AgregarServicio(servicio);
        public void ModificarServicio(Servicio servicio) => _servicioDao.ModificarServicio(servicio);
    }
}
