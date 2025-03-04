using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace G4_SC701_CasoPractico1.Rutas.Models
{


    public class Ruta
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El espacio es requerido")]
        [DisplayName("Nombre de ruta")]    
        public string NombreRuta { get; set; }
        [DisplayName("Ruta")]
        public bool Estado { get; set; }
        [DisplayName("Fecha de Registro")]

        public DateTime FechaRegistro { get; set; }
        
        public int IdUsuarioRegistro { get; set; }
        [DisplayName("Nombre usuario de registro")]
        public int IdVehiculo { get; set; }

        public Vehiculo? vehiculo { get; set; }
        public Usuario? usuario { get; set; }

        public IEnumerable<Paradas>? paradas { get; set; }
        public IEnumerable<Horarios>? horario { get; set; }
    }
}