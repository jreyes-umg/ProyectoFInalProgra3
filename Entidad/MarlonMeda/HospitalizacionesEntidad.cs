using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.MarlonMeda
{
    internal class HospitalizacionesEntidad
    {

        [Key]
        public int CodigoHospitalizacion { get; set; }

        public int CodigoAtencion { get; set; }

        public string NumeroHabitacion { get; set; }

        public int Dias { get; set; }

        public decimal CostoDia { get; set; }

        public decimal CostoMedico { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }

        public decimal TotalHospitalizacion { get; set; }

        public bool Estado { get; set; }

        public string UsuarioSistema { get; set; }

        public DateTime FechaSistema { get; set; }

        public DateTime HoraSistema { get; set; }
    }
}
