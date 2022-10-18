using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pre_entrega.Models;
using pre_entrega.Services;

namespace pre_entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        private readonly ProductoVendidoService servicio;

        public ProductoVendidoController()
        {
            servicio = new ProductoVendidoService();
        }

        [HttpGet]
        public ActionResult<List<ProductoVendido>> ObtenerProductosVendidos(int idUsuario)
        {
            try
            {
                return servicio.ObtenerPorUsuarioId(idUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
