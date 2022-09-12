using System.ComponentModel.DataAnnotations;

namespace proyecto_taller_alto_nivel.Models
{
    public class MecanicoModel
    { 
        public int id_Persona { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Identificacion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Nacimiento { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? NivelEducacion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Telefono { get; set; }
    
    }
}
