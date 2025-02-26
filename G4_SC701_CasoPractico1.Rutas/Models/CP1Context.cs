using Microsoft.EntityFrameworkCore;

namespace G4_SC701_CasoPractico1.Rutas.Models
{
    public class CP1Context : DbContext
    {
        public CP1Context(DbContextOptions<CP1Context> options) : base(options){ }

        public object Usuario { get; internal set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(Usuario =>
            {
                Usuario.HasKey(u => u.Id);
                Usuario.Property(u => u.NombreUsuario).HasMaxLength(50).IsRequired().HasColumnName("Usuario");
                Usuario.Property(u => u.NombreCompleto).HasMaxLength(100).IsRequired().IsUnicode(true);
                Usuario.Property(u => u.CorreoElectronico).HasMaxLength(100).IsRequired();
            });
            modelBuilder.Entity<Rol>(Rol =>
            {
                Rol.HasKey(r => r.Id);
                Rol.Property(r => r.Nombre).HasMaxLength(50).IsRequired();

            });

            modelBuilder.Entity<Usuario>().HasOne<Rol>(u => u.Rol)
                                          .WithMany(r => r.Usuarios)
                                          .HasForeignKey(u => u.Id)
                                          .HasConstraintName("FK_Usuario_Rol")
                                          .OnDelete(DeleteBehavior.Cascade);
        }
        
    }
}


    
