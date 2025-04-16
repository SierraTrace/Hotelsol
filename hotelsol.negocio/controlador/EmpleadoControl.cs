using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.negocio.controlador
{
    public class EmpleadoControl
    {
        private readonly HotelSolDbContext _dbContext;

        public EmpleadoControl(HotelSolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ExisteUserName(string userName)
        {
            return _dbContext.Empleados.Any(e => e.UserName == userName);
        }

        public void Agregar(Empleado empleado)
        {
            _dbContext.Empleados.Add(empleado);
            _dbContext.SaveChanges();
        }

        public List<object> ObtenerTodosParaTabla()
        {
            return _dbContext.Empleados
                .Select(e => new
                {
                    e.IdEmpleado,
                    e.Nombre,
                    e.Apellido,
                    e.UserName,
                    Categoria = e.Categoria.ToString()
                })
                .Cast<object>()
                .ToList();
        }
    }
}
