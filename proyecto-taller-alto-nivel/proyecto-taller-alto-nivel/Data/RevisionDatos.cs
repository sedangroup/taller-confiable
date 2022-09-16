using proyecto_taller_alto_nivel.Models;
using System.Data.SqlClient;
using System.Data;

namespace proyecto_taller_alto_nivel.Data
{
    public class RevisionDatos
    {
        public bool Guardar(RevisionModel oMecanico)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarRevision", conexion);
                    cmd.Parameters.AddWithValue("id_Servicio",oMecanico.id_Servicio);
                    cmd.Parameters.AddWithValue("NivelAceite", oMecanico.NivelAceite);
                    cmd.Parameters.AddWithValue("NivelLiquidoFrenos", oMecanico.NivelLiquidoFrenos);
                    cmd.Parameters.AddWithValue("NivelRefrigerante", oMecanico.NivelRefrigerante);
                    cmd.Parameters.AddWithValue("NivelLiquidoDireccion", oMecanico.NivelLiquidoDireccion);
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
