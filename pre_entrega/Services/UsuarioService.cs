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

        public string Guardar (Usuario usuario)
        {
            try
            {
                if (usuario.Id != 0)
                {
                    return repositorio.Modificar(usuario);
                }
                else
                {
                    return repositorio.Agregar(usuario);
                }
            }
            catch (Exception)
            {
                throw;
            }
        } 

        public Usuario ObtenerPorId (int id)
        {
            try
            {
                return repositorio.ObtenerPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
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
