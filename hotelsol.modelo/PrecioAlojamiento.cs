using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSol.hotelsol.modelo
{
    public class PrecioAlojamiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Clave foránea
        public int TipoHabitacionId { get; set; }

        // Propiedad de navegación
        public required TipoHabitacion TipoHabitacion { get; set; }

        // 🔹 FALTA que agregaste:
        public required TipoAlojamiento TipoAlojamiento { get; set; }

        public required decimal Precio { get; set; }

        public PrecioAlojamiento() { }

        public PrecioAlojamiento(TipoHabitacion tipoHabitacion, TipoAlojamiento tipoAlojamiento, decimal precio)
        {
            TipoHabitacion = tipoHabitacion;
            TipoHabitacionId = tipoHabitacion.Id; // Muy importante
            TipoAlojamiento = tipoAlojamiento;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"PrecioAlojamiento [Id={Id}, TipoHabitación={TipoHabitacion.Nombre}, TipoAlojamiento={TipoAlojamiento}, Precio={Precio:C}]";
        }
    }
}