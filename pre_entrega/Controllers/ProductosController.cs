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

        [HttpGet]
        public ActionResult<List<Producto>> ObtenerTodos()
        {
            try
            {
                return servicio.ObtenerTodos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("id")]
        public ActionResult<Producto> ObtenerPorId ([FromQuery] int id)
        {
            try
            {
                return servicio.ObtenerPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("idUsuario")]
        public ActionResult<List<Producto>> ObtenerPorIdUsuario([FromQuery]int idUsuario)
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

        [HttpPost]
        public ActionResult<string> Agregar([FromBody] Producto producto)
        {
            bool valido = false;
            if (ModelState.IsValid)
            {
                valido = true;
            }

            return Ok(servicio.Guardar(producto));
        }

        [HttpPut]
        public ActionResult<string> Modificar([FromBody] Producto producto)
        {
            return Ok(servicio.Guardar(producto));
        }

        [HttpDelete("id")]
        public ActionResult<string> Eliminar([FromQuery] int id)
        {
            return Ok(servicio.Eliminar(id));
        }
    }
}
