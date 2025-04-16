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
        private readonly HotelSolDbContext _dbContext;

        public ServicioControl(HotelSolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Cliente> ObtenerClientes()
        {
            return _dbContext.Clientes.ToList();
        }

        public Cliente? BuscarClientePorDni(string dni)
        {
            return _dbContext.Clientes.FirstOrDefault(c => c.Dni == dni);
        }

        public List<object> ObtenerServiciosParaTabla()
        {
            return _dbContext.Servicios
                .Include(s => s.Cliente)
                .ToList()
                .Select(s => new
                {
                    s.IdServicio,
                    Cliente = s.Cliente.DniYNombre,
                    s.Concepto,
                    s.Precio
                })
                .Cast<object>()
                .ToList();
        }

        public Servicio? ObtenerServicioPorId(int id)
        {
            return _dbContext.Servicios
                .Include(s => s.Cliente)
                .FirstOrDefault(s => s.IdServicio == id);
        }

        public void AgregarServicio(Servicio servicio)
        {
            _dbContext.Servicios.Add(servicio);
            _dbContext.SaveChanges();
        }

        public void ModificarServicio(Servicio servicio)
        {
            _dbContext.SaveChanges();
        }
    }
}
