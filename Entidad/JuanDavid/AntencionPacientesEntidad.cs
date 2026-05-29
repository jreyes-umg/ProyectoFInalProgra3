using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.JuanDavid
{
    internal class AntencionPacientesEntidad
    {
        [Key]
        [Required]
        public int CodigoLaboratorio { get; set; }
        public int CodigoAtencion { get; set; }
        public string TipoExamen {  get; set; }
        public decimal CostoExamen { get; set; }
        public int Cantidad {  get; set; }
        public bool Urgente { get; set; }
        public decimal RecargoUrgente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalLaboratorio { get; set; }
        public bool Estado { get; set; }
        public string UsuarioSistema { get; set; }
        public DateTime FechaSistema { get; set; }
        public TimeSpan HoraSistema { get; set; }
    }
}
