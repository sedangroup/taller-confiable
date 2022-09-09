using System.ComponentModel.DataAnnotations;

namespace proyecto_taller_alto_nivel.Models
{
    public class PropietarioModel
    {
        public int id_Persona { get; set; }
        public string? Identificacion { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Nacimiento { get; set; }
        public string? Ciudad { get; set; }
        public string? Correo { get; set; }

    }
}
