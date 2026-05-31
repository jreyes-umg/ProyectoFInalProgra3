using Datos.JuanDavid;
using Datos.MarlonMeda;
using Entidad.MarlonMeda;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.MarlonMeda
{
    public class DietasNegocio
    {
        // Instanciamos
        DietaDatos Datos = new DietaDatos();

        public List<DietasEntidad> MtdConsultar()
        {
            return Datos.MtdConsultar();
        }

        /* ----- AGREGAR -----   */
        public bool MtdAgregar(DietasEntidad RegistroDieta)
        {
            if (RegistroDieta == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (RegistroDieta.CodigoHospitalizacion <= 0)
                throw new Exception("El Código de Hospitalización es incorrecto");
            if (string.IsNullOrEmpty(RegistroDieta.TipoDieta))
                throw new Exception("El Tipo de Dieta es incorrecto");
            if (RegistroDieta.CostoDiario < 0)
                throw new Exception("El valor del costo diario es incorrecto");
            if (RegistroDieta.Dias <= 0)
                throw new Exception("La cantidad de días es incorrecta");
            if (string.IsNullOrEmpty(RegistroDieta.Nutricionista))
                throw new Exception("El nombre del Nutricionista es incorrecto");

            return Datos.MtdAgregar(RegistroDieta);
        }

        /* ----- EDITAR -----   */
        public bool MtdEditar(DietasEntidad RegistroDieta)
        {
            if (RegistroDieta == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (RegistroDieta.CodigoDieta <= 0)
                throw new Exception("El Código de Dieta es incorrecto");
            if (RegistroDieta.CodigoHospitalizacion <= 0)
                throw new Exception("El Código de Hospitalización es incorrecto");
            if (string.IsNullOrEmpty(RegistroDieta.TipoDieta))
                throw new Exception("El Tipo de Dieta es incorrecto");
            if (RegistroDieta.CostoDiario < 0)
                throw new Exception("El valor del costo diario es incorrecto");
            if (RegistroDieta.Dias <= 0)
                throw new Exception("La cantidad de días es incorrecta");
            if (string.IsNullOrEmpty(RegistroDieta.Nutricionista))
                throw new Exception("El nombre del Nutricionista es incorrecto");

            return Datos.MtdEditar(RegistroDieta);
        }

        /* ----- ELIMINAR ----- */
        public bool MtdEliminar(int codigodieta)
        {
            if (codigodieta <= 0)
                throw new Exception("Codigo de la DIETA inválido");

            return Datos.MtdEliminar(codigodieta);
        }

        
        /* ---- BUSCAR ---- */
        public List<DietasEntidad> MtdBuscar(string TipoDieta) 
        {
          
            DataTable dt = Datos.MtdBuscar(TipoDieta);

            List<DietasEntidad> lista = new List<DietasEntidad>();

            foreach (DataRow row in dt.Rows)
            {
                DietasEntidad RegistroDieta = new DietasEntidad
                {
                    CodigoDieta = Convert.ToInt32(row["CodigoDieta"]),
                    CodigoHospitalizacion = Convert.ToInt32(row["CodigoHospitalizacion"]),
                    TipoDieta = Convert.ToString(row["TipoDieta"]),
                    CostoDiario = Convert.ToDecimal(row["CostoDiario"]),
                    Dias = Convert.ToInt32(row["Dias"]),
                    Nutricionista = Convert.ToString(row["Nutricionista"]),
                    SubTotal = Convert.ToDecimal(row["SubTotal"]),
                    Impuesto = Convert.ToDecimal(row["Impuesto"]),
                    TotalDieta = Convert.ToDecimal(row["TotalDieta"]),
                    Estado = Convert.ToBoolean(row["Estado"]),
                    UsuarioSistema = Convert.ToString(row["UsuarioSistema"]),
                    FechaSistema = Convert.ToDateTime(row["FechaSistema"]),
                    HoraSistema = (TimeSpan)row["HoraSistema"]
                };

                lista.Add(RegistroDieta);
            }

            return lista;
        }


        // CAPA DE NEGOCIO combobox
        public List<dynamic> MtdListaHospitalizaciones()
        {
            return Datos.MtdListaHospitalizaciones(); 
        }


        const decimal DietasImpuesto = 0.12m;
        //metodos 
        public decimal mtdDietasSubtotal(decimal costodiario, int dias)
        {
            return costodiario * dias;

        }


        public decimal mtdDietasImpuesto(decimal subtotal)
        {
            return subtotal * DietasImpuesto;

        }

        public decimal mtdTotalDietas(decimal subtotal, decimal impuesto)
        {
            return subtotal + impuesto;

        }
    }
}
