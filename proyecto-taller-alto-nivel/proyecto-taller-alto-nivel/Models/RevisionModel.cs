using System.ComponentModel.DataAnnotations;

namespace proyecto_taller_alto_nivel.Models
{
    public class RevisionModel
    {
        public int id_Revision { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int id_Servicio { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? NivelAceite { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? NivelLiquidoFrenos { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? NivelRefrigerante { get; set; }
        public string? NivelLiquidoDireccion { get; set; }
    }
}
