using pre_entrega.Models;
using pre_entrega.Repositories;

namespace pre_entrega.Services
{

    public class ProductoService
    {
        private readonly ProductoRepository repositorio;

        public ProductoService()
        {
            repositorio = new ProductoRepository();
        }

        public int Eliminar (int id)
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

        public int Guardar (Producto producto)
        {
            try
            {
                if (producto.Id == 0) {
                    return repositorio.Crear(producto);
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
    }
}
