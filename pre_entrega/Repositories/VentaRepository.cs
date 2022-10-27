using pre_entrega.Models;
using pre_entrega.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace pre_entrega.Repositories
{
    public class VentaRepository
    {
        private readonly GestorDeConexion gestorDeConexion;

        public VentaRepository()
        {
            gestorDeConexion = new GestorDeConexion();
        }

        public int Crear (Venta entidad)
        {
            int respuesta = -1;
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta =
                    @"INSERT INTO Venta
                    (Comentarios, IdUsuario)
                    VALUES (@Comentarios, @IdUsuario)
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("Comentarios", entidad.Comentarios);
                    comando.Parameters.AddWithValue("IdUsuario", entidad.IdUsuario);

                    conexion.Open();
                    respuesta = Convert.ToInt32(comando.ExecuteScalar());
                    entidad.Id = respuesta;
                    conexion.Close();
                }
            }
            return respuesta;
        }

        public int Eliminar(int id)
        {
            int respuesta = -1;
            string cs = gestorDeConexion.establecerConexion();

            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta = "DELETE FROM ProductoVendido WHERE IdVenta = @IdVenta;";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("IdVenta", id);

                    conexion.Open();
                    respuesta = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }

            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta = "DELETE FROM Venta WHERE Id = @Id;";

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

        public int Modificar(Venta entidad)
        {
            int respuesta = -1;
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta =
                    @"UPDATE Venta
                    SET Comentarios = @Comentarios, IdUsuario = @IdUsuario
                    WHERE Id = @Id;";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("Id", entidad.Id);
                    comando.Parameters.AddWithValue("Comentarios", entidad.Comentarios);
                    comando.Parameters.AddWithValue("IdUsuario", entidad.IdUsuario);

                    conexion.Open();
                    respuesta = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return respuesta;
        }

        public Venta ObtenerPorId(int id)
        {
            Venta venta = null;

            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta = "SELECT * FROM Venta WHERE Id = @Id;";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("Id", SqlDbType.Int).Value = id;
                    conexion.Open();
                    var lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        venta = new Venta()
                        {
                            Id = (int)lector.GetInt64(0),
                            Comentarios = lector.GetString(1),
                            IdUsuario = (int)lector.GetInt64(2),
                        };
                    }
                    conexion.Close();
                }
            }
            return venta;
        }

        public List<Venta> ObtenerTodos()
        {
            List<Venta> ventas = new List<Venta>();

            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta = "SELECT * FROM Venta;";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    conexion.Open();
                    var lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        Venta venta = new Venta()
                        {
                            Id = (int)lector.GetInt64(0),
                            Comentarios = lector.GetString(1),
                            IdUsuario = (int)lector.GetInt64(2),
                        };
                        ventas.Add(venta);
                    }
                    conexion.Close();
                }
            }
            return ventas;
        }

        public List<Venta> ObtenerPorUsuarioId(int idUsuario)
        {
            List<Venta> ventas = new List<Venta>();

            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta = "SELECT * FROM Venta WHERE IdUsuario = @IdUsuario;";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("IdUsuario", SqlDbType.Int).Value = idUsuario;
                    conexion.Open();
                    var lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        Venta venta = new Venta()
                        {
                            Id = (int)lector.GetInt64(0),
                            Comentarios = lector.GetString(1),
                            IdUsuario = (int)lector.GetInt64(2),
                        };
                        ventas.Add(venta);
                    }
                    conexion.Close();
                }
            }
            return ventas;
        }
    }
}
