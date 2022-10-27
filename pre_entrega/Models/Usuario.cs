using System.ComponentModel.DataAnnotations;

namespace pre_entrega.Models
{

    public class Usuario
    {
        #region Statements
        [Required]
        private int _id;
        [Required]
        private string _nombre;
        [Required]
        private string _apellido;
        [Required]
        private string _nombreUsuario;
        [Required, DataType(DataType.Password)]
        private string _contrasenia;
        [Required, EmailAddress]
        private string _mail;
        #endregion

        #region Properties
        public int Id { get { return _id; } set { _id = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string NombreUsuario { get { return _nombreUsuario; } set { _nombreUsuario = value; } }
        public string Contrasenia { get { return _contrasenia; } set { _contrasenia = value; } }
        public string Mail { get { return _mail; } set { _mail = value; } }
        #endregion

        #region Constructors
        public Usuario() { }

        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string contrasenia, string mail)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            NombreUsuario = nombreUsuario;
            Contrasenia = contrasenia;
            Mail = mail;
        }
        #endregion
    }
}
