using System.ComponentModel.DataAnnotations;

namespace proyecto_taller_alto_nivel.Models
{
    public class VehiculoModel
    {
        public int Id_Vehicle { get; set; }
        public int Id_Owner { get; set; }
        public string? License { get; set; }
        public string? Tipo { get; set; }
        public string? Brand { get; set; }
        public string? Modelo { get; set; }
        public string? Capacity { get; set; }
        public string? Displacement { get; set; }
        public string? OriginCountry { get; set; }
        public string? Description { get; set; }
    }
}

