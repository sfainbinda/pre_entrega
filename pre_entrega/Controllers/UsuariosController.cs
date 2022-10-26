using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public ActionResult<Usuario> ObtenerPorId(int id)
        {
            try
            {
                var usuario = servicio.ObtenerPorId(id);
                if (usuario != null) return usuario;
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult<Usuario> Crear ([FromBody] Usuario entidad)
        {
            try
            {
                servicio.Guardar(entidad);
                return servicio.ObtenerPorId(entidad.Id);
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public ActionResult<int> Modificar([FromBody] Usuario entidad)
        {
            try
            {
                return servicio.Guardar(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult<Usuario> ObtenerUsuario([FromBody] string nombreUsuario)
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
