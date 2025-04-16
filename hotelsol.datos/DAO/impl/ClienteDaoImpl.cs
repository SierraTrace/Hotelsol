using HotelSol.hotelsol.datos.DAO.interfaz;
using HotelSol.hotelsol.modelo;


namespace HotelSol.hotelsol.datos.DAO.impl
{
    public class ClienteDaoImpl : ClienteDao
    {
        private readonly HotelSolDbContext _context;

        public ClienteDaoImpl(HotelSolDbContext context)
        {
            _context = context;
        }

        public List<Cliente> ObtenerTodos()
        {
            return _context.Clientes.ToList();
        }

        public Cliente ObtenerPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public Cliente BuscarPorDni(string dni)
        {
            return _context.Clientes.FirstOrDefault(c => c.Dni == dni);
        }

        public void Agregar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Modificar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
