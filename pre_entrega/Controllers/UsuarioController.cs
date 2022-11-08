using Microsoft.AspNetCore.Mvc;
using pre_entrega.Models;
using pre_entrega.Services;

namespace pre_entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService servicio;

        public UsuarioController()
        {
            servicio = new UsuarioService();
        }

        [HttpDelete("{id}")]
        public ActionResult Eliminar (int id)
        {
            try
            {
                var usuario = servicio.ObtenerPorId(id);
                if (usuario == null) return NotFound();
                servicio.Eliminar(id);
                return Ok(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{nombreUsuario}")]
        public ActionResult<Usuario> ObtenerPorNombreUsuario(string nombreUsuario)
        {
            try
            {
                var usuario = servicio.ObtenerPorNombreUsuario(nombreUsuario);
                if (usuario != null) return Ok(usuario);
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
                return Ok(servicio.ObtenerPorId(entidad.Id));
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{nombreUsuario}/{contraseña}")]
        public ActionResult<Usuario> IniciarSesion(string nombreUsuario, string contraseña)
        {
            try
            {
                return Ok(servicio.IniciarSesion(nombreUsuario, contraseña));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public ActionResult<Usuario> Modificar([FromBody] Usuario entidad)
        {
            try
            {
                servicio.Guardar(entidad);
                return Ok(servicio.ObtenerPorId(entidad.Id));
            }
            catch (Exception)
            {
                throw;
            }
        }   
    }
}
