using proyecto_taller_alto_nivel.Models;
using System.Data.SqlClient;
using System.Data;

namespace proyecto_taller_alto_nivel.Data
{
    public class AuxiliarDatos
    {
        public List<AuxiliarModel> Listar()
        {
            var oLista = new List<AuxiliarModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAuxiliar", conexion);///cambiar nombre procedimiento para auxiliar
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new AuxiliarModel()
                        {
                            id_Persona = Convert.ToInt32(dr["id_Persona"]),
                            Identificacion = dr["Identificacion"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Nacimiento = dr["Nacimiento"].ToString(),
                            Telefono = dr["Telefono"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        public AuxiliarModel Obtener(int id_Persona)
        {
            var oAuxiliar = new AuxiliarModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerAuxiliar", conexion);          ///cambiar nombre procedimiento para auxiliar
                cmd.Parameters.AddWithValue("id_Persona", id_Persona);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oAuxiliar.id_Persona = Convert.ToInt32(dr["id_Persona"]);
                        oAuxiliar.Identificacion = dr["Identificacion"].ToString();
                        oAuxiliar.Nombre = dr["Nombre"].ToString();
                        oAuxiliar.Apellido = dr["Apellido"].ToString();
                        oAuxiliar.Nacimiento = dr["Nacimiento"].ToString();
                        oAuxiliar.Telefono = dr["Telefono"].ToString();
                    }
                }
            }
            return oAuxiliar;
        }
        public bool Guardar(AuxiliarModel oAuxiliar)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarAuxiliar", conexion);         ///cambiar nombre procedimiento para auxiliar
                    cmd.Parameters.AddWithValue("Identificacion", oAuxiliar.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", oAuxiliar.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oAuxiliar.Apellido);
                    cmd.Parameters.AddWithValue("Nacimiento", oAuxiliar.Nacimiento);
                    cmd.Parameters.AddWithValue("Telefono", oAuxiliar.Telefono);
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
        public bool Editar(AuxiliarModel oAuxiliar)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarAuxiliar", conexion);           ///cambiar nombre procedimiento para auxiliar
                    cmd.Parameters.AddWithValue("id_Persona", oAuxiliar.id_Persona);
                    cmd.Parameters.AddWithValue("Identificacion", oAuxiliar.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", oAuxiliar.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oAuxiliar.Apellido);
                    cmd.Parameters.AddWithValue("Nacimiento", oAuxiliar.Nacimiento);
                    cmd.Parameters.AddWithValue("Telefono", oAuxiliar.Telefono);
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
        public bool Eliminar(int id_Persona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarAuxiliar", conexion);         ///cambiar nombre procedimiento para auxiliar
                    cmd.Parameters.AddWithValue("id_Persona", id_Persona);
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
