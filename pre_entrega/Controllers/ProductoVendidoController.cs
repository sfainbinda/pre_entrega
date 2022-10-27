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

        [HttpGet("{id}")]
        public ActionResult<ProductoVendido> ObtenerPorId(int id)
        {
            try
            {
                var productoVendido = servicio.ObtenerPorId(id);
                if (productoVendido != null) return Ok(productoVendido);
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("producto/{id}")]
        public ActionResult<List<ProductoVendido>> ObtenerPorProductoId(int id)
        {
            try
            {
                return Ok(servicio.ObtenerPorProductoId(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("usuario/{id}")]
        public ActionResult<List<ProductoVendido>> ObtenerPorUsuarioId(int id)
        {
            try
            {
                return Ok(servicio.ObtenerPorUsuarioId(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("venta/{id}")]
        public ActionResult<List<ProductoVendido>> ObtenerPorVentaId(int id)
        {
            try
            {
                return Ok(servicio.ObtenerPorVentaId(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
