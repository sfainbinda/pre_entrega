using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pre_entrega.Models;
using pre_entrega.Services;

namespace pre_entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService servicio;

        public ProductoController()
        {
            servicio = new ProductoService();
        }

        [HttpDelete("{idProducto}")]
        public ActionResult<string> Eliminar (int idProducto)
        {
            var producto = servicio.ObtenerPorId(idProducto);
            if (producto == null) return NotFound();
            servicio.Eliminar(idProducto);
            return Ok(producto);
        }

        [HttpGet("{idUsuario}")]
        public ActionResult<List<Producto>> ObtenerPorIdUsuario (int idUsuario)
        {
            try
            {
                var producto = servicio.ObtenerPorUsuarioId(idUsuario);
                if (producto != null) return Ok(producto);
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult<List<Producto>> ObtenerTodos ()
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

        [HttpPost]
        public ActionResult<Producto> Crear ([FromBody] Producto entidad)
        {
            servicio.Guardar(entidad);
            return Ok(servicio.ObtenerPorId(entidad.Id));
        }

        [HttpPut]
        public ActionResult<Producto> Modificar ([FromBody] Producto entidad)
        {
            servicio.Guardar(entidad);
            return Ok(servicio.ObtenerPorId(entidad.Id));
        }
    }
}
