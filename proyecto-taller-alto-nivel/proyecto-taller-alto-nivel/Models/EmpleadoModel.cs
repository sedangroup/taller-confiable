using System.ComponentModel.DataAnnotations;

namespace proyecto_taller_alto_nivel.Models
{
    public class EmpleadoModel : PersonaModel
    {
        public int Id_Empleado { get; set; }

        public string Phone { get; set; }

    }
}
