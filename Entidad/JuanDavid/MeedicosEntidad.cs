using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class MeedicosEntidad
    {
        [Key]
        public int CodigoMedico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad {  get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public decimal HonorarioBase { get; set; }
        public int AniosExperiencia { get; set; }
        public decimal BonoExperiencia { get; set; }
        public bool Estado { get; set; }
        public string UsuarioSistema { get; set; }
        public DateTime FechaSistema { get; set; }
        public TimeSpan HoraSistema { get; set; }
    }
}
