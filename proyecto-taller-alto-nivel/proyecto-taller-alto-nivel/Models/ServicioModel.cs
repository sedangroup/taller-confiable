namespace proyecto_taller_alto_nivel.Models
{
    public class ServicioModel
    {
        public int Id_Servicio { get; set; }
        public int Id_Propietario { get; set; }
        public int Id_mecanico { get; set; }
        public int Id_Revision { get; set; }
        public int Id_Soat { get; set; }
        public string? Fecha { get; set; }
        public string? Hora { get; set; }

    }
}
