using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pre_entrega.Models;
using pre_entrega.Services;

namespace pre_entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoService servicio;

        public ProductosController()
        {
            servicio = new ProductoService();
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Eliminar (int id)
        {
            var producto = servicio.ObtenerPorId(id);
            if (producto == null) return NotFound();
            servicio.Eliminar(id);
            return Ok(producto);
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> ObtenerPorId (int id)
        {
            try
            {
                var producto = servicio.ObtenerPorId(id);
                if (producto != null) return Ok(producto);
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("usuario/{id}")]
        public ActionResult<List<Producto>> ObtenerPorIdUsuario (int id)
        {
            try
            {
                var producto = servicio.ObtenerPorUsuarioId(id);
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
