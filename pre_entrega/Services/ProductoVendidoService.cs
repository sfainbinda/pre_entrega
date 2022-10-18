using pre_entrega.Models;
using pre_entrega.Repositories;

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

        public List<ProductoVendido> ObtenerPorUsuarioId(int idUsuario)
        {
            try
            {
                List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
                List<Producto> productos = productoServicio.ObtenerPorUsuarioId(idUsuario);
                foreach(var producto in productos)
                {
                    List<ProductoVendido> encontrados = repositorio.ObtenerPorProductoId(producto.Id);
                    foreach (var encontrado in encontrados)
                    {
                        encontrado.Producto = producto;
                        productosVendidos.Add(encontrado);
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
                List<ProductoVendido> productosVendidos = repositorio.ObtenerPorVentaId(idVenta);
                foreach (var productoVendido in productosVendidos)
                {
                    productoVendido.Producto = productoServicio.ObtenerPorId(productoVendido.IdProducto);
                }
                return productosVendidos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
