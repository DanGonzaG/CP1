namespace G4_SC701_CasoPractico1.Rutas.Models
{
    public class Horarios
    {
        public int Id { get; set; }
        public TimeOnly Horario { get; set; }

        public int RutaId { get; set; }

        public Ruta? ruta { get; set; }

    }
}
