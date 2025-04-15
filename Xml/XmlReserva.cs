using System.Xml.Linq;
using HotelSol.hotelsol.modelo;
using System.Collections.Generic;
using System.Linq;

public class XmlReservaHelper
{
    public static void GuardarReservasEnXml(List<Reserva> reservas, string ruta)
    {
        var doc = new XDocument(
            new XElement("Reservas",
                reservas.Select(r =>
                    new XElement("Reserva",
                        new XElement("IdReserva", r.IdReserva),
                        new XElement("ClienteNombre", r.Cliente?.Nombre ?? "SinNombre"),
                        new XElement("ClienteApellido", r.Cliente?.Apellido ?? "SinApellido"),
                        new XElement("HabitacionNumero", r.Habitacion?.Numero.ToString() ?? "SinHabitación"),
                        new XElement("FechaLlegada", r.FechaLlegada.ToString("yyyy-MM-dd")),
                        new XElement("FechaSalida", r.FechaSalida.ToString("yyyy-MM-dd")),
                        new XElement("TipoAlojamiento", r.TipoAlojamiento.ToString()),
                        new XElement("Temporada", r.Temporada.ToString()),
                        new XElement("PrecioEstancia", r.PrecioEstanciaGuardado),
                        new XElement("PrecioAlojamiento", r.PrecioAlojamientoGuardado),
                        new XElement("PrecioTotal", r.PrecioReservaGuardado)
                    )
                )
            )
        );

        doc.Save(ruta);
    }
}