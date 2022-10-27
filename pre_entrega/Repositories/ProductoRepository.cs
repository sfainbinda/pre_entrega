using pre_entrega.Models;
using pre_entrega.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace pre_entrega.Repositories
{
    public class ProductoRepository
    {
        private readonly GestorDeConexion gestorDeConexion;

        public ProductoRepository()
        {
            gestorDeConexion = new GestorDeConexion();
        }

        public int Crear (Producto entidad)
        {
            int respuesta = -1;
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta =
                    @"INSERT INTO Producto
                    (Descripciones, Costo, PrecioVenta, Stock, IdUsuario)
                    VALUES
                    (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("Descripciones", entidad.Descripciones);
                    comando.Parameters.AddWithValue("Costo", entidad.Costo);
                    comando.Parameters.AddWithValue("PrecioVenta", entidad.PrecioVenta);
                    comando.Parameters.AddWithValue("Stock", entidad.Stock);
                    comando.Parameters.AddWithValue("IdUsuario", entidad.IdUsuario);

                    conexion.Open();
                    respuesta = Convert.ToInt32(comando.ExecuteScalar());
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
                string consulta = "DELETE FROM Producto WHERE Id = @Id;";

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

        public int Modificar(Producto entidad)
        {
            int respuesta = -1;
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta =
                    @"UPDATE Producto
                    SET Descripciones = @Descripciones, Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario
                    WHERE Id = @Id";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("Id", entidad.Id);
                    comando.Parameters.AddWithValue("Descripciones", entidad.Descripciones);
                    comando.Parameters.AddWithValue("Costo", entidad.Costo);
                    comando.Parameters.AddWithValue("PrecioVenta", entidad.PrecioVenta);
                    comando.Parameters.AddWithValue("Stock", entidad.Stock);
                    comando.Parameters.AddWithValue("IdUsuario", entidad.IdUsuario);

                    conexion.Open();
                    respuesta = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                }
            }
            return respuesta;
        }

        public Producto ObtenerPorId(int id)
        {
            Producto producto = null;

            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta = "SELECT * FROM Producto WHERE Id = @Id;";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("Id", SqlDbType.Int).Value = id;
                    conexion.Open();
                    var lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        producto = new Producto()
                        {
                            Id = (int)lector.GetInt64(0),
                            Descripciones = lector.GetString(1),
                            Costo = lector.GetDecimal(2),
                            PrecioVenta = lector.GetDecimal(3),
                            Stock = lector.GetInt32(4),
                            IdUsuario = (int)lector.GetInt64(5),
                        };
                    }
                    conexion.Close();
                }
            }
            return producto;
        }

        public List<Producto> ObtenerTodos ()
        {
            List<Producto> productos = new List<Producto>();

            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta = "SELECT * FROM Producto;";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    conexion.Open();
                    var lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        Producto producto = new Producto()
                        {
                            Id = (int)lector.GetInt64(0),
                            Descripciones = lector.GetString(1),
                            Costo = lector.GetDecimal(2),
                            PrecioVenta = lector.GetDecimal(3),
                            Stock = lector.GetInt32(4),
                            IdUsuario = (int)lector.GetInt64(5),
                        };
                        productos.Add(producto);
                    }
                    conexion.Close();
                }
            }
            return productos;
        }

        public List<Producto> ObtenerPorUsuarioId(int idUsuario)
        {
            List<Producto> productos = new List<Producto>();

            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta = "SELECT * FROM Producto WHERE IdUsuario = @IdUsuario;";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("IdUsuario", SqlDbType.Int).Value = idUsuario;
                    conexion.Open();
                    var lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        Producto producto = new Producto()
                        {
                            Id = (int)lector.GetInt64(0),
                            Descripciones = lector.GetString(1),
                            Costo = lector.GetDecimal(2),
                            PrecioVenta = lector.GetDecimal(3),
                            Stock = lector.GetInt32(4),
                            IdUsuario = (int)lector.GetInt64(5),
                        };
                        productos.Add(producto);
                    }
                    conexion.Close();
                }
            }
            return productos;
        }
    }
}
