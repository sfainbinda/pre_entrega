using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pre_entrega.Models;
using pre_entrega.Services;

namespace pre_entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly VentaService servicio;

        public VentaController()
        {
            servicio = new VentaService();
        }

        [HttpDelete("{idVenta}")]
        public ActionResult<string> Eliminar (int idVenta)
        {
            var venta = servicio.ObtenerPorId(idVenta);
            if (venta == null) return NotFound();
            servicio.Eliminar(idVenta);
            return Ok(venta);
        }

        [HttpGet("{idUsuario}")]
        public ActionResult<List<Venta>> ObtenerPorIdUsuario (int idUsuario)
        {
            try
            {
                var venta = servicio.ObtenerPorUsuarioId(idUsuario);
                if (venta != null) return Ok(venta);
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult<List<Venta>> ObtenerTodos()
        {
            try
            {
                return Ok(servicio.ObtenerTodos());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("{idUsuario}")]
        public ActionResult<Venta> Crear(List<Producto> productos, int idUsuario)
        {
            servicio.Guardar(productos, idUsuario);
            return Ok();
        }
    }
}
