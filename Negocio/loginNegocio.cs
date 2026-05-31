using Datos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class loginNegocio
    {
        LoginDatos Datos = new LoginDatos();
        public string MtdObtenerContraseñaUsuario(string NombredeUsuario)
        {
            return Datos.MtdObtenerContraseñaUsuario(NombredeUsuario);
        }
    }
}
