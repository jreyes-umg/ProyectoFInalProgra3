using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SanatorioNegocios
    {







        //* ---- Metodos ---- *//

        const int CantidadBonoExperiencia = 50;
        const decimal CantidadRecargoBase = 0.10m;
        const decimal CantidadRecargoEmergencia =  0.25m;

        public int mtdEdad(DateTime FechaNacimiento)
        {
            return DateTime.Today.Year - FechaNacimiento.Year;
        }

        public decimal mtdBonoExperiencia(int AñosExperiencia) 
        {


            return Convert.ToDecimal(AñosExperiencia * CantidadBonoExperiencia);

        }

        public decimal mtdRecargoBase(decimal TarifaBase)
        {
            return Convert.ToDecimal(TarifaBase * CantidadRecargoBase);


        }

        public decimal mtdCostoBase(decimal TarifaBase)
        {

            return TarifaBase * CantidadRecargoBase;

        }
         //*--- PREGUNTA ----*//
       // public decimal mtdRecargoEmegencia( AplicaEmergencia)
       // {
         //   if ( < 0)



       // }

        public decimal mtdTotalAtencion(decimal CostoBase)
        {

            return CostoBase * CantidadRecargoEmergencia;

        }
    }
}
