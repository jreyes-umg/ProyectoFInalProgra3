using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.MarlonMeda
{
    public class PacientesEntidad
    {
        [Key]
        public int CodigoPaciente { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public long Dpi { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Genero { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public int Edad { get; set; }

        public bool Estado { get; set; }

        public string UsuarioSistema { get; set; }

        public DateTime FechaSistema { get; set; }

        public TimeSpan HoraSistema { get; set; }
    }
}
