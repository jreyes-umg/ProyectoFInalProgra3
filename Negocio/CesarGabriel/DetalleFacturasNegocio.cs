using System;
using System.Collections.Generic;
using System.Data;
using Entidad.Detalles; 
using Datos.DetalleFacturas;

namespace Negocio.DetalleFacturas
{
    public class DetalleFacturasNegocio
    {
        DetalleFacturaDatos Datos = new DetalleFacturaDatos();

   
        public List<DetallesFacturasEntidad> MtdConsultarDetalle()
        {
            return Datos.MtdConsultarDetalles();
        }

        /* ----- AGREGAR ----- */
        public bool MtdAgregar(DetallesFacturasEntidad detalle)
        {
            if (detalle == null) throw new Exception("El objeto esta vacio.");
            if (detalle.Cantidad <= 0) throw new Exception("La cantidad debe ser mayor a cero.");
            if (detalle.PrecioUnitario < 0) throw new Exception("El precio unitario no puede ser negativo.");

            return Datos.MtdAgregar(detalle);
        }

        /* ----- EDITAR ----- */
        public bool MtdEditar(DetallesFacturasEntidad detalle)
        {
            if (detalle.CodigoDetalle <= 0) throw new Exception("Codigo de detalle invalido.");
            return Datos.MtdEditar(detalle);
        }

        /* ----- ELIMINAR ----- */
        public bool MtdEliminar(int codigoDetalle)
        {
            if (codigoDetalle <= 0) throw new Exception("Codigo invalido.");
            return Datos.MtdEliminar(codigoDetalle);
        }

        /* ----- BUSCAR ----- */
        public List<DetallesFacturasEntidad> MtdBuscar(string codigoDetalle)
        {
            DataTable dt = Datos.MtdBuscar(codigoDetalle);
            List<DetallesFacturasEntidad> lista = new List<DetallesFacturasEntidad>();

            foreach (DataRow dr in dt.Rows)
            {
                DetallesFacturasEntidad detalle = new DetallesFacturasEntidad
                {
                    CodigoDetalle = Convert.ToInt32(dr["CodigoDetalle"]),
                    CodigoFactura = Convert.ToInt32(dr["CodigoFactura"]),
                    TipoConcepto = Convert.ToString(dr["TipoConcepto"]),
                    CodigoReferencia = Convert.ToInt32(dr["CodigoReferencia"]),
                    DescripcionReferencia = Convert.ToString(dr["DescripcionReferencia"]),
                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                    PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                    SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                    Impuesto = Convert.ToDecimal(dr["Impuesto"]),
                    TotalDetalle = Convert.ToDecimal(dr["TotalDetalle"]),
                    Estado = Convert.ToBoolean(dr["Estado"]),
                    UsuarioSistema = Convert.ToString(dr["UsuarioSistema"]),
                    FechaSistema = Convert.ToDateTime(dr["FechaSistema"]),
                    HoraSistema = Convert.ToDateTime(dr["HoraSistema"])
                };
                lista.Add(detalle);
            }
            return lista;
        }

      
        public decimal CalcularSubTotal(int cantidad, decimal precioUnitario)
        {
            return cantidad * precioUnitario;
        }

       
        public decimal CalcularImpuesto(decimal subTotal)
        {
            return subTotal * 0.12m;
        }

     
        public decimal CalcularTotalDetalle(decimal subTotal, decimal impuesto)
        {
            return subTotal + impuesto;
        }

        public List<DetallesFacturasEntidad> MtdConsultarDetalles()
        {
         
            return Datos.MtdConsultarDetalles();
        }
    }
}