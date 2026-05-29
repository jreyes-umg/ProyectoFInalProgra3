using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.MarlonMeda
{
    public class TipoServicioEntidad
    {
        [Key]
        public int CodigoTipoServicio { get; set; }

        public string NombreServicio { get; set; }

        public decimal TarifaBase { get; set; }

        public bool AplicaEmergencia { get; set; }

        public bool AplicaHospitalizacion { get; set; }

        public bool AplicaLaboratorio { get; set; }

        public string NivelComplejidad { get; set; }

        public decimal RecargoBase { get; set; }

        public bool Estado { get; set; }

        public string UsuarioSistema { get; set; }

        public DateTime FechaSistema { get; set; }

        public TimeSpan HoraSistema { get; set; }
    }
}
