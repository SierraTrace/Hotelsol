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
        bool ExisteDni(string dni);
        void Agregar(Cliente cliente);
        void Modificar(Cliente cliente);
        Cliente? ObtenerPorId(int id);
        Cliente? BuscarPorDni(string dni);
        List<object> ObtenerTodosParaTabla();
        List<Cliente> ObtenerTodos();
    }
}
