using pre_entrega.Models;
using pre_entrega.Repositories;

namespace pre_entrega.Services
{
    public class VentaService
    {
        private readonly VentaRepository repositorio;
        
        public VentaService()
        {
            repositorio = new VentaRepository();
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

        public int Guardar(Venta venta)
        {
            try
            {
                if (venta.Id == 0)
                {
                    return repositorio.Crear(venta);
                }
                else
                {
                    return repositorio.Modificar(venta);
                }
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
                return repositorio.ObtenerPorId(id);
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
                return repositorio.ObtenerPorUsuarioId(idUsuario);
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
                return repositorio.ObtenerTodos();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
