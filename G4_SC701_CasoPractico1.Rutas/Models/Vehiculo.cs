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
        [DisplayName("Fecha de registro")]
        public DateTime FechaRegistro { get; set; }
        [Required]
        
        public int idUsuario { get; set; }
        [DisplayName("Nombre usuario de registro")]
        public required Usuario? usuario { get; set; }
    }
}
