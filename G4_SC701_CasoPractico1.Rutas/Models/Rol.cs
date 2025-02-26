namespace G4_SC701_CasoPractico1.Rutas.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public IEnumerable<Usuario>? Usuarios { get; set; }

    }
}
