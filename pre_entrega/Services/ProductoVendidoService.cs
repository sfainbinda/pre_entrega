using pre_entrega.Models;
using pre_entrega.Repositories;
using System.Data.SqlClient;
using System.Data;

namespace pre_entrega.Services
{
    public class ProductoVendidoService
    {
        private readonly ProductoVendidoRepository repositorio;
        private readonly ProductoService productoServicio;

        public ProductoVendidoService()
        {
            repositorio = new ProductoVendidoRepository();
            productoServicio = new ProductoService();
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

        public List<ProductoVendido> ObtenerPorUsuarioId (int idUsuario)
        {
            try
            {
                List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
                var productos = productoServicio.ObtenerPorUsuarioId(idUsuario);
                foreach (var producto in productos)
                {
                    var parcial = repositorio.ObtenerPorProductoId(producto.Id);
                    foreach (var item in parcial)
                    {
                        item.Producto = producto;
                        productosVendidos.Add(item);
                    }
                }
                return productosVendidos;
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
