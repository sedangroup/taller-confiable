using System.ComponentModel.DataAnnotations;
namespace proyecto_taller_alto_nivel.Models
{
    public class SoatModel
    {
        public int id_Soat { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int id_Vehiculo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int id_Propietario { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? FechaInicio { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? FechaFin { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? NumeroPoliza { get; set; }
    }
}
