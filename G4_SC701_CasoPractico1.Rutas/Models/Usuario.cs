namespace G4_SC701_CasoPractico1.Rutas.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
        
        public Rol Rol { get; set; }
    }
}
