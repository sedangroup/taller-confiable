
using System.ComponentModel.DataAnnotations;
namespace proyecto_taller_alto_nivel.Models
{
    public class RepuestosModel
    {
        public int Id_parts { get; set; }
      
        public int Id_service { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Tipo { get; set; }

    }
}
