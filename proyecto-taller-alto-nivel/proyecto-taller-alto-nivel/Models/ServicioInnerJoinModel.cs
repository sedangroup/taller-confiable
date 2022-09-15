namespace proyecto_taller_alto_nivel.Models
{
    public class ServicioInnerJoinModel
    {
        public int Id_Servicio { get; set; }
        public string? Propietario { get; set; }
        public string? Mecanico { get; set; }
        public string? Vehiculo { get; set; }
        public string? Licencia { get; set; }    
        public string? NivelAceite { get; set; }
        public string? NivelLiquidoDireccion { get; set; }
        public string? NivelLiquidoFrenos { get; set; }
        public string? NivelRefrigerante { get; set; }
        public string? SoatPoliza { get; set; }
        public string? Fecha { set; get; }
        public string? Hora { set; get; }

    }
}
