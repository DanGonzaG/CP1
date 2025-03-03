using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace G4_SC701_CasoPractico1.Rutas.Models
{
    public class Paradas
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public required string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una ruta")]
        public int IdRuta { get; set; }  

        public Ruta? ruta { get; set; }  
    }

}
