using Microsoft.EntityFrameworkCore;

namespace HotelSol.hotelsol.modelo
{
    public class HotelSolDbContext : DbContext
    {
        public HotelSolDbContext(DbContextOptions<HotelSolDbContext> options) : base(options) { }

        // DbSets (Tablas)
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<PrecioNoche> PreciosNoche { get; set; }
        public DbSet<TipoHabitacion> TiposHabitacion { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<PrecioAlojamiento> PrecioAlojamiento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // EMPLEADO
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.Property(e => e.IdEmpleado).ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(30);
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(15);
                entity.Property(e => e.Contraseña).IsRequired().HasMaxLength(15);
                entity.HasIndex(e => e.UserName).IsUnique();

                entity.Property(e => e.Contraseña).IsRequired();

                entity.Property(e => e.Categoria)
                      .HasConversion<string>()
                      .IsRequired();
            });

            // CLIENTE
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes");
                entity.HasKey(c => c.IdCliente);
                entity.Property(c => c.Nombre).IsRequired().HasMaxLength(30);
                entity.Property(c => c.Apellido).IsRequired().HasMaxLength(30);
                entity.Property(c => c.Dni).IsRequired().HasMaxLength(15);
                entity.Property(c => c.Email).IsRequired().HasMaxLength(30);
                entity.Property(c => c.Telefono).IsRequired().HasMaxLength(13);
                entity.Property(c => c.TipoCliente).HasConversion<string>().IsRequired();

                entity.HasMany(c => c.Facturas)
                      .WithOne(f => f.Cliente)
                      .HasForeignKey(f => f.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // FACTURA
            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(f => f.IdFactura);

                entity.Property(f => f.Fecha)
                      .IsRequired();

                entity.Property(f => f.PrecioFactura)
                      .HasColumnType("decimal(10,2)")
                      .IsRequired();

                entity.HasOne(f => f.Cliente)
                      .WithMany(c => c.Facturas)
                      .HasForeignKey(f => f.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(f => f.ListaReservas)
                      .WithOne() 
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(f => f.ListaServicios)
                      .WithOne() 
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasKey(f => f.IdFactura);
                entity.Property(f => f.Fecha).IsRequired();
                entity.HasOne(f => f.Cliente)
                      .WithMany(c => c.Facturas)
                      .HasForeignKey(f => f.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // PRECIO_NOCHE
            modelBuilder.Entity<PrecioNoche>(entity =>
            {
                entity.ToTable("PreciosNoche");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Precio).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(p => p.Temporada).HasConversion<string>().IsRequired();

                entity.HasOne(p => p.Habitacion)
                      .WithMany(h => h.PreciosPorTemporada)
                      .HasForeignKey(p => p.HabitacionId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // TIPO_HABITACION
            modelBuilder.Entity<TipoHabitacion>(entity =>
            {
                entity.ToTable("TiposHabitacion");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Nombre).IsRequired().HasMaxLength(15);
                entity.HasMany(t => t.Habitaciones)
                      .WithOne(h => h.TipoHabitacion)
                      .HasForeignKey(h => h.TipoHabitacionId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // HABITACION
            modelBuilder.Entity<Habitacion>(entity =>
            {
                entity.ToTable("Habitaciones");
                entity.HasKey(h => h.Numero);
                entity.Property(h => h.Estado).HasConversion<string>().IsRequired();

                entity.HasOne(h => h.TipoHabitacion)
                      .WithMany(t => t.Habitaciones)
                      .HasForeignKey(h => h.TipoHabitacionId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // SERVICIO
            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.ToTable("Servicios");
                entity.HasKey(s => s.IdServicio);
                entity.Property(s => s.Concepto).HasMaxLength(50).IsRequired();
                entity.Property(s => s.Precio).HasColumnType("decimal(18,2)").IsRequired();

                entity.HasOne(s => s.Cliente)
                      .WithMany(c => c.Servicios)
                      .HasForeignKey(s => s.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // PRECIO_ALOJAMIENTO
            modelBuilder.Entity<PrecioAlojamiento>(entity =>
            {
                entity.HasKey(pa => pa.Id);
                entity.HasOne(pa => pa.TipoHabitacion)
                      .WithMany()
                      .HasForeignKey(pa => pa.TipoHabitacionId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(pa => pa.TipoAlojamiento).HasConversion<string>().IsRequired();
                entity.Property(pa => pa.Precio).HasColumnType("decimal(10,2)").IsRequired();
                entity.Property(pa => pa.TipoHabitacionId).IsRequired();
            });

            // RESERVA
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("Reservas");
                entity.HasKey(r => r.IdReserva);

                entity.HasOne(r => r.Cliente)
                      .WithMany(c => c.Reservas)
                      .HasForeignKey(r => r.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r => r.Habitacion)
                      .WithMany(h => h.Reservas)
                      .HasForeignKey(r => r.HabitacionId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(r => r.Estado).HasConversion<string>().IsRequired();
                entity.Property(r => r.TipoAlojamiento).HasConversion<string>().IsRequired();
                entity.Property(r => r.Temporada).HasConversion<string>().IsRequired();
                entity.Property(r => r.FechaLlegada).IsRequired();
                entity.Property(r => r.FechaSalida).IsRequired();
                entity.Property(r => r.PrecioEstanciaGuardado).HasColumnType("decimal(10,2)");
                entity.Property(r => r.PrecioAlojamientoGuardado).HasColumnType("decimal(10,2)");
                entity.Property(r => r.PrecioReservaGuardado).HasColumnType("decimal(10,2)");
            });
        }
    }
}
