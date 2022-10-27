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

        public int Eliminar (int id)
        {
            try
            {
                return repositorio.Eliminar(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Guardar (Usuario entidad)
        {
            try
            {
                Usuario existe = repositorio.ObtenerPorNombreUsuario(entidad.NombreUsuario);
                if (existe == null || existe.Id == entidad.Id)
                {
                    if (entidad.Id == 0)
                    {
                        return repositorio.Crear(entidad);
                    }
                    else
                    {
                        return repositorio.Modificar(entidad);
                    }
                } else
                {
                    throw new Exception("El nombre de usuario ya existe.");
                }
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
    }
}
