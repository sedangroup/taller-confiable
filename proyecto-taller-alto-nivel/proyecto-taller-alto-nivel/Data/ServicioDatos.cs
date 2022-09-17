using proyecto_taller_alto_nivel.Models;
using System.Data.SqlClient;
using System.Data;

namespace proyecto_taller_alto_nivel.Data
{
    public class ServicioDatos
    {
        public List<ServicioInnerJoinModel> Listar()
        {
            var oLista = new List<ServicioInnerJoinModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarServicios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ServicioInnerJoinModel()
                        {
                            Id_Servicio = Convert.ToInt32(dr["id_Servicio"]),
                            Propietario = dr["propietario"].ToString(),
                            Mecanico = dr["mecanico"].ToString(),
                            Vehiculo = dr["vehiculo"].ToString(),
                            Licencia = dr["Licencia"].ToString(),
                            NivelAceite = dr["NivelAceite"].ToString(),
                            NivelLiquidoDireccion = dr["NivelLiquidoDireccion"].ToString(),
                            NivelLiquidoFrenos = dr["NivelLiquidoFrenos"].ToString(),
                            NivelRefrigerante = dr["NivelRefrigerante"].ToString(),
                            SoatPoliza = dr["soat_poliza"].ToString(),
                            Fecha = dr["fecha"].ToString(),
                            Hora = dr["Hora"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }


        public List<ServicioInnerJoinModel> ListarByLicencia(string placa)
        {
            var oLista = new List<ServicioInnerJoinModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerServicioPorPlaca", conexion);
                cmd.Parameters.AddWithValue("Placa", placa);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ServicioInnerJoinModel()
                        {
                            Id_Servicio = Convert.ToInt32(dr["id_Servicio"]),
                            Propietario = dr["propietario"].ToString(),
                            Mecanico = dr["mecanico"].ToString(),
                            Vehiculo = dr["vehiculo"].ToString(),
                            Licencia = dr["Licencia"].ToString(),
                            NivelAceite = dr["NivelAceite"].ToString(),
                            NivelLiquidoDireccion = dr["NivelLiquidoDireccion"].ToString(),
                            NivelLiquidoFrenos = dr["NivelLiquidoFrenos"].ToString(),
                            NivelRefrigerante = dr["NivelRefrigerante"].ToString(),
                            SoatPoliza = dr["soat_poliza"].ToString(),
                            Fecha = dr["fecha"].ToString(),
                            Hora = dr["Hora"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }


        public List<ServicioInnerJoinModel> ListarByDocumento(MecanicoModel mecanico)
        {
            var oLista = new List<ServicioInnerJoinModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerServicioPorDocumento", conexion);
                cmd.Parameters.AddWithValue("Documento", mecanico.Identificacion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ServicioInnerJoinModel()
                        {
                            Id_Servicio = Convert.ToInt32(dr["id_Servicio"]),
                            Propietario = dr["propietario"].ToString(),
                            Mecanico = dr["mecanico"].ToString(),
                            Vehiculo = dr["vehiculo"].ToString(),
                            Licencia = dr["Licencia"].ToString(),
                            NivelAceite = dr["NivelAceite"].ToString(),
                            NivelLiquidoDireccion = dr["NivelLiquidoDireccion"].ToString(),
                            NivelLiquidoFrenos = dr["NivelLiquidoFrenos"].ToString(),
                            NivelRefrigerante = dr["NivelRefrigerante"].ToString(),
                            SoatPoliza = dr["soat_poliza"].ToString(),
                            Fecha = dr["fecha"].ToString(),
                            Hora = dr["Hora"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }


        public bool Guardar(ServicioInnerJoinModel servicio)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarServicio", conexion);
                    cmd.Parameters.AddWithValue("DocumentoPropietario", servicio.DocumentoPropietario);
                    cmd.Parameters.AddWithValue("DocumentoMecanico", servicio.DocumentoMecanico);
                    cmd.Parameters.AddWithValue("Licencia", servicio.Licencia);
                    cmd.Parameters.AddWithValue("NumeroPoliza", servicio.SoatPoliza);
                    cmd.Parameters.AddWithValue("Fecha", servicio.Fecha);
                    cmd.Parameters.AddWithValue("Hora", servicio.Hora);
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
