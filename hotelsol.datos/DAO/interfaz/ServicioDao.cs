using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.datos.DAO.interfaz
{
    public interface ServicioDao
    {
        List<Cliente> ObtenerClientes();
        Cliente? BuscarClientePorDni(string dni);
        List<object> ObtenerServiciosParaTabla();
        Servicio? ObtenerServicioPorId(int id);
        void AgregarServicio(Servicio servicio);
        void ModificarServicio(Servicio servicio);
    }
}
