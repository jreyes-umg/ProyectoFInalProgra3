using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidad.JuanDavid
{
    public class EntidadSanatorios
    {
        [Key]
        [Required]
        public int CodigoSanatorio { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public int CapacidadHabitaciones { get; set; }
        public string Telefono { get; set; }
        public string Director { get; set; }
        public string TipoSanatorio { get; set; }
        public decimal CostoOperacionDiario { get; set; }
        public string NivelServicio { get; set; }
        public bool Estado {  get; set; }
        public string UsuarioSistema { get; set; }
        public DateTime FechaSistema { get; set; }
        public TimeSpan HoraSistema { get; set; }
    }
}
