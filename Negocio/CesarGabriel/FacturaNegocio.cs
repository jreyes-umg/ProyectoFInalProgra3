using Datos.Facturas;
using Entidad.Factura;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio.Facturas
{
    public class FacturasNegocio
    {
        FacturaDatos Datos = new FacturaDatos();

        public List<FacturasEntidad> MtdConsultarFacturas()
        {
            return Datos.MtdConsultarFacturas();
        }

        public bool MtdAgregar(FacturasEntidad RegistroFactura)
        {
            if (RegistroFactura == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (RegistroFactura.CodigoAtencion <= 0)
                throw new Exception("Debe seleccionar un Código de Atención válido.");
            if (RegistroFactura.CodigoSeguro <= 0)
                throw new Exception("Debe seleccionar un Código de Seguro válido.");
            if (RegistroFactura.SubTotal <= 0)
                throw new Exception("El SubTotal no puede ser cero.");

            return Datos.MtdAgregar(RegistroFactura);
        }

        public bool MtdEditar(FacturasEntidad RegistroFactura)
        {
            if (RegistroFactura == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (RegistroFactura.CodigoFactura <= 0)
                throw new Exception("Código de factura inválido.");

            return Datos.MtdEditar(RegistroFactura);
        }

        public bool MtdEliminar(int codigoFactura)
        {
            if (codigoFactura <= 0)
                throw new Exception("Código de factura inválido.");

            return Datos.MtdEliminar(codigoFactura);
        }

        public List<FacturasEntidad> MtdBuscar(string parametroBusqueda)
        {
            DataTable dt = Datos.MtdBuscar(parametroBusqueda);
            List<FacturasEntidad> lista = new List<FacturasEntidad>();

            foreach (DataRow row in dt.Rows)
            {
                FacturasEntidad RegistroFactura = new FacturasEntidad
                {
                    CodigoFactura = Convert.ToInt32(row["CodigoFactura"]),
                    CodigoAtencion = Convert.ToInt32(row["CodigoAtencion"]),
                    CodigoSeguro = Convert.ToInt32(row["CodigoSeguro"]),
                    FechaFactura = Convert.ToDateTime(row["FechaFactura"]),
                    SubTotal = Convert.ToDecimal(row["SubTotal"]),
                    DescuentoSeguro = Convert.ToDecimal(row["DescuentoSeguro"]),
                    Impuesto = Convert.ToDecimal(row["Impuesto"]),
                    TotalPagar = Convert.ToDecimal(row["TotalPagar"]),
                    Estado = Convert.ToBoolean(row["Estado"]),
                    UsuarioSistema = Convert.ToString(row["UsuarioSistema"]),
                    FechaSistema = Convert.ToDateTime(row["FechaSistema"]),
                    HoraSistema = (TimeSpan)row["HoraSistema"]
                };
                lista.Add(RegistroFactura);
            }
            return lista;
        }



        public decimal CalcularDescuentoSeguro(decimal subTotal, decimal porcentajeCobertura)
        {
            return subTotal * porcentajeCobertura;
        }

        public decimal CalcularImpuesto(decimal subTotal, decimal descuentoSeguro)
        {
            return (subTotal - descuentoSeguro) * 0.12m;
        }

        public decimal CalcularTotalPagar(decimal subTotal, decimal descuentoSeguro, decimal impuesto)
        {
            return subTotal - descuentoSeguro + impuesto;
        }
    }
}