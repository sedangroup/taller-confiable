﻿using proyecto_taller_alto_nivel.Models;
using System.Data.SqlClient;
using System.Data;
using proyecto_taller_alto_nivel.Data;


namespace proyecto_taller_alto_nivel.Data
{
    public class PersonaDatos
    {
        public List<PersonaModel> Listar()
        {
            var oLista = new List<PersonaModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new PersonaModel()
                        {
                            id_Persona = Convert.ToInt32(dr["id_Persona"]),
                            Identificacion = dr["Identificacion"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Nacimiento = dr["Nacimiento"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }
        public PersonaModel Obtener(int id_Persona)
        {
            var oPersona = new PersonaModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("id_Persona", id_Persona);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oPersona.id_Persona = Convert.ToInt32(dr["id_Persona"]);
                        oPersona.Identificacion = dr["Identificacion"].ToString();
                        oPersona.Nombre = dr["Nombre"].ToString();
                        oPersona.Apellido = dr["Apellido"].ToString();
                        oPersona.Nacimiento = dr["Nacimiento"].ToString();
                    }
                }
            }
            return oPersona;
        }
        public bool Guardar(PersonaModel oPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Identificacion", oPersona.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", oPersona.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oPersona.Apellido);
                    cmd.Parameters.AddWithValue("Nacimiento", oPersona.Nacimiento);
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
        public bool Editar(PersonaModel opersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("id_Persona", opersona.id_Persona);
                    cmd.Parameters.AddWithValue("Identificacion", opersona.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", opersona.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", opersona.Apellido);
                    cmd.Parameters.AddWithValue("Nacimiento", opersona.Nacimiento);
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
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
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