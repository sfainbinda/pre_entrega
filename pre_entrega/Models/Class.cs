using System.ComponentModel.DataAnnotations;

namespace pre_entrega.Models
{
    public class Negocio
    {
        #region Statements
        private string _nombre = "Un negocio";
        #endregion

        #region Properties
        public string Nombre { get { return _nombre; } }
        #endregion

        #region Constructors
        public Negocio()
        {

        }
        #endregion
    }
}
