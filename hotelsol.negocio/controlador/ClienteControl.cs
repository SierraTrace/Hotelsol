using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.negocio.controlador
{
    internal class ClienteControl
    {
        private readonly HotelSolDbContext _dbContext;

        public ClienteControl(HotelSolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ExisteDni(string dni)
        {
            return _dbContext.Clientes.Any(c => c.Dni == dni);
        }

        public void Agregar(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();
        }

        public void Modificar(Cliente cliente)
        {
            _dbContext.Clientes.Update(cliente);
            _dbContext.SaveChanges();
        }

        public Cliente? ObtenerPorId(int id)
        {
            return _dbContext.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public Cliente? BuscarPorDni(string dni)
        {
            return _dbContext.Clientes.FirstOrDefault(c => c.Dni == dni);
        }

        public List<object> ObtenerTodosParaTabla()
        {
            return _dbContext.Clientes
                .Select(c => new
                {
                    c.IdCliente,
                    c.Nombre,
                    c.Apellido,
                    c.Dni,
                    c.Email,
                    c.Telefono,
                    Tipo = c.TipoCliente.ToString()
                })
                .Cast<object>()
                .ToList();
        }

        public List<Cliente> ObtenerTodos()
        {
            return _dbContext.Clientes.ToList();
        }
    }
}
