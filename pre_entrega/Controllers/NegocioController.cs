using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pre_entrega.Models;

namespace pre_entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : Controller
    {

        [HttpGet]
        public ActionResult<string> Obtener ()
        {
            try
            {
                var negocio = new Negocio();
                return Ok(negocio);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
