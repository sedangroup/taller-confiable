using proyecto_taller_alto_nivel.Models;
using System.Data.SqlClient;
using System.Data;

namespace proyecto_taller_alto_nivel.Data
{
    public class MecanicoDatos
    {
        public List<MecanicoModel> Listar()
        {
            var oLista = new List<MecanicoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarMecanico", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new MecanicoModel()
                        {
                            id_Persona = Convert.ToInt32(dr["id_Persona"]),
                            id_Mecanico = Convert.ToInt32(dr["id_Mecanico"]),
                            Identificacion = dr["Identificacion"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Nacimiento = dr["Nacimiento"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            NivelEducacion = dr["NivelEducacion"].ToString(),
                            Telefono = dr["Telefono"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        public MecanicoModel Obtener(int id_Persona)
        {
            var oMecanico = new MecanicoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerMecanico", conexion);
                cmd.Parameters.AddWithValue("id_Persona", id_Persona);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oMecanico.id_Persona = Convert.ToInt32(dr["id_Persona"]);
                        oMecanico.id_Mecanico = Convert.ToInt32(dr["id_Mecanico"]);
                        oMecanico.Identificacion = dr["Identificacion"].ToString();
                        oMecanico.Nombre = dr["Nombre"].ToString();
                        oMecanico.Apellido = dr["Apellido"].ToString();
                        oMecanico.Nacimiento = dr["Nacimiento"].ToString();
                        oMecanico.Direccion = dr["Direccion"].ToString();
                        oMecanico.NivelEducacion = dr["NivelEducacion"].ToString();
                        oMecanico.Telefono = dr["Telefono"].ToString();
                    }
                }
            }
            return oMecanico;
        }

        public MecanicoModel ObtenerIdMecanico(int id_Mecanico)
        {
            var oMecanico = new MecanicoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerIdMecanico", conexion);
                cmd.Parameters.AddWithValue("id_Mecanico", id_Mecanico);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oMecanico.id_Persona = Convert.ToInt32(dr["id_Persona"]);
                        oMecanico.id_Mecanico = Convert.ToInt32(dr["id_Mecanico"]);
                        oMecanico.Identificacion = dr["Identificacion"].ToString();
                        oMecanico.Nombre = dr["Nombre"].ToString();
                        oMecanico.Apellido = dr["Apellido"].ToString();
                        oMecanico.Nacimiento = dr["Nacimiento"].ToString();
                        oMecanico.Direccion = dr["Direccion"].ToString();
                        oMecanico.NivelEducacion = dr["NivelEducacion"].ToString();
                        oMecanico.Telefono = dr["Telefono"].ToString();
                    }
                }
            }
            return oMecanico;
        }
        public bool Guardar(MecanicoModel oMecanico)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarMecanico", conexion);
                    cmd.Parameters.AddWithValue("Identificacion", oMecanico.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", oMecanico.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oMecanico.Apellido);
                    cmd.Parameters.AddWithValue("Nacimiento", oMecanico.Nacimiento);
                    cmd.Parameters.AddWithValue("Direccion", oMecanico.Direccion);
                    cmd.Parameters.AddWithValue("NivelEducacion", oMecanico.NivelEducacion);
                    cmd.Parameters.AddWithValue("Telefono", oMecanico.Telefono);
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
        public bool Editar(MecanicoModel oMecanico)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarMecanico", conexion);
                    cmd.Parameters.AddWithValue("id_Persona", oMecanico.id_Persona);
                    cmd.Parameters.AddWithValue("Identificacion", oMecanico.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", oMecanico.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oMecanico.Apellido);
                    cmd.Parameters.AddWithValue("Nacimiento", oMecanico.Nacimiento);
                    cmd.Parameters.AddWithValue("Direccion", oMecanico.Direccion);
                    cmd.Parameters.AddWithValue("NivelEducacion", oMecanico.NivelEducacion);
                    cmd.Parameters.AddWithValue("Telefono", oMecanico.Telefono);
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
                    SqlCommand cmd = new SqlCommand("sp_EliminarMecanico", conexion);
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
