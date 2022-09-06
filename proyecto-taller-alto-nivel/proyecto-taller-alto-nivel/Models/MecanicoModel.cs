namespace proyecto_taller_alto_nivel.Models
{
    public class MecanicoModel : EmpleadoModel
    {
        public int Id_mechanic { get; set; }
        public string Direccion { get; set; }
        public string Nivel_educacion { get; set; }
    }
}
