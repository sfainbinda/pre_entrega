using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pre_entrega.Models;

namespace pre_entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NombreController : Controller
    {

        [HttpGet]
        public string Obtener ()
        {
            try
            {
                var negocio = new Negocio();
                return negocio.Nombre;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
