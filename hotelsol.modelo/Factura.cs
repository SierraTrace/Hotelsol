using HotelSol.hotelsol.modelo;
using HotelSolLimpio.hotelsol.modelo;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Factura
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdFactura { get; set; }

    public DateTime Fecha { get; set; }

    public int ClienteId { get; set; }
    public required Cliente Cliente { get; set; }

    public List<Reserva> ListaReservas { get; set; } = new();
    public List<Servicio> ListaServicios { get; set; } = new();
    public decimal PrecioFactura { get; set; }

    // 🔸 Estas propiedades son auxiliares de cálculo (no se guardan)
    [NotMapped]
    public decimal Descuento =>
        Cliente != null ? DescuentoCliente.ObtenerDescuento(Cliente.TipoCliente) : 0m;

    [NotMapped]
    public decimal PrecioTotal =>
        (ListaReservas?.Sum(r => r.PrecioReservaGuardado) ?? 0m) +
        (ListaServicios?.Sum(s => s.Precio) ?? 0m);

    // 🔸 Constructor
    public Factura() { }

    public Factura(Cliente cliente, List<Reserva> reservas, List<Servicio> listaServicios)
    {
        Fecha = DateTime.Now;
        Cliente = cliente;
        ClienteId = cliente.IdCliente;
        ListaReservas = reservas ?? new();
        ListaServicios = listaServicios ?? new();
    }


    public void CalcularPrecioFactura()
    {
        PrecioFactura = PrecioTotal * (1 - Descuento);
    }

    public override string ToString()
    {
        string serviciosInfo = ListaServicios.Count > 0
            ? string.Join(", ", ListaServicios.Select(s => $"{s.Concepto} ({s.Precio:C})"))
            : "Sin servicios adicionales";

        string reservasInfo = ListaReservas.Count > 0
            ? string.Join(", ", ListaReservas.Select(r => $"#{r.IdReserva}"))
            : "Sin reservas asociadas";

        return $"Factura [ID={IdFactura}, Fecha={Fecha:dd/MM/yyyy}, Cliente={Cliente.Nombre} {Cliente.Apellido}, " +
               $"Reservas=[{reservasInfo}], Total={PrecioTotal:C}, " +
               $"Descuento={Descuento:P}, Precio Final={PrecioFactura:C}, Servicios=[{serviciosInfo}]]";
    }
}