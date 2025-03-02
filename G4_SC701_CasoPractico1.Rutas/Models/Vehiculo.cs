using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace G4_SC701_CasoPractico1.Rutas.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }

        [Required]
        [MinLength(6)]
        public string Placa { get; set; }


        [Required]
        [MaxLength(200)]
        public string Modelo { get; set; }

        [Required]
        [DisplayName("Cantidad de pasajeros")]
        public int CapacidadPasajeros { get; set; }

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; }

        
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required]
        [DisplayName("Nombre de usuario")]
        public int idUsuario { get; set; }

        //join
        public Usuario usuario { get; set; }
    }
}
