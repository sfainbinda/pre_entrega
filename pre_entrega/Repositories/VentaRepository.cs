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

        public List<Venta> ObtenerPorUsuarioId(int idUsuario)
        {
            List<Venta> ventas = new List<Venta>();
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
                    FROM Venta 
                    WHERE IdUsuario = @IdUsuario;";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.Add(parametro);
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Venta venta = new Venta()
                            {
                                Id = (int)dr.GetInt64(0),
                                Comentarios = dr.GetString(1),
                                IdUsuario = (int)dr.GetInt64(2),
                            };
                            ventas.Add(venta);
                        }
                    }
                }
                conexion.Close();
            }
            return ventas;
        }
    }
}
