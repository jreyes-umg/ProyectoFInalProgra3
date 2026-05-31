using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class LoginDatos
    {
        ConexionDatos conexionDatos = new ConexionDatos();
        public string MtdObtenerContraseñaUsuario(string NombredeUsuario)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();

                    string query = @"SELECT Contraseña 
                             FROM Tbl_UsuariosSistema 
                             WHERE Usuario = @Usuario;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Usuario", NombredeUsuario);
                        object rs = cmd.ExecuteScalar();
                        return Convert.ToString(rs);
                    }
                }
            }
            catch (SqlException exSql)
            {
                throw new Exception("Error en la base de datos: " + exSql.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al buscar el Usuario: " + ex.Message);
            }
        }
    }
    
}
