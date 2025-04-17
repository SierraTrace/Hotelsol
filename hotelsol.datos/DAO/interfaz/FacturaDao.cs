using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.datos.DAO.interfaz
{
    public interface FacturaDao
    {
        List<object> ObtenerClientesParaCombo();
        Cliente? BuscarClientePorDni(string dni);
        Cliente? ObtenerClientePorId(int idCliente);
        List<Reserva> ObtenerReservasDisponibles(int clienteId);
        List<Servicio> ObtenerServiciosDisponibles(int clienteId);
        Factura GenerarFactura(Cliente cliente, List<Reserva> reservas, List<Servicio> servicios);
        void GuardarFactura(Factura factura);
        List<object> ObtenerFacturasParaTabla();
        Factura? ObtenerFacturaPorId(int idFactura);
    }
}
