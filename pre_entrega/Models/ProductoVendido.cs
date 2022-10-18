namespace pre_entrega.Models
{
    public class ProductoVendido
    {
        #region Statements
        private int _id;
        private int _sotck;
        private int _idProducto;
        private int _idVenta;
        #endregion

        #region Properties
        public int Id { get { return _id; } set { _id = value; } }
        public int Stock { get { return _sotck; } set { _sotck = value; } }
        public int IdProducto { get { return _idProducto; } set { _idProducto = value; } }
        public int IdVenta { get { return _idVenta; } set { _idVenta = value; } }
        public Producto Producto { get; set; }
        #endregion

        #region Constructors
        public ProductoVendido()
        {

        }

        public ProductoVendido(int id, int sotck, int idProducto, int idVenta)
        {
            Id = id;
            _sotck = sotck;
            IdProducto = idProducto;
            IdVenta = idVenta;
        }
        #endregion
    }
}
