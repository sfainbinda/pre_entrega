using System.Data;
using System.Data.SqlClient;

namespace pre_entrega.Repositories
{
    public class GestorDeConexion
    {
        #region Statements
        private string _dataSource = "localhost";
        private string _initialCatalog = "SistemaGestion";
        private bool _integratedSecurity = true;
        private string _userId = "";
        private string _password = "";
        #endregion

        public string establecerConexion()
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder
            {
                DataSource = _dataSource,
                InitialCatalog = _initialCatalog,
                IntegratedSecurity = _integratedSecurity,
                UserID = _userId,
                Password = _password,
            };

            return csb.ToString();
        }
    }
}
