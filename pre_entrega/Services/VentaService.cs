using pre_entrega.Models;
using pre_entrega.Repositories;

namespace pre_entrega.Services
{
    public class VentaService
    {
        private readonly VentaRepository repositorio;
        private readonly ProductoVendidoService productoVendidoServicio;
        private readonly ProductoService productoServicio;
        public VentaService()
        {
            repositorio = new VentaRepository();
            productoVendidoServicio = new ProductoVendidoService();
            productoServicio = new ProductoService();
        }

        public int Eliminar(int id)
        {
            try
            {
                return repositorio.Eliminar(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Guardar(List<Producto> productos, int idUsuario)
        {
            try
            {
                Venta venta = new Venta();
                venta.IdUsuario = idUsuario;
                venta.Comentarios = "";

                venta.Id = repositorio.Crear(venta);

                foreach (Producto producto in productos)
                {
                    ProductoVendido productoVendido = new ProductoVendido
                    {
                        Stock = producto.Stock,
                        IdProducto = producto.Id,
                        IdVenta = venta.Id,
                    };
                    productoVendidoServicio.Guardar(productoVendido);

                    var productoActualizado = productoServicio.ObtenerPorId(producto.Id);
                    int diferencia = productoActualizado.Stock - producto.Stock;
                    if (diferencia < 0)
                    {
                        throw new Exception("Stock insuficiente.");
                    }
                    else
                    {
                        productoActualizado.Stock = diferencia;
                        productoServicio.Guardar(productoActualizado);
                    }
                }
                return venta.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Venta ObtenerPorId(int id)
        {
            try
            {
                var venta = repositorio.ObtenerPorId(id);
                var productosVendidos = productoVendidoServicio.ObtenerPorVentaId(venta.Id);
                foreach (var productoVendido in productosVendidos)
                {
                    var producto = productoServicio.ObtenerPorId(productoVendido.IdProducto);
                    productoVendido.Producto = producto;
                }
                venta.ProductosVendidos = productosVendidos;
                return venta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Venta> ObtenerPorUsuarioId(int idUsuario)
        {
            try
            {
                var ventas = repositorio.ObtenerPorUsuarioId(idUsuario);
                foreach (var venta in ventas)
                {
                    var productosVendidos = productoVendidoServicio.ObtenerPorVentaId(venta.Id);
                    foreach (var productoVendido in productosVendidos)
                    {
                        var producto = productoServicio.ObtenerPorId(productoVendido.IdProducto);
                        productoVendido.Producto = producto;
                    }
                    venta.ProductosVendidos = productosVendidos;
                }
                return ventas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Venta> ObtenerTodos()
        {
            try
            {
                var ventas = repositorio.ObtenerTodos();
                foreach (var venta in ventas)
                {
                    var productosVendidos = productoVendidoServicio.ObtenerPorVentaId(venta.Id);
                    foreach (var productoVendido in productosVendidos)
                    {
                        var producto = productoServicio.ObtenerPorId(productoVendido.IdProducto);
                        productoVendido.Producto = producto;
                    }
                    venta.ProductosVendidos = productosVendidos;
                }
                return ventas;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
