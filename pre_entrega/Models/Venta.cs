using System.ComponentModel.DataAnnotations;

namespace pre_entrega.Models
{
    public class Venta
    {
        #region Statements
        private int _id;
        private string _comentarios;
        private int _idUsuario;
        #endregion

        #region Properties
        [Required]
        public int Id { get { return _id; } set { _id = value; } }
        public string Comentarios { get { return _comentarios; } set { _comentarios = value; } }
        [Required]
        public int IdUsuario { get { return _idUsuario; } set { _idUsuario = value; } }
        #endregion

        #region Constructors
        public Venta() { }

        public Venta(int id, string comentarios, int idUsuario)
        {
            Id = id;
            Comentarios = comentarios;
            IdUsuario = idUsuario;
        }
        #endregion
    }
}
