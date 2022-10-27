using pre_entrega.Models;
using pre_entrega.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace pre_entrega.Repositories
{
    public class ProductoVendidoRepository
    {
        private readonly GestorDeConexion gestorDeConexion;

        public ProductoVendidoRepository()
        {
            gestorDeConexion = new GestorDeConexion();
        }

        public int Crear (ProductoVendido entidad)
        {
            int respuesta = -1;
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta =
                    @"INSERT INTO ProductoVendido
                    VALUES (@Stock, @IdProducto, @IdVenta)
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("Stock", entidad.Stock);
                    comando.Parameters.AddWithValue("IdProducto", entidad.IdProducto);
                    comando.Parameters.AddWithValue("IdVenta", entidad.IdVenta);

                    conexion.Open();
                    respuesta = Convert.ToInt32(comando.ExecuteScalar());
                    entidad.Id = respuesta;
                    conexion.Close();
                }
            }
            return respuesta;
        }

        public ProductoVendido ObtenerPorId (int id)
        {
            ProductoVendido productoVendido = null;
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta = "SELECT * FROM ProductoVendido WHERE Id = @Id;";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("Id", SqlDbType.Int).Value = id;
                    conexion.Open();
                    var lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        productoVendido = new ProductoVendido
                        {
                            Id = (int)lector.GetInt64(0),
                            Stock = (int)lector.GetInt32(1),
                            IdProducto = (int)lector.GetInt64(2),
                            IdVenta = (int)lector.GetInt64(3),
                        };
                    }
                    conexion.Close();
                }
            }
            return productoVendido;
        }

        public List<ProductoVendido> ObtenerPorProductoId (int idProducto)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta = "SELECT * FROM ProductoVendido WHERE IdProducto = @IdProducto;";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("IdProducto", SqlDbType.Int).Value = idProducto;
                    conexion.Open();
                    var lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        ProductoVendido productoVendido = new ProductoVendido
                        {
                            Id = (int)lector.GetInt64(0),
                            Stock = (int)lector.GetInt32(1),
                            IdProducto = (int)lector.GetInt64(2),
                            IdVenta = (int)lector.GetInt64(3),
                        };
                        productosVendidos.Add(productoVendido);
                    }
                    conexion.Close();
                }
            }
            return productosVendidos;
        }

        public List<ProductoVendido> ObtenerPorVentaId (int idVenta)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                string consulta = "SELECT * FROM ProductoVendido WHERE IdVenta = @IdVenta;";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("IdVenta", SqlDbType.Int).Value = idVenta;
                    conexion.Open();
                    var lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        ProductoVendido productoVendido = new ProductoVendido
                        {
                            Id = (int)lector.GetInt64(0),
                            Stock = (int)lector.GetInt32(1),
                            IdProducto = (int)lector.GetInt64(2),
                            IdVenta = (int)lector.GetInt64(3),
                        };
                        productosVendidos.Add(productoVendido);
                    }
                    conexion.Close();
                }
            }
            return productosVendidos;
        }
    }
}
