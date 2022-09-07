using proyecto_taller_alto_nivel.Models;
using System.Data.SqlClient;
using System.Data;

namespace proyecto_taller_alto_nivel.Data
{
    public class VehiculoDatos
    {
        public bool Guardar(VehiculoModel vehiculo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("Id_Propietario", vehiculo.Id_Propietario);
                    cmd.Parameters.AddWithValue("Liciencia", vehiculo.Liciencia);
                    cmd.Parameters.AddWithValue("Tipo", vehiculo.Tipo);
                    cmd.Parameters.AddWithValue("Marca", vehiculo.Marca);
                    cmd.Parameters.AddWithValue("Modelo", vehiculo.Modelo);
                    cmd.Parameters.AddWithValue("Capacidad", vehiculo.Capacidad);
                    cmd.Parameters.AddWithValue("Desplazamiento", vehiculo.Desplazamiento);
                    cmd.Parameters.AddWithValue("PaisOrigen", vehiculo.PaisOrigen);
                    cmd.Parameters.AddWithValue("Descripcion", vehiculo.Descripcion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
