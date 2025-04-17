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
    public class FacturaControl
    {
        private readonly FacturaDao _facturaDao;

        public FacturaControl(FacturaDao facturaDao)
        {
            _facturaDao = facturaDao;
        }

        public List<object> ObtenerClientesParaCombo() => _facturaDao.ObtenerClientesParaCombo();

        public Cliente? BuscarClientePorDni(string dni) => _facturaDao.BuscarClientePorDni(dni);

        public Cliente? ObtenerClientePorId(int idCliente) => _facturaDao.ObtenerClientePorId(idCliente);

        public List<Reserva> ObtenerReservasDisponibles(int clienteId) => _facturaDao.ObtenerReservasDisponibles(clienteId);

        public List<Servicio> ObtenerServiciosDisponibles(int clienteId) => _facturaDao.ObtenerServiciosDisponibles(clienteId);

        public Factura GenerarFactura(Cliente cliente, List<Reserva> reservas, List<Servicio> servicios)
              => _facturaDao.GenerarFactura(cliente, reservas, servicios);

        public void GuardarFactura(Factura factura) => _facturaDao.GuardarFactura(factura);

        public List<object> ObtenerFacturasParaTabla() => _facturaDao.ObtenerFacturasParaTabla();


        public Factura? ObtenerFacturaPorId(int idFactura) => _facturaDao.ObtenerFacturaPorId(idFactura);
    }
}
