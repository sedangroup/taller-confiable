using proyecto_taller_alto_nivel.Models;
using System.Data.SqlClient;
using System.Data;

namespace proyecto_taller_alto_nivel.Data
{
    public class ServicioDatos
    {
        public List<ServicioInnerJoinModel> Listar(VehiculoModel oVehiculo)
        {
            var oLista = new List<ServicioInnerJoinModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerServicioPorPlaca", conexion);
                cmd.Parameters.AddWithValue("Placa", oVehiculo.Licencia);
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
    }
}
