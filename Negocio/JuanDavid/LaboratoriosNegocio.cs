using Datos.JuanDavid;
using Entidad.JuanDavid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.JuanDavid
{
    public class LaboratoriosNegocio
    {
        decimal PorcentajeRecargoUrgencia = 0.2m;
        LaboratoriosDatos Datos = new LaboratoriosDatos();
        public List<LaboratoriosEntidad> MtdConsultar()
        {
            return Datos.MtdConsultar();
        }
        /*  ----- Agregar -----   */
        public bool MtdAgregar(LaboratoriosEntidad RegistroLaboratorio)
        {
            if (RegistroLaboratorio == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (RegistroLaboratorio.CodigoAtencion < 0)
                throw new Exception("El Codigo de Atencion es incorrecto");
            if (string.IsNullOrEmpty(RegistroLaboratorio.TipoExamen))
                throw new Exception("El valor del Tipo de Examen es incorrecto");
            if (RegistroLaboratorio.CostoExamen < 0)
                throw new Exception("El Costo de Examen es incorrecto");
            if (RegistroLaboratorio.Cantidad < 0)
                throw new Exception("La cantidad de Examenes es incorrecta");
            if (RegistroLaboratorio.SubTotal == 0)
                throw new Exception("El SubTotal del Laboratorio es incorrecto");
            if (RegistroLaboratorio.TotalLaboratorio == 0)
                throw new Exception("El Total del Laboratorio es incorrecto");
            if (RegistroLaboratorio.Cantidad < 0)
                throw new Exception("El Total es incorrecto");   
            return Datos.MtdAgregar(RegistroLaboratorio);
        }
        /*  ----- EDITAR -----   */
        public bool MtdEditar(LaboratoriosEntidad RegistroLaboratorio)
        {
            if (RegistroLaboratorio == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (RegistroLaboratorio.CodigoLaboratorio == 0)
                throw new Exception("El Codigo de Laboratorio es incorrecto");
            if (RegistroLaboratorio.CodigoAtencion == 0)
                throw new Exception("El Codigo de Atencion es incorrecto");
            if (string.IsNullOrEmpty(RegistroLaboratorio.TipoExamen))
                throw new Exception("El valor del Tipo de Examen es incorrecto");
            if (RegistroLaboratorio.CostoExamen < 0)
                throw new Exception("El Costo de Examen es incorrecto");
            if (RegistroLaboratorio.Cantidad < 0)
                throw new Exception("La cantidad de Examenes es incorrecta");
            if (RegistroLaboratorio.SubTotal == 0)
                throw new Exception("El SubTotal del Laboratorio es incorrecto");
            if (RegistroLaboratorio.TotalLaboratorio == 0)
                throw new Exception("El Total del Laboratorio es incorrecto");
            if (RegistroLaboratorio.Cantidad < 0)
                throw new Exception("El Total es incorrecto");
            return Datos.MtdEditar(RegistroLaboratorio);
        }
        /*  ----- ELIMINAR ----- */
        public bool MtdEliminar(int CodigoLaboratorio)
        {
            if (CodigoLaboratorio <= 0)
                throw new Exception("Codigo del Laboratorio inválido");

            return Datos.MtdEliminar(CodigoLaboratorio);
        }
        /* ---- BUSCAR ---- */

        public List<LaboratoriosEntidad> MtdBuscar(string NombreSanatorios)
        {
            DataTable dt = Datos.MtdBuscarLaboratoriosPorPaciente(NombreSanatorios);

            List<LaboratoriosEntidad> lista = new List<LaboratoriosEntidad>();

            foreach (DataRow row in dt.Rows)
            {
                LaboratoriosEntidad RegistroSanatorio = new LaboratoriosEntidad
                {
                    CodigoLaboratorio = Convert.ToInt32(row["CodigoLaboratorio"]),
                    CodigoAtencion = Convert.ToInt32(row["CodigoAtencion"]),
                    TipoExamen = Convert.ToString(row["TipoExamen"]),
                    CostoExamen = Convert.ToDecimal(row["CostoExamen"]),
                    Cantidad = Convert.ToInt32(row["CodigoAtencion"]),
                    Urgente = Convert.ToBoolean(row["Urgente"]),
                    RecargoUrgente = Convert.ToDecimal(row["RecargoUrgente"]),
                    SubTotal = Convert.ToDecimal(row["SubTotal"]),
                    TotalLaboratorio = Convert.ToDecimal(row["TotalLaboratorio"]),
                    Estado = Convert.ToBoolean(row["Estado"]),
                    UsuarioSistema = Convert.ToString(row["UsuarioSistema"]),
                    FechaSistema = Convert.ToDateTime(row["FechaSistema"]),
                    HoraSistema = (TimeSpan)row["HoraSistema"]
                };

                lista.Add(RegistroSanatorio);
            }
            return lista;
        }
        /* ---------- METODOS DE LOS COMBOBOX ---------- */

        public List<dynamic> MtdListarAtenciones()
        {
            return Datos.MtdListarAtenciones();
        }
        /* ---------- METODOS GENERALES ---------- */
        public decimal CalcularSubtotal(decimal CostoExamen, int cantidad)
        {
            return CostoExamen * cantidad;
        }
        public decimal CalcularRecargoUrgente(decimal SubTotal)
        {
            return SubTotal * PorcentajeRecargoUrgencia;
        }
        public decimal CalcularTotalLaboratorio(decimal SubTotal, decimal RecargoUrgente)
        {
            return SubTotal + RecargoUrgente;
        }
    }
}
