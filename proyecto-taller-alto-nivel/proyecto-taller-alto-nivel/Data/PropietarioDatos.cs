using proyecto_taller_alto_nivel.Models;
using System.Data.SqlClient;
using System.Data;

namespace proyecto_taller_alto_nivel.Data
{
    public class PropietarioDatos
    {
        public List<PropietarioModel> Listar()
        {
            var oLista = new List<PropietarioModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarPropietario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new PropietarioModel()
                        {
                            id_Persona = Convert.ToInt32(dr["id_Persona"]),
                            Identificacion = dr["Identificacion"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Nacimiento = dr["Nacimiento"].ToString(),
                            Ciudad = dr["Ciudad"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        public PropietarioModel Obtener(int id_Persona)
        {
            var oPropietario= new PropietarioModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerPropietario", conexion);          
                cmd.Parameters.AddWithValue("id_Persona", id_Persona);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oPropietario.id_Persona = Convert.ToInt32(dr["id_Persona"]);
                        oPropietario.Identificacion = dr["Identificacion"].ToString();
                        oPropietario.Nombre = dr["Nombre"].ToString();
                        oPropietario.Apellido = dr["Apellido"].ToString();
                        oPropietario.Nacimiento = dr["Nacimiento"].ToString();
                        oPropietario.Ciudad = dr["Ciudad"].ToString();
                        oPropietario.Correo = dr["Correo"].ToString();
                }
                }
            }
            return oPropietario;
        }
       
        public bool Guardar(PropietarioModel oPropietario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarPropietario", conexion);         
                    cmd.Parameters.AddWithValue("Identificacion", oPropietario.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", oPropietario.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oPropietario.Apellido);
                    cmd.Parameters.AddWithValue("Nacimiento", oPropietario.Nacimiento);
                    cmd.Parameters.AddWithValue("Ciudad", oPropietario.Ciudad);
                    cmd.Parameters.AddWithValue("Correo", oPropietario.Correo);
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
        public bool Editar(PropietarioModel oPropietario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarPropietario", conexion);          
                    cmd.Parameters.AddWithValue("id_Persona", oPropietario.id_Persona);
                    cmd.Parameters.AddWithValue("Identificacion", oPropietario.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", oPropietario.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oPropietario.Apellido);
                    cmd.Parameters.AddWithValue("Nacimiento", oPropietario.Nacimiento);
                    cmd.Parameters.AddWithValue("Ciudad", oPropietario.Ciudad);
                    cmd.Parameters.AddWithValue("Correo", oPropietario.Correo);
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
                    SqlCommand cmd = new SqlCommand("sp_EliminarPropietario", conexion);      
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
