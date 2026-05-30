using System;
using System.Collections.Generic;
using System.Data;
using Entidad.Factura; 
using Datos.Facturas; 

namespace Negocio.Facturas
{
    public class FacturasNegocio
    {
        FacturaDatos Datos = new FacturaDatos();

        /* ----- CONSULTAR ----- */
        public List<FacturasEntidad> MtdConsultarFacturas()
        {
            return Datos.MtdConsultarFacturas();
        }

        /* ----- AGREGAR ----- */
        public bool MtdAgregar(FacturasEntidad ControlFacturas)
        {
            if (ControlFacturas == null)
                throw new Exception("Error: El objeto de factura está vacío.");
            if (ControlFacturas.CodigoAtencion <= 0)
                throw new Exception("Debe seleccionar un código de atención válido.");
            if (ControlFacturas.SubTotal <= 0)
                throw new Exception("El SubTotal no puede ser cero o negativo.");

            return Datos.MtdAgregar(ControlFacturas);
        }

        /* ----- EDITAR ----- */
        public bool MtdEditar(FacturasEntidad ControlFacturas)
        {
            if (ControlFacturas == null)
                throw new Exception("Error: El objeto de factura está vacío.");
            if (ControlFacturas.CodigoFactura <= 0)
                throw new Exception("Código de factura inválido para editar.");
            if (ControlFacturas.CodigoAtencion <= 0)
                throw new Exception("Debe seleccionar un código de atención válido.");

            return Datos.MtdEditar(ControlFacturas);
        }

        /* ----- ELIMINAR ----- */
        public bool MtdEliminar(int codigoFactura)
        {
            if (codigoFactura <= 0)
                throw new Exception("Código de factura inválido.");

            return Datos.MtdEliminar(codigoFactura);
        }

        /* ----- BUSCAR ----- */
        public List<FacturasEntidad> MtdBuscar(string codigoFactura)
        {
            DataTable dt = Datos.MtdBuscar(codigoFactura);
            List<FacturasEntidad> lista = new List<FacturasEntidad>();

            foreach (DataRow dr in dt.Rows)
            {
                FacturasEntidad factura = new FacturasEntidad
                {
                    CodigoFactura = Convert.ToInt32(dr["CodigoFactura"]),
                    CodigoAtencion = Convert.ToInt32(dr["CodigoAtencion"]),
                    CodigoSeguro = Convert.ToInt32(dr["CodigoSeguro"]),
                    FechaFactura = Convert.ToDateTime(dr["FechaFactura"]),
                    SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                    DescuentoSeguro = Convert.ToDecimal(dr["DescuentoSeguro"]),
                    Impuesto = Convert.ToDecimal(dr["Impuesto"]),
                    TotalPagar = Convert.ToDecimal(dr["TotalPagar"]),
                    Estado = Convert.ToBoolean(dr["Estado"]),
                    UsuarioSistema = Convert.ToString(dr["UsuarioSistema"]),
                    FechaSistema = Convert.ToDateTime(dr["FechaSistema"]),
                    HoraSistema = (TimeSpan)dr["HoraSistema"]
                };
                lista.Add(factura);
            }
            return lista;
        }

        public decimal CalcularDescuentoSeguro(decimal subTotal, decimal porcentajeCobertura)
        {
            return subTotal * porcentajeCobertura;
        }

        public decimal CalcularImpuesto(decimal subTotal, decimal descuentoSeguro)
        {
            decimal baseImponible = subTotal - descuentoSeguro;
            return baseImponible * 0.12m;
        }

        public decimal CalcularTotalPagar(decimal subTotal, decimal descuentoSeguro, decimal impuesto)
        {
            return (subTotal - descuentoSeguro) + impuesto;
        }
    }
}