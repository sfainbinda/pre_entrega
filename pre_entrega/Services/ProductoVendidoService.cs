using pre_entrega.Models;
using pre_entrega.Repositories;
using System.Data.SqlClient;
using System.Data;

namespace pre_entrega.Services
{
    public class ProductoVendidoService
    {
        private readonly ProductoVendidoRepository repositorio;

        public ProductoVendidoService()
        {
            repositorio = new ProductoVendidoRepository();
        }

        public int Guardar (ProductoVendido entidad)
        {
            try
            {
                return repositorio.Crear(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProductoVendido ObtenerPorId(int id)
        {
            try
            {
                return repositorio.ObtenerPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ProductoVendido> ObtenerPorProductoId(int idProducto)
        {
            try
            {
                return repositorio.ObtenerPorProductoId(idProducto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ProductoVendido> ObtenerPorVentaId(int idVenta)
        {
            try
            {
                return repositorio.ObtenerPorVentaId(idVenta);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
