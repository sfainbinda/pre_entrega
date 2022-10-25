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
        public ActionResult<List<Producto>> ObtenerProductos([FromBody]int idUsuario)
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
        public ActionResult<Producto> Agregar([FromBody] Producto producto)
        {
            return producto;
        }

        [HttpPut]
        public ActionResult<Producto> Modificar([FromBody] Producto producto)
        {
            return producto;
        }

        [HttpDelete]
        public ActionResult<bool> Eliminar([FromBody] int id)
        {
            return true;
        }
    }
}
