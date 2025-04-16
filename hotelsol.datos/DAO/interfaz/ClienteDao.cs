using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.datos.DAO.interfaz
{
    public interface ClienteDao
    {
        List<Cliente> ObtenerTodos();
        Cliente ObtenerPorId(int id);
        Cliente BuscarPorDni(string dni);
        void Agregar(Cliente cliente);
        void Modificar(Cliente cliente);
        void Eliminar(int id);
    }
}
