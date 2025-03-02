using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace G4_SC701_CasoPractico1.Rutas.Models
{
    public class CP1Context : DbContext
    {
        public CP1Context(DbContextOptions<CP1Context> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Ruta> Rutas { get; set; }  // Agregado para gestionar la entidad Ruta

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la entidad Usuario
            modelBuilder.Entity<Usuario>(usuario =>
            {
                usuario.HasKey(u => u.Id);
                usuario.Property(u => u.NombreUsuario)
                    .HasMaxLength(50)
                    .IsRequired()
                    .HasColumnName("Usuario");
                usuario.Property(u => u.NombreCompleto)
                    .HasMaxLength(100)
                    .IsRequired()
                    .IsUnicode(true);
                usuario.Property(u => u.CorreoElectronico)
                    .HasMaxLength(100)
                    .IsRequired();
            });

            // Configuración de la entidad Rol
            modelBuilder.Entity<Rol>(rol =>
            {
                rol.HasKey(r => r.Id);
                rol.Property(r => r.Nombre)
                    .HasMaxLength(50)
                    .IsRequired();
            });

            // Relación uno a muchos entre Rol y Usuario
            modelBuilder.Entity<Rol>()
                        .HasMany<Usuario>(r => r.Usuarios)
                        .WithOne(u => u.Rol)
                        .HasForeignKey(u => u.RolId)
                        .HasConstraintName("FK_Usuario_Rol")
                        .OnDelete(DeleteBehavior.Cascade);

            // Configuración de la entidad Vehiculo
            modelBuilder.Entity<Vehiculo>(vehiculo =>
            {
                vehiculo.HasKey(v => v.Id);
                vehiculo.Property(v => v.Placa)
                    .IsRequired()
                    .HasMaxLength(6);
                vehiculo.Property(v => v.Modelo)
                    .HasMaxLength(200)
                    .IsRequired();
                vehiculo.Property(v => v.CapacidadPasajeros)
                    .IsRequired();
                vehiculo.Property(v => v.Estado)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            // Configuración de la relación entre Usuario y Vehiculo para evitar eliminación en cascada
            modelBuilder.Entity<Usuario>()
                        .HasMany(u => u.Vehiculos)
                        .WithOne(v => v.usuario)
                        .HasForeignKey(v => v.idUsuario)
                        .HasConstraintName("FK_Usuario_Vehiculo")
                        .OnDelete(DeleteBehavior.Restrict);

            // Configuración para la entidad Ruta
            modelBuilder.Entity<Ruta>(ruta =>
            {
                ruta.HasKey(r => r.Id);
                ruta.Property(r => r.Codigo)
                    .IsRequired();
                ruta.Property(r => r.Nombre)
                    .IsRequired();
                // Se definen longitudes máximas para las propiedades de texto
                ruta.Property(r => r.Paradas)
                    .HasMaxLength(500);
                ruta.Property(r => r.Horarios)
                    .HasMaxLength(200);

                // Configuración de la relación con el usuario que registra la ruta.
                // Se asume que en el modelo Usuario se agregó la colección "RutasRegistradas".
                ruta.HasOne(r => r.UsuarioRegistro)
                    .WithMany(u => u.RutasRegistradas)
                    .HasForeignKey(r => r.UsuarioRegistroId)
                    .HasConstraintName("FK_Ruta_UsuarioRegistro")
                    .OnDelete(DeleteBehavior.Restrict);
                // Razón: Se establece la relación mediante la FK para mantener la integridad referencial, evitando eliminar en cascada.
            });
        }
    }
}
