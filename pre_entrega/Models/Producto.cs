using System.ComponentModel.DataAnnotations;

namespace pre_entrega.Models
{
    public class Producto
    {
        #region Statements
        private int _id;
        private string _descripciones;
        private decimal _costo;
        private decimal _precioVenta;
        private int _stock;
        private int _idUsuario;
        #endregion

        #region Properties
        [Required]
        public int Id { get { return _id; } set { _id = value; } }
        [Required]
        public string Descripciones { get { return _descripciones; } set { _descripciones = value; } }
        public decimal Costo { get { return _costo; } set { _costo = value; } }
        [Required]
        public decimal PrecioVenta { get { return _precioVenta; } set { _precioVenta = value; } }
        [Required]
        public int Stock { get { return _stock; } set { _stock = value; } }
        [Required]
        public int IdUsuario { get { return _idUsuario; } set { _idUsuario = value; } }
        #endregion

        #region Constructors
        public Producto()
        {

        }

        public Producto(int id, string descripciones, decimal costo, decimal precioVenta, int stock, int idUsuario)
        {
            Id = id;
            Descripciones = descripciones;
            Costo = costo;
            PrecioVenta = precioVenta;
            Stock = stock;
            IdUsuario = idUsuario;
        }
        #endregion
    }
}
