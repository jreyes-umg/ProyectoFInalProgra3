using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.MarlonMeda
{
    public class DietasEntidad
    {
        [Key]
        public int CodigoDieta { get; set; }

        public int CodigoHospitalizacion { get; set; }

        public string TipoDieta { get; set; }

        public decimal CostoDiario { get; set; }

        public int Dias { get; set; }

        public string Nutricionista { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Impuesto { get; set; }

        public decimal TotalDieta { get; set; }

        public bool Estado { get; set; }

        public string UsuarioSistema { get; set; }

        public DateTime FechaSistema { get; set; }

        public TimeSpan HoraSistema { get; set; }
    }
}
