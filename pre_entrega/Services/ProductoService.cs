using pre_entrega.Models;
using pre_entrega.Repositories;

namespace pre_entrega.Services
{

    public class ProductoService
    {
        private readonly ProductoRepository repositorio;
        private readonly ProductoVendidoService productoVendidoServicio;

        public ProductoService()
        {
            repositorio = new ProductoRepository();
            productoVendidoServicio = new ProductoVendidoService();
        }

        public string Guardar (Producto producto)
        {
            try
            {
                if (producto.Id == 0) {
                    return repositorio.Agregar(producto);
                }
                else
                {
                    return repositorio.Modificar(producto);
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }

        public List<Producto> ObtenerTodos ()
        {
            try
            {
                return repositorio.ObtenerTodos();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Producto ObtenerPorId(int id)
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

        public List<Producto> ObtenerPorUsuarioId(int idUsuario)
        {
            try
            {
                return repositorio.ObtenerPorUsuarioId(idUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Eliminar (int id)
        {
            try
            {
                bool ventasEliminadas = productoVendidoServicio.EliminarPorProductoId(id);
                return repositorio.Eliminar(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
