using HotelSolLimpio.hotelsol.modelo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSol.hotelsol.modelo
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReserva { get; set; }

        public EstadoReserva Estado { get; set; }

        public int ClienteId { get; set; }
        public required Cliente Cliente { get; set; }

        public int HabitacionId { get; set; }
        public required Habitacion Habitacion { get; set; }

        public DateTime FechaLlegada { get; set; }
        public DateTime FechaSalida { get; set; }

        public required TipoAlojamiento TipoAlojamiento { get; set; }
        public Temporada Temporada { get; set; }

        [NotMapped]
        public List<PrecioNoche> PreciosNoche { get; set; } = new();

        [NotMapped]
        public List<PrecioAlojamiento> PreciosAlojamiento { get; set; } = new();

        // Precio guardado para facturación
        public decimal PrecioEstanciaGuardado { get; set; }
        public decimal PrecioAlojamientoGuardado { get; set; }
        public decimal PrecioReservaGuardado { get; set; }

        // 🔹 Método: Calcula el precio por noche según temporada
        public decimal CalcularPrecioEstancia(HotelSolDbContext db)
        {
            decimal total = 0m;

            for (DateTime dia = FechaLlegada; dia < FechaSalida; dia = dia.AddDays(1))
            {
                Temporada temporadaDia = TemporadaDia.CalcularTemporadaPorDia(dia, db);

                decimal precioPorNoche = PreciosNoche
                    .FirstOrDefault(p => p.Temporada == temporadaDia)?.Precio ?? 0m;

                total += precioPorNoche;
            }

            return total;
        }

        // 🔹 Método: Calcula el precio de alojamiento por tipo * noches
        public decimal CalcularPrecioAlojamiento()
        {
            int noches = (FechaSalida - FechaLlegada).Days;

            decimal precioPorDia = PreciosAlojamiento
                .Where(p => p.TipoHabitacion.Id == Habitacion.TipoHabitacion.Id &&
                            p.TipoAlojamiento == TipoAlojamiento)
                .Select(p => p.Precio)
                .FirstOrDefault();

            return precioPorDia * noches;
        }

        // 🔹 Método: Calcula el precio total (estancia + alojamiento)
        public decimal CalcularPrecioReserva(HotelSolDbContext db)
        {
            return CalcularPrecioEstancia(db) + PrecioAlojamiento;
        }

        // 🔹 Propiedad de solo lectura (cálculo del alojamiento)
        public decimal PrecioAlojamiento
        {
            get
            {
                int noches = (FechaSalida - FechaLlegada).Days;

                decimal precioPorDia = PreciosAlojamiento
                    .Where(p => p.TipoHabitacion.Id == Habitacion.TipoHabitacion.Id &&
                                p.TipoAlojamiento == TipoAlojamiento)
                    .Select(p => p.Precio)
                    .FirstOrDefault();

                return precioPorDia * noches;
            }
        }

        // 🔹 Método: Guarda todos los precios pre-calculados
        public void GuardarPrecios(HotelSolDbContext db)
        {
            PrecioEstanciaGuardado = CalcularPrecioEstancia(db);
            PrecioAlojamientoGuardado = CalcularPrecioAlojamiento();
            PrecioReservaGuardado = PrecioEstanciaGuardado + PrecioAlojamientoGuardado;
        }

        // 🔹 Método: Muestra resumen en texto (para depuración o mostrar en consola)
        public override string ToString()
        {
            return $"Reserva [ID={IdReserva}, Cliente={Cliente.Nombre} {Cliente.Apellido}, " +
                   $"Habitación={Habitacion.Numero}, Fecha: {FechaLlegada:dd/MM/yyyy} - {FechaSalida:dd/MM/yyyy}, " +
                   $"Tipo Alojamiento={TipoAlojamiento}, Temporada Base={Temporada}, " +
                   $"Precio Estancia={PrecioEstanciaGuardado:C}, " +
                   $"Precio Alojamiento={PrecioAlojamientoGuardado:C}, " +
                   $"Total Reserva={PrecioReservaGuardado:C}]";
        }
    }
}
