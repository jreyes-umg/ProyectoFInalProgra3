using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidad
{
    public class PagosEntidad
    {
        [Key]
        public int CodigoPago { get; set; }
        public int CodigoFactura { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal MontoFactura { get; set; }
        public decimal MontoPagado { get; set; }
        public string MetodoPago { get; set; }
        public decimal Mora { get; set; }
        public decimal Cambio { get; set; }
        public decimal TotalCancelado { get; set; }
        public bool Estado { get; set; }
        public string UsuarioSistema { get; set; }
        public DateTime FechaSistema { get; set; }
        public DateTime HoraSistema { get; set; }


    }
}
