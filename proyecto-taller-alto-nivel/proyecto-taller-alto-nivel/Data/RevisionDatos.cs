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
                    cmd.Parameters.AddWithValue("id_Servicio", oMecanico.id_Servicio);
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

        public List<RevisionModel> Listar()
        {
            var oLista = new List<RevisionModel>();

            var cn = new Conexion();

            var sql = "select  NivelAceite,NivelLiquidoDireccion,NivelLiquidoFrenos,NivelRefrigerante from Tbl_Revision as re LEFT JOIN Tbl_Servicio as ser on ser.id_Revision = re.id_Revision";

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);


                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new RevisionModel()
                        {
                            NivelAceite = dr["NivelAceite"].ToString(),
                            NivelLiquidoDireccion = dr["NivelLiquidoDireccion"].ToString(),
                            NivelLiquidoFrenos = dr["NivelLiquidoFrenos"].ToString(),
                            NivelRefrigerante = dr["NivelRefrigerante"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }
    }
}
