using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.modelo
{

    // Clase Empleado
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpleado { get; private set; }
        public required string Nombre { get; set; }
        public string Apellido { get; set; } = string.Empty;
        public required string UserName { get; set; }
        public required string Contraseña { get; set; }
        public required TipoEmpleado Categoria { get; set; }

        // Constructor vacío requerido por Entity Framework Core
        public Empleado() { }

        // Constructor con parametros
        public Empleado(string nombre, string apellido, string userName, string contraseña, TipoEmpleado categoria)
        {
            UserName = userName;
            Nombre = nombre;
            Apellido = apellido;
            Contraseña = contraseña;
            Categoria = categoria;
        }

        // Método ToString 
        public override string ToString()
        {
            return $"Empleado [IdEmpleado={IdEmpleado}, Nombre={Nombre}, Apellido={Apellido}, UserName={UserName}, Codigo={Contraseña}, Categoria={Categoria}]";
        }
    }
}
