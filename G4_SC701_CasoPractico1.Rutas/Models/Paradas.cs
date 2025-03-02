namespace G4_SC701_CasoPractico1.Rutas.Models
{
    public class Paradas
    {
        public int Id { get; set; }
        public required string Descripcion { get; set; }
        public required Ruta ruta { get; set; }
    }
}
