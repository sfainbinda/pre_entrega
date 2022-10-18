using pre_entrega.Models;
using pre_entrega.Repositories;

namespace pre_entrega.Services
{
    public class VentaService
    {
        private readonly VentaRepository repositorio;
        private readonly ProductoVendidoService productoVendidoServicio;

        public VentaService()
        {
            repositorio = new VentaRepository();
            productoVendidoServicio = new ProductoVendidoService();
        }

        public List<Venta> ObtenerPorUsuarioId(int idUsuario)
        {
            try
            {
                List<Venta> ventas = repositorio.ObtenerPorUsuarioId(idUsuario);
                foreach (var venta in ventas)
                {
                    venta.ProductosVendidos = productoVendidoServicio.ObtenerPorVentaId(venta.Id);
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
