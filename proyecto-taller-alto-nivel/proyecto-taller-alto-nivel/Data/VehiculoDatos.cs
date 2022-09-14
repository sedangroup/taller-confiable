using proyecto_taller_alto_nivel.Models;
using System.Data.SqlClient;
using System.Data;
using proyecto_taller_alto_nivel.Data;
using System.Reflection;

namespace proyecto_taller_alto_nivel.Data
{
    public class VehiculoDatos
    {
        public List<VehiculoModel> Listar()
        {
            var oLista = new List<VehiculoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarVehiculo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new VehiculoModel()
                        {
                            id_Vehiculo = Convert.ToInt32(dr["id_Vehiculo"]),
                            id_Propietario = Convert.ToInt32(dr["id_Propietario"]),
                            Licencia = dr["Licencia"].ToString(),
                            Tipo = dr["Tipo"].ToString(),
                            Marca = dr["Marca"].ToString(),
                            Modelo = dr["Modelo"].ToString(),
                            Capacidad = dr["Capacidad"].ToString(),
                            Cilindraje = dr["Cilindraje"].ToString(),
                            PaisOrigen = dr["PaisOrigen"].ToString(),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        public VehiculoModel ObtenerPlaca(string Licencia)
        {
            var oVehiculo = new VehiculoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerPlaca", conexion);          
                cmd.Parameters.AddWithValue("Licencia", Licencia);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oVehiculo.id_Vehiculo = Convert.ToInt32(dr["id_Vehiculo"]);
                        oVehiculo.id_Propietario = Convert.ToInt32(dr["id_Propietario"]);
                        oVehiculo.Licencia = dr["Licencia"].ToString();
                        oVehiculo.Tipo = dr["Tipo"].ToString();
                        oVehiculo.Marca = dr["Marca"].ToString();
                        oVehiculo.Modelo = dr["Modelo"].ToString();
                        oVehiculo.Capacidad = dr["Capacidad"].ToString();
                        oVehiculo.Cilindraje = dr["Cilindraje"].ToString();
                        oVehiculo.PaisOrigen = dr["PaisOrigen"].ToString();
                        oVehiculo.Descripcion = dr["Descripcion"].ToString();
                    }
                }
            }
            return oVehiculo;
        }

        public VehiculoModel Obtener(int id_Vehiculo)
        {
            var oVehiculo = new VehiculoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerVehiculo", conexion);
                cmd.Parameters.AddWithValue("id_Vehiculo", id_Vehiculo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oVehiculo.id_Vehiculo = Convert.ToInt32(dr["id_Vehiculo"]);
                        oVehiculo.id_Propietario = Convert.ToInt32(dr["id_Propietario"]);
                        oVehiculo.Licencia = dr["Licencia"].ToString();
                        oVehiculo.Tipo = dr["Tipo"].ToString();
                        oVehiculo.Marca = dr["Marca"].ToString();
                        oVehiculo.Modelo = dr["Modelo"].ToString();
                        oVehiculo.Capacidad = dr["Capacidad"].ToString();
                        oVehiculo.Cilindraje = dr["Cilindraje"].ToString();
                        oVehiculo.PaisOrigen = dr["PaisOrigen"].ToString();
                        oVehiculo.Descripcion = dr["Descripcion"].ToString();
                    }
                }
            }
            return oVehiculo;
        }


        public bool Guardar(VehiculoModel oVehiculo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("id_propietario", oVehiculo.id_Propietario);
                    cmd.Parameters.AddWithValue("Identificacion", oVehiculo.Identificacion);
                    cmd.Parameters.AddWithValue("Licencia", oVehiculo.Licencia);
                    cmd.Parameters.AddWithValue("Tipo", oVehiculo.Tipo);
                    cmd.Parameters.AddWithValue("Marca", oVehiculo.Marca);
                    cmd.Parameters.AddWithValue("Modelo", oVehiculo.Modelo);
                    cmd.Parameters.AddWithValue("Capacidad", oVehiculo.Capacidad);
                    cmd.Parameters.AddWithValue("Cilindraje", oVehiculo.Cilindraje);
                    cmd.Parameters.AddWithValue("PaisOrigen", oVehiculo.PaisOrigen);
                    cmd.Parameters.AddWithValue("Descripcion", oVehiculo.Descripcion);
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

        public bool Editar(VehiculoModel oVehiculo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("id_Vehiculo", oVehiculo.id_Vehiculo);
                    cmd.Parameters.AddWithValue("Licencia", oVehiculo.Licencia);
                    cmd.Parameters.AddWithValue("Tipo", oVehiculo.Tipo);
                    cmd.Parameters.AddWithValue("Marca", oVehiculo.Marca);
                    cmd.Parameters.AddWithValue("Modelo", oVehiculo.Modelo);
                    cmd.Parameters.AddWithValue("Capacidad", oVehiculo.Capacidad);
                    cmd.Parameters.AddWithValue("Cilindraje", oVehiculo.Cilindraje);
                    cmd.Parameters.AddWithValue("PaisOrigen", oVehiculo.PaisOrigen);
                    cmd.Parameters.AddWithValue("Descripcion", oVehiculo.Descripcion);
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

        public bool Eliminar(int id_Vehiculo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("id_Vehiculo", id_Vehiculo);
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
