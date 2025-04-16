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
        private readonly HotelSolDbContext _dbContext;

        public FacturaControl(HotelSolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<object> ObtenerClientesParaCombo()
        {
            return _dbContext.Clientes
                .Select(c => new
                {
                    c.IdCliente,
                    NombreCompleto = c.Nombre + " " + c.Apellido,
                    c.Dni
                })
                .Cast<object>()
                .ToList();
        }

        public Cliente? BuscarClientePorDni(string dni)
        {
            return _dbContext.Clientes
                .Include(c => c.Reservas)
                .FirstOrDefault(c => c.Dni == dni);
        }

        public Cliente? ObtenerClientePorId(int idCliente)
        {
            return _dbContext.Clientes.FirstOrDefault(c => c.IdCliente == idCliente);
        }

        public List<Reserva> ObtenerReservasDisponibles(int clienteId)
        {
            var reservasUsadas = _dbContext.Facturas
                .SelectMany(f => f.ListaReservas)
                .Select(r => r.IdReserva)
                .ToHashSet();

            return _dbContext.Reservas
                .Where(r => r.ClienteId == clienteId
                            && !reservasUsadas.Contains(r.IdReserva)
                            && r.Estado != EstadoReserva.Cancelada)
                .ToList();
        }

        public List<Servicio> ObtenerServiciosDisponibles(int clienteId)
        {
            var serviciosUsados = _dbContext.Facturas
                .SelectMany(f => f.ListaServicios)
                .Select(s => s.IdServicio)
                .ToHashSet();

            return _dbContext.Servicios
                .Where(s => s.ClienteId == clienteId && !serviciosUsados.Contains(s.IdServicio))
                .ToList();
        }

        public Factura GenerarFactura(Cliente cliente, List<Reserva> reservas, List<Servicio> servicios)
        {
            var factura = new Factura
            {
                Fecha = DateTime.Now,
                Cliente = cliente,
                ClienteId = cliente.IdCliente,
                ListaReservas = reservas,
                ListaServicios = servicios
            };

            factura.CalcularPrecioFactura();
            return factura;
        }

        public void GuardarFactura(Factura factura)
        {
            _dbContext.Facturas.Add(factura);
            _dbContext.SaveChanges();
        }

        public List<object> ObtenerFacturasParaTabla()
        {
            return _dbContext.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.ListaReservas)
                .Include(f => f.ListaServicios)
                .ToList()
                .Select(f => new
                {
                    f.IdFactura,
                    Cliente = $"{f.Cliente.Nombre} {f.Cliente.Apellido}",
                    Fecha = f.Fecha.ToString("dd/MM/yyyy"),
                    Total = f.PrecioTotal,
                    Descuento = f.Descuento,
                    PrecioFinal = f.PrecioFactura
                })
                .Cast<object>()
                .ToList();
        }

        public Factura? ObtenerFacturaPorId(int idFactura)
        {
            return _dbContext.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.ListaReservas)
                .Include(f => f.ListaServicios)
                .FirstOrDefault(f => f.IdFactura == idFactura);
        }
    }
}
