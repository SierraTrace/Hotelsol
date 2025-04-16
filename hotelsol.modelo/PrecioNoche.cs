using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSol.hotelsol.modelo
{
    public class PrecioNoche
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // FK y navegación
        public int HabitacionId { get; set; }
        public Habitacion? Habitacion { get; set; }

        public required Temporada Temporada { get; set; }

        public required decimal Precio { get; set; }

        public PrecioNoche() { }

        public PrecioNoche(Habitacion habitacion, Temporada temporada, decimal precio)
        {
            Habitacion = habitacion;
            HabitacionId = habitacion.Numero;
            Temporada = temporada;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"PrecioNoche [Id={Id}, HabitacionId={HabitacionId}, Temporada={Temporada}, Precio={Precio:C}]";
        }
    }
}

