using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pre_entrega.Models;
using pre_entrega.Services;

namespace pre_entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService servicio;

        public UsuariosController()
        {
            servicio = new UsuarioService();
        }

        [HttpGet]
        public ActionResult<Usuario> ObtenerUsuario(string nombreUsuario)
        {
            try
            {
                return servicio.ObtenerPorNombreUsuario(nombreUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("iniciar-sesion")]
        public ActionResult<Usuario> IniciarSesion(string nombreUsuario, string contrasenia)
        {
            try
            {
                return servicio.IniciarSesion(nombreUsuario, contrasenia);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
