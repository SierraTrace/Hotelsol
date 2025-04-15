using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSol.hotelsol.modelo
{
    public class Habitacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Numero { get; set; }

        // Relación con TipoHabitacion
        public int TipoHabitacionId { get; set; }
        public TipoHabitacion TipoHabitacion { get; set; } = null!;

        public EstadoHabitacion Estado { get; set; }

        public List<PrecioNoche> PreciosPorTemporada { get; set; } = new();

        public List<Reserva> Reservas { get; set; } = new();

        public Habitacion() { }

        public Habitacion(int numero, int tipoHabitacionId, EstadoHabitacion estado)
        {
            Numero = numero;
            TipoHabitacionId = tipoHabitacionId;
            Estado = estado;
        }
        public override string ToString()
        {
            string tipoNombre = TipoHabitacion?.Nombre ?? "Sin tipo";
            return $"Habitación Nº{Numero} - Tipo: {tipoNombre} - Estado: {Estado}";
        }
    }
}