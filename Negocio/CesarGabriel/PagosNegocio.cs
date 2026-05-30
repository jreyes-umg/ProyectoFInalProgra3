using System;
using System.Collections.Generic;
using System.Data;
using Entidad.Pagos; 
using Datos.Pagos;   

namespace Negocio.Pagos
{
    public class PagosNegocio
    {
        
        PagoDatos Datos = new PagoDatos();

        /* ----- CONSULTAR----- */
        public List<PagosEntidad> MtdConsultarPagos()
        {
            return Datos.MtdConsultarPagos();
        }

        /* ----- AGREGAR ----- */
        public bool MtdAgregar(PagosEntidad ControlPagos)
        {
            // Validaciones de seguridad antes de ir a SQL
            if (ControlPagos == null)
                throw new Exception("Error: El objeto de pago está vacío.");
            if (ControlPagos.CodigoFactura <= 0)
                throw new Exception("Debe seleccionar una factura válida.");
            if (string.IsNullOrEmpty(ControlPagos.MetodoPago))
                throw new Exception("Debe seleccionar un método de pago.");
            if (ControlPagos.MontoPagado < ControlPagos.TotalCancelado)
                throw new Exception("El monto pagado no puede ser menor al total a cancelar.");

            return Datos.MtdAgregar(ControlPagos);
        }

        /* ----- EDITAR ----- */
        public bool MtdEditar(PagosEntidad ControlPagos)
        {
            if (ControlPagos == null)
                throw new Exception("Error: El objeto de pago está vacío.");
            if (ControlPagos.CodigoPago <= 0)
                throw new Exception("Código de pago inválido para editar.");
            if (ControlPagos.CodigoFactura <= 0)
                throw new Exception("Debe seleccionar una factura válida.");

            return Datos.MtdEditar(ControlPagos);
        }

        /* ----- ELIMINAR ----- */
        public bool MtdEliminar(int codigoPago)
        {
            if (codigoPago <= 0)
                throw new Exception("Código de pago inválido.");

            return Datos.MtdEliminar(codigoPago);
        }

        /* ----- BUSCAR ----- */
        public List<PagosEntidad> MtdBuscar(string codigoPagoBuscar)
        {
          
            DataTable dt = Datos.MtdBuscar(codigoPagoBuscar);
            List<PagosEntidad> lista = new List<PagosEntidad>();

          
            foreach (DataRow dr in dt.Rows)
            {
                PagosEntidad pago = new PagosEntidad
                {
                    CodigoPago = Convert.ToInt32(dr["CodigoPago"]),
                    CodigoFactura = Convert.ToInt32(dr["CodigoFactura"]),
                    FechaPago = Convert.ToDateTime(dr["FechaPago"]),
                    MontoFactura = Convert.ToDecimal(dr["MontoFactura"]),
                    MontoPagado = Convert.ToDecimal(dr["MontoPagado"]),
                    MetodoPago = Convert.ToString(dr["MetodoPago"]),
                    Mora = Convert.ToDecimal(dr["Mora"]),
                    Cambio = Convert.ToDecimal(dr["Cambio"]),
                    TotalCancelado = Convert.ToDecimal(dr["TotalCancelado"]),
                    Estado = Convert.ToBoolean(dr["Estado"]),
                    UsuarioSistema = Convert.ToString(dr["UsuarioSistema"]),
                    FechaSistema = Convert.ToDateTime(dr["FechaSistema"]),
                    HoraSistema = (TimeSpan)dr["HoraSistema"]
                };
                lista.Add(pago);
            }
            return lista;
        }

       

        public decimal CalcularMora(DateTime fechaPago, DateTime fechaFactura, decimal montoFactura)
        {
            
            TimeSpan diferencia = fechaPago.Date - fechaFactura.Date;
            int diasRetraso = diferencia.Days;

            
            if (diasRetraso >= 5)
            {
                return montoFactura * 0.50m; // 50% Mora
            }
            else if (diasRetraso == 3 || diasRetraso == 4)
            {
                return montoFactura * 0.30m; // 30% Mora
            }
            else if (diasRetraso == 1 || diasRetraso == 2)
            {
                return montoFactura * 0.20m; // 20% Mora
            }
            else
            {
                return 0m; // No retraso, Mora =0
            }
        }

        public decimal CalcularTotalCancelado(decimal montoFactura, decimal mora)
        {
            
            return montoFactura + mora;
        }

        public decimal CalcularCambio(decimal montoPagado, decimal montoFactura, decimal mora)
        {
           
            decimal totalCosto = montoFactura + mora;

           
            if (montoPagado < totalCosto)
                return 0m;

            return montoPagado - totalCosto;
        }
    }
}