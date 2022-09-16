using proyecto_taller_alto_nivel.Models;
using System.Data.SqlClient;
using System.Data;
using proyecto_taller_alto_nivel.Data;
using System.Reflection;

namespace proyecto_taller_alto_nivel.Data
{
    public class SoatDatos
    {
        public List<SoatModel> Listar()
        {
            var oLista = new List<SoatModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarSoat", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new SoatModel()
                        {
                            
                            id_Vehiculo = Convert.ToInt32(dr["id_Vehiculo"]),
                            id_Propietario = Convert.ToInt32(dr["id_Propietario"]),
                            
                            FechaInicio = dr["FechaInicio"].ToString(),
                            FechaFin = dr["FechaFin"].ToString(),
                            NumeroPoliza = dr["NumeroPoliza"].ToString(),
                            
                        });
                    }
                }
            }
            return oLista;
        }

      

        public SoatModel Obtener(int id_Soat)
        {
            var oSoat = new SoatModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerSoat", conexion);
                cmd.Parameters.AddWithValue("id_Soat", id_Soat);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oSoat.Licencia = dr["Licencia"].ToString();                     
                        oSoat.FechaInicio= dr["FechaInicio"].ToString();
                        oSoat.FechaFin = dr["FechaFin"].ToString();
                        oSoat.NumeroPoliza = dr["NumeroPoliza"].ToString();                        
                    }
                }
            }
            return oSoat;
        }


        public bool Guardar(SoatModel oSoat)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarSoat", conexion);
                    cmd.Parameters.AddWithValue("id_Vehiculo", oSoat.id_Propietario);
                    cmd.Parameters.AddWithValue("id_propietario", oSoat.id_Propietario);
                    cmd.Parameters.AddWithValue("Licencia", oSoat.Licencia);
                    cmd.Parameters.AddWithValue("FechaInicio", oSoat.FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFin", oSoat.FechaFin);
                    cmd.Parameters.AddWithValue("NumeroPoliza", oSoat.NumeroPoliza);                                      
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

        public bool Editar(SoatModel oSoat)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarSoat", conexion);
                    cmd.Parameters.AddWithValue("id_Vehiculo", oSoat.id_Vehiculo);
                    cmd.Parameters.AddWithValue("id_Propietario", oSoat.id_Propietario);
                    cmd.Parameters.AddWithValue("Licencia", oSoat.Licencia);
                    cmd.Parameters.AddWithValue("FechaInicio", oSoat.FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFin", oSoat.FechaFin);
                    cmd.Parameters.AddWithValue("NumeroPoliza", oSoat.NumeroPoliza);                                    
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

        public bool Eliminar(int id_Soat)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarSoat", conexion);
                    cmd.Parameters.AddWithValue("id_Soat", id_Soat);
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
