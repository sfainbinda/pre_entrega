using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pre_entrega.Models;
using pre_entrega.Services;

namespace pre_entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly VentaService servicio;

        public VentasController()
        {
            servicio = new VentaService();
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Eliminar([FromQuery] int id)
        {
            var venta = servicio.ObtenerPorId(id);
            if (venta == null) return NotFound();
            servicio.Eliminar(id);
            return Ok(venta);
        }

        [HttpGet("{id}")]
        public ActionResult<Venta> ObtenerPorId([FromQuery] int id)
        {
            try
            {
                var venta = servicio.ObtenerPorId(id);
                if (venta != null) return venta;
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("[controller]/usuario/{idUsuario}")]
        public ActionResult<List<Venta>> ObtenerPorIdUsuario([FromQuery] int idUsuario)
        {
            try
            {
                var venta = servicio.ObtenerPorUsuarioId(idUsuario);
                if (venta != null) return venta;
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

        [HttpPost]
        public ActionResult<Venta> Crear([FromBody] Venta entidad)
        {
            servicio.Guardar(entidad);
            return Ok(servicio.ObtenerPorId(entidad.Id));
        }

        [HttpPut]
        public ActionResult<Venta> Modificar([FromBody] Venta entidad)
        {
            servicio.Guardar(entidad);
            return Ok(servicio.ObtenerPorId(entidad.Id));
        }
    }
}
