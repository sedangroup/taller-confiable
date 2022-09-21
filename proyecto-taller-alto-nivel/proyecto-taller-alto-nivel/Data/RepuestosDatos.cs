using proyecto_taller_alto_nivel.Models;
using System.Data.SqlClient;
using System.Data;

namespace proyecto_taller_alto_nivel.Data
{
    public class RepuestosDatos
    {
        public bool Guardar(RepuestosModel oMecanico)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarRepuestos", conexion);                    
                    cmd.Parameters.AddWithValue("id_Servicio", oMecanico.id_Servicio);                   
                    cmd.Parameters.AddWithValue("Marca", oMecanico.Marca);
                    cmd.Parameters.AddWithValue("Tipo", oMecanico.Tipo);                   
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

        public List<RepuestosModel> Listar()
        {
            var oLista = new List<RepuestosModel>();

            var cn = new Conexion();

            var sql = "select*from Tbl_PiezasRepuesto";

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);


                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new RepuestosModel()
                        {
                            id_Partes = Convert.ToInt32(dr["id_Revision"]),
                            Marca = dr["NivelAceite"].ToString(),
                            Tipo = dr["NivelLiquidoDireccion"].ToString(),
                            
                            
                        });
                    }
                }
            }
            return oLista;
        }

        public RepuestosModel Obtener(int idRepuestos)
        {
            var revision = new RepuestosModel();

            var cn = new Conexion();
            var sql = "SELECT*from Tbl_PiezasRepuesto where id_Partes = @Partes";
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@Partes", idRepuestos);


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        revision.id_Partes = Convert.ToInt32(dr["id_Partes"]);
                        revision.id_Servicio = Convert.ToInt32(dr["id_Servicio"]);
                        revision.Marca = dr["NivelLiquidoFrenos"].ToString();
                        revision.Tipo = dr["NivelRefrigerante"].ToString();
                       
                    }
                }
            }
            return revision;
        }

        public bool Editar(RepuestosModel repuestos)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                var sql = "UPDATE Tbl_PiezasRepuesto set Marca=@Marca , Tipo=@Tipo where id_Partes=@id_Partes";
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@id_Partes", repuestos.id_Partes);
                    cmd.Parameters.AddWithValue("@id_Servicio", repuestos.id_Servicio);
                    cmd.Parameters.AddWithValue("@Tipo", repuestos.Tipo);
                    cmd.Parameters.AddWithValue("@Marca", repuestos.Marca);
                    

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
