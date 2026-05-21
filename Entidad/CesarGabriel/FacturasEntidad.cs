using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    internal class FacturasEntidad
    {

        [Key]
        public int CodigoFactura { get; set; }
        public int CodigoAtencion { get; set; }
        public int CodigoSeguro { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DescuentoSeguro { get; set; }
        public decimal Impuesto { get; set; }
        public decimal TotalPagar { get; set; }
        public bool Estado { get; set; }
        public string UsuarioSistema { get; set; }
        public DateTime FechaSistema { get; set; }
        public DateTime HoraSistema { get; set; }

    }
}
