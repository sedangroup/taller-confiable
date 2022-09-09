﻿using proyecto_taller_alto_nivel.Models;
using System.Data.SqlClient;
using System.Data;
using proyecto_taller_alto_nivel.Data;

namespace proyecto_taller_alto_nivel.Data
{
    public class VehiculoDatos
    {
        public bool Guardar(VehiculoModel vehiculo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("id_propietario", vehiculo.id_Propietario);
                    cmd.Parameters.AddWithValue("Licencia", vehiculo.Licencia);
                    cmd.Parameters.AddWithValue("Tipo", vehiculo.Tipo);
                    cmd.Parameters.AddWithValue("Marca", vehiculo.Marca);
                    cmd.Parameters.AddWithValue("Modelo", vehiculo.Modelo);
                    cmd.Parameters.AddWithValue("Capacidad", vehiculo.Capacidad);
                    cmd.Parameters.AddWithValue("Desplazamiento", vehiculo.Desplazamiento);
                    cmd.Parameters.AddWithValue("PaisOrigen", vehiculo.PaisOrigen);
                    cmd.Parameters.AddWithValue("Descripcion", vehiculo.Descripcion);
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


        public List<VehiculoModel> Listar()
        {
            var oLista = new List<VehiculoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarVehiculo", conexion);///cambiar nombre procedimiento para auxiliar
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
                            Desplazamiento = dr["Desplazamiento"].ToString(),
                            PaisOrigen = dr["PaisOrigen"].ToString(),
                            Descripcion = dr["Descripcion"].ToString()

                        });
                    }
                }
            }
            return oLista;
        }



    }
}
