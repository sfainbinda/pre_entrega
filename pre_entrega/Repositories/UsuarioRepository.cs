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

        public int Crear (Usuario entidad)
        {
            int respuesta = -1;
            string cs = gestorDeConexion.establecerConexion();
            
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta =
                    @"INSERT INTO Usuario
                    VALUES (@Nombre, @Apellido, @NombreUsuario, @Contrasenia, @Mail)
                    SELECT SCOPE_IDENTITY();"; // SCOPE_IDENTITY recupera el último id insertado en la tabla.
                
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("Nombre", entidad.Nombre);
                    comando.Parameters.AddWithValue("Apellido", entidad.Apellido);
                    comando.Parameters.AddWithValue("NombreUsuario", entidad.NombreUsuario);
                    comando.Parameters.AddWithValue("Contrasenia", entidad.Contrasenia);
                    comando.Parameters.AddWithValue("Mail", entidad.Mail);
                    
                    conexion.Open();
                    // ExecuteScalar retorna el valor de la primer columna de la primera fila del resultado devuelto por la consulta.
                    respuesta = Convert.ToInt32(comando.ExecuteScalar());
                    entidad.Id = respuesta;
                    conexion.Close();
                }
            }
            return respuesta;
        }

        public int Eliminar (int id)
        {
            int respuesta = -1;
            string cs = gestorDeConexion.establecerConexion();

            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta = "DELETE FROM Usuario WHERE Id = @Id;";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("Id", id);

                    conexion.Open();
                    respuesta = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return respuesta;
        }

        public int Modificar (Usuario entidad)
        {
            int respuesta = -1;
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta =
                    @"UPDATE Usuario
                    SET Nombre = @Nombre, Apellido = @Apellido, NombreUsuario = @NombreUsuario, Contraseña = @Contrasenia, Mail = @Mail
                    WHERE Id = @Id;";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("Id", entidad.Id);
                    comando.Parameters.AddWithValue("Nombre", entidad.Nombre);
                    comando.Parameters.AddWithValue("Apellido", entidad.Apellido);
                    comando.Parameters.AddWithValue("NombreUsuario", entidad.NombreUsuario);
                    comando.Parameters.AddWithValue("Contrasenia", entidad.Contrasenia);
                    comando.Parameters.AddWithValue("Mail", entidad.Mail);
                    
                    conexion.Open();
                    respuesta = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return respuesta;
        }

        public Usuario ObtenerPorId (int id)
        {
            Usuario usuario = null;
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta = "SELECT * FROM Usuario WHERE Id = @Id;";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    // Otra manera de resolver la carga de parámetros.
                    comando.Parameters.Add("Id", SqlDbType.Int).Value = id;
                    conexion.Open();
                    var lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        usuario = new Usuario
                        {
                            Id = (int)lector.GetInt64(0),
                            Nombre = lector.GetString(1),
                            Apellido = lector.GetString(2),
                            NombreUsuario = lector.GetString(3),
                            Contrasenia = lector.GetString(4),
                            Mail = lector.GetString(5),
                        };
                    }
                    conexion.Close();
                }
            }
            return usuario;
        }

        public Usuario ObtenerPorNombreUsuario (string nombreUsuario)
        {
            Usuario usuario = null;
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta = "SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario;";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("NombreUsuario", SqlDbType.Char).Value = nombreUsuario;
                    conexion.Open();
                    var lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        usuario = new Usuario
                        {
                            Id = (int)lector.GetInt64(0),
                            Nombre = lector.GetString(1),
                            Apellido = lector.GetString(2),
                            NombreUsuario = lector.GetString(3),
                            Contrasenia = lector.GetString(4),
                            Mail = lector.GetString(5),
                        };
                    }
                    conexion.Close();
                }
            }
            return usuario;
        }

        public Usuario IniciarSesion (string nombreUsuario, string contrasenia)
        {
            Usuario usuario = null;

            
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta =
                    @"SELECT *
                    FROM Usuario
                    WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contrasenia;";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("NombreUsuario", nombreUsuario);
                    comando.Parameters.AddWithValue("Contrasenia", contrasenia);

                    conexion.Open();
                    var lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        usuario = new Usuario
                        {
                            Id = (int)lector.GetInt64(0),
                            Nombre = lector.GetString(1),
                            Apellido = lector.GetString(2),
                            NombreUsuario = lector.GetString(3),
                            Contrasenia = lector.GetString(4),
                            Mail = lector.GetString(5),
                        };
                    }
                    conexion.Close();
                }
            }
            return usuario;
        }
    }
}
