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

       /// <summary>
       /// Crear producto
       /// Recibe un producto como parámetro, debe crearlo, puede ser void, pero valida los datos obligatorios.
       /// </summary>
       /// <returns></returns>
        public string Agregar(Producto producto)
        {
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                conexion.Open();

                string consulta =
                    @"INSERT INTO Producto
                    (Descripciones, Costo, PrecioVenta, Stock, IdUsuario)
                    VALUES
                    (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";

                SqlCommand comando = new SqlCommand(consulta, conexion);

                var descripciones = new SqlParameter()
                {
                    ParameterName = "Descripciones",
                    SqlDbType = SqlDbType.Char,
                    Value = producto.Descripciones,
                };

                var costo = new SqlParameter()
                {
                    ParameterName = "Costo",
                    SqlDbType = SqlDbType.Decimal,
                    Value = producto.Costo,
                };

                var precioVenta = new SqlParameter()
                {
                    ParameterName = "PrecioVenta",
                    SqlDbType = SqlDbType.Decimal,
                    Value = producto.PrecioVenta,
                };

                var stock = new SqlParameter()
                {
                    ParameterName = "Stock",
                    SqlDbType = SqlDbType.Int,
                    Value = producto.Stock,
                };

                var idUsuario = new SqlParameter()
                {
                    ParameterName = "IdUsuario",
                    SqlDbType = SqlDbType.Int,
                    Value = producto.IdUsuario,
                };


                comando.Parameters.Add(descripciones);
                comando.Parameters.Add(costo);
                comando.Parameters.Add(precioVenta);
                comando.Parameters.Add(stock);
                comando.Parameters.Add(idUsuario);

                comando.ExecuteNonQuery();
                conexion.Close();
            }
            return "Producto creado.";
        }

        public string Modificar(Producto producto)
        {
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                conexion.Open();

                string consulta =
                    @"UPDATE Producto
                    SET Descripciones = @Descripciones, Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario
                    WHERE Id = @Id";

                SqlCommand comando = new SqlCommand(consulta, conexion);

                var id = new SqlParameter()
                {
                    ParameterName = "Id",
                    SqlDbType = SqlDbType.Int,
                    Value = producto.Id,
                };

                var descripciones = new SqlParameter()
                {
                    ParameterName = "Descripciones",
                    SqlDbType = SqlDbType.Char,
                    Value = producto.Descripciones,
                };

                var costo = new SqlParameter()
                {
                    ParameterName = "Costo",
                    SqlDbType = SqlDbType.Decimal,
                    Value = producto.Costo,
                };

                var precioVenta = new SqlParameter()
                {
                    ParameterName = "PrecioVenta",
                    SqlDbType = SqlDbType.Decimal,
                    Value = producto.PrecioVenta,
                };

                var stock = new SqlParameter()
                {
                    ParameterName = "Stock",
                    SqlDbType = SqlDbType.Int,
                    Value = producto.Stock,
                };

                var idUsuario = new SqlParameter()
                {
                    ParameterName = "IdUsuario",
                    SqlDbType = SqlDbType.Int,
                    Value = producto.IdUsuario,
                };


                comando.Parameters.Add(id);
                comando.Parameters.Add(descripciones);
                comando.Parameters.Add(costo);
                comando.Parameters.Add(precioVenta);
                comando.Parameters.Add(stock);
                comando.Parameters.Add(idUsuario);

                comando.ExecuteNonQuery();
                conexion.Close();
            }
            return "Producto modificado.";
        }

        public List<Producto> ObtenerTodos ()
        {
            List<Producto> productos = new List<Producto>();
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                conexion.Open();
                
                string consulta = "SELECT * FROM Producto;";

                SqlCommand comando = new SqlCommand(consulta, conexion);
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

        /// <summary>
        /// Eliminar producto
        /// Recibe un id de producto a eliminar y debe eliminarlo de la base de datos (eliminar antes
        /// sus productos vendidos también, sino no lo podrá hacer).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Eliminar (int id)
        {
            string cs = gestorDeConexion.establecerConexion();
            using (SqlConnection conexion = new SqlConnection(cs))
            {
                conexion.Open();

                var idProducto = new SqlParameter()
                {
                    ParameterName = "Id",
                    SqlDbType = SqlDbType.Int,
                    Value = id,
                };

                string consulta =
                    @"DELETE FROM ProductoVendido
                    WHERE IdProducto = @Id";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.Add(idProducto);
                comando.ExecuteNonQuery();

                conexion.Close();
            }
            return "Producto eliminado.";
        }
    }
}
