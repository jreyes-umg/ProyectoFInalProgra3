using System;
using System.Collections.Generic;
using System.Data;
using Entidad; 
using Datos.SegurosMedicos; 

namespace Negocio.SegurosMedicos
{
    public class SegurosMedicosNegocio
    {
        SegurosMedicoDatos Datos = new SegurosMedicoDatos();

       /* ---CONSULTAR----*/
        public List<SegurosMedicosEntidad> MtdConsultarSeguros()
        {
            return Datos.MtdConsultarSeguros();
        }

        /* ----- AGREGAR ---- */
        public bool MtdAgregar(SegurosMedicosEntidad seguro)
        {
            if (seguro == null) throw new Exception("El objeto seguro está vacío.");
            if (string.IsNullOrEmpty(seguro.NombreSeguro)) throw new Exception("El nombre del seguro es obligatorio.");
            if (string.IsNullOrEmpty(seguro.TipoSeguro)) throw new Exception("Debe seleccionar un tipo de seguro.");

            return Datos.MtdAgregar(seguro);
        }

        /* ---- EDITAR ----- */
        public bool MtdEditar(SegurosMedicosEntidad seguro)
        {
            if (seguro.CodigoSeguro <= 0) throw new Exception("Código de seguro inválido para editar.");
            if (string.IsNullOrEmpty(seguro.NombreSeguro)) throw new Exception("El nombre del seguro es obligatorio.");

            return Datos.MtdEditar(seguro);
        }

        /* ---- ELIMINAR ----- */
        public bool MtdEliminar(int codigoSeguro)
        {
            if (codigoSeguro <= 0) throw new Exception("Código de seguro inválido.");
            return Datos.MtdEliminar(codigoSeguro);
        }

        /* ----- BUSCAR ---- */
        public List<SegurosMedicosEntidad> MtdBuscar(string codigoSeguro)
        {
            DataTable dt = Datos.MtdBuscar(codigoSeguro);
            List<SegurosMedicosEntidad> lista = new List<SegurosMedicosEntidad>();

            foreach (DataRow dr in dt.Rows)
            {
                SegurosMedicosEntidad seguro = new SegurosMedicosEntidad
                {
                    CodigoSeguro = Convert.ToInt32(dr["CodigoSeguro"]),
                    NombreSeguro = Convert.ToString(dr["NombreSeguro"]),
                    TipoSeguro = Convert.ToString(dr["TipoSeguro"]),
                    PorcentajeCobertura = Convert.ToDecimal(dr["PorcentajeCobertura"]),
                    Telefono = Convert.ToString(dr["Telefono"]),
                    Direccion = Convert.ToString(dr["Direccion"]),
                    MontoMaximo = Convert.ToDecimal(dr["MontoMaximo"]),
                    Estado = Convert.ToBoolean(dr["Estado"]),
                    UsuarioSistema = Convert.ToString(dr["UsuarioSistema"]),
                    FechaSistema = Convert.ToDateTime(dr["FechaSistema"]),
                    HoraSistema = (TimeSpan)(dr["HoraSistema"])
                };
                lista.Add(seguro);
            }
            return lista;
        }

   

        public decimal CalcularPorcentajeCobertura(string tipoSeguro)
        {
            switch (tipoSeguro)
            {
                case "Básico":
                    return 0.50m;
                case "Intermedio":
                    return 0.70m;
                case "Premium":
                    return 0.90m;
                default:
                    return 0m;
            }
        }
    }
}