using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatorios
{
    internal class UsuarioLogueado
    {
        public static class Sesion
        {
            // Esta propiedad funcionará como tu "variable global"
            public static string NombreUsuario { get; set; }

            // Opcional: Podrías guardar también el ID del médico si lo necesitas
            // public static int CodigoMedico { get; set; }
        }
    }
}
