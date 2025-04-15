using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TipoHabitacion
{
    [Key]
    public int Id { get; set; }

    public required string Nombre { get; set; }

    public List<Habitacion> Habitaciones { get; set; } = new();

    public override string ToString()
    {
        return $"Tipo: {Nombre} (ID: {Id})";
    }
}
