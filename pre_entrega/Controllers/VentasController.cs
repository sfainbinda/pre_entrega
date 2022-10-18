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

        [HttpGet]
        public ActionResult<List<Venta>> ObtenerVentas(int idUsuario)
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
