using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSol.hotelsol.modelo
{
    public class Servicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdServicio { get; private set; }

        public required string Concepto { get; set; }
        public required decimal Precio { get; set; }

        // Relación con Cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public Servicio() { }

        public Servicio(string concepto, decimal precio, Cliente cliente)
        {
            Concepto = concepto;
            Precio = precio;
            Cliente = cliente;
            ClienteId = cliente.IdCliente;
        }

        public override string ToString()
        {
            return $"Servicio [IdServicio={IdServicio}, Concepto={Concepto}, Precio={Precio:C}, Cliente ID={ClienteId}]";
        }
    }
}