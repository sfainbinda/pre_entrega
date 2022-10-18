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
    }
}
