using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelSolLimpio.hotelsol.modelo;
using System.Net;

namespace HotelSol.hotelsol.modelo
{
    // Clase Cliente
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Dni { get; set; }
        [NotMapped]
        public string DniYNombre => $"{Dni} - {Nombre} {Apellido}";
        public required string Email { get; set; }
        public required string Telefono { get; set; }
        public required TipoCliente TipoCliente { get; set; }

        public List<Factura> Facturas { get; set; } = new List<Factura>();
        public List<Reserva> Reservas { get; set; } = new();
        public List<Servicio> Servicios { get; set; } = new(); // <-- ¡aquí está lo nuevo!

        // Constructor vacío requerido por Entity Framework Core
        public Cliente() { }

        // Constructor con parámetros
        public Cliente(string nombre, string apellido, string dni, string email, string telefono, TipoCliente tipoCliente)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Email = email;
            Telefono = telefono;
            TipoCliente = tipoCliente;
        }

        public override string ToString()
        {
            return $"Cliente [IdCliente={IdCliente}, Nombre={Nombre}, Apellido={Apellido}, DNI={Dni}, " +
                   $"Email={Email}, Telefono={Telefono}, TipoCliente={TipoCliente}, " +
                   $"Descuento={DescuentoCliente.ObtenerDescuento(TipoCliente) * 100}%]";
        }
    }
}

