using G4_SC701_CasoPractico1.Rutas.Models;
using Microsoft.EntityFrameworkCore;

namespace G4_SC701_CasoPractico1.api.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context>options):base(options) { }

        
        public DbSet<Vehiculo> Rutas { get; set; }
    }
}
