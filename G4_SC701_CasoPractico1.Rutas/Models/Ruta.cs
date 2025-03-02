using System;
using System.ComponentModel.DataAnnotations;

namespace G4_SC701_CasoPractico1.Rutas.Models
{
    public enum EstadoRuta
    {
        Activo,
        Inactivo
    }

    public class Ruta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El código de la ruta es obligatorio.")]
        [Display(Name = "Código de la ruta")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre de la ruta es obligatorio.")]
        [Display(Name = "Nombre de la ruta")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Paradas (separadas por comas)")]
        public string Paradas { get; set; }

        [Display(Name = "Horarios (separados por comas)")]
        public string Horarios { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Display(Name = "Estado")]
        public EstadoRuta Estado { get; set; }

        // Se asigna la fecha de registro en el controlador.
        public DateTime FechaRegistro { get; set; }

        // Nueva llave foránea para referenciar el usuario que registra la ruta.
        [Display(Name = "Usuario que registra")]
        public int UsuarioRegistroId { get; set; }

        // Propiedad de navegación para obtener los datos del usuario que registró la ruta.
        // Razón: Permite establecer la relación y navegar hacia el usuario responsable del registro.
        public Usuario UsuarioRegistro { get; set; }
    }
}
