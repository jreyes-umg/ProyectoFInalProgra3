using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    internal class SegurosMedicosEntidad
    {

        public int CodigoSeguro { get; set; }
        public string NombreSeguro { get; set; }
        public string TipoSeguro { get; set; }
        public decimal PorcentajeCobertura { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public decimal MontoMaximo { get; set; }
        public bool Estado { get; set; }
        public string UsuarioSistema { get; set; }
        public DateTime FechaSistema { get; set; }
        public DateTime HoraSistema { get; set; }


    }
}
