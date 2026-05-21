using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class ConexionDatos
    {
        private string CadenaConexion = ConfigurationManager.ConnectionStrings["CadenaConexionDB"].ConnectionString;

        public SqlConnection MtdConexion()
        {
            return new SqlConnection(CadenaConexion);
        }

    }
}
