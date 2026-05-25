using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class DetallesFacturasEntidad
    {
        [Key]
        public int CodigoDetalle { get; set; }
        
        public int CodigoFactura { get; set; }
        public string TipoConcepto { get; set; }
        public int CodigoReferencia { get; set; }
        public string DescripcionReferencia { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal TotalDetalle { get; set; }
        public bool Estado { get; set; }
        public string UsuarioSistema { get; set; }
        public DateTime FechaSistema { get; set; }
        public DateTime HoraSistema { get; set; }

    }
}
