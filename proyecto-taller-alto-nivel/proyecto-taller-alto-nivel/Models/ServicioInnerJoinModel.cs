namespace proyecto_taller_alto_nivel.Models
{
    public class ServicioInnerJoinModel
    {
        public int Id_Servicio { get; set; }
        public string Propietario { get; set; }
        public string Mecanico { get; set; }
        public string VehiculoMarca { get; set; }
        public string VehiculoModelo { get; set; }
        public string? NivelAceite { get; set; }
        public string? NivelLiquidoFrenos { get; set; }
        public string? NivelRefrigerante { get; set; }
        public string? NivelLiquidoDireccion { get; set; }
        public string NumeroPoliza { get; set; }
        public string Fecha { set; get; }
        public string Hora { set; get; }

    }
}
