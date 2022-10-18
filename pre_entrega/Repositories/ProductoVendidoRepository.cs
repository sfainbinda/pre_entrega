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

        public List<ProductoVendido> ObtenerPorProductoId(int idProducto)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                conexion.Open();
                var parametro = new SqlParameter()
                {
                    ParameterName = "IdProducto",
                    SqlDbType = SqlDbType.Int,
                    Value = idProducto,
                };

                string consulta =
                    @"SELECT 
                    *
                    FROM ProductoVendido
                    WHERE IdProducto = @IdProducto";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.Add(parametro);
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ProductoVendido productoVendido = new ProductoVendido() 
                            {
                                Id = (int) dr.GetInt64(0),
                                Stock = (int)dr.GetInt32(1),
                                IdProducto = (int)dr.GetInt64(2),
                                IdVenta = (int) dr.GetInt64(3),
                            };
                            productosVendidos.Add(productoVendido);
                        }
                    }
                }
                conexion.Close();
            }
            return productosVendidos;
        }

        public List<ProductoVendido> ObtenerPorVentaId(int idVenta)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                conexion.Open();
                var parametro = new SqlParameter()
                {
                    ParameterName = "IdVenta",
                    SqlDbType = SqlDbType.Int,
                    Value = idVenta,
                };

                string consulta =
                    @"SELECT 
                    *
                    FROM ProductoVendido
                    WHERE IdVenta = @IdVenta";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.Add(parametro);
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ProductoVendido productoVendido = new ProductoVendido()
                            {
                                Id = (int)dr.GetInt64(0),
                                Stock = (int)dr.GetInt32(1),
                                IdProducto = (int)dr.GetInt64(2),
                                IdVenta = (int)dr.GetInt64(3),
                            };
                            productosVendidos.Add(productoVendido);
                        }
                    }
                }
                conexion.Close();
            }
            return productosVendidos;
        }
    }
}
