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

        public List<Producto> ObtenerPorUsuarioId(int idUsuario)
        {
            List<Producto> productos = new List<Producto>();
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                conexion.Open();
                var parametro = new SqlParameter()
                {
                    ParameterName = "IdUsuario",
                    SqlDbType = SqlDbType.Int,
                    Value = idUsuario,
                };

                string consulta =
                    @"SELECT * 
                    FROM Producto 
                    WHERE IdUsuario = @IdUsuario;";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.Add(parametro);
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Producto producto = new Producto()
                            {
                                Id = (int)dr.GetInt64(0),
                                Descripciones = dr.GetString(1),
                                Costo = dr.GetDecimal(2),
                                PrecioVenta = dr.GetDecimal(3),
                                Stock = dr.GetInt32(4),
                                IdUsuario = (int)dr.GetInt64(5),
                            };
                            productos.Add(producto);
                        }
                    }
                }
            }
            return productos;
        }

        public Producto ObtenerPorId(int id)
        {
            Producto producto = new Producto();
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                conexion.Open();
                var parametro = new SqlParameter()
                {
                    ParameterName = "Id",
                    SqlDbType = SqlDbType.Int,
                    Value = id,
                };

                string consulta =
                    @"SELECT * 
                    FROM Producto 
                    WHERE Id = @Id;";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.Add(parametro);
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Producto encontrado = new Producto()
                            {
                                Id = (int)dr.GetInt64(0),
                                Descripciones = dr.GetString(1),
                                Costo = dr.GetDecimal(2),
                                PrecioVenta = dr.GetDecimal(3),
                                Stock = dr.GetInt32(4),
                                IdUsuario = (int)dr.GetInt64(5),
                            };
                            producto = encontrado;
                        }
                    }
                }
            }
            return producto;
        }
    }
}
