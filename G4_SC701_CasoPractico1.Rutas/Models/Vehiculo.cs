using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace G4_SC701_CasoPractico1.Rutas.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        [Required]
        [MinLength(6)]
        public required string Placa { get; set; }
        [Required]
        [MaxLength(200)]
        public required string Modelo { get; set; }
        [Required]
        [DisplayName("Cantidad de pasajeros")]
        public int CapacidadPasajeros { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        [Required]
        [DisplayName("Nombre de usuario")]
        public int idUsuario { get; set; }
        public required Usuario usuario { get; set; }
    }
}
