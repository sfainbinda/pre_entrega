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
        public ActionResult<string> Eliminar (int id)
        {
            var venta = servicio.ObtenerPorId(id);
            if (venta == null) return NotFound();
            servicio.Eliminar(id);
            return Ok(venta);
        }

        [HttpGet("{id}")]
        public ActionResult<Venta> ObtenerPorId (int id)
        {
            try
            {
                var venta = servicio.ObtenerPorId(id);
                if (venta != null) return Ok(venta);
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("/usuario/{id}")]
        public ActionResult<List<Venta>> ObtenerPorIdUsuario (int id)
        {
            try
            {
                var venta = servicio.ObtenerPorUsuarioId(id);
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

        [HttpPost]
        public ActionResult<Venta> Crear([FromBody] List<ProductoVendido> productosVendidos, int idUsuario)
        {
            Venta entidad = new Venta();
            entidad.IdUsuario = idUsuario;
            entidad.Comentarios = ""; //Por consigna, no forma parte de los parámetros.

            servicio.Guardar(entidad, productosVendidos);
            return Ok(servicio.ObtenerPorId(entidad.Id));
        }

        [HttpPut]
        public ActionResult<Venta> Modificar([FromBody] Venta entidad)
        {
            servicio.Guardar(entidad, null);
            return Ok(servicio.ObtenerPorId(entidad.Id));
        }
    }
}
