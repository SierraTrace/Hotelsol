using HotelSol.hotelsol.datos.DAO.interfaz;
using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelSol.hotelsol.datos.DAO;

namespace HotelSol.hotelsol.negocio.controlador
{
    internal class ClienteControl
    {
        private readonly ClienteDao _clienteDao;

        public ClienteControl(ClienteDao clienteDao)
        {
            _clienteDao = clienteDao;
        }

        public bool ExisteDni(string dni) => _clienteDao.ExisteDni(dni);
        public void Agregar(Cliente cliente) => _clienteDao.Agregar(cliente);
        public void Modificar(Cliente cliente) => _clienteDao.Modificar(cliente);
        public Cliente? ObtenerPorId(int id) => _clienteDao.ObtenerPorId(id);
        public Cliente? BuscarPorDni(string dni) => _clienteDao.BuscarPorDni(dni);
        public List<object> ObtenerTodosParaTabla() => _clienteDao.ObtenerTodosParaTabla();
        public List<Cliente> ObtenerTodos() => _clienteDao.ObtenerTodos();

    }
}
