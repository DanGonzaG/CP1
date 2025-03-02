namespace G4_SC701_CasoPractico1.Rutas.Models
{
    public class Boleto
    {
        public int Id { get; set; }
        public int IdRuta { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCompra { get; set; }
        public required Ruta ruta { get; set; }
        public required Usuario usuario { get; set; }
    }
}
