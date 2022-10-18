using pre_entrega.Models;
using pre_entrega.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace pre_entrega.Repository
{
    public class UsuarioRepository
    {
        private readonly GestorDeConexion gestorDeConexion;

        public UsuarioRepository()
        {
            gestorDeConexion = new GestorDeConexion();
        }

        public Usuario ObtenerPorNombreUsuario(string nombreUsuario)
        {
            Usuario usuario = new Usuario();
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                conexion.Open();
                var parametro = new SqlParameter()
                {
                    ParameterName = "NombreUsuario",
                    SqlDbType = SqlDbType.Char,
                    Value = nombreUsuario,
                };

                string consulta =
                    @"SELECT * 
                    FROM Usuario 
                    WHERE NombreUsuario = @NombreUsuario;";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.Add(parametro);
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Usuario auxiliar = new Usuario()
                            {
                                Id = (int) dr.GetInt64(0),
                                Nombre = dr.GetString(1),
                                Apellido = dr.GetString(2),
                                NombreUsuario = dr.GetString(3),
                                Contrasenia = dr.GetString(4),
                                Mail = dr.GetString(5),
                            };
                            usuario = auxiliar;
                        }
                    }
                }
                conexion.Close();
            }
            return usuario;
        }

        public Usuario IniciarSesion(string nombreUsuario, string contrasenia)
        {
            Usuario usuario = new Usuario();
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                conexion.Open();
                var parametroNombre = new SqlParameter()
                {
                    ParameterName = "NombreUsuario",
                    SqlDbType = SqlDbType.Char,
                    Value = nombreUsuario,
                };

                var parametroContrasenia = new SqlParameter()
                {
                    ParameterName = "Contraseña",
                    SqlDbType = SqlDbType.Char,
                    Value = contrasenia,
                };

                string consulta =
                    @"SELECT *
                    FROM Usuario
                    WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contraseña;";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.Add(parametroNombre);
                comando.Parameters.Add(parametroContrasenia);
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Usuario auxiliar = new Usuario()
                            {
                                Id = (int)dr.GetInt64(0),
                                Nombre = dr.GetString(1),
                                Apellido = dr.GetString(2),
                                NombreUsuario = dr.GetString(3),
                                Contrasenia = dr.GetString(4),
                                Mail = dr.GetString(5),
                            };
                            usuario = auxiliar;
                        }
                    }
                }
                conexion.Close();
            }
            return usuario;
        }
    }
}
