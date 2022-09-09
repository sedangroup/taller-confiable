using System.ComponentModel.DataAnnotations;

namespace proyecto_taller_alto_nivel.Models
{
    public class VehiculoModel
    {
        public int id_Vehiculo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int id_Propietario { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Licencia { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Tipo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Modelo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Capacidad { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Desplazamiento { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? PaisOrigen { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? Descripcion { get; set; }
    }
}

