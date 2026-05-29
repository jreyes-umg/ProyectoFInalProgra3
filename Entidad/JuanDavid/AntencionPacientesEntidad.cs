using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.JuanDavid
{
    public class AntencionPacientesEntidad
    {
        [Key]
        [Required]
        public int CodigoAtencion { get; set; }
        public int CodigoPaciente { get; set; }
        public int CodigoMedico { get; set; }
        public int CodigoTipoServicio { get; set; }
        public int CodigoSanatorio { get; set; }
        public DateTime FechaAtencion { get; set; }
        public decimal CostoBase { get; set; }
        public decimal RecargoEmergencia {  get; set; }
        public decimal TotalAtencion { get; set; }
        public bool Estado { get; set; }
        public string UsuarioSistema { get; set; }
        public DateTime FechaSistema { get; set; }
        public TimeSpan HoraSistema { get; set; }
    }
}
