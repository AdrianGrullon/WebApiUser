using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class UsuarioData
    {
        public static bool Registrar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", oUsuario.nombre);
                cmd.Parameters.AddWithValue("@email", oUsuario.email);
                cmd.Parameters.AddWithValue("@telefono", oUsuario.telefono);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", oUsuario.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@sexo", oUsuario.sexo);
                cmd.Parameters.AddWithValue("@contrasena", oUsuario.contrasena);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario", oUsuario.id_usuario);
                cmd.Parameters.AddWithValue("@nombre", oUsuario.nombre);
                cmd.Parameters.AddWithValue("@email", oUsuario.email);
                cmd.Parameters.AddWithValue("@telefono", oUsuario.telefono);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", oUsuario.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@sexo", oUsuario.sexo);
                cmd.Parameters.AddWithValue("@contrasena", oUsuario.contrasena);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Usuario> Listar()
        {
            List<Usuario> oListaUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Usuario()
                            {
                                id_usuario = Convert.ToInt32(dr["id_usuario"]),
                                nombre = dr["nombre"].ToString(),
                                email = dr["email"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"].ToString()),
                                sexo = dr["sexo"].ToString(),
                                contrasena = dr["contrasena"].ToString(),
                            });
                        }

                    }



                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    return oListaUsuario;
                }
            }
        }

        public static Usuario Obtener(int idusuario)
        {
            Usuario oUsuario = new Usuario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", idusuario);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oUsuario = new Usuario()
                            {
                                id_usuario = Convert.ToInt32(dr["id_usuario"]),
                                nombre = dr["nombre"].ToString(),
                                email = dr["email"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"].ToString()),
                                sexo = dr["sexo"].ToString(),
                                contrasena = dr["contrasena"].ToString()
                            };
                        }

                    }



                    return oUsuario;
                }
                catch (Exception ex)
                {
                    return oUsuario;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}