
using System.ComponentModel.DataAnnotations;
namespace proyecto_taller_alto_nivel.Models
{
    public class RepuestosModel
    {
        public int id_Partes { get; set; }
      
        public int id_Servicio{ get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Tipo { get; set; }

    }
}
