using pre_entrega.Models;
using pre_entrega.Repository;

namespace pre_entrega.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository repositorio;

        public UsuarioService()
        {
            repositorio = new UsuarioRepository();
        }

        public Usuario ObtenerPorNombreUsuario(string nombreUsuario)
        {
            try
            {
                return repositorio.ObtenerPorNombreUsuario(nombreUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario IniciarSesion(string nombreUsuario, string contrasenia)
        {
            try
            {
                return repositorio.IniciarSesion(nombreUsuario, contrasenia);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
