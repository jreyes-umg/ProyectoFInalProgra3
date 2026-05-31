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
    public class HospitalizacionesNegocio
    {
        // Instanciamos
        HospitalizacionDatos Datos = new HospitalizacionDatos();    

        /* ----- CONSULTAR ----- */
        public List<HospitalizacionesEntidad> MtdConsultar()
        {
            return Datos.MtdConsultar();
        }

        /* ----- AGREGAR ----- */
        public bool MtdAgregar(HospitalizacionesEntidad Registro)
        {
            if (Registro == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (Registro.CodigoAtencion <= 0)
                throw new Exception("El Código de Atención es incorrecto");
            if (string.IsNullOrEmpty(Registro.NumeroHabitacion))
                throw new Exception("El Número de Habitación es obligatorio");
            if (Registro.Dias <= 0)
                throw new Exception("La cantidad de días debe ser mayor a cero");
            if (Registro.CostoDia < 0)
                throw new Exception("El costo por día no puede ser negativo");
            if (Registro.CostoMedico < 0)
                throw new Exception("El costo médico no puede ser negativo");

            return Datos.MtdAgregar(Registro);
        }

        /* ----- EDITAR ----- */
        public bool MtdEditar(HospitalizacionesEntidad Registro)
        {
            if (Registro == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (Registro.CodigoHospitalizacion <= 0)
                throw new Exception("El Código de Hospitalización es requerido para editar");
            if (Registro.CodigoAtencion <= 0)
                throw new Exception("El Código de Atención es incorrecto");
            if (string.IsNullOrEmpty(Registro.NumeroHabitacion))
                throw new Exception("El Número de Habitación es obligatorio");
            if (Registro.Dias <= 0)
                throw new Exception("La cantidad de días debe ser mayor a cero");
            if (Registro.CostoDia < 0)
                throw new Exception("El costo por día no puede ser negativo");
            if (Registro.CostoMedico < 0)
                throw new Exception("El costo médico no puede ser negativo");

            return Datos.MtdEditar(Registro);
        }

        /* ----- ELIMINAR ----- */
        public bool MtdEliminar(int codigoHospitalizacion)
        {
            if (codigoHospitalizacion <= 0)
                throw new Exception("Código de Hospitalización inválido");

            return Datos.MtdEliminar(codigoHospitalizacion);
        }

        /* ---- BUSCAR ---- */
           public List<HospitalizacionesEntidad> MtdBuscar(int CodigoAtencion)
        {
            DataTable dt = Datos.MtdBuscar(CodigoAtencion);
            List<HospitalizacionesEntidad> lista = new List<HospitalizacionesEntidad>();

            foreach (DataRow row in dt.Rows)
            {
                HospitalizacionesEntidad Registro = new HospitalizacionesEntidad
                {
                    CodigoHospitalizacion = Convert.ToInt32(row["CodigoHospitalizacion"]),
                    CodigoAtencion = Convert.ToInt32(row["CodigoAtencion"]),
                    NumeroHabitacion = Convert.ToString(row["NumeroHabitacion"]),
                    Dias = Convert.ToInt32(row["Dias"]),
                    CostoDia = Convert.ToDecimal(row["CostoDia"]),
                    CostoMedico = Convert.ToDecimal(row["CostoMedico"]),
                    SubTotal = Convert.ToDecimal(row["SubTotal"]),
                    Descuento = Convert.ToDecimal(row["Descuento"]),
                    TotalHospitalizacion = Convert.ToDecimal(row["TotalHospitalizacion"]),
                    Estado = Convert.ToBoolean(row["Estado"]),
                    UsuarioSistema = Convert.ToString(row["UsuarioSistema"]),
                    FechaSistema = Convert.ToDateTime(row["FechaSistema"]),
                    HoraSistema = (TimeSpan)row["HoraSistema"]
                };

                lista.Add(Registro);
            }
            return lista;
        }

        // Crear Metodo Envia Atenciones de la Base de Datos a Capa Presentación
        public List<dynamic> MtdListaAtenciones()
        {
            return Datos.MtdListaAtenciones();
        }


        //metodos
        const decimal hospitalizacionesdescuento = 0.10m;

        public decimal mtdHospitalizacionesSubtotal(int dias, decimal costodia, decimal costomedico)
        {
            return (dias * costodia) + costomedico;

        }

        public decimal mtdhospitalizacionesdescuento(int dias, decimal subtotal)
        {

            decimal descuento;
            if (dias > 5)
            {
                descuento = subtotal * hospitalizacionesdescuento;

            }
            else
            {
                descuento = 0;
            }
            return descuento;

        }


        public decimal mtdhospitalizacionesTotalHospitalizaciones(decimal subtotal, decimal descuento)
        {

            return subtotal - descuento;

        }
    }
}
