using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G4_SC701_CasoPractico1.Rutas.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El usuario es requerido")]
        [DisplayName("Nombre de Usuario")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        [DisplayName("Nombre Completo")]
        public string NombreCompleto { get; set; }
        [Required(ErrorMessage = "El Correo de usuario es requerido")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Correo Electronico")]
        public string CorreoElectronico { get; set; }
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "El formato de telefono debe ser ####-####")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "La Contraseña es un valor requerido")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
        [DisplayName("Rol")]
        public int? RolId { get; set; }
        public Rol? Rol { get; set; }

        public ICollection<Vehiculo>? Vehiculos { get; set; }

        public int? idVehiculo { get; set; }


    }
}
